using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Customers
{
    public partial class Register : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (UNameTb0.Value == "" || EmailTb.Value == "" || TelTb.Value == "" || PasswordTb.Value == "" || PasswordTb2.Value == "")       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string UName = UNameTb0.Value;
                    string Email = EmailTb.Value;
                    string Tel = TelTb.Value;
                    string Password = PasswordTb.Value;
                    string Password2 = PasswordTb2.Value;
                    if (Password == Password2)
                    {
                        string Query = "INSERT INTO CustomerTb1 VALUES('{0}','{1}','{2}','{3}')";
                        Query = string.Format(Query, UName, Email, Tel, Password);
                        Con.SetData(Query);
                        ErrMsg.Text = "注册成功！";
                    }
                    else
                    {
                        ErrMsg.Text = "密码不一致！";
                    }                
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}


