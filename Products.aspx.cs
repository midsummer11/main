using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowProducts();
                GetCategories();
                GetManufactors();
            }
        }
        private void ShowProducts()
        {
            string Query = "SELECT * FROM ProductTb1";
            ProductList.DataSource = Con.GetData(Query);
            ProductList.DataBind();
            ProductList.HeaderRow.Cells[1].Text = "序号";
            ProductList.HeaderRow.Cells[2].Text = "商品名称";
            ProductList.HeaderRow.Cells[3].Text = "生产商";
            ProductList.HeaderRow.Cells[4].Text = "商品类目";
            ProductList.HeaderRow.Cells[5].Text = "库存总量";
            ProductList.HeaderRow.Cells[6].Text = "商品价格";
        }
        private void GetCategories()
        {
            string Query = "SELECT * FROM CategoryTb1";
            PCatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();  //CatName 字段用于显示文本 
            PCatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();   //CatId 字段用于存储值
            PCatCb.DataSource = Con.GetData(Query);
            PCatCb.DataBind();                  //绑定数据源
        }
        private void GetManufactors()
        {
            string Query = "SELECT * FROM ManufactorTb1";
            PManufactCb.DataTextField = Con.GetData(Query).Columns["ManufactName"].ToString();
            PManufactCb.DataValueField = Con.GetData(Query).Columns["ManufactId"].ToString();
            PManufactCb.DataSource = Con.GetData(Query);
            PManufactCb.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || PManufactCb.SelectedIndex == -1 || PCatCb.SelectedIndex == -1 || PriceTb.Value == "" || Qty.Value == "")       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    string PCat = PCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(Qty.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = "INSERT INTO ProductTb1 VALUES('{0}',{1},{2},{3},{4})";
                    Query = string.Format(Query, PName, PManufact, PCat, Quantity, Price);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "商品信息添加成功！";
                    PNameTb.Value = "";
                    PManufactCb.SelectedIndex = -1;
                    PCatCb.SelectedIndex = -1;
                    PriceTb.Value = "";
                    Qty.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
        int key = 0;
        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNameTb.Value = ProductList.SelectedRow.Cells[2].Text;
            PManufactCb.SelectedValue = ProductList.SelectedRow.Cells[3].Text;
            PCatCb.SelectedValue = ProductList.SelectedRow.Cells[4].Text;
            Qty.Value = ProductList.SelectedRow.Cells[5].Text;
            PriceTb.Value = ProductList.SelectedRow.Cells[6].Text;

            if (PNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || PManufactCb.SelectedIndex == -1 || PCatCb.SelectedIndex == -1 || PriceTb.Value == "" || Qty.Value == "")       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    string PCat = PCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(Qty.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = "UPDATE ProductTb1 SET PName='{0}',PManufact={1},PCategory={2},PQty={3},PPrice={4} WHERE Pid={5}";
                    Query = string.Format(Query, PName, PManufact, PCat, Quantity, Price, ProductList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "商品信息修改成功！";
                    PNameTb.Value = "";
                    PManufactCb.SelectedIndex = -1;
                    PCatCb.SelectedIndex = -1;
                    PriceTb.Value = "";
                    Qty.Value = "";
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
                if (PNameTb.Value == "" || PManufactCb.SelectedIndex == -1 || PCatCb.SelectedIndex == -1 || PriceTb.Value == "" || Qty.Value == "")       //未输入值
                {
                    ErrMsg.Text = "请选择一行数据！";
                }
                else
                {
                    string PName = PNameTb.Value;
                    string PManufact = PManufactCb.SelectedValue.ToString();
                    string PCat = PCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(Qty.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = "DELETE FROM ProductTb1 WHERE Pid={0}";
                    Query = string.Format(Query, ProductList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "商品信息删除成功！";
                    PNameTb.Value = "";
                    PManufactCb.SelectedIndex = -1;
                    PCatCb.SelectedIndex = -1;
                    PriceTb.Value = "";
                    Qty.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}