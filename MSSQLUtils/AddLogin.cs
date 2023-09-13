/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 26.06.2023
 * Время: 13:26
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSSQLUtils
{
	/// <summary>
	/// Description of AddLogin.
	/// </summary>
	public partial class AddLogin : Form
	{
		
		public class LoginInfo
		{
			public string DataSource { get; set; }
			public string InitialCatalog { get; set; }
			public string UserID { get; set; }
			public string Password { get; set; }
			
			public string Error { get; set; }
		}		
		
		public AddLogin()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public static LoginInfo Add(){
			LoginInfo info = new LoginInfo();
			var form = new AddLogin();
			form.btnAdd.Click += (sender, e) => 
            {
				info.DataSource = form.tbServer.Text;
				info.InitialCatalog = form.tbDatabase.Text;
				info.UserID = form.tbLogin.Text;
				info.Password = form.tbPassword.Text;
				form.Dispose();
            };
			form.ShowDialog();
			return info;
		}
		
		public static void Edit(LoginInfo info){
			var form = new AddLogin();
			form.tbServer.Text=info.DataSource;
			form.tbDatabase.Text=info.InitialCatalog;
			form.tbLogin.Text=info.UserID;
			form.tbPassword.Text=info.Password;
				
			form.btnAdd.Click += (sender, e) => 
            {
				info.DataSource = form.tbServer.Text;
				info.InitialCatalog = form.tbDatabase.Text;
				info.UserID = form.tbLogin.Text;
				info.Password = form.tbPassword.Text;
				form.Dispose();
            };
			form.ShowDialog();
		}		
	}
}
