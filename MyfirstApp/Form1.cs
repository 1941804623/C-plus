using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace MyfirstApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Console.WriteLine("Form1_Load");
            Type type = typeof(EventArgs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Selected_Path = "";
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Selected_Path = openFileDialog.SelectedPath;
                textBox1.Text = Selected_Path;  //文件路径
                // 创建一个 DirectoryInfo 对象
                DirectoryInfo mydir = new DirectoryInfo(Selected_Path);

                // 获取目录中的文件以及它们的名称和大小
                FileInfo[] f = mydir.GetFiles();
                foreach (FileInfo file in f)
                {
                    Console.WriteLine("File Name: {0} Size: {1}",
                                        file.Name, file.Length);
                }


                // Excel文件路径  
                string filePath = @"D:\file" + DateTime.Now.ToString("HHmmss") +  ".xlsx";

                // 使用FileInfo类打开文件（如果文件不存在，EPPlus会创建它）  
                FileInfo excelFile = new FileInfo(filePath );
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // 使用EPPlus的ExcelPackage类来操作Excel文件  
                using (ExcelPackage package = new ExcelPackage(excelFile))
                {
                    // 获取第一个工作表（或者添加一个新工作表）  
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    foreach (FileInfo file in f)
                    {
                        Console.WriteLine("File Name: {0} Size: {1}",
                                            file.Name, file.Length);
                    }

                    // 遍历List中的每一行数据  
                    for (int row = 0; row < f.Length; row++)
                    {
                        // 获取当前行的数据  
                        string data = f[row].Name;

                        // 将数据写入Excel单元格中  
                        worksheet.Cells[row + 1,  1].Value = data; // 注意索引是从1开始的，不是从0  
                    }

                    // 保存Excel文件  
                    package.Save();
                }
            }

        }
    }
}
