/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 07.06.2023
 * Время: 14:48
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MSSQLUtils
{
	/// <summary>
	/// Description of List.
	/// </summary>
	public partial class List : Form, IConnectedForm
	{
		enum ListState {
			Default,
			Changed, //отредактированный(синий)
			Error, //ошибка выполнения(красный)
			Complete //выполнился(зеленый)
		}
		
		class ListItem
		{
			public string Name { get; set; }
			public string Value { get; set; }
			public ListState State { get; set; }
			public string ErrorMessage { get; set; }
		}
		
		SqlConnection conn;
		int lastIndex = -1;
		string changedText = "";
		
		public List()
		{
			InitializeComponent();
		}
		
		public void setConnection(SqlConnection con, Login.ConnectInfo info)
		{
			conn = con;
			this.Text = string.Format("MSSQL {0}.{1} ({2}) ver {3}", info.Server, conn.Database, info.Login, info.Version);
		}
		
		//процедура для корректной замены подстроки
		public static string Replace(string str, string old, string @new, StringComparison comparison)
		{
			@new = @new ?? "";
			if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(old) || old.Equals(@new, comparison))
				return str;
			int foundAt = 0;
			while ((foundAt = str.IndexOf(old, foundAt, comparison)) != -1) {
				str = str.Remove(foundAt, old.Length).Insert(foundAt, @new);
				foundAt += @new.Length;
			}
			return str;
		}

		public void setList(List<string> sqllist)
		{
			listBox1.DisplayMember = "Name";
			listBox1.ValueMember = "Value";
			foreach (var item in sqllist) {
				//в видимую часть (title) добавим укороченный вариант
				
				//var itemStr = Replace(item, "create procedure","alter procedure",StringComparison.InvariantCultureIgnoreCase);
				var itemStr = item;
				
				var title = itemStr;
				try {
					int startIndex = itemStr.IndexOf("CREATE procedure", StringComparison.OrdinalIgnoreCase);
					int endIndex = itemStr.IndexOf("(", StringComparison.OrdinalIgnoreCase);
					int endIndex2 = itemStr.IndexOf("as ", StringComparison.OrdinalIgnoreCase);
					endIndex = Math.Min(endIndex, endIndex2);
					int length = endIndex - (startIndex + 16) + 1;
					title = itemStr.Substring(startIndex + 16, length);
				} catch {
				}

				listBox1.Items.Add(new ListItem() {
					Name = title,
					Value = itemStr,
					State = ListState.Default
				});
			}

		}
		
		void ListBox1Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedItem == null)
				return;
			
			//если были изменения - предлагаем сохранить
			if (changedText.Length > 0 && !((ListItem)listBox1.Items[lastIndex]).Value.Equals(changedText)) {
				if (MessageBox.Show("Сохранить изменения?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					((ListItem)listBox1.Items[lastIndex]).Value = changedText;
					((ListItem)listBox1.Items[lastIndex]).State = ListState.Changed;
					((ListItem)listBox1.SelectedItem).ErrorMessage = "";//стираем старую ошибку
				}
				changedText = "";
			}
			
			lastIndex = listBox1.SelectedIndex;
			
			//заполняем (убираем обработчик)
			tbText.TextChanged -= TbTextTextChanged;
			tbText.Text = ((ListItem)listBox1.SelectedItem).Value;
			tbText.TextChanged += TbTextTextChanged;
			
			tbErrorMessage.Text = ((ListItem)listBox1.SelectedItem).ErrorMessage;
		}

		
		void BtnReplaceClick(object sender, EventArgs e)
		{
			//не различает скобки
			//tbCellText.Text=Regex.Replace(tbCellText.Text, tbWho.Text,tbWhen.Text, RegexOptions.IgnoreCase);
			
			if (!cbGlobalReplace.Checked) {
				if (listBox1.SelectedItem == null)
					return;				
				((ListItem)listBox1.SelectedItem).Value = Replace(tbText.Text, tbWho.Text, tbWhen.Text, StringComparison.InvariantCultureIgnoreCase);
				((ListItem)listBox1.SelectedItem).State = ListState.Changed;
				((ListItem)listBox1.SelectedItem).ErrorMessage = "";//стираем старую ошибку
			} else {
				foreach (ListItem item in listBox1.Items) {
					item.Value = Replace(item.Value, tbWho.Text, tbWhen.Text, StringComparison.InvariantCultureIgnoreCase);
					item.State = ListState.Changed;
					item.ErrorMessage = "";//стираем старую ошибку
				}
			}
			
			//обновляем текущий текстбокс
			if (listBox1.SelectedItem == null)
				return;
			tbText.Text = ((ListItem)listBox1.SelectedItem).Value;
			
			listBox1.Invalidate();
		}
		
		void ListBox1KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete) {
				listBox1.Items.Remove(listBox1.SelectedItem);
				changedText = "";
			}
		}

		void ListBox1DrawItem(object sender, DrawItemEventArgs e)
		{
			ListItem item = ((ListItem)listBox1.Items[e.Index]);

			Color color = e.ForeColor;
			if (item != null) {
				switch (item.State) {
					case ListState.Changed:
						color = Color.Blue;
						break;
					case ListState.Error:
						color = Color.Red;
						break;		
					case ListState.Complete:
						color = Color.Green;
						break;	
					default:
						break;
				} 
			}
			
			var isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
		
	
			var backColor = isItemSelected ? SystemColors.Highlight : listBox1.BackColor;
			using (var backBrush = new SolidBrush(backColor)) {
				e.Graphics.FillRectangle(backBrush, e.Bounds);
			}
    
			const TextFormatFlags formatFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
			TextRenderer.DrawText(e.Graphics, item.Name, e.Font, e.Bounds, color, formatFlags);			
		}
		
		//реализация делегата
		private void ExecQuery(SqlConnection con, ListBox listbox, BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e)
		{
			foreach (ListItem item in listbox.Items) {
				
				//запросили останов - прерываемся
				if (worker.CancellationPending)	{
					break;
				}				
				
				//ВЫПОЛНЯЕМ ТОЛЬКО ОТРЕДАКТИРОВАННЫЙ (СИНИЙ)
				if (item.State != ListState.Changed)
					continue;
				
				try {
					SqlCommand command = new SqlCommand(item.Value, con); 	
					using (SqlDataReader reader = command.ExecuteReader()) {
						this.Invoke((MethodInvoker)delegate {
							ExecResult(item, ListState.Complete, "");
						});
					}
				} catch (Exception ex) {
					this.Invoke((MethodInvoker)delegate {
						ExecResult(item, ListState.Error, ex.Message);
					});
				} finally {
				}

			}
		}
		
		//результат выполняющийся в основном потоке
		private void ExecResult(ListItem item, ListState State, string ErrorMessage)
		{
			item.State = State;
			item.ErrorMessage = ErrorMessage;			
			listBox1.Invalidate();						
			Application.DoEvents();
		}
		
		void BackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			ExecQuery(conn, listBox1, worker, e);
		}
		
		void BackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			btnExecAll.Text="Выполнить!";
		}	

		private void StartScan()
		{
			if (backgroundWorker.IsBusy != true)
            {
				int prepareToRun = 0;
				foreach (ListItem item in listBox1.Items) {
					if (item.State == ListState.Changed)
						prepareToRun++;
				}
				
				if (prepareToRun < 1) {
					MessageBox.Show("Нет ни одного измененного скрипта\nдля запуска", "ВНИМАНИЕ!!!", MessageBoxButtons.OK);
					return;
				}
				
				if (MessageBox.Show(string.Format("БУДЕТ ЗАПУЩЕНО {0} СКРИПТА/ОВ\nВЫ ДЕЙСТВИТЕЛЬНО ХОТИТЕ ВЫПОЛНИТЬ СКРИПТЫ???", prepareToRun), "ВНИМАНИЕ!!!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					if (MessageBox.Show("ВЫ ТОЧНО УВЕРЕНЫ ЧТО ХОТИТЕ ВЫПОЛНИТЬ СКРИПТЫ???", "ВНИМАНИЕ!!!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
						//запускаем в фоновом режиме
						btnExecAll.Text="Остановить";
                		backgroundWorker.RunWorkerAsync();						
					}
				}
            }
		}		
		
		private void EndScan()
		{
			//пытаемся остановить
			backgroundWorker.CancelAsync();
		}

		void BtnExecAllClick(object sender, EventArgs e)
		{
			if (!backgroundWorker.IsBusy)
				StartScan();
			else
				EndScan();
		}
		
		void TbTextTextChanged(object sender, EventArgs e)
		{
			//при изменении текста - делаем кнопку "Сохранить" активной
			if (listBox1.SelectedItem == null)
				return;
			var source = ((ListItem)listBox1.SelectedItem).Value;
			var changed = tbText.Text;
			
			if (!source.Equals(changed)) {
				btnSave.Enabled = true;
			} else
				btnSave.Enabled = false;
			
			changedText = changed;			
		}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			//сохраняем изменения
			if (listBox1.SelectedItem == null)
				return;
			
			((ListItem)listBox1.SelectedItem).Value = tbText.Text;
			((ListItem)listBox1.SelectedItem).State = ListState.Changed;
			((ListItem)listBox1.SelectedItem).ErrorMessage = "";//стираем старую ошибку
			listBox1.Invalidate();
		}
		void ListFormClosed(object sender, FormClosedEventArgs e)
		{
			backgroundWorker.CancelAsync();
		}
		
		
	}
}
