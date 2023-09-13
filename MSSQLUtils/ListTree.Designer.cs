/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 19.06.2023
 * Время: 14:36
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace MSSQLUtils
{
	partial class ListTree
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView tvList;
		private System.Windows.Forms.Panel panel1;
		private FastColoredTextBoxNS.FastColoredTextBox tbSQLText;
		private System.Windows.Forms.Button btnGetTree;
		private System.Windows.Forms.TextBox tbProcedureName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbFindUp;
		private System.Windows.Forms.CheckBox cbShowAll;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbLevel;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListTree));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvList = new System.Windows.Forms.TreeView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.cbLevel = new System.Windows.Forms.ComboBox();
			this.cbShowAll = new System.Windows.Forms.CheckBox();
			this.cbFindUp = new System.Windows.Forms.CheckBox();
			this.tbProcedureName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnGetTree = new System.Windows.Forms.Button();
			this.tbSQLText = new FastColoredTextBoxNS.FastColoredTextBox();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSQLText)).BeginInit();
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
			this.splitContainer1.Panel1.Controls.Add(this.tvList);
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tbSQLText);
			this.splitContainer1.Size = new System.Drawing.Size(701, 466);
			this.splitContainer1.SplitterDistance = 226;
			this.splitContainer1.SplitterWidth = 8;
			this.splitContainer1.TabIndex = 0;
			// 
			// tvList
			// 
			this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvList.HideSelection = false;
			this.tvList.Location = new System.Drawing.Point(0, 0);
			this.tvList.Name = "tvList";
			this.tvList.Size = new System.Drawing.Size(222, 254);
			this.tvList.TabIndex = 1;
			this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvListAfterSelect);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cbLevel);
			this.panel1.Controls.Add(this.cbShowAll);
			this.panel1.Controls.Add(this.cbFindUp);
			this.panel1.Controls.Add(this.tbProcedureName);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnGetTree);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 254);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(222, 208);
			this.panel1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(210, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "Глубина сканирования";
			// 
			// cbLevel
			// 
			this.cbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLevel.FormattingEnabled = true;
			this.cbLevel.Items.AddRange(new object[] {
			"Без ограничений",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"10",
			"11",
			"12",
			"13",
			"14",
			"15",
			"16",
			"17",
			"18",
			"19",
			"20"});
			this.cbLevel.Location = new System.Drawing.Point(10, 128);
			this.cbLevel.Name = "cbLevel";
			this.cbLevel.Size = new System.Drawing.Size(193, 24);
			this.cbLevel.TabIndex = 5;
			this.cbLevel.Tag = "Для поиска вверх лучше ограничить";
			// 
			// cbShowAll
			// 
			this.cbShowAll.Location = new System.Drawing.Point(10, 51);
			this.cbShowAll.Name = "cbShowAll";
			this.cbShowAll.Size = new System.Drawing.Size(187, 24);
			this.cbShowAll.TabIndex = 4;
			this.cbShowAll.Tag = "Подходит для обычного поиска вниз";
			this.cbShowAll.Text = "Отображать всё";
			this.cbShowAll.UseVisualStyleBackColor = true;
			// 
			// cbFindUp
			// 
			this.cbFindUp.Location = new System.Drawing.Point(10, 81);
			this.cbFindUp.Name = "cbFindUp";
			this.cbFindUp.Size = new System.Drawing.Size(187, 24);
			this.cbFindUp.TabIndex = 3;
			this.cbFindUp.Tag = "Если стартовое имя - таблица, вьюха и т.д.";
			this.cbFindUp.Text = "Поиск вверх";
			this.cbFindUp.UseVisualStyleBackColor = true;
			// 
			// tbProcedureName
			// 
			this.tbProcedureName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbProcedureName.Location = new System.Drawing.Point(10, 23);
			this.tbProcedureName.Name = "tbProcedureName";
			this.tbProcedureName.Size = new System.Drawing.Size(192, 22);
			this.tbProcedureName.TabIndex = 2;
			this.tbProcedureName.Tag = "Таблица, вьюха, функция, процедура...";
			this.tbProcedureName.Text = "procedure_name";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(210, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Стартовое имя процедуры...";
			// 
			// btnGetTree
			// 
			this.btnGetTree.Location = new System.Drawing.Point(25, 158);
			this.btnGetTree.Name = "btnGetTree";
			this.btnGetTree.Size = new System.Drawing.Size(150, 40);
			this.btnGetTree.TabIndex = 0;
			this.btnGetTree.Text = "Получить список";
			this.btnGetTree.UseVisualStyleBackColor = true;
			this.btnGetTree.Click += new System.EventHandler(this.BtnGetTreeClick);
			// 
			// tbSQLText
			// 
			this.tbSQLText.AutoCompleteBracketsList = new char[] {
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
			this.tbSQLText.AutoIndentCharsPatterns = "";
			this.tbSQLText.AutoScrollMinSize = new System.Drawing.Size(31, 18);
			this.tbSQLText.BackBrush = null;
			this.tbSQLText.CharHeight = 18;
			this.tbSQLText.CharWidth = 10;
			this.tbSQLText.CommentPrefix = "--";
			this.tbSQLText.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tbSQLText.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.tbSQLText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSQLText.IsReplaceMode = false;
			this.tbSQLText.Language = FastColoredTextBoxNS.Language.SQL;
			this.tbSQLText.LeftBracket = '(';
			this.tbSQLText.Location = new System.Drawing.Point(0, 0);
			this.tbSQLText.Name = "tbSQLText";
			this.tbSQLText.Paddings = new System.Windows.Forms.Padding(0);
			this.tbSQLText.RightBracket = ')';
			this.tbSQLText.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.tbSQLText.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbSQLText.ServiceColors")));
			this.tbSQLText.Size = new System.Drawing.Size(463, 462);
			this.tbSQLText.TabIndex = 1;
			this.tbSQLText.Zoom = 100;
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
			// 
			// ListTree
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(701, 466);
			this.Controls.Add(this.splitContainer1);
			this.Name = "ListTree";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ListTree";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListTreeFormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSQLText)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
