<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add_index.aspx.cs" Inherits="GoldTradeNaming.Web.product_type.Add_index" Title="添加产品" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" >
		请选择要添加的产品的种类</td>
	</tr>
	<tr>
	<td height="25">
                <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="黄金" 
                    onclick="ImageButton1_Click" ImageUrl="~/image/1_1.jpg" />
            <br />
                <asp:ImageButton ID="ImageButton2" runat="server"  ToolTip="白银"
                    onclick="ImageButton2_Click" ImageUrl="~/image/1_2.jpg" />
            </td>
	</tr>

	
	
	<tr>
	<td height="25">
        &nbsp;</td></tr>
	
	
	<tr>
	<td height="25" align="center">
        &nbsp;</td></tr>
	
</table>

</asp:Content>
