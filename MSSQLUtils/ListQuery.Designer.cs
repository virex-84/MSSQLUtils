/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 06.06.2023
 * Время: 18:04
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace MSSQLUtils
{
	partial class ListQuery
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btExec;
		private System.Windows.Forms.TextBox tbResult;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbGrid;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TabPage tbMessages;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Button btnList;
		private FastColoredTextBoxNS.FastColoredTextBox tbCellText;
		private FastColoredTextBoxNS.FastColoredTextBox tbSQL;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListQuery));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btExec = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tbSQL = new FastColoredTextBoxNS.FastColoredTextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbGrid = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tbMessages = new System.Windows.Forms.TabPage();
			this.tbResult = new System.Windows.Forms.TextBox();
			this.tbCellText = new FastColoredTextBoxNS.FastColoredTextBox();
			this.btnList = new System.Windows.Forms.Button();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSQL)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tbGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tbMessages.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbCellText)).BeginInit();
			this.SuspendLayout();
			// 
			// btExec
			// 
			this.btExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExec.Location = new System.Drawing.Point(33, 426);
			this.btExec.Name = "btExec";
			this.btExec.Size = new System.Drawing.Size(145, 34);
			this.btExec.TabIndex = 1;
			this.btExec.Text = "Получить список";
			this.btExec.UseVisualStyleBackColor = true;
			this.btExec.Click += new System.EventHandler(this.btExecClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tbCellText);
			this.splitContainer1.Size = new System.Drawing.Size(757, 426);
			this.splitContainer1.SplitterDistance = 404;
			this.splitContainer1.SplitterWidth = 8;
			this.splitContainer1.TabIndex = 5;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.tbSQL);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer2.Size = new System.Drawing.Size(400, 422);
			this.splitContainer2.SplitterDistance = 202;
			this.splitContainer2.SplitterWidth = 8;
			this.splitContainer2.TabIndex = 0;
			// 
			// tbSQL
			// 
			this.tbSQL.AutoCompleteBracketsList = new char[] {
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
			this.tbSQL.AutoIndentCharsPatterns = "";
			this.tbSQL.AutoScrollMinSize = new System.Drawing.Size(741, 162);
			this.tbSQL.BackBrush = null;
			this.tbSQL.CharHeight = 18;
			this.tbSQL.CharWidth = 10;
			this.tbSQL.CommentPrefix = "--";
			this.tbSQL.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tbSQL.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.tbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSQL.IsReplaceMode = false;
			this.tbSQL.Language = FastColoredTextBoxNS.Language.SQL;
			this.tbSQL.LeftBracket = '(';
			this.tbSQL.Location = new System.Drawing.Point(0, 0);
			this.tbSQL.Name = "tbSQL";
			this.tbSQL.Paddings = new System.Windows.Forms.Padding(0);
			this.tbSQL.RightBracket = ')';
			this.tbSQL.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.tbSQL.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbSQL.ServiceColors")));
			this.tbSQL.Size = new System.Drawing.Size(400, 202);
			this.tbSQL.TabIndex = 0;
			this.tbSQL.Text = resources.GetString("tbSQL.Text");
			this.tbSQL.Zoom = 100;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbGrid);
			this.tabControl1.Controls.Add(this.tbMessages);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(400, 212);
			this.tabControl1.TabIndex = 8;
			// 
			// tbGrid
			// 
			this.tbGrid.Controls.Add(this.dataGridView1);
			this.tbGrid.Location = new System.Drawing.Point(4, 25);
			this.tbGrid.Name = "tbGrid";
			this.tbGrid.Padding = new System.Windows.Forms.Padding(3);
			this.tbGrid.Size = new System.Drawing.Size(392, 183);
			this.tbGrid.TabIndex = 0;
			this.tbGrid.Text = "Результат";
			this.tbGrid.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(386, 177);
			this.dataGridView1.TabIndex = 4;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellClick);
			// 
			// tbMessages
			// 
			this.tbMessages.Controls.Add(this.tbResult);
			this.tbMessages.Location = new System.Drawing.Point(4, 25);
			this.tbMessages.Name = "tbMessages";
			this.tbMessages.Padding = new System.Windows.Forms.Padding(3);
			this.tbMessages.Size = new System.Drawing.Size(392, 183);
			this.tbMessages.TabIndex = 1;
			this.tbMessages.Text = "Сообщения";
			this.tbMessages.UseVisualStyleBackColor = true;
			// 
			// tbResult
			// 
			this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbResult.Location = new System.Drawing.Point(3, 3);
			this.tbResult.Multiline = true;
			this.tbResult.Name = "tbResult";
			this.tbResult.ReadOnly = true;
			this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbResult.Size = new System.Drawing.Size(386, 177);
			this.tbResult.TabIndex = 3;
			this.tbResult.WordWrap = false;
			// 
			// tbCellText
			// 
			this.tbCellText.AutoCompleteBracketsList = new char[] {
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
			this.tbCellText.AutoIndentCharsPatterns = "";
			this.tbCellText.AutoScrollMinSize = new System.Drawing.Size(31, 18);
			this.tbCellText.BackBrush = null;
			this.tbCellText.CharHeight = 18;
			this.tbCellText.CharWidth = 10;
			this.tbCellText.CommentPrefix = "--";
			this.tbCellText.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tbCellText.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.tbCellText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbCellText.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.AllTextRange;
			this.tbCellText.IsReplaceMode = false;
			this.tbCellText.Language = FastColoredTextBoxNS.Language.SQL;
			this.tbCellText.LeftBracket = '(';
			this.tbCellText.Location = new System.Drawing.Point(0, 0);
			this.tbCellText.Name = "tbCellText";
			this.tbCellText.Paddings = new System.Windows.Forms.Padding(0);
			this.tbCellText.RightBracket = ')';
			this.tbCellText.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.tbCellText.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbCellText.ServiceColors")));
			this.tbCellText.Size = new System.Drawing.Size(341, 422);
			this.tbCellText.TabIndex = 0;
			this.tbCellText.Zoom = 100;
			this.tbCellText.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TbCellTextTextChanged);
			// 
			// btnList
			// 
			this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnList.Location = new System.Drawing.Point(201, 426);
			this.btnList.Name = "btnList";
			this.btnList.Size = new System.Drawing.Size(111, 34);
			this.btnList.TabIndex = 9;
			this.btnList.Text = "Список";
			this.btnList.UseVisualStyleBackColor = true;
			this.btnList.Click += new System.EventHandler(this.BtnListClick);
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
			// 
			// ListQuery
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(753, 466);
			this.Controls.Add(this.btnList);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btExec);
			this.Name = "ListQuery";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ListQuery";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListQueryFormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbSQL)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tbGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tbMessages.ResumeLayout(false);
			this.tbMessages.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbCellText)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
