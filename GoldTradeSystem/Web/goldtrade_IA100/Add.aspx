<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.goldtrade_IA100.Add" Title="添加认证锁" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td style="width: 113px"></td>
	<td height="25" colspan="" style="width: 612px"><div align="center">
		
		<fieldset>
		<legend >认证锁添加</legend>
			    <table style="width:76%; height: 87px;">
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" Text="认证锁唯一ID" runat="server"></asp:Label>
                </td>
                <td align="left">
		<asp:TextBox id="txtIA100GUID" runat="server"  Width="362px"  MaxLength="32"></asp:TextBox>
	            </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="认证锁密钥" ></asp:Label>
                </td>
                <td align="left">
		<asp:TextBox id="txtIA100Key" runat="server" Width="362px"  MaxLength="32"></asp:TextBox>
	            </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="认证锁超级密码"></asp:Label>
                </td>
                <td align="left">
		<asp:TextBox id="txtIA100SuperPswd" runat="server" Width="362px" MaxLength="32"></asp:TextBox>
	            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
                    <asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
                    </td>
            </tr>
        </table>
        </fieldset>

	</div></td>
	<td></td>
	</tr>
</table>
    <base target="_self">
</asp:Content>
