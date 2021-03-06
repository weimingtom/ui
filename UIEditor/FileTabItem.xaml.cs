﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace UIEditor
{
	/// <summary>
	/// FileTabItem.xaml 的交互逻辑
	/// </summary>
	public partial class FileTabItem : UserControl
	{
		public OpenedFile m_fileDef;
		public string m_filePath;
		public string m_fileType;
		public object m_child;

		public FileTabItem(OpenedFile fileDef, string skinName = "")
		{
			m_filePath = "";
			InitializeComponent();

			if (m_filePath == "")
			{
				UserControl tabContent;
				MainWindow parentWindow = Window.GetWindow(this) as MainWindow;

				m_fileDef = fileDef;
				m_filePath = fileDef.m_path;
				this.filePath.Text = m_filePath;

				m_fileType = StringDic.getFileType(m_filePath).ToLower();
				switch (m_fileType)
				{
					case "bmp":
					case "cut":
					case "dcx":
					case "dds":
					case "ico":
					case "gif":
					case "jpg":
					case "lbm":
					case "lif":
					case "mdl":
					case "pcd":
					case "pcx":
					case "pic":
					case "png":
					case "pnm":
					case "psd":
					case "psp":
					case "raw":
					case "sgi":
					case "tga":
					case "tif":
					case "wal":
					case "act":
					case "pal":
						{
							tabContent = new PngControl(this, fileDef);
							MainWindow.s_pW.showGLCtrl(false);
						}
						break;
					case "xml":
						{
							tabContent = new XmlControl(this, fileDef, skinName);
						}
						break;
					case "htm":
					case "html":
					case "php":
						{
							tabContent = new HtmlControl(this, fileDef);
						}
						break;
					case "bolos":
					case "txt":
						{
							tabContent = new BoloScript.TextControl(this, fileDef);
							MainWindow.s_pW.showGLCtrl(false);
						}
						break;
					default:
						{
							tabContent = new UnknownControl(this, fileDef);
							MainWindow.s_pW.showGLCtrl(false);
						}
						break;
				}
				this.itemFrame.Children.Clear();
				this.itemFrame.Children.Add(tabContent);
				m_child = tabContent;
			}
			mx_wsBckBrush.ImageSource = new BitmapImage(new Uri(@".\data\image\hyaline.png", UriKind.Relative));
		}

		public void closeFile(bool isForce = false)
		{
			TabItem tabItem = (TabItem)this.Parent;
			MainWindow pW = MainWindow.s_pW;
			XmlControl xmlCtrl = XmlControl.getCurXmlControl();

			if (isForce == false && m_fileDef != null && m_fileDef.haveDiffToFile())
			{
				MessageBoxResult ret = MessageBox.Show("是否将更改保存到 " + m_filePath, "保存确认", MessageBoxButton.YesNoCancel, MessageBoxImage.Asterisk);
				switch (ret)
				{
					case MessageBoxResult.Yes:
						{
							if(m_fileDef.m_frame != null && m_fileDef.m_frame is XmlControl)
							{
								((XmlControl)m_fileDef.m_frame).saveCurStatus();
							}
						}
						break;
					case MessageBoxResult.No:
						break;
					case MessageBoxResult.Cancel:
					default:
						return;
				}
			}
			pW.updateGL(m_filePath, W2GTag.W2G_NORMAL_NAME);
			pW.m_mapOpenedFiles.Remove(m_filePath);
			pW.mx_workTabs.Items.Remove(tabItem);
			if (pW.mx_workTabs.Items.Count == 0)
			{
				if (xmlCtrl != null)
				{
					pW.mx_treeCtrlFrame.Items.Remove(xmlCtrl.m_treeUI);
					pW.mx_treeSkinFrame.Items.Remove(xmlCtrl.m_treeSkin);
				}
				pW.mx_xmlText.Document = new FlowDocument();
			}
			XmlOperation.XmlAttr.AttrList.hiddenAllAttr();
		}
		private void closeFileTab(object sender, RoutedEventArgs e)
		{
			closeFile();
		}
	}
}
