using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Customers
{
    public partial class Communicate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 初始化问题列表
                Session["Messages"] = new List<string>();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //从 Session 中获取名为 "CMessages" 的对象--List<string>
            //使用 Add 方法将新的问题添加到问题列表中。
            var messages = Session["Messages"] as List<string>;
            messages.Add(txtMessage.Text); 

            // 添加客服回复逻辑
            string botReply = GenerateBotReply(txtMessage.Text);
            messages.Add("客服回复: " + botReply);
            //使用问题列表作为数据源，将问题列表绑定到 GridView
            lvMessages.DataSource = messages;
            lvMessages.DataBind();
        }
        private string GenerateBotReply(string userMessage)
        {
            if (txtMessage.Text == Button1.Text)
            {
                return "我是客服机器人，您可以点击左侧导航栏中的订单结算进行商品选购";
            }
            else if (txtMessage.Text == Button2.Text)
            {
                return "我是客服机器人，一般1-2个小时即可送到";
            }
            else if(txtMessage.Text == Button3.Text)
            {
                return "我是客服机器人，您可以点击左侧导航栏中的商品评价查看评价或提交评价";
            }
            else
            {
                return "我是客服机器人，不好意思这个问题我不太清楚";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtMessage.Text= Button1.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtMessage.Text = Button2.Text;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            txtMessage.Text = Button3.Text;
        }
    }
}