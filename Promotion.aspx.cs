using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace OnlineSupermarketTuto.Views.Admin
{
    public partial class Promotion : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowPromotion();
        }
        private void ShowPromotion()
        {           
            string Query = "SELECT PromotionID,PId,Title, Description, StartDate, EndDate FROM PromotionTb1";
            PromotionList.DataSource = Con.GetData(Query);
            PromotionList.DataBind();
            PromotionList.HeaderRow.Cells[1].Text = "活动序号";
            PromotionList.HeaderRow.Cells[2].Text = "相关商品";
            PromotionList.HeaderRow.Cells[3].Text = "活动标题";
            PromotionList.HeaderRow.Cells[4].Text = "活动描述";
            PromotionList.HeaderRow.Cells[5].Text = "开始时间";
            PromotionList.HeaderRow.Cells[6].Text = "结束时间";


        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PIdTb.Value == "" || PtitleTb.Value == "" || PDescTb.Value == "" || PStartTb.Value == "" || PEndTb.Value == "")       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string PId = PIdTb.Value;
                    string Ptitle = PtitleTb.Value;
                    string PDesc = PDescTb.Value;
                    string PStart = PStartTb.Value;
                    string PEnd = PEndTb.Value;
                    
                    string Query = "INSERT INTO PromotionTb1(PId,Title, Description, StartDate, EndDate) VALUES({0},'{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query,PId, Ptitle, PDesc, PStart, PEnd);
                    Con.SetData(Query);
                    ShowPromotion();
                    ErrMsg.Text = "活动信息添加成功！";
                    PIdTb.Value = "";
                    PtitleTb.Value = "";
                    PDescTb.Value = "";
                    PStartTb.Value = "";
                    PEndTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
        int key = 0;
        protected void PromotionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PIdTb.Value = PromotionList.SelectedRow.Cells[2].Text;
            PtitleTb.Value = PromotionList.SelectedRow.Cells[3].Text;
            PDescTb.Value = PromotionList.SelectedRow.Cells[4].Text;
            PStartTb.Value = PromotionList.SelectedRow.Cells[5].Text;
            PEndTb.Value = PromotionList.SelectedRow.Cells[6].Text;
            if (PIdTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PromotionList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PIdTb.Value == "" || PtitleTb.Value == "" || PDescTb.Value == "" || PStartTb.Value == "" || PEndTb.Value == "")       //未输入值
                {
                    ErrMsg.Text = "信息缺失";
                }
                else
                {
                    string PId = PIdTb.Value;
                    string Ptitle = PtitleTb.Value;
                    string PDesc = PDescTb.Value;
                    string PStart = PStartTb.Value;
                    string PEnd = PEndTb.Value;

                    string Query = "UPDATE PromotionTb1 SET PId= {0},Title = '{1}',Description = '{2}',StartDate = '{3}',EndDate='{4}' WHERE PromotionID = {5}";
                    Query = string.Format(Query, PId, Ptitle, PDesc, PStart, PEnd, PromotionList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowPromotion();
                    ErrMsg.Text = "活动信息修改成功！";
                    PIdTb.Value = "";
                    PtitleTb.Value = "";
                    PDescTb.Value = "";
                    PStartTb.Value = "";
                    PEndTb.Value = "";
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
                if (PIdTb.Value == "" || PtitleTb.Value == "" || PDescTb.Value == "" || PStartTb.Value == "" || PEndTb.Value == "")       //未输入值
                {
                    ErrMsg.Text = "请选择一行数据！";
                }
                else
                {
                    string PId = PIdTb.Value;
                    string Ptitle = PtitleTb.Value;
                    string PDesc = PDescTb.Value;
                    string PStart = PStartTb.Value;
                    string PEnd = PEndTb.Value;

                    string Query = "DELETE FROM PromotionTb1 WHERE PromotionID = {0}";
                    Query = string.Format(Query, PromotionList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowPromotion();
                    ErrMsg.Text = "活动信息删除成功！";
                    PIdTb.Value = "";
                    PtitleTb.Value = "";
                    PDescTb.Value = "";
                    PStartTb.Value = "";
                    PEndTb.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
    }
}