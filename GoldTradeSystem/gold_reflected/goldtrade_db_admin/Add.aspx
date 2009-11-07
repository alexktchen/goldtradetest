<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.goldtrade_db_admin.Add" Title="添加管理员" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <fieldset>
            <legend>添加管理员</legend>
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
    <tr>
        <td height="25" align="right" style="width: 48%">
            <asp:HiddenField ID="hdnAdminID" runat="server" Visible="False" />
        </td>
        <td height="25" width="*" align="left">
            <asp:HiddenField ID="hdnAdminNm" runat="server" Visible="False" />
        </td>
    </tr>
    <tr>
        <td height="25" width="50%" align="right">
		管理员姓名:
	    </td>
        <td height="25" width="*" align="left">
            <asp:TextBox id="txtsys_admin_name" runat="server" Width="239px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td height="25" width="50%" align="right">
		管理员TEL:
	    </td>
        <td height="25" width="*" align="left">
            <asp:TextBox id="txtsys_admin_tel" runat="server" Width="239px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td height="25" width="50%" align="right">
		管理员手机:
	    </td>
        <td height="25" width="*" align="left">
            <asp:TextBox id="txtsys_admin_cellphone" runat="server" Width="239px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td height="25" width="50%" align="right">
		IA100唯一ID:
	    </td>
        <td height="25" width="*" align="left">
            <asp:TextBox id="txtIA100GUID" MaxLength="32" runat="server" Width="239px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td height="25" colspan="2">
            <div align="center">
                <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" >
                </asp:Button>
                <asp:Button ID="btnReset"   runat="server" Text="· 取消 ·" OnClick="btnCancel_Click" />
            </div>
        </td>
    </tr>
</table></fieldset>
</asp:Content>
