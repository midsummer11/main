<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="OnlineSupermarketTuto.Views.Admin.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">商品管理</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label" style="color:#805475">商品名称</label>
                    <input type="text" placeholder="" autocomplete="off" class="form-control " runat="server" id="PNameTb"/>
                </div>
                <div class="mb-3">
                    <label for="" class="form-label" style="color:#805475">生产商名称</label>
                    <asp:DropDownList ID="PManufactCb" runat="server" CssClass="form-control"></asp:DropDownList> 
                </div>
                <div class="mb-3">
                    <label for="" class="form-label" style="color:#805475">商品类目</label>
                    <asp:DropDownList ID="PCatCb" runat="server" CssClass="form-control"></asp:DropDownList>                    
                </div>
                <div class="mb-3">
                    <label for="" class="form-label" style="color:#805475">价格</label>
                    <input type="text" placeholder="" autocomplete="off" class="form-control " runat="server" id="PriceTb"/>
                </div>
                <div class="mb-3">
                    <label for="" class="form-label" style="color:#805475">数量</label>
                    <input type="text" placeholder="" autocomplete="off" class="form-control " runat="server" id="Qty"/>
                </div>
                <div class="row">
                    <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger text-center"></asp:Label>
                    <div class="col-md-4">
                        <asp:Button Text="编辑" runat="server" CssClass="btn btn-block" Width="100px" BackColor="#F4BDC9" ForeColor="White" ID="EditBtn" OnClick="EditBtn_Click" /></div>
                    <div class="col-md-4">
                        <asp:Button Text="保存" runat="server" CssClass="btn btn-block" Width="100px" BackColor="#D38BB1" ForeColor="White" ID="SaveBtn" OnClick="SaveBtn_Click" /></div>
                    <div class="col-md-4">
                        <asp:Button Text="删除" runat="server" CssClass="btn btn-block" Width="100px" BackColor="#D2BDC4" ForeColor="White" ID="DeleteBtn" OnClick="DeleteBtn_Click" /></div>
                </div>
            </div>
            <div class="col-md-8">               
                <asp:GridView ID="ProductList" runat="server" AutoGenerateSelectButton="True" class="table" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="ProductList_SelectedIndexChanged">
                       <AlternatingRowStyle BackColor="#f8d7da"></AlternatingRowStyle>

                       <FooterStyle BackColor="#FDE3D4" ForeColor="Black"></FooterStyle>

                       <HeaderStyle BackColor="#5E5B7A" Font-Bold="True" ForeColor="White"></HeaderStyle>

                       <PagerStyle HorizontalAlign="Center" BackColor="#FDE3D4" ForeColor="Black"></PagerStyle>

                       <RowStyle BackColor="#FFF9EB" ForeColor="Black"></RowStyle>

                       <SelectedRowStyle BackColor="#6E5F78" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                   </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content> 
