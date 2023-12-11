using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace OnlineSupermarketTuto
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions(); ////创建一个类的实例来执行数据库操作
        }
        public static string UName = "";
        public static int User;
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb0.Value == "" || PassswordTb.Value == "")
            {
                ErrMsg.Text = "请输入用户名和密码！";
            }
            else if (UNameTb0.Value == "admin" && PassswordTb.Value == "123456")
            {
                Response.Redirect("~/Views/Admin/Products.aspx");
            }
            else
            {
                string Query = "SELECT * FROM CustomerTb1 WHERE CustName='{0}' AND CustPass='{1}' ";
                Query = string.Format(Query, UNameTb0.Value, PassswordTb.Value);    //构建SQL查询字符串，从用户表中检索相应的用户名和密码的记录。
                DataTable dt = Con.GetData(Query); //执行查询并将结果存储在 DataTable 中
                if (dt.Rows.Count == 0)   //通过检查 DataTable 中的行数来判断是否找到了匹配的记录
                {
                    ErrMsg.Text = "用户名或密码错误";
                }
                else
                {
                    //将用户名存储在 UName 变量中，将用户id存储在 User 变量中，并将用户重定向到 Billing.aspx 页面。
                    UName = UNameTb0.Value;
                    User = Convert.ToInt32(dt.Rows[0][0].ToString()); 
                    Response.Redirect("~/Views/Customers/Billing.aspx");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Customers/Register.aspx");
        }
    }
}

