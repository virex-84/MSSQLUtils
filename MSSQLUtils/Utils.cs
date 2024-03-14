/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 22.06.2023
 * Время: 17:34
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.SqlParser.Parser;
using Microsoft.SqlServer.Management.SqlParser.SqlCodeDom;

namespace MSSQLUtils
{
	/// <summary>
	/// Description of Utils.
	/// </summary>
	public static class Utils
	{
		/*
		public static IEnumerable<T> Flatten<T, R>(this IEnumerable<T> source, Func<T, R> recursion) where R : IEnumerable<T>
		{
		    return source.SelectMany(x => (recursion(x) != null && recursion(x).Any()) ? recursion(x).Flatten(recursion) : null)
		                 .Where(x => x != null);
		}
		*/
	
		public static List<Control> GetAllControls(Control container)
		{
			List<Control> list = new List<Control>();
		    foreach (Control c in container.Controls)
		    {
		    	list.AddRange(GetAllControls(c));
		        list.Add(c);
		    }
			return list;
		}		
		
		//возвращает плоский список из бесконечно-вложенного
		public static IEnumerable<T> Flatten<T, R>(this IEnumerable<T> source, Func<T, R> recursion) where R : IEnumerable<T>
		{
		    var flattened = source.ToList();
		
		    var children = source.Select(recursion);
		
		    if (children != null)
		    {
		        foreach (var child in children)
		        {
		            flattened.AddRange(child.Flatten(recursion));
		        }
		    }
		
		    return flattened;
		}
		
		//расширение для удобства поиска case insensitive
	    public static bool Contains(this string source, string toCheck, StringComparison comp)
	    {
	        return source.IndexOf(toCheck, comp) >= 0;
	    }		
		
	    public class CheckQueryResult
	    {
	    	public bool isError { get; set; }
	    	public bool isModify { get; set; }
		}
	    
		private static bool checkModify(SqlCodeObject statement){
			if (statement is SqlUpdateStatement) return true;
			if (statement is SqlMergeStatement) return true;
			if (statement is SqlInsertStatement) return true;
			if (statement is SqlDeleteStatement) return true;
			if (statement is SqlExecuteStatement) return true; //exec
			if (statement is SqlExecuteModuleStatement) return true; //execute, DROP IF EXISTS, 
			if (statement is SqlDropTableStatement) return true;
			if (statement is SqlRestoreDatabaseStatement) return true;
			if (statement is SqlBackupDatabaseStatement) return true;
			if (statement is SqlNullStatement) {
				var state = (statement as SqlNullStatement);
				if (state.Sql.Contains("create",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("add",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("close",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("DENY",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("GRANT",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("REVOKE",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("SETUSER",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("CONVERSATION",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("MOVE",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("RECEIVE",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("SEND",StringComparison.InvariantCultureIgnoreCase))	return true;	
				if (state.Sql.Contains("truncate",StringComparison.InvariantCultureIgnoreCase))	return true; //truncate table	
				if (state.Sql.Contains("alter",StringComparison.InvariantCultureIgnoreCase))	return true; //alter table	
				if (state.Sql.Contains("kill",StringComparison.InvariantCultureIgnoreCase))	return true;
				if (state.Sql.Contains("RECONFIGURE",StringComparison.InvariantCultureIgnoreCase))	return true;
				if (state.Sql.Contains("SHUTDOWN",StringComparison.InvariantCultureIgnoreCase))	return true;
				if (state.Sql.Contains("BACKUP",StringComparison.InvariantCultureIgnoreCase))	return true;
				if (state.Sql.Contains("RESTORE",StringComparison.InvariantCultureIgnoreCase))	return true;
			}
			return false;
		}		
		
		public static CheckQueryResult checkQuery(string sql){
	    	var result = new CheckQueryResult();
	    	result.isError=false;
	    	result.isModify=false;

			
			var parseResult = Parser.Parse(sql);
			if (parseResult.Errors.Count()>0)
				result.isError=true;
			
			foreach (var batch in parseResult.Script.Batches)
			{
			    foreach (var chbatch in batch.Statements)
			    {
			    	result.isModify=result.isModify || checkModify(chbatch);
					    
			    	//вытаскиваем плоский список всех потомков
			    	var all = chbatch.Children.Flatten(x => x.Children).ToList();

			    	foreach (var statement in all) {
				    	result.isModify=result.isModify || checkModify(statement);					    
			    	}
			    }
			}
			
			return result;
		}

	    public static string ClearShema(string procedurename){
	    	procedurename = procedurename.Replace("'","");
			procedurename = procedurename.Replace("[","");
			procedurename = procedurename.Replace("]","");							
			//отсекаем "dbo." из dbo.procedurename
			//иначе запрос не выдаст содержимое
			procedurename = Regex.Replace(procedurename,@"[\w]+\.(?!\.)","");
			return procedurename;
	    }
	    
	    public static string ClearLongComment(string sql){
			return Regex.Replace(sql,@"(?s)/\*(?>/\*(?<LEVEL>)|\*/(?<-LEVEL>)|(?!/\*|\*/).)+(?(LEVEL)(?!))\*/", "");	    	
	    }
	    
	    public static string ClearShortComment(string sql){
			return Regex.Replace(sql,@"(/\*(.|[\r\n])*?\*/)|(--(.*|[\r\n]))", "");	    	
	    }	    
	}
}
