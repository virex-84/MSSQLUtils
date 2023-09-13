/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 06.06.2023
 * Время: 18:25
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MSSQLUtils
{
	/// <summary>
	/// Description of Login.
	/// </summary>
	public partial class Login : Form
	{
		public enum NextForm
		{
		    ListQuery,
		    ListTree,
		    Assembles
		}
		
		private NextForm nextForm;

		public class ConnectInfo
		{
			public string Server { get; set; }
			public string Version { get; set; }
			public string Login { get; set; }
		}
		
		public Login(NextForm _nextForm)
		{
			InitializeComponent();
			this.nextForm=_nextForm;
		}
		
		private bool testConnect(string targetAddress)
		{
			try {
				using (TcpClient tcpClient = new TcpClient()) {
					var result = tcpClient.BeginConnect(targetAddress, 1433, null, null);
					result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));
					if (!tcpClient.Connected)
						return false;
				}
				return true;
			} catch{
				return false;
			}			
		}

		void BtnConnectClick(object sender, EventArgs e)
		{
			var builder = new SqlConnectionStringBuilder();
			
			builder.DataSource = tbServer.Text;
			builder.InitialCatalog = tbDatabase.Text;
			builder.UserID = tbLogin.Text;
			builder.Password = tbPassword.Text;
			builder.ApplicationName = "MSSQLUtils";
			//builder.AsynchronousProcessing = true;
			//builder.ConnectTimeout      = 5;
			//builder.IntegratedSecurity  = true;

			//string connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connect Timeout=1",tbServer.Text, tbDatabase.Text, tbLogin.Text, tbPassword.Text);
			string connString = builder.ToString();
			
			//сначала пробуем понять: можно ли вообще подключиться
			if (!testConnect(tbServer.Text)) {
				MessageBox.Show(string.Format("Адрес {0} не доступен для подключения", tbServer.Text), "Ошибка подключения!", MessageBoxButtons.OK);
				return;
			}
			
			using (SqlConnection con = new SqlConnection(connString)) {
				try {
					//var result=con.OpenAsync();
					//result.Wait(5);
					con.Open();
				} catch (SqlException ex) {
					MessageBox.Show(ex.Message, "Ошибка подключения!", MessageBoxButtons.OK);
				} finally {
					// если подключение открыто
					if (con.State == ConnectionState.Open) {
						Form main=null;
						switch (nextForm){
							case NextForm.ListQuery:
								main = new ListQuery();
								break;
							case NextForm.ListTree:
								main = new ListTree();
								break;		
							case NextForm.Assembles:
								main = new Assembles();
								break;									
						}
						if (main!=null) {
							if (main is IConnectedForm){
								(main as IConnectedForm).setConnection(con, new ConnectInfo() {
									Server = tbServer.Text,
									Version = con.ServerVersion,
									Login = tbLogin.Text
								});
							}
							main.ShowDialog();
						}
	                    
						// закрываем подключение
						con.Close();
					}
				}
			}
			
		}

	}
}
