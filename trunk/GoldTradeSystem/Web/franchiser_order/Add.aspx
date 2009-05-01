<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order.Add"
    Title="增加页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="1">
        <tr>
            <td height="25" align="right" style="width: 49%">
                <asp:HiddenField ID="thisProductType" runat="server" Visible="False" />
            </td>
            <td height="25" width="*" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                &nbsp;
            </td>
            <td height="25" width="*" align="left">
                &nbsp;
                <asp:Label ID="Label2" runat="server" ForeColor="#CC3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                客户名称&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblFranName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                运输方式
            </td>
            <td height="25" width="*" align="left">
                <asp:RadioButtonList ID="transway" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">航空</asp:ListItem>
                    <asp:ListItem Value="1">邮寄</asp:ListItem>
                    <asp:ListItem Value="2">自取</asp:ListItem>
                    <asp:ListItem Value="3">其他</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                收货地址
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_address" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                邮政编码
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_postcode" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                收货人
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_handle_man" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                收货人电话（座机）
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_handle_tel" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                收货人手机
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_handle_phone" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                基础金价&nbsp;&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                订货产品类型&nbsp;&nbsp;&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblProdType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="center" colspan="2">
                <asp:Panel ID="Panel1" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td height="25">
                                <div align="center">
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="下一步" />
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="重置" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td height="25" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
