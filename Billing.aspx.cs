using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineSupermarketTuto.Views.Customers
{
    public partial class Billing : System.Web.UI.Page
    {
        Models.Functions Con;     
        int customer = Login.User;     //id      
        string CName = Login.UName;     //用户名
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions(); //创建一个类的实例来执行数据库操作
            //仅在初次加载时执行
            if (!IsPostBack)
            {
                ShowProducts();            
                //创建存储账单信息的表结构
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("序号"),
                    new DataColumn("商品名称"),
                    new DataColumn("价格"),
                    new DataColumn("数量"),
                    new DataColumn("总计")
                });
                //使用 ViewState 将刚刚创建的 DataTable 存储在页面的状态中。ViewState 可以在页面回发时保留一些数据，以便在页面上的不同请求之间保持状态。
                ViewState["账单"] = dt;
                this.BindGrid();                
            }
        }
        //将 DataTable 中的数据绑定到GridView上
        protected void BindGrid()
        {
            ShoppingCartList.DataSource = ViewState["账单"];
            ShoppingCartList.DataBind();
        }
        private void ShowProducts()
        {
            string Query = "SELECT Pid,PName,PPrice,PQty FROM ProductTb1";
            ProductList.DataSource = Con.GetData(Query);
            ProductList.DataBind();
            ProductList.HeaderRow.Cells[1].Text = "序号";
            ProductList.HeaderRow.Cells[2].Text = "商品名称";
            ProductList.HeaderRow.Cells[4].Text = "库存总量";
            ProductList.HeaderRow.Cells[3].Text = "商品价格";
        }
        int key = 0;
        int stock = 0;
        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PnameTb.Value = ProductList.SelectedRow.Cells[2].Text;
            PriceTb.Value = ProductList.SelectedRow.Cells[3].Text;
            stock = Convert.ToInt32(ProductList.SelectedRow.Cells[4].Text);

            if (PnameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductList.SelectedRow.Cells[1].Text);
            }
        }

        private void UpdateStock()
        {
            //购买后更新商品总量
            int NewQty;
            NewQty = Convert.ToInt32(ProductList.SelectedRow.Cells[4].Text)-Convert.ToInt32(QtyTb.Value);
            string Query = "UPDATE ProductTb1 SET PQty={0} WHERE Pid={1}";
            Query = string.Format(Query,NewQty, ProductList.SelectedRow.Cells[1].Text);
            Con.SetData(Query);
            ShowProducts();
        }

        private void InsertBill()
        {
            //向账单表中添加数据
            try
            {
                string Query = "INSERT INTO BillTb1 VALUES('{0}','{1}','{2}')";
                Query = string.Format(Query, DateTime.Today.Date.ToString(), customer, Convert.ToInt32(GrdTotalTb.Text));
                Con.SetData(Query);
            }
            catch(Exception Ex) { 
                Response.Write(Ex.Message);
            }
        }

        int GrdTotal = 0;
        int Amount;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            if (PnameTb.Value == "" || QtyTb.Value == "" || PriceTb.Value == "")
            {
                ErrMsg.Text = "请输入数据";
            }
            else
            {
                //计算商品的总价
                int total = Convert.ToInt32(QtyTb.Value) * Convert.ToInt32(PriceTb.Value);
                //从 ViewState 中获取之前存储的账单数据表，并将新的商品信息添加到该表中
                DataTable dt = (DataTable)ViewState["账单"];
                //Trim() 方法是用于去除字符串两端的空白字符
                dt.Rows.Add(ShoppingCartList.Rows.Count + 1,
                    PnameTb.Value.Trim(),
                    PriceTb.Value.Trim(),
                    QtyTb.Value.Trim(),
                    total);
                //将更新后的数据表重新存储到 ViewState 中
                ViewState["账单"] = dt;

                //将 DataTable 中的数据绑定到GridView上
                this.BindGrid();
                //购买后更新商品总量
                UpdateStock();
                //计算最后的总价
                GrdTotal = 0;
                for (int i = 0; i < ShoppingCartList.Rows.Count; i++)
                {
                    GrdTotal = GrdTotal + Convert.ToInt32(ShoppingCartList.Rows[i].Cells[4].Text);
                }
                Amount = GrdTotal;
                RMBLable.Text = "¥";
                //GrdTotalTb.Text = "¥" + GrdTotal;
                GrdTotalTb.Text = Convert.ToString(GrdTotal);
                PnameTb.Value = "";
                QtyTb.Value = "";
                PriceTb.Value = "";
            }            
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            InsertBill();
        }

        protected void btnSel_Click(object sender, EventArgs e)
        {
            this.gvbind();
        }
        public void gvbind()
        {
            if (txtKey.Text == "")
            {
                ShowProducts();
            }
            else
            {
                string sqlstr = "select Pid,PName,PPrice,PQty from ProductTb1 where " + ddlCondition.SelectedValue + " like '%" + txtKey.Text.Trim() + "%'";
                Con.SetData(sqlstr);
                ProductList.DataSource = Con.GetData(sqlstr);
                ProductList.DataBind();
                ProductList.HeaderRow.Cells[1].Text = "序号";
                ProductList.HeaderRow.Cells[2].Text = "商品名称";
                ProductList.HeaderRow.Cells[4].Text = "库存总量";
                ProductList.HeaderRow.Cells[3].Text = "商品价格";
            }
        }
    }
}