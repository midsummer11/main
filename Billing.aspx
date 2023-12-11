<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customers/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="OnlineSupermarketTuto.Views.Customers.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintBill() {
            //获取ShoppingCartList 对应的客户端 HTML 元素
            var PGrid = document.getElementById('<%=ShoppingCartList.ClientID%>');
            PGrid.border= 0;
            var PWin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=768,tollbar=0,scrollbars=1,status=0,resizable=1');
            //将表格 PGrid 的 HTML 内容写入新打开的窗口
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            //将焦点设置到新打开的窗口，使打印对话框出现在新窗口上。
            PWin.focus();
            PWin.print();
            PWin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">

        </div>
        <div class="row">
            <div class="col-md-5">
                <h3 class="text-center" style="color:#5E5B7A">商品选购</h3>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <asp:Label ID="Label1" runat="server" Text="商品名称" CssClass="form-label" ForeColor="#805475"></asp:Label>
                            <input type="text" placeholder="" autocomplete="off" class="form-control " id="PnameTb" runat="server"/>
                        </div> 
                    </div>
                     <div class="col">
                        <div class="mt-3">
                            <asp:Label ID="Label2" runat="server" Text="价格" CssClass="form-label" ForeColor="#805475"></asp:Label>
                            <input type="text" placeholder="" autocomplete="off" class="form-control " id="PriceTb" runat="server"/>
                        </div> 
                     </div>
                     <div class="col">
                        <div class="mt-3">
                            <asp:Label ID="Label3" runat="server" Text="数量" CssClass="form-label" ForeColor="#805475"></asp:Label>
                            <input type="text" placeholder="" autocomplete="off" class="form-control " id="QtyTb" runat="server"/>
                        </div> 
                     </div>
                    <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger text-center"></asp:Label>
                    <div class="row mt-4 mb-5" >
                        <div class="col d-grid" align="center">
                            <asp:Button Text="加入购物车" runat="server" CssClass="btn btn-block" BackColor="#F4BDC9" ForeColor="#5E5B7A" ID="AddToBillBtn" OnClick="AddToBillBtn_Click" Width="495px" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="Label4" runat="server" Text="查询条件：" Width="105px" ForeColor="#805475"></asp:Label>
                      <asp:DropDownList ID="ddlCondition" runat="server" Width="150px" ForeColor="#805475" Height="24px">
                           <asp:ListItem Value="Pid">序号</asp:ListItem>
                           <asp:ListItem Value="PName">商品名称</asp:ListItem>
                           <asp:ListItem Value="PPrice">商品价格</asp:ListItem>
                        </asp:DropDownList>
                    <asp:Label ID="Label5" runat="server" Text="关键字：" Width="90px" ForeColor="#805475"></asp:Label>
                    <asp:TextBox ID="txtKey" runat="server" Width="90px" Height="24px" ForeColor="#805475" class="form-control"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Button ID="btnSel" runat="server" Height="24px" Width="60px" ForeColor="#5E5B7A" BackColor="#F4BDC9" Text="查询" BorderWidth="0" OnClick="btnSel_Click" /><br /><br />
                    <h4 class="text-center" style="color:#5E5B7A">商品列表</h4>
                    <div class="col">
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
            <div class="col-md-7">
                    <h4 class="text-center" style="color:#5E5B7A">购物车</h4>
                        <div class="col">
                            <asp:GridView ID="ShoppingCartList" runat="server" class="table" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
                                <AlternatingRowStyle BackColor="#C7D1EB"></AlternatingRowStyle>

                                <FooterStyle BackColor="#FDE3D4" ForeColor="Black"></FooterStyle>

                                <HeaderStyle BackColor="#8698C2" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Center" BackColor="#FDE3D4" ForeColor="Black"></PagerStyle>

                                <RowStyle BackColor="#FFF9EB" ForeColor="Black"></RowStyle>

                                <SelectedRowStyle BackColor="#90B9DD" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                            </asp:GridView>
                       </div>

                <div class="row">
                    <div class="row">
                        <div class="col-md-5">

                        </div>
                        <div class="col-md-1">
                             <asp:Label ID="RMBLable" runat="server" CssClass="text-danger text-center"></asp:Label>
                        </div>
                        <div class="col-md-6">
                             <asp:Label ID="GrdTotalTb" runat="server" CssClass="text-danger text-center"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                         <asp:Button Text="结算" runat="server" CssClass="btn btn-block" BackColor="#AFBBD3" ForeColor="White" ID="PrintBtn" OnClick="PrintBtn_Click" OnClientClick="PrintBill()"/>
                    </div>                                                        
                </div>
            </div>  
       </div>     
    </div>
</asp:Content>
