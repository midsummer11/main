<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customers/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="OnlineSupermarketTuto.Views.Customers.Comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
	/*用户评价样式*/
	ul#user_evaluate li{ 
		border-top: 2px dashed #eee;
		padding: 30px 0;
		list-style:none 
	}
	li.evaluate_li span{
		display: inline-block;
		vertical-align: top;
	}
	li.evaluate_li span.img img{
		width: 50px;
		height:50px;
		border-radius: 50%;
		margin-right:30px
	}
	li.evaluate_li span.info{
		width: 675px;
		display: inline-block;
		vertical-align: top;
	}
	li.evaluate_li span.info h4{
		font-size: 12px;
		color: #999;
	}
	li.evaluate_li span.info p.time{
		font-size: 12px;
		color: #999;
	}
	li.evaluate_li span.info div.reply_info{
		margin-top: 15px;
		padding: 15px;
		background: #f8f8f8;
		font-size: 12px;
		color: #999;
	}
	/*分页点击操作*/
	div.switch-tag-wrap {
		text-align:right;
	}
	div.js-switch{
		color: #999;
		display: inline-block;
		font-size: 14px;
		width: 60px;
		text-align: center;
		cursor: pointer;
		margin-right: 20px;
	}
	div.js-switch:hover{
		color:red;
	}
	div.switch-tag-wrap div.fr{
		float:right;
	}
	/*评价选择*/
	p.switch-head-line span.mr{
		cursor: pointer;
		margin-right: 60px;
	}
	.chooseActive{
		color: red;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="row">
        <div class="col">
            <h3 class="text-center" style="color:#5E5B7A">商品评价</h3>
        </div>
		<div class="art-content">
			<!-- 评价选择 -->
			<p class="switch-head-line">
				<label style="width: 80px;color: #999;">排序：</label>
				<span class="mr chooseActive" eval_data='1' onclick="chooseEval(this)">好评(6)</span>
				<span class="mr" eval_data='2' onclick="chooseEval(this)">中评(0)</span>
				<span class="mr" eval_data='3' onclick="chooseEval(this)">差评(1)</span>
			</p>
			<!-- 评价选择 -->
			
			<ul id="user_evaluate">
				<li class="evaluate_li">					
					<span class="info">
						<h4>某某用户</h4>
						<p>牛奶很好喝</p>
						<p class="time">2019-04-28</p>
						<div class="reply_info"> 回复：谢谢。 </div><br />
					</span>
					<span class="info">
				        <h4>某某用户2</h4>
				        <p>可乐很好喝</p>
				        <p class="time">2019-04-29</p>
				        <div class="reply_info"> 回复：谢谢。 </div><br />
                    </span>
					<span class="info">
                        <h4>某某用户2</h4>
                        <p>纸巾不好用</p>
                        <p class="time">2019-05-02</p>
                        <div class="reply_info"> 回复：不好意思。 </div><br />
                    </span>
				</li>
			</ul>
		</div>
	    <div>
			<asp:GridView ID="CommentList" runat="server" class="table" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#C7D1EB"></AlternatingRowStyle>

                <FooterStyle BackColor="#FDE3D4" ForeColor="Black"></FooterStyle>

                <HeaderStyle BackColor="#8698C2" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#FDE3D4" ForeColor="Black"></PagerStyle>

                <RowStyle BackColor="#FFF9EB" ForeColor="Black"></RowStyle>

                <SelectedRowStyle BackColor="#90B9DD" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
             </asp:GridView>
			<asp:TextBox ID="txtComment" runat="server" CssClass="form-control"></asp:TextBox><br />
			
            <asp:Button Text="提交评价" runat="server" CssClass="btn btn-block" BackColor="#AFBBD3" ForeColor="White" ID="btnSubmit" OnClick="btnSubmit_Click" Width="200" Font-Bold="True"/>
            
	    </div>
    </div>
</asp:Content>
