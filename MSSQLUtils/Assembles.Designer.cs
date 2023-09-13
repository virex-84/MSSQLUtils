/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 12.07.2023
 * Время: 17:54
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace MSSQLUtils
{
	partial class Assembles
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TreeView tvList;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnGetTree;
		private FastColoredTextBoxNS.FastColoredTextBox tbSQLText;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.ImageList imageList1;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Assembles));
			this.tvList = new System.Windows.Forms.TreeView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnGetTree = new System.Windows.Forms.Button();
			this.tbSQLText = new FastColoredTextBoxNS.FastColoredTextBox();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSQLText)).BeginInit();
			this.SuspendLayout();
			// 
			// tvList
			// 
			this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvList.HideSelection = false;
			this.tvList.ImageIndex = 0;
			this.tvList.ImageList = this.imageList1;
			this.tvList.Location = new System.Drawing.Point(0, 0);
			this.tvList.Name = "tvList";
			this.tvList.SelectedImageIndex = 0;
			this.tvList.Size = new System.Drawing.Size(198, 435);
			this.tvList.TabIndex = 1;
			this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvListAfterSelect);
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
			this.splitContainer1.Size = new System.Drawing.Size(629, 495);
			this.splitContainer1.SplitterDistance = 202;
			this.splitContainer1.SplitterWidth = 8;
			this.splitContainer1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnGetTree);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 435);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(198, 56);
			this.panel1.TabIndex = 0;
			// 
			// btnGetTree
			// 
			this.btnGetTree.Location = new System.Drawing.Point(22, 6);
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
			this.tbSQLText.AutoIndent = false;
			this.tbSQLText.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
	"*(?<range>:)\\s*(?<range>[^;]+);\r\n";
			this.tbSQLText.AutoScrollMinSize = new System.Drawing.Size(31, 18);
			this.tbSQLText.BackBrush = null;
			this.tbSQLText.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
			this.tbSQLText.CharHeight = 18;
			this.tbSQLText.CharWidth = 10;
			this.tbSQLText.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tbSQLText.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.tbSQLText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSQLText.IsReplaceMode = false;
			this.tbSQLText.Language = FastColoredTextBoxNS.Language.CSharp;
			this.tbSQLText.LeftBracket = '(';
			this.tbSQLText.LeftBracket2 = '{';
			this.tbSQLText.Location = new System.Drawing.Point(0, 0);
			this.tbSQLText.Name = "tbSQLText";
			this.tbSQLText.Paddings = new System.Windows.Forms.Padding(0);
			this.tbSQLText.RightBracket = ')';
			this.tbSQLText.RightBracket2 = '}';
			this.tbSQLText.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.tbSQLText.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbSQLText.ServiceColors")));
			this.tbSQLText.Size = new System.Drawing.Size(415, 491);
			this.tbSQLText.TabIndex = 1;
			this.tbSQLText.Zoom = 100;
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "images-class.png");
			this.imageList1.Images.SetKeyName(1, "images-field.png");
			this.imageList1.Images.SetKeyName(2, "images-method.png");
			this.imageList1.Images.SetKeyName(3, "images-property.png");
			// 
			// Assembles
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(629, 495);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Assembles";
			this.Text = "Assembles";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tbSQLText)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
