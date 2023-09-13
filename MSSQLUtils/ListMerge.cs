/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 26.06.2023
 * Время: 13:05
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Menees.Diffs;

namespace MSSQLUtils
{
	/// <summary>
	/// Description of ListMerge.
	/// </summary>
	public partial class ListMerge : Form
	{
		public class RunInfo
		{
			public AddLogin.LoginInfo[] logins { get; set; }
			public string query { get; set; }			
		}
		
		public class ResultValue{
			public string Text { get; set; }
			public AddLogin.LoginInfo login { get; set; }
		}
		
		public class ResultDisplay{
			public string Name { get; set; }
			public List<ResultValue> Values { get; set; }
		}
		
		public class Result{
			public string Name { get; set; }
			public string Value { get; set; }
		}		
			
		public class QueryResult
		{
			public AddLogin.LoginInfo login { get; set; }
			public string Query { get; set; }
			public List<Result> Result { get; set; }
			public string Error { get; set; }
			public string Title { get; set; }
		}		
		
		public ListMerge()
		{
			InitializeComponent();
		}
		
		static bool Equals(string text1, string text2){
			if (text1==null || text2==null) return false;
			return text1.Equals(text2);
		}
		
		void TsbAddClick(object sender, EventArgs e)
		{
			if (lbConnections.Items.Count>=2) {
				MessageBox.Show("Нельзя добавить больше 2 подключений", "ВНИМАНИЕ!", MessageBoxButtons.OK);
				return;
			}
			
			var info = AddLogin.Add();
			
			foreach(var i in lbConnections.Items){
				var item = (AddLogin.LoginInfo)i;
				if  (
					Equals(item.DataSource,info.DataSource) &&
					Equals(item.InitialCatalog,info.InitialCatalog)
					//Equals(item.UserID,info.UserID)
				) {
					MessageBox.Show("Такое подключение уже существует", "ВНИМАНИЕ!", MessageBoxButtons.OK);
					return;
				};
			}
			
			lbConnections.Items.Add(info);			
		}

		void ListBox1DrawItem(object sender, DrawItemEventArgs e)
		{
			var fontColor=Color.Black;
			
			AddLogin.LoginInfo item = null;
			try{
				item = ((AddLogin.LoginInfo)lbConnections.Items[e.Index]);
			} catch {}
			var text = "";
			if (item!=null)	{
				text=string.Format("{0}.{1}", item.DataSource, item.InitialCatalog);				
				if (item.Error!=null) fontColor=Color.Red;
			}
			
			var isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
		
	
			var backColor = isItemSelected ? SystemColors.Highlight : lbConnections.BackColor;
			using (var backBrush = new SolidBrush(backColor)) {
				e.Graphics.FillRectangle(backBrush, e.Bounds);
			}
    
			const TextFormatFlags formatFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
			TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds, fontColor, formatFlags);	
		}
		
		void TsbEditClick(object sender, EventArgs e)
		{
			if (lbConnections.SelectedItem==null) return;
			AddLogin.LoginInfo info = (AddLogin.LoginInfo)lbConnections.SelectedItem;
			if (info==null) return;
			info.Error=null;
			AddLogin.Edit(info);
		}

		void TsbDeleteClick(object sender, EventArgs e)
		{
			if (lbConnections.SelectedItem==null) return;
			lbConnections.Items.Remove(lbConnections.SelectedItem);
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
			} catch {
				return false;
			}			
		}		
		
		//реализация запроса		
		private void GetList(AddLogin.LoginInfo[] logins, string query, BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e){
			List<QueryResult> list = new List<QueryResult>();
			
			//прогоняем по всем подключениям
			foreach (var i in logins){
				QueryResult res=new QueryResult();
				res.Result=new List<Result>();
				res.Query=query;
				res.login=i;
				res.Error=null;
				list.Add(res);
					
				var builder = new SqlConnectionStringBuilder();
				builder.DataSource = i.DataSource;
				builder.InitialCatalog = i.InitialCatalog;
				builder.UserID = i.UserID;
				builder.Password = i.Password;
				builder.ApplicationName = "MSSQLUtils";
				string connString = builder.ToString();
				
				//быстрая проверка на подключение
				if (!testConnect(i.DataSource)){
					res.Error=string.Format("Адрес {0} не доступен для подключения", i.DataSource);
					continue;
				}
				
				using (SqlConnection con = new SqlConnection(connString)) {
					
				//запросили останов - прерываемся
				if (worker.CancellationPending)	{
					break;
				}
					
					try {
						con.Open();
					} catch (SqlException ex) {
						res.Error=ex.Message.ToString();
						continue;
					}
					
					DataTable dt = new DataTable();
					try {
						SqlCommand command = new SqlCommand(query, con);
						using (SqlDataReader reader = command.ExecuteReader()) {
							
							//запросили останов - прерываемся
							if (worker.CancellationPending)	{
								break;
							}
							
							dt.Load(reader);
							try{
								foreach(DataRow  item in dt.Rows){
									res.Result.Add(new Result(){Name=item["name"].ToString(),Value=item["definition"].ToString()});
								}
							
							} catch {}
						}
					} catch (Exception ex) {
						res.Error=ex.Message.ToString();
						continue;
					}
					dt.Clear();
					
					con.Close();
				}
	
			}
			
			this.Invoke((MethodInvoker)delegate {
				ExecResult(list);
			});
		}
		
		private ResultDisplay Find(ListBox list, string Name){
			foreach(var item in list.Items){
				if (item is ResultDisplay && (item as ResultDisplay).Name.Equals(Name)){
					return (item as ResultDisplay);
				}
			}
			return null;
		}

		
		//результат выполняющийся в основном потоке
		private void ExecResult(List<QueryResult> list)
		{
			EndScan();
			
			lbList.Items.Clear();
			lbList.DisplayMember = "Name";
			lbList.ValueMember = "Values";
			foreach (var item in list) {
				//обновляем список подключений (если ошибка - красный, иначе - обычнй черный шрифт)
				foreach(var i in lbConnections.Items){
					if (i is AddLogin.LoginInfo && (i as AddLogin.LoginInfo)==item.login)
						(i as AddLogin.LoginInfo).Error=item.Error;
					}
				lbConnections.Invalidate();
				foreach (var res in item.Result) {
					var finded = Find(lbList,res.Name);
					if (finded==null) {
						finded = new ResultDisplay(){Name=res.Name,Values=new List<ResultValue>()};
						lbList.Items.Add(finded);
					}
					finded.Values.Add(new ResultValue(){Text=res.Value, login=item.login});
				}
			}
			
		}
		
		void BackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			var runInfo = (e.Argument as RunInfo);
			GetList(runInfo.logins, runInfo.query, worker, e);
		}
		
		void BackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			btnExec.Text="Получить список";
			lbConnections.Invalidate();
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
				
				btnExec.Text="Остановить";
				
				lbList.Items.Clear();
				AddLogin.LoginInfo[] connections = new AddLogin.LoginInfo[lbConnections.Items.Count];
				lbConnections.Items.CopyTo(connections, 0);
				
				var runInfo=new RunInfo();
				runInfo.logins=connections;
				runInfo.query=tbSQL.Text;				
				
				backgroundWorker.RunWorkerAsync(runInfo);
			}
		}		
		
		private void EndScan()
		{
			//пытаемся остановить
			backgroundWorker.CancelAsync();			
		}			
		
		void BtnExecClick(object sender, EventArgs e)
		{
			if (!backgroundWorker.IsBusy)
				StartScan();
			else
				EndScan();
		}
		
		void LbListClick(object sender, EventArgs e)
		{
			if (lbList.SelectedItem == null)
				return;
			
			var item = ((ResultDisplay)lbList.SelectedItem);
			
			ResultValue item1 = null;
			ResultValue item2 = null;
			
			try{
			item1 = item.Values[0];
			}catch{}
			try{
			item2 = item.Values[1];
			}catch{}
			
			//что-бы левая и правая часть для сравнения
			//не менялись местами
			//поменяем по порядку подключения
			if (lbConnections.Items.Count>0) {
				var left = (AddLogin.LoginInfo)lbConnections.Items[0];
				if (item2!=null && item2.login==left){
					var tmp=item1;
					item1=item2;
					item2=tmp;
				}
				if (item1!=null && item1.login!=left){
					var tmp=item1;
					item1=item2;
					item2=tmp;
				}			
			}
				
			var Caption1="";
			var Caption2="";			
			if (item1!=null) Caption1=string.Format("{0} {1}", item1.login.DataSource, item1.login.InitialCatalog);
			if (item2!=null) Caption2=string.Format("{0} {1}", item2.login.DataSource, item2.login.InitialCatalog);			
			
			string[] tokens1 = new string[0];
			string[] tokens2 = new string[0];

			if (item1!=null) tokens1 = Regex.Split(item1.Text, @"\r?\n|\r");
			if (item2!=null) tokens2 = Regex.Split(item2.Text, @"\r?\n|\r");

			
			MyersDiff<string> diff = new MyersDiff<string>(tokens1,tokens2, true);
			EditScript result = diff.Execute();
			diffControl1.SetData(tokens1,tokens2,result, Caption1, Caption2);

		}
		
		void ListMergeFormClosed(object sender, FormClosedEventArgs e)
		{
			EndScan();
		}
		

	}
}
