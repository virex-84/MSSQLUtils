/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 19.06.2023
 * Время: 13:55
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Windows.Forms;

namespace MSSQLUtils
{
	/// <summary>
	/// Description of Main.
	/// </summary>
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		void BtnListClick(object sender, EventArgs e)
		{
			var login = new Login(Login.NextForm.ListQuery);
			login.ShowDialog();
		}
		
		void btnTreeClick(object sender, EventArgs e)
		{
			var login = new Login(Login.NextForm.ListTree);
			login.ShowDialog();
		}
		
		void btnMergeClick(object sender, EventArgs e)
		{
			var listMerge = new ListMerge();
			listMerge.ShowDialog();
		}
		
		void btnAssemblesClick(object sender, EventArgs e)
		{
			var login = new Login(Login.NextForm.Assembles);
			login.ShowDialog();
		}
	}
}
