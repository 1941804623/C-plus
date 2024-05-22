    using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyfirstApp
{

    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Hello World");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


    class HelloWorld
    {
        unsafe  static void Main1(string[] args)
        {
            /* 我的第一个 C# 程序*/
            Console.WriteLine("Hello World");
            int[] list = { 10, 100, 200 };
            fixed (int* ptr = list)

                /* 显示指针中数组地址 */
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Address of list[{0}]={1}", i, (int)(ptr + i));
                    Console.WriteLine("Value of list[{0}]={1}", i, (ptr + i)->ToString());
                }

        }
    }
}
