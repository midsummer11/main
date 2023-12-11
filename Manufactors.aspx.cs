using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSupermarketTuto.Views.Admin
{
    public partial class Suppliers : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowManufactors();
        }
        private void ShowManufactors()
        {
            string Query = "SELECT * FROM ManufactorTb1";
            ManufactList.DataSource = Con.GetData(Query);
            ManufactList.DataBind();
            ManufactList.HeaderRow.Cells[1].Text = "序号";
            ManufactList.HeaderRow.Cells[2].Text = "生产商名称";
            ManufactList.HeaderRow.Cells[3].Text = "生产许可证号";
            ManufactList.HeaderRow.Cells[4].Text = "产地";
        }     
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "INSERT INTO ManufactorTb1 VALUES('{0}','{1}','{2}')";
                    Query = string.Format(Query, MName, PermNum, Place);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "生产商信息添加成功！";
                    MNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void ManufactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MNameTb.Value = ManufactList.SelectedRow.Cells[2].Text;
            PermNumTb.Value = ManufactList.SelectedRow.Cells[3].Text;
            PlaceCb.SelectedItem.Value = ManufactList.SelectedRow.Cells[4].Text;
            if (MNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ManufactList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "UPDATE ManufactorTb1 SET ManufactName = '{0}',ManufactPermNum = '{1}',ManufactPlace = '{2}' WHERE ManufactId = {3}";
                    Query = string.Format(Query, MName, PermNum, Place, ManufactList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "生产商信息修改成功！";
                    MNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;
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
                if (MNameTb.Value == "" || PermNumTb.Value == "" || PlaceCb.SelectedIndex == -1)       //未输入值
                {
                    ErrMsg.Text = "请选择一行数据！";
                }
                else
                {
                    string MName = MNameTb.Value;
                    string PermNum = PermNumTb.Value;
                    string Place = PlaceCb.SelectedItem.ToString();

                    string Query = "DELETE FROM ManufactorTb1 WHERE ManufactId = {0}";
                    Query = string.Format(Query, ManufactList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManufactors();
                    ErrMsg.Text = "生产商信息删除成功！";
                    MNameTb.Value = "";
                    PermNumTb.Value = "";
                    PlaceCb.SelectedIndex = -1;
                }


            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}