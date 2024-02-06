/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 19.06.2023
 * Время: 14:36
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace MSSQLUtils
{
	public partial class ListTree : Form, IConnectedForm
	{
		public class RunInfo
		{
			public TreeNode root { get; set; }
			public bool isShowAll { get; set; }
			public bool isFindUp { get; set; }
			public int scanLevel { get; set; }
		}			
		
		SqlCommand lastCommand;
		SqlConnection conn;
		Login.ConnectInfo info;
		Regex sql_comment_fix = new Regex(@"(?s)/\*(?>/\*(?<LEVEL>)|\*/(?<-LEVEL>)|(?!/\*|\*/).)+(?(LEVEL)(?!))\*/", SyntaxHighlighter.RegexCompiledOption);
		
		//выпадающая подсказка, хинт
		//добавляем подсказку в свойство Tag		
		private ToolTip ToolTip;
		private void PrepareTooltips()
		{
		    ToolTip = new ToolTip();
		    
		    List<Control> all = Utils.GetAllControls(this);
		    
		    foreach(Control ctrl in all)
		    {
		    	if (!(ctrl.Tag is string)) continue;
		    	
		        //if (ctrl is Button && ctrl.Tag is string)
		        //{
		            ctrl.MouseHover += new EventHandler(delegate(Object o, EventArgs a) {
						ToolTip.SetToolTip(ctrl, ctrl.Tag.ToString());
					});
		        //}
		    }
		}
		
		public ListTree()
		{
			InitializeComponent();
			
			PrepareTooltips();
			
			//выделим по умолчанию "Без ограничения"
			cbLevel.SelectedIndex=0;
		}
		
		public void setConnection(SqlConnection con, Login.ConnectInfo info)
		{
			this.conn = con;
			this.info = info;
			this.Text = string.Format("MSSQL {0}.{1} ({2}) ver {3}", info.Server, conn.Database, info.Login, info.Version);
		}		
		
		private bool findBack(TreeNode node, string name){
			if (node==null || node.Parent==null) return false;
			if (node.Parent.Name==name) return true;
			return findBack(node.Parent, name);
		}		
		
		//делегат
		//private delegate void ExecQueryDelegateRoot(SqlConnection con, string procedureName, TreeNode root);
		//private delegate void ExecQueryDelegate(SqlConnection con, string procedureName, TreeNode node);		
		
		private void ExecQueryRoot(SqlConnection con, string procedureName, TreeNode root, BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e){
			var sql=@"
			select top 1 name=object_name(o.id),xtype, m.definition
			from sys.sql_modules as m
			join sys.sysobjects as o  on m.object_id = o.id
			where o.name='{0}'	
			";
			
			var start=string.Format(sql, procedureName);
			var definition = "";
			try {
				SqlCommand command = new SqlCommand(start, con);
				lastCommand = command;
				using (SqlDataReader reader = command.ExecuteReader()) {
					DataTable dt = new DataTable();
					dt.Load(reader);
					try{
						definition = dt.Rows[0]["definition"].ToString();
					} catch{}
				}
			} catch (Exception ex) {
				this.Invoke((MethodInvoker)delegate {						
					root.Name=procedureName;
					root.Tag =ex.Message.ToString();
					EndScan();
				});					
			}
			
			this.Invoke((MethodInvoker)delegate {
				root.Name=procedureName;      	
				root.Tag =definition;
			});
			
				
			ExecQuery(con, procedureName, root, worker, e);
		}
		

		//реализация запроса
		private void ExecQuery(SqlConnection con, string procedureName, TreeNode node, BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e)
		{
			var runInfo = (e.Argument as RunInfo);
			
			//поиск вниз
			var sql=@"
			select [name]=sed.referenced_entity_name, [type]=rtrim(ltrim(coalesce(o2.type,o.type))), m.definition
			from sys.sql_expression_dependencies sed
			JOIN sys.objects o ON o.object_id = sed.referencing_id
			left join sys.sql_modules as m on object_name(m.object_id)=sed.referenced_entity_name
			left JOIN sys.objects o2 ON o2.object_id=sed.referenced_id
			where o.name='{0}'
			and o.name != sed.referenced_entity_name		
			";
			
			if (!runInfo.isShowAll) {
				sql=sql+" and is_caller_dependent=1	";
			}			
			
			//поиск вверх
			if (runInfo.isFindUp) {
			sql=@"
			select
			[name]=o.name, [type]=rtrim(ltrim(o.type)), m.definition
			from sys.sql_expression_dependencies sed
			JOIN sys.objects o ON o.object_id = sed.referencing_id
			left join sys.sql_modules as m on m.object_id=sed.referencing_id
			where sed.referenced_entity_name='{0}'
			";								
			}
			
			var start=string.Format(sql, procedureName);
			try {
				SqlCommand command = new SqlCommand(start, con);
				lastCommand = command;
				using (SqlDataReader reader = command.ExecuteReader()) {
					
					DataTable dt = new DataTable();
					dt.Load(reader);

					this.Invoke((MethodInvoker)delegate {
					for (int i=0; i<dt.Rows.Count; i++){
						
						var name = dt.Rows[i]["name"].ToString();
						var child = node.Nodes.Add(name);
						child.Name=name;
						child.Tag=dt.Rows[i]["definition"].ToString();
						child.Parent.ExpandAll();
						
						var tp=dt.Rows[i]["type"].ToString();
						var color=child.ForeColor;
						switch(tp){
							case "SN": //синоним
								break;								
							case "FS": //скалярная функция сборки (среда CLR)
								break;								
							case "FN": //скалярная функция SQL
								color=Color.Coral;
								break;								
							case "IF": //возвращающая табличное значение функция SQL
								color=Color.Brown;
								break;								
							case "IT": //внутренняя таблица
								break;								
							case "P":  //хранимая процедура SQL
								color=Color.Blue;
								break;								
							case "SQ": //очередь обслуживания
								break;								
							case "AF": //статистическая функция (среда CLR)
								break;								
							case "FT": //возвращающая табличное значение функция сборки (среда CLR)
								break;								
							case "PC": //хранимая процедура сборки (среда CLR)
								break;								
							case "C":  //ограничение CHECK
								break;								
							case "U":  //таблица
								color=Color.Red;
								break;								
							case "TR": //триггер DML SQL
								break;								
							case "PK": //ограничение PRIMARY KEY
								break;								
							case "D":  //DEFAULT (ограничение или изолированный)
								break;								
							case "S":  //системная базовая таблица
								break;								
							case "V":  //представление VIEW
								color=Color.Green;
								break;								
							case "TF": //возвращающая табличное значение функция SQL
								break;								
							case "UQ": //ограничение UNIQUE
								break;								
							case "F":  //ограничение FOREIGN KEY
								break;								
							case "TT": //табличный тип
								break;	
							case "X":  //расширенная хранимая процедура
								break;									
							default:
								break;
						}
						child.ForeColor=color;
					}
					});	
				}
			} catch (Exception ex) {
				this.Invoke((MethodInvoker)delegate {						
					var name = ex.Message;
					var child = node.Nodes.Add(name);
					child.Name=name;
				});					
			}
			
			//this.Invoke((MethodInvoker)delegate {
				for (int i=0; i<node.Nodes.Count; i++){
				
					//запросили останов - прерываемся
					if (worker.CancellationPending)	{
						break;
					}
			            		
			            var name = node.Nodes[i].Name;
	            
			            /*
			            //вверх ищем всё
			            if (isFindUp) {
							//дожидаемся что-бы запросы были выполнены последовательно
							//иначе ошибка "SqlCommand и SqlDataReader заняты" 								
							//ExecQueryDelegate del = new ExecQueryDelegate(ExecQuery);							
							//IAsyncResult resultObj =  del.BeginInvoke(con, name, node.Nodes[i], null, null);							
							//del.EndInvoke(resultObj);
							//del.Invoke(con, name, node.Nodes[i]);
							
							ExecQuery(con, name, node.Nodes[i]);
					
							continue;
			            }
			            */
			            
			            //избавляемся от бесконечной рекурсии
			            if (!findBack(node.Nodes[i], name) && (node.Nodes[i].ForeColor!=Color.Red)){
			            	
			            	if (runInfo.scanLevel>0)
			            		if (node.Nodes[i].Level>=runInfo.scanLevel) continue;
			            	
							//дожидаемся что-бы запросы были выполнены последовательно
							//ExecQueryDelegate del = new ExecQueryDelegate(ExecQuery);							
							//иначе ошибка "SqlCommand и SqlDataReader заняты" 								
							//IAsyncResult resultObj =  del.BeginInvoke(con, name, node.Nodes[i], null, null);							
							//del.EndInvoke(resultObj);
							//del.Invoke(con, name, node.Nodes[i]);
							
							ExecQuery(con, name, node.Nodes[i], worker, e);
			            }
				}
			//});				
			
			
			this.Invoke((MethodInvoker)delegate {
			    node.ExpandAll();
			    if (procedureName == tbProcedureName.Text) EndScan();
			});
		}	

		void BackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			ExecQueryRoot(conn, tbProcedureName.Text, (e.Argument as RunInfo).root, worker, e);
		}
		
		void BackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			btnGetTree.Text="Получить список";
		}	
		
		private void StartScan()
		{
			
			if (backgroundWorker.IsBusy != true)
            {
				btnGetTree.Text="Остановить";
				
				tvList.Nodes.Clear();
				var root=tvList.Nodes.Add(tbProcedureName.Text);
				root.Name=tbProcedureName.Text;				

				var runInfo=new RunInfo();
				runInfo.root=root;
				runInfo.isShowAll=cbShowAll.Checked;
				runInfo.isFindUp=cbFindUp.Checked;
				runInfo.scanLevel=cbLevel.SelectedIndex;
				
                backgroundWorker.RunWorkerAsync(runInfo);
            }
			
		}		
		
		private void EndScan()
		{
			//пытаемся остановить
			backgroundWorker.CancelAsync();
			if (lastCommand!=null)
				lastCommand.Cancel();			
		}	
		
		void BtnGetTreeClick(object sender, EventArgs e)
		{
			if (!backgroundWorker.IsBusy)
				StartScan();
			else
				EndScan();
		}
		
		
		void TvListAfterSelect(object sender, TreeViewEventArgs e)
		{
			//выделение ветки
			tbSQLText.Clear();
			
			if (tvList.SelectedNode!=null)
			if (tvList.SelectedNode.Tag!=null)
			tbSQLText.Text=tvList.SelectedNode.Tag.ToString();
			
			tbSQLText.OnTextChanged();
		}
		
		void ListTreeFormClosed(object sender, FormClosedEventArgs e)
		{
			EndScan();
		}

		private void GetTreeViewNodesText(TreeNodeCollection nodesInCurrentLevel, StringBuilder sb, int level = 0)
		{
		    foreach (TreeNode currentNode in nodesInCurrentLevel)
		    {
		        sb.Append(new string(' ', level+1 * 2));
		        sb.AppendLine(currentNode.Text);
		        GetTreeViewNodesText(currentNode.Nodes, sb, level + 2);
		    }
		}
		
		void TbSQLTextTextChanged(object sender, EventArgs e)
		{
			//fix! распознаем комментарии более корректно, и помечаем их
			Range range = tbSQLText.Range;
			range.SetStyle(tbSQLText.SyntaxHighlighter.CommentStyle,sql_comment_fix);
		}			
		
	}
}
