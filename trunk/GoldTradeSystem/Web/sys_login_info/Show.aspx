<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.sys_login_info.Show" Title="ÏÔÊ¾Ò³" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ID
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IP
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIP" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		login_time
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbllogin_time" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		login_ID
	</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbllogin_ID" runat="server"></asp:Label>
	</td></tr>
</table>

</asp:Content>
