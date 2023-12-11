<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customers/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Communicate.aspx.cs" Inherits="OnlineSupermarketTuto.Views.Customers.Communicate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link rel="stylesheet" type="text/css" href="Site.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
     <div class="row">
         <div class="col">
             <h3 class="text-center" style="color:#5E5B7A">人工智能</h3>
         </div>
    </div>
    <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control"></asp:TextBox><br />
    <asp:Button Text="发送" runat="server" CssClass="btn btn-block" BackColor="#AFBBD3" ForeColor="White" ID="btnSend" OnClick="btnSend_Click" Width="200" Font-Bold="True"/><br /><br />
    <asp:ListView ID="lvMessages" runat="server">
        <ItemTemplate>
            <div class="listViewStyle"><%# Container.DataItem %></div>
        </ItemTemplate>
    </asp:ListView>
    <div class="row mt-2">
        <asp:Label ID="Label1" runat="server" Text="问题示例：" Font-Bold="True" ForeColor="#8698C2"></asp:Label>
        <div class="mt-1">
            <asp:Button ID="Button1" runat="server" Text="怎么购买呢" CssClass="btn btn-block" BackColor="#FFF9EB" ForeColor="Black" OnClick="Button1_Click" />
        </div>
        <div class="mt-1">
            <asp:Button ID="Button2" runat="server" Text="大概多久可以送到呢" CssClass="btn btn-block" BackColor="#FFF9EB" ForeColor="Black" OnClick="Button2_Click" />
        </div>
        <div class="mt-1">
            <asp:Button ID="Button3" runat="server" Text="如何查看评价" CssClass="btn btn-block" BackColor="#FFF9EB" ForeColor="Black" OnClick="Button3_Click" />
        </div>
        

    </div>
</asp:Content>
