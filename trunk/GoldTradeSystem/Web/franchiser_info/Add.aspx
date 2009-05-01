<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_info.Add" Title="添加经销商" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="25" width="45%" align="right">
                经销商名称
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_name" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="45%" align="right">
                担保款
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_asure_money" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="45%" align="right">
                经销商座机
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_tel" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="45%" align="right">
                经销商手机
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_cellphone" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="45%" align="right">
                经销商地址
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_address" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="45%" align="right">
                认证锁ID
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtIA100GUID" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <font color="red">
                    <asp:Label ID="lblMsg" runat="server" Width="500px"></asp:Label></font>
            </td>
        </tr>
        <tr>
            <td height="25" colspan="2">
                <div align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click"></asp:Button>
                    <asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click">
                    </asp:Button>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
