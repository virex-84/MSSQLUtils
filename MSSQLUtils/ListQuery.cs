/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 06.06.2023
 * Время: 18:04
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace MSSQLUtils
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class ListQuery : Form, IConnectedForm
	{
		SqlCommand lastCommand;
		SqlConnection conn;
		Login.ConnectInfo info;
		Regex sql_comment_fix = new Regex(@"(?s)/\*(?>/\*(?<LEVEL>)|\*/(?<-LEVEL>)|(?!/\*|\*/).)+(?(LEVEL)(?!))\*/", SyntaxHighlighter.RegexCompiledOption);

		public ListQuery()
		{
			InitializeComponent();
		}
		
		public void setConnection(SqlConnection con, Login.ConnectInfo info)
		{
			this.conn = con;
			this.info = info;
			this.Text = string.Format("MSSQL {0}.{1} ({2}) ver {3}", info.Server, conn.Database, info.Login, info.Version);
		}
		
		//реализация запроса
		private void ExecQuery(SqlConnection con, string query, BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e)
		{
			DataTable dt = new DataTable();
			try {
				SqlCommand command = new SqlCommand(query, con);
				lastCommand = command;
				using (SqlDataReader reader = command.ExecuteReader()) {
					
					//запросили останов - прерываемся
					if (worker.CancellationPending)	{
						return;
					}
					
					dt.Load(reader);
					
					this.Invoke((MethodInvoker)delegate {
						ExecResult(dt, null);
					});
				}
			} catch (Exception ex) {
				this.Invoke((MethodInvoker)delegate {
					ExecResult(null, ex);
				});
			}
		}
		
		//результат выполняющийся в основном потоке
		private void ExecResult(DataTable dt, Exception ex)
		{
			tbResult.Clear();
			if (ex != null) {
				//ошибки - переключаемся во вкладку "сообщения"
				tabControl1.SelectedTab = tabControl1.TabPages["tbMessages"];
				tbResult.AppendText("ERROR: " + ex.Message);
				return;
			}
			
			if (dt != null) {
				dataGridView1.DataSource = dt;
				//ошибок нет - переключаемся во вкладку с гридом
				tabControl1.SelectedTab = tabControl1.TabPages["tbGrid"];
				tbResult.AppendText(string.Format("(затронуто строк: {0})", dt.Rows.Count));
				//перерисовываем т.к. может смениться Database
				setConnection(conn, info);
			}
		}
	
		void BackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			ExecQuery(conn, tbSQL.Text, worker, e);
		}
		
		void BackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			btExec.Text="Получить список";
		}	
		
		private void StartScan()
		{
			if (backgroundWorker.IsBusy != true)
            {
				Utils.CheckQueryResult check=Utils.checkQuery(tbSQL.Text);
				
				if (check.isError)
					if (MessageBox.Show("В скрипте присутствуют ошибки\nПродолжить запуск?", "ВНИМАНИЕ!!!", MessageBoxButtons.YesNo)== DialogResult.No)
						return;		
				
				if (!check.isError && check.isModify)
					if (MessageBox.Show("В скрипте присутсвует модификация данных/таблиц\nПродолжить запуск?", "ВНИМАНИЕ!!!", MessageBoxButtons.YesNo)== DialogResult.No)
						return;
	
				
				btExec.Text="Остановить";
				tbResult.Clear();
				
				backgroundWorker.RunWorkerAsync();
			}
		}		
		
		private void EndScan()
		{
			//пытаемся остановить
			backgroundWorker.CancelAsync();
			if (lastCommand!=null)
				lastCommand.Cancel();				
		}			
	
		void btExecClick(object sender, EventArgs e)
		{
			if (!backgroundWorker.IsBusy)
				StartScan();
			else
				EndScan();
		}
		
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//клик по ячейке
			if (e.RowIndex == -1)
				return;
			if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
				tbCellText.Text = dataGridView1.CurrentCell.Value.ToString();
		}
		

		void BtnListClick(object sender, EventArgs e)
		{
			//кнопка "Список"
			var columnName = "definition";
			
			if (dataGridView1.CurrentCell != null)
				columnName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
			
			List<string> sqllist = new List<string>();
			foreach (DataGridViewRow row in dataGridView1.Rows) {
				sqllist.Add(row.Cells[columnName].Value.ToString());
			}
			var list = new List();
			list.setConnection(conn, info);
			list.setList(sqllist);
			list.ShowDialog();
		}
		
		void ListQueryFormClosed(object sender, FormClosedEventArgs e)
		{
			EndScan();
		}
		
		void TbCellTextTextChanged(object sender, EventArgs e)
		{
			//fix! распознаем комментарии более корректно, и помечаем их
			Range range = tbSQL.Range;
			range.SetStyle(tbSQL.SyntaxHighlighter.CommentStyle,sql_comment_fix);
		}
		
	}
	
}
