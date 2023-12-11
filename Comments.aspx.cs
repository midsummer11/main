using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Customers
{
    public partial class Comments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 初始化评价列表
                Session["Comments"] = new List<string>();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //从 Session 中获取名为 "Comments" 的对象--List<string>
            //使用 Add 方法将新的评论txtComment.Text添加到评论列表中。
            var comments = Session["Comments"] as List<string>;
            comments.Add(txtComment.Text);
            //使用评论列表作为数据源，将评论列表绑定到 GridView
            CommentList.DataSource = comments;
            CommentList.DataBind();
            CommentList.HeaderRow.Cells[0].Text = "我的评价";
        }
    }
}