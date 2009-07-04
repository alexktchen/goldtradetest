<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoldTradeNaming.Web.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>首页</title>
    
<style type="text/css">

body {
	margin:0 auto;
	background-color:#fff;
	color:#000;
	font-size: 12px;
	line-height: 28px;
	text-align: center;
}

td{

	font-size: 12px;
}


#dengl1 {
	width:900px;
	height:554px;
	z-index:1;
	background-image: url(image/dengl_bg.gif);
}
#dengl2 {
	width:900px;
	height:29px;
	z-index:2;
}

#foot {
	position:relative;
	left:0px;
	width:900px;
	height:31px;
	z-index:4;
	background-image: url(image/foot_bg.gif);
	text-align: center;
	color: #FFFFFF;
	font-size: 12px;
	line-height: 31px;
}

</style>
</head>
<body text="1000">
    <form id="form1" runat="server">
<div id="dengl1">

<table border="0" cellpadding="0" cellspacing="0" width="520">
<!-- fwtable fwsrc="未命名" fwpage="页面 1" fwbase="dengl_1_r1_c1.gif" fwstyle="Dreamweaver" 

fwdocid = "2033459842" fwnested="1" -->
  <tr>
   <td width="79" height="116"><img name="dengl_1_r1_c1_r1_c1" 

src="image/dengl_1_r1_c1_r1_c1.gif"  border="0" id="dengl_1_r1_c1_r1_c1" alt="" /></td>
   <td><img name="dengl_1_r1_c1_r1_c2" src="image/dengl_1_r1_c1_r1_c2.gif" width="347" 

height="116" border="0" id="dengl_1_r1_c1_r1_c2" alt="" /></td>
   <td width="94" height="116"></td>
  </tr>
  <tr>
   <td><img name="dengl_1_r1_c1_r2_c1" src="image/dengl_1_r1_c1_r2_c1.gif" width="79" 

height="326" border="0" id="dengl_1_r1_c1_r2_c1" alt="" /></td>
   <td>
   
   
   <table align="left" border="0" cellpadding="0" cellspacing="0" width="347">
	  <tr>
	   <td><img name="dengl_1_r1_c1_r2_c2" src="image/dengl_1_r1_c1_r2_c2.gif" width="347" 

height="54" border="0" id="dengl_1_r1_c1_r2_c2" alt="" /></td>
	  </tr>
	  <tr>
	   <td width="347" height="272" background="image/dengl_1_r1_c1_r3_c2.gif">
       
       <table width="300" border="0" align="center">
       <tr>
           <td align="right">
           
           <asp:Label ID="Label1" runat="server" Text="经销商ID"></asp:Label>           </td>
           <td align="left">
           
           <asp:TextBox ID="TextBox1" runat="server">1000</asp:TextBox>           
           
           <asp:Button ID="Button1" runat="server" Text="无卡登录" onclick="Button1_Click" />               
           </td>
         </tr>
         <tr>
           <td colspan="2" align="center">
           
               &nbsp;</td>
           </tr>
         <tr>
           <td colspan="2" align="center">
           
           <asp:Label ID="Label3" runat="server" Text="管理员ID"></asp:Label>           
                <asp:TextBox ID="TextBox3" runat="server">1001</asp:TextBox>
               <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="无卡登录" />
             </td>
           </tr>
         <tr>
           <td colspan="2" align="center">
           
                     </td>
           </tr>
         <tr>
           <td colspan="2" align="center">
           
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/User_Login/flogin.aspx">经销商IA登录入口</asp:HyperLink>
             </td>
           </tr>
         <tr>
           <td colspan="2" align="center">
           
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/User_Login/AdminLogin.aspx">管理员IA登录入口</asp:HyperLink>
             </td>
           </tr>
       </table>       </td>
	  </tr>
	</table></td>
   <td><img name="dengl_1_r1_c1_r2_c3" src="image/dengl_1_r1_c1_r2_c3.gif" width="94" 

height="326" border="0" id="dengl_1_r1_c1_r2_c3" alt="" /></td>
  </tr>
</table>


</div>

  </form>

<div id="foot">技术支持：13625778033 Copyright &copy;2009-2010 金牛企业</div>

</body>
</html>
