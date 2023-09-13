/*
 * Создано в SharpDevelop.
 * Пользователь: user
 * Дата: 12.07.2023
 * Время: 17:54
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
 
using System.Data.SqlTypes;
using System.IO;
﻿using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using Mono.Cecil; 
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MSSQLUtils
{
	public partial class Assembles : Form, IConnectedForm
	{
		SqlCommand lastCommand;
		SqlConnection conn;
		Login.ConnectInfo info;
		
		public class NodeInfo
		{
			public AssemblyDefinition _assemblyDefinition { get; set; }
			public IMemberDefinition member { get; set; }
		}
		
		public Assembles()
		{
			InitializeComponent();
		}
		
		public void setConnection(SqlConnection con, Login.ConnectInfo info)
		{
			this.conn = con;
			this.info = info;
			this.Text = string.Format("MSSQL {0}.{1} ({2}) ver {3}", info.Server, conn.Database, info.Login, info.Version);
		}	
		
		private void ExecQuery(SqlConnection con, TreeNode root, BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e){
        	var pars = new ReaderParameters();
        	AssemblyDefinition _assemblyDefinition = Mono.Cecil.AssemblyDefinition.ReadAssembly(new MemoryStream((root.Tag as SqlBytes).Value), pars);        	
        	
        	NodeInfo nodeInfo = null;
        	
			foreach (var typeInAssembly in _assemblyDefinition.MainModule.Types)
                    {
                        //if (typeInAssembly.IsPublic)
                       // {
        					nodeInfo = new NodeInfo();
	       					nodeInfo._assemblyDefinition=_assemblyDefinition;                        	
                            nodeInfo.member = typeInAssembly;
                            
                            var node = new TreeNode(typeInAssembly.FullName);
                            node.Tag=nodeInfo;
                            node.ImageIndex = 0;
                            node.SelectedImageIndex = 0;
                            
                            foreach (var item in typeInAssembly.Methods)
                            {
	               				nodeInfo = new NodeInfo();
		       					nodeInfo._assemblyDefinition=_assemblyDefinition;                        	
	                            nodeInfo.member = item;
                            
                                var mNode = new TreeNode(item.Name);
                            	mNode.Tag=nodeInfo;                                
                                mNode.ImageIndex = 2;
                                mNode.SelectedImageIndex = 2;
                                node.Nodes.Add(mNode);
                            }

                            foreach (var item in typeInAssembly.Properties)
                            {
	               				nodeInfo = new NodeInfo();
		       					nodeInfo._assemblyDefinition=_assemblyDefinition;                        	
	                            nodeInfo.member = item;
	                            
                                var mNode = new TreeNode(item.Name);
                            	mNode.Tag=nodeInfo;  
                                mNode.ImageIndex = 3;
                                mNode.SelectedImageIndex = 3;
                                node.Nodes.Add(mNode);
                            }

                            foreach (var item in typeInAssembly.Fields)
                            {
	               				nodeInfo = new NodeInfo();
		       					nodeInfo._assemblyDefinition=_assemblyDefinition;                        	
	                            nodeInfo.member = item;                            	
                            	
                                var mNode = new TreeNode(item.Name);
                                mNode.Tag=nodeInfo;  
                                mNode.ImageIndex = 1;
                                mNode.SelectedImageIndex = 1;
                                node.Nodes.Add(mNode);
                            }

                            root.Nodes.Add(node);

                        //}
                    }        	
		}
		
		private void ExecQueryRoot(SqlConnection con, BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e){
			var sql=@"
			SELECT 
			af.name,
			af.content 
			FROM sys.assemblies a
			INNER JOIN sys.assembly_files af ON a.assembly_id = af.assembly_id 
			";
			
			try {
				SqlCommand command = new SqlCommand(sql, con);
				lastCommand = command;
				using (SqlDataReader reader = command.ExecuteReader()) {
					this.Invoke((MethodInvoker)delegate {
					    while (reader.Read()){
					            		
							//запросили останов - прерываемся
							if (worker.CancellationPending)	{
								break;
							}					            		
						            		
							var name = reader.GetSqlString(0).ToString();
							SqlBytes content = reader.GetSqlBytes(1);
							
							
							var node = tvList.Nodes.Add(name);
							node.Name=name;
							node.Tag=content;
							
							try{
								ExecQuery(con, node, worker, e);						
							}catch {}
						}
					});	
				}
			} catch {}
			
			this.Invoke((MethodInvoker)delegate {
				EndScan();
			});
		}		
		
		void BackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			ExecQueryRoot(conn, worker, e);
		}
		
		void BackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			btnGetTree.Text="Получить список";
		}			

		private void StartScan()
		{
			
			if (backgroundWorker.IsBusy != true)
            {
				btnGetTree.Text="Остановить";
				
				tvList.Nodes.Clear();
				
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
		
		void BtnGetTreeClick(object sender, EventArgs e)
		{
			if (!backgroundWorker.IsBusy)
				StartScan();
			else
				EndScan();
		}
		
		void TvListAfterSelect(object sender, TreeViewEventArgs e)
		{
	
			try{
				NodeInfo nodeInfo = (e.Node.Tag as NodeInfo);
				var decompiler = new CSharpDecompiler(nodeInfo._assemblyDefinition.MainModule, new DecompilerSettings());
	
	            var str = decompiler.DecompileAsString(nodeInfo.member);
	
	            tbSQLText.Text = str;
			}catch (Exception ex) {
				tbSQLText.Text = ex.Message;
				if (ex.InnerException!=null)
					tbSQLText.Text +=ex.InnerException.ToString();
			}
			
		}
	}
}
