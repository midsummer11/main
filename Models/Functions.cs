using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineSupermarketTuto.Models
{    
    public class Functions
    {
        private SqlConnection Con;         //表示与数据库的连接
        private SqlCommand Command;        //用于执行SQL命令
        private DataTable dt;              //存储数据库的结果集
        private SqlDataAdapter sda;        //适配器
        private string ConStr;             //存储数据库连接的字符串
        public Functions() {
            ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\l0033\\Documents\\SupermarketDb.mdf;Integrated Security=True;Connect Timeout=30";    //数据库连接字符串
            Con = new SqlConnection(ConStr);    //创建与数据库的连接对象 Con
            Command = new SqlCommand();
            Command.Connection = Con;          //对Con执行 SQL 命令
        }
        //使用 SqlDataAdapter 从数据库中检索数据并将其填充到 DataTable 中
        public DataTable GetData(string Query)
        {
            DataTable dt = new DataTable();        //实例化一个 DataTable 对象，用于存储从数据库检索的数据
            sda = new SqlDataAdapter(Query,ConStr);  //Query:要执行的 SQL 查询语句
            sda.Fill(dt);             //填充到 DataTable 对象中
            return dt;               //将填充好数据的 DataTable 对象
        }
        //执行非查询的 SQL 命令，并返回受影响的行数
        public int SetData(string Query)
        {
            int cnt = 0;    //存储受影响的行数
            if (Con.State == ConnectionState.Closed)     //检查数据库连接状态是否关闭
            {
                Con.Open();                             //如果关了则打开
            }
            Command.CommandText = Query;               //将 SQL 命令文本设置为传入的 Query  Query：非查询 SQL 语句。
            cnt = Command.ExecuteNonQuery();           //执行非查询 SQL 命令,返回受影响的行数
            Con.Close();                          //关闭数据库连接
            return cnt;                            //将受影响的行数返回
        }
    }
}