<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GoldTradeNaming.Web.goldtrade_IA100.Modify" Title="修改认证锁" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		IA100GUID
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblIA100GUID" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IA100Key
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIA100Key" runat="server" Width="200px" MaxLength="32"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IA100SuperPswd
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIA100SuperPswd" runat="server" Width="200px" MaxLength="32"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IA100State
	</td>
	<td height="25" width="*" align="left">
		            <asp:ListBox ID="lstIA100_State" runat="server" Height="51px" Width="246px">
                        <asp:ListItem Value="0">可用</asp:ListItem>
                        <asp:ListItem Value="1">禁用</asp:ListItem>
                    </asp:ListBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		StateChangeReason
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtStateChangeReason" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>

</asp:Content>
