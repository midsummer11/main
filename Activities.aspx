<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Customers/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Activities.aspx.cs" Inherits="OnlineSupermarketTuto.Views.Customers.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    	<style> 
		*{
			padding:0;
			margin:0;
		}
		.container
		{
			width: 1100px;
			background:white;
			margin: 10px auto;
		}
		.item
		{
			box-sizing: border-box;  /*border计算在width中*/
			-moz-box-sizing:border-box; /* Firefox */
			-webkit-box-sizing:border-box; /* Safari */
			width: 33.33%;
			height: 250px;
			border:0px;
			float:left;
		}
		.container:after{
			display: block;
			clear: both;
			content: ".";
			height: 0;
			visibility: hidden;
			display: block;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
	<div class="row">
        <div class="col">
            <h3 class="text-center" style="color:#5E5B7A">最新活动</h3>
        </div>
    </div>       
	<div class="container">
		<div class="item">
            <asp:ImageButton ID="ImageButton1" runat="server" src="../../Assets/Images/Snipaste_2023-11-28_23-42-58.png" Height="250" Width="350px" />
		</div>
		<div class="item">
			 <asp:Label ID="Label1" runat="server" Height="250" Width="500">
                 在这个超市折扣日，探索无限优惠的世界！只有一天，精选商品震撼折扣，让您的购物体验升级！<br />
                 🕒 活动时间：仅限今天！不容错过的时间窗口，从早晨8点开始，一直到夜幕降临！<br />
                 💸在这里，您将发现超市历史上最低的价格。新鲜蔬果、高品质肉类、家居用品，统统都参与了这场盛大的折扣狂欢。无论您是精打细算的购物达人还是品质至上的挑剔消费者，我们都有超过您期待的特价商品等待着。<br />
                 🎁更有活动不断，首50位光顾者更有机会获得神秘礼品！惊喜连连，欢笑不断。<br />
             </asp:Label>   
		</div>		
	</div>
	<div class="container">
		<div class="item">
            <asp:ImageButton ID="ImageButton2" runat="server"  Height="250" Width="350px" src="../../Assets/Images/Snipaste_2023-11-28_23-44-39.png" />
        </div>
        <div class="item">
	         <asp:Label ID="Label2" runat="server" Height="250" Width="500">
				🌟 在这个五一假期，我们为您准备了令人惊叹的特价优惠，让您的购物体验达到新的高度。<br />
                🍎 新鲜水果：从甜蜜的草莓到多汁的蜜桃，我们的新鲜水果应有尽有，保证口感鲜美，价格更是惊喜连连！<br />
                🥩 优质肉类：欢迎品鉴我们的精选肉品，品质保证，价格实惠。五一烧烤季即将到来，为您的烹饪提供最佳选择。<br />
                🛒 日用百货：家居用品、清洁用具，五一特价超市为您提供一站式购物体验。不仅价格低廉，更有限时促销，物美价廉。<br />
                💰 超值特惠：每日不同的爆款商品，折扣力度大，数量有限，速来抢购！五一特价超市，只为给您带来更多实惠。<br />
             </asp:Label>   
        </div>		
	</div>
	<div class="container">
	    <div class="item">
            <asp:ImageButton ID="ImageButton3" runat="server"  Height="250" Width="350px" src="../../Assets/Images/Snipaste_2023-11-28_23-47-51.png" /> 
        </div>
        <div class="item">
            <asp:Label ID="Label3" runat="server" Height="250" Width="500">
               今日促销活动，满百立减，更有福利送不停！只需轻松购物满100元，即可享受免费配送到家服务。<br />
		       🚚无论您身在何处，优质商品直达您门前，为您省心省力。新鲜食材、家居用品，百货应有尽有。购物不仅轻松，更是超值体验！<br />
			   💸赶快行动吧，今天就来参与我们的促销，畅享购物的便利与实惠！<br />
			   🚀抢购倒计时，每天限时特价，让您足不出户就能尽情享受购物乐趣。<br />
			   🛍️✨抓住机会，尽在今日促销活动中，让您的购物体验更上一层楼。<br />
			   🎉赶快加入我们，一百元的轻松满足，免费送货的便利体验，今日促销，让您的购物感受焕然一新！<br />
            </asp:Label>   
        </div>		
   </div>
</asp:Content>
