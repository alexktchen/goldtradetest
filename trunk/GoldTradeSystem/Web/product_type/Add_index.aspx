<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add_index.aspx.cs" Inherits="GoldTradeNaming.Web.product_type.Add_index" Title="��Ӳ�Ʒ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" >
		��ѡ��Ҫ��ӵĲ�Ʒ������</td>
	</tr>
	<tr>
	<td height="25">
                <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="�ƽ�" 
                    onclick="ImageButton1_Click" ImageUrl="~/image/1_1.jpg" />
            <br />
                <asp:ImageButton ID="ImageButton2" runat="server"  ToolTip="����"
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
