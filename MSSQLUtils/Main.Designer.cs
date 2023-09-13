/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 19.06.2023
 * Время: 13:55
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace MSSQLUtils
{
	partial class Main
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnTree;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnMerge;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnAssembles;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.btnList = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.btnTree = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.btnMerge = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.btnAssembles = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(689, 321);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.btnList);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(681, 292);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Пакетная обработка процедур";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(445, 246);
			this.label1.TabIndex = 3;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// btnList
			// 
			this.btnList.Location = new System.Drawing.Point(8, 252);
			this.btnList.Name = "btnList";
			this.btnList.Size = new System.Drawing.Size(252, 31);
			this.btnList.TabIndex = 2;
			this.btnList.Text = "Пакетная обработка процедур";
			this.btnList.UseVisualStyleBackColor = true;
			this.btnList.Click += new System.EventHandler(this.BtnListClick);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.btnTree);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(681, 292);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Дерево вызовов";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(445, 246);
			this.label2.TabIndex = 5;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// btnTree
			// 
			this.btnTree.Location = new System.Drawing.Point(8, 252);
			this.btnTree.Name = "btnTree";
			this.btnTree.Size = new System.Drawing.Size(252, 31);
			this.btnTree.TabIndex = 4;
			this.btnTree.Text = "Дерево вызовов";
			this.btnTree.UseVisualStyleBackColor = true;
			this.btnTree.Click += new System.EventHandler(this.btnTreeClick);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.btnMerge);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(681, 292);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "Сравнение";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(445, 246);
			this.label4.TabIndex = 8;
			this.label4.Text = "Сравнение:\r\n1. Добавить несколько подключений\r\n2. Выполнить запрос показывающий с" +
	"одержимое процедуры/функции из всех подключенных БД\r\n3. Сравнить";
			// 
			// btnMerge
			// 
			this.btnMerge.Location = new System.Drawing.Point(8, 252);
			this.btnMerge.Name = "btnMerge";
			this.btnMerge.Size = new System.Drawing.Size(252, 31);
			this.btnMerge.TabIndex = 7;
			this.btnMerge.Text = "Сравнить";
			this.btnMerge.UseVisualStyleBackColor = true;
			this.btnMerge.Click += new System.EventHandler(this.btnMergeClick);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label5);
			this.tabPage4.Controls.Add(this.btnAssembles);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(681, 292);
			this.tabPage4.TabIndex = 4;
			this.tabPage4.Text = "Сборки";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(445, 246);
			this.label5.TabIndex = 5;
			this.label5.Text = "Просмотр содержимого сборок";
			// 
			// btnAssembles
			// 
			this.btnAssembles.Location = new System.Drawing.Point(8, 252);
			this.btnAssembles.Name = "btnAssembles";
			this.btnAssembles.Size = new System.Drawing.Size(252, 31);
			this.btnAssembles.TabIndex = 4;
			this.btnAssembles.Text = "Сборки";
			this.btnAssembles.UseVisualStyleBackColor = true;
			this.btnAssembles.Click += new System.EventHandler(this.btnAssemblesClick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(689, 321);
			this.Controls.Add(this.tabControl1);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MSSQLUtils";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
