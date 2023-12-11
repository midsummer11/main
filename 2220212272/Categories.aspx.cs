using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;     //创建一个类的实例来执行数据库操作
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            string Query = "SELECT * FROM CategoryTb1";
            CategoryList.DataSource = Con.GetData(Query);        //获取数据源
            CategoryList.DataBind();       //将数据绑定到GridView中
            CategoryList.HeaderRow.Cells[1].Text = "类目号";
            CategoryList.HeaderRow.Cells[2].Text = "商品类目名称";
            CategoryList.HeaderRow.Cells[3].Text = "详细信息";
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string CName = CatNameTb.Value;       
                    string CDesc = DescriptionTb.Value;

                    string Query = "INSERT INTO CategoryTb1 VALUES('{0}','{1}')";         //{0} 和 {1} 是占位符，将在后面的代码中被实际的值替代。
                    Query = string.Format(Query, CName, CDesc);   //将占位符 {0} 和 {1} 替换为实际的值 CName 和 CDesc，从而得到完整的 SQL 插入语句
                    Con.SetData(Query);       //执行插入操作
                    ShowCategories();          //显示数据  
                    ErrMsg.Text = "商品类目信息添加成功！";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
        int key = 0;
        protected void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatNameTb.Value = CategoryList.SelectedRow.Cells[2].Text;
            DescriptionTb.Value = CategoryList.SelectedRow.Cells[3].Text;
            if (CatNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoryList.SelectedRow.Cells[1].Text);  //获取类目号并转换为整数
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = "UPDATE CategoryTb1 SET CatName = '{0}',CatDescription = '{1}' WHERE CatId = {2}";
                    Query = string.Format(Query, CName, CDesc, CategoryList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "商品类目信息修改成功！";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DescriptionTb.Value == "")       //未输入值
                {
                    ErrMsg.Text = "请选择一行数据！";
                }
                else
                {
                    string CName = CatNameTb.Value;
                    string CDesc = DescriptionTb.Value;

                    string Query = "DELETE FROM CategoryTb1 WHERE CatId = {0}";
                    Query = string.Format(Query, CategoryList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "商品类目信息删除成功！";
                    CatNameTb.Value = "";
                    DescriptionTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}