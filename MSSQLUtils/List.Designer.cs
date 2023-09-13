/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 07.06.2023
 * Время: 14:48
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace MSSQLUtils
{
	partial class List
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListBox listBox1;
		private FastColoredTextBoxNS.FastColoredTextBox tbText;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnReplace;
		private System.Windows.Forms.TextBox tbWhen;
		private System.Windows.Forms.TextBox tbWho;
		private System.Windows.Forms.CheckBox cbGlobalReplace;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnExecAll;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox tbErrorMessage;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(List));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnExecAll = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.tbText = new FastColoredTextBoxNS.FastColoredTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbErrorMessage = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.cbGlobalReplace = new System.Windows.Forms.CheckBox();
			this.btnReplace = new System.Windows.Forms.Button();
			this.tbWhen = new System.Windows.Forms.TextBox();
			this.tbWho = new System.Windows.Forms.TextBox();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			this.splitContainer1.Panel1.Controls.Add(this.listBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tbText);
			this.splitContainer1.Panel2.Controls.Add(this.panel1);
			this.splitContainer1.Size = new System.Drawing.Size(828, 457);
			this.splitContainer1.SplitterDistance = 275;
			this.splitContainer1.SplitterWidth = 8;
			this.splitContainer1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnExecAll);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 403);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(271, 50);
			this.panel2.TabIndex = 1;
			// 
			// btnExecAll
			// 
			this.btnExecAll.Location = new System.Drawing.Point(78, 7);
			this.btnExecAll.Name = "btnExecAll";
			this.btnExecAll.Size = new System.Drawing.Size(101, 35);
			this.btnExecAll.TabIndex = 1;
			this.btnExecAll.Text = "Выполнить!";
			this.btnExecAll.UseVisualStyleBackColor = true;
			this.btnExecAll.Click += new System.EventHandler(this.BtnExecAllClick);
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(271, 453);
			this.listBox1.TabIndex = 0;
			this.listBox1.Click += new System.EventHandler(this.ListBox1Click);
			this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1DrawItem);
			this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox1KeyDown);
			// 
			// tbText
			// 
			this.tbText.AutoCompleteBracketsList = new char[] {
		'(',
		')',
		'{',
		'}',
		'[',
		']',
		'\"',
		'\"',
		'\'',
		'\''};
			this.tbText.AutoIndentCharsPatterns = "";
			this.tbText.AutoScrollMinSize = new System.Drawing.Size(31, 18);
			this.tbText.BackBrush = null;
			this.tbText.CharHeight = 18;
			this.tbText.CharWidth = 10;
			this.tbText.CommentPrefix = "--";
			this.tbText.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tbText.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.tbText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbText.IsReplaceMode = false;
			this.tbText.Language = FastColoredTextBoxNS.Language.SQL;
			this.tbText.LeftBracket = '(';
			this.tbText.Location = new System.Drawing.Point(0, 0);
			this.tbText.Name = "tbText";
			this.tbText.Paddings = new System.Windows.Forms.Padding(0);
			this.tbText.RightBracket = ')';
			this.tbText.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.tbText.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbText.ServiceColors")));
			this.tbText.Size = new System.Drawing.Size(541, 329);
			this.tbText.TabIndex = 1;
			this.tbText.Zoom = 100;
			this.tbText.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TbTextTextChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tbErrorMessage);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.cbGlobalReplace);
			this.panel1.Controls.Add(this.btnReplace);
			this.panel1.Controls.Add(this.tbWhen);
			this.panel1.Controls.Add(this.tbWho);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 329);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(541, 124);
			this.panel1.TabIndex = 0;
			// 
			// tbErrorMessage
			// 
			this.tbErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbErrorMessage.Location = new System.Drawing.Point(0, 0);
			this.tbErrorMessage.Multiline = true;
			this.tbErrorMessage.Name = "tbErrorMessage";
			this.tbErrorMessage.ReadOnly = true;
			this.tbErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbErrorMessage.Size = new System.Drawing.Size(541, 43);
			this.tbErrorMessage.TabIndex = 14;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(428, 49);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(101, 31);
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// cbGlobalReplace
			// 
			this.cbGlobalReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cbGlobalReplace.Location = new System.Drawing.Point(4, 93);
			this.cbGlobalReplace.Name = "cbGlobalReplace";
			this.cbGlobalReplace.Size = new System.Drawing.Size(183, 24);
			this.cbGlobalReplace.TabIndex = 12;
			this.cbGlobalReplace.Text = "Глобальная замена";
			this.cbGlobalReplace.UseVisualStyleBackColor = true;
			// 
			// btnReplace
			// 
			this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReplace.Location = new System.Drawing.Point(454, 91);
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Size = new System.Drawing.Size(75, 30);
			this.btnReplace.TabIndex = 11;
			this.btnReplace.Text = "замена";
			this.btnReplace.UseVisualStyleBackColor = true;
			this.btnReplace.Click += new System.EventHandler(this.BtnReplaceClick);
			// 
			// tbWhen
			// 
			this.tbWhen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWhen.Location = new System.Drawing.Point(322, 95);
			this.tbWhen.Name = "tbWhen";
			this.tbWhen.Size = new System.Drawing.Size(126, 22);
			this.tbWhen.TabIndex = 10;
			this.tbWhen.Text = "GETUTCDATE()";
			// 
			// tbWho
			// 
			this.tbWho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWho.Location = new System.Drawing.Point(193, 95);
			this.tbWho.Name = "tbWho";
			this.tbWho.Size = new System.Drawing.Size(123, 22);
			this.tbWho.TabIndex = 9;
			this.tbWho.Text = "GETDATE()";
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
			// 
			// List
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 457);
			this.Controls.Add(this.splitContainer1);
			this.Name = "List";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "List";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListFormClosed);
			this.TextChanged += new System.EventHandler(this.TbTextTextChanged);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
