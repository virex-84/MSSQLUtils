/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 26.06.2023
 * Время: 13:05
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace MSSQLUtils
{
	partial class ListMerge
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private FastColoredTextBoxNS.FastColoredTextBox tbSQL;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnExec;
		private System.Windows.Forms.ListBox lbConnections;
		private System.Windows.Forms.SplitContainer splitContainer4;
		private System.Windows.Forms.ListBox lbList;
		private Menees.Diffs.Windows.Forms.DiffControl diffControl1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbAdd;
		private System.Windows.Forms.ToolStripButton tsbEdit;
		private System.Windows.Forms.ToolStripButton tsbDelete;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListMerge));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.lbConnections = new System.Windows.Forms.ListBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.lbList = new System.Windows.Forms.ListBox();
			this.tbSQL = new FastColoredTextBoxNS.FastColoredTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnExec = new System.Windows.Forms.Button();
			this.diffControl1 = new Menees.Diffs.Windows.Forms.DiffControl();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSQL)).BeginInit();
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
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.diffControl1);
			this.splitContainer1.Size = new System.Drawing.Size(1101, 634);
			this.splitContainer1.SplitterDistance = 312;
			this.splitContainer1.SplitterWidth = 8;
			this.splitContainer1.TabIndex = 1;
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tbSQL);
			this.splitContainer2.Panel2.Controls.Add(this.panel1);
			this.splitContainer2.Size = new System.Drawing.Size(312, 634);
			this.splitContainer2.SplitterDistance = 395;
			this.splitContainer2.SplitterWidth = 8;
			this.splitContainer2.TabIndex = 0;
			// 
			// splitContainer4
			// 
			this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(0, 0);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.lbConnections);
			this.splitContainer4.Panel1.Controls.Add(this.toolStrip1);
			// 
			// splitContainer4.Panel2
			// 
			this.splitContainer4.Panel2.Controls.Add(this.lbList);
			this.splitContainer4.Size = new System.Drawing.Size(312, 395);
			this.splitContainer4.SplitterDistance = 86;
			this.splitContainer4.SplitterWidth = 8;
			this.splitContainer4.TabIndex = 0;
			// 
			// lbConnections
			// 
			this.lbConnections.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbConnections.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lbConnections.FormattingEnabled = true;
			this.lbConnections.ItemHeight = 16;
			this.lbConnections.Location = new System.Drawing.Point(0, 27);
			this.lbConnections.Name = "lbConnections";
			this.lbConnections.Size = new System.Drawing.Size(308, 55);
			this.lbConnections.TabIndex = 3;
			this.lbConnections.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1DrawItem);
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tsbAdd,
			this.tsbEdit,
			this.tsbDelete});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(308, 27);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbAdd
			// 
			this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(80, 24);
			this.tsbAdd.Text = "Добавить";
			this.tsbAdd.Click += new System.EventHandler(this.TsbAddClick);
			// 
			// tsbEdit
			// 
			this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEdit.Name = "tsbEdit";
			this.tsbEdit.Size = new System.Drawing.Size(115, 24);
			this.tsbEdit.Text = "Редактировать";
			this.tsbEdit.Click += new System.EventHandler(this.TsbEditClick);
			// 
			// tsbDelete
			// 
			this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(69, 24);
			this.tsbDelete.Text = "Удалить";
			this.tsbDelete.Click += new System.EventHandler(this.TsbDeleteClick);
			// 
			// lbList
			// 
			this.lbList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbList.FormattingEnabled = true;
			this.lbList.ItemHeight = 16;
			this.lbList.Location = new System.Drawing.Point(0, 0);
			this.lbList.Name = "lbList";
			this.lbList.Size = new System.Drawing.Size(308, 297);
			this.lbList.TabIndex = 4;
			this.lbList.Click += new System.EventHandler(this.LbListClick);
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
			this.tbSQL.AutoScrollMinSize = new System.Drawing.Size(501, 126);
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
			this.tbSQL.Size = new System.Drawing.Size(308, 173);
			this.tbSQL.TabIndex = 1;
			this.tbSQL.Text = "select top 10\r\n  name=object_name(o.id),\r\n  m.definition\r\nfrom sys.sql_modules as" +
	" m\r\njoin sys.sysobjects as o  on m.object_id = o.id\r\nwhere\r\no.name like \'%name%\'" +
	"";
			this.tbSQL.Zoom = 100;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnExec);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 173);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(308, 54);
			this.panel1.TabIndex = 0;
			// 
			// btnExec
			// 
			this.btnExec.Location = new System.Drawing.Point(50, 6);
			this.btnExec.Name = "btnExec";
			this.btnExec.Size = new System.Drawing.Size(194, 38);
			this.btnExec.TabIndex = 0;
			this.btnExec.Text = "Получить список";
			this.btnExec.UseVisualStyleBackColor = true;
			this.btnExec.Click += new System.EventHandler(this.BtnExecClick);
			// 
			// diffControl1
			// 
			this.diffControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.diffControl1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.diffControl1.LineDiffHeight = 51;
			this.diffControl1.Location = new System.Drawing.Point(0, 0);
			this.diffControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.diffControl1.Name = "diffControl1";
			this.diffControl1.OverviewWidth = 36;
			this.diffControl1.ShowWhiteSpaceInLineDiff = true;
			this.diffControl1.Size = new System.Drawing.Size(777, 630);
			this.diffControl1.TabIndex = 0;
			this.diffControl1.ViewFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
			// 
			// ListMerge
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1101, 634);
			this.Controls.Add(this.splitContainer1);
			this.Name = "ListMerge";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ListMerge";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListMergeFormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel1.PerformLayout();
			this.splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSQL)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		}
}
