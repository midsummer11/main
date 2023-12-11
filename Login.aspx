<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineSupermarketTuto.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Assets/Lib/css/bootstrap.min.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="row mt-5 mb-5">

        </div>
        <div class="row">
            <div class="col-md-4">

            </div>
            <div class="col-md-4" >
                 <form id="form1" runat="server">
                     <div align="center">
                         <img src="Assets/Images/3514407.png" width="180" height="180" />
                     </div>
                   <div class="mt-4">
                       <asp:Label ID="Label1" runat="server" Text="用户名" ></asp:Label>
                       <input type="text" placeholder="" autocomplete="off" class="form-control " id="UNameTb0" runat="server"/>
                   </div> 
                   <div class="mt-3">
                       <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
                       <input type="password" placeholder="" autocomplete="off" class="form-control" id="PassswordTb" runat="server"/>
                   </div>
                   <div class="mt-3 d-grid">
                       <asp:Label ID="ErrMsg" runat="server" CssClass="text-danger text-center"></asp:Label>
                       <div class="mt-3 d-grid">
                           <asp:Button Text="登录" runat="server" CssClass="btn-success btn" ID="LoginBtn" OnClick="LoginBtn_Click" />
                       </div>
                       <div class="mt-3 d-grid">
                           <asp:Button ID="btnRegister" runat="server" CssClass="btn-success btn" Text="注册" OnClick="btnRegister_Click"/>
                       </div>
                      
                   </div>
                 </form>
            </div>
            <div class="col-md-4">
             
            </div>
        </div>
    </div>
   
</body>
</html>
