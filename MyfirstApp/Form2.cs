using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyfirstApp
{
    public partial class Form2 : Form
    {

        MySqlDataAdapter mysqlAdapter = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        private static string _connectionString = string.Format("server={0};Port={1};User Id={2};database={3};password={4};Charset=utf8",
                         "192.168.71.134", 3306, "root", "mall", "root");
        public Form2()
        {
            string sqlString = string.Format("select count(*) from {0}", "pms_brand");
          
            //使用using，相当于使用了try{}finally{using括号的对象的Dispose(即释放对象)}
            System.Console.WriteLine("query1:"+ExcuteSQL(sqlString, 1));
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            string sqlString = string.Format("select  * from {0}", "pms_brand");
            //使用using，相当于使用了try{}finally{using括号的对象的Dispose(即释放对象)}
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    //MySqlDataAdapter获取数据库，可以断Connection
                    mysqlAdapter.SelectCommand = new MySqlCommand(sqlString, connection);
                    //MySqlDataAdapter填充到DataTable，即dt获取数据库所有的行
                    mysqlAdapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        //输出表的name列的值
                        System.Console.WriteLine(Convert.ToString(row["name"]));
                    }

                }
                catch (MySqlException)
                {
                    MessageBox.Show("数据库读取失败，本数据库的设置是：\n" +
              "server=localhost;Port=3306;User Id=root;database=test;password=root;Charset=utf8");
                }
            
            }
        }

        public int ExcuteSQL(string sqlString, int flag)
        {
            int n;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                //第二种操作数据库的方式是使用MySqlCommand。第一种是使用了MysqlDataAdapter来操作。
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 0;
                        cmd.CommandText = sqlString;
                        connection.Open();
                        //flag=0表示增删改的操作，否则就是查询。语句是不一样的，你们可以查ExecuteNonQuery()和ExecuteScalar()的不同
                        if (flag == 0)
                            n = Convert.ToInt32(cmd.ExecuteNonQuery());
                        else
                            n = Convert.ToInt32(cmd.ExecuteScalar());
                        return n;
                    }
                    catch (MySqlException)
                    {
                        MessageBox.Show("数据库读取失败，本数据库的设置是：\n" +
                "server=localhost;Port=3306;User Id=root;database=test;password=root;Charset=utf8");
                        return 0;
                    }
                }
            }
        }

    }
}
