/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 19.06.2023
 * Время: 14:12
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data.SqlClient;

namespace MSSQLUtils
{
	/// <summary>
	/// Description of ConnectedForm.
	/// </summary>
	public interface IConnectedForm
	{
		void setConnection(SqlConnection con, Login.ConnectInfo info);
	}
	
}
