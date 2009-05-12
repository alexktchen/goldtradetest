<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GoldTradeNaming.Web.goldtrade_db_admin.Modify" Title="修改管理员" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <fieldset>
            <legend>修改管理员</legend>
<table cellSpacing="0" cellPadding="0" border="0" style="height: 131px; width: 80%">
	<tr>
	<td height="25" align="right" style="width: 48%">
		管理员编号
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblsys_admin_id" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 48%">
		管理员姓名
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtsys_admin_name" runat="server" Width="245px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 48%">
		管理员TEL 	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtsys_admin_tel" runat="server" Width="248px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 48%">
		管理员手机 	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtsys_admin_cellphone" runat="server" Width="248px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 48%">
		IA100GUID 	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIA100GUID" runat="server" Width="249px" MaxLength="32"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
</table>
</fieldset>
</asp:Content>
