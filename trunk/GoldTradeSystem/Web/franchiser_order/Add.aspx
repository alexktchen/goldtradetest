<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order.Add"
    Title="����ҳ" %>

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
                �ͻ�����&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblFranName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                ���䷽ʽ
            </td>
            <td height="25" width="*" align="left">
                <asp:RadioButtonList ID="transway" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">����</asp:ListItem>
                    <asp:ListItem Value="1">�ʼ�</asp:ListItem>
                    <asp:ListItem Value="2">��ȡ</asp:ListItem>
                    <asp:ListItem Value="3">����</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ջ���ַ
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_address" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                ��������
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_postcode" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ջ���
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_handle_man" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ջ��˵绰��������
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_handle_tel" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ջ����ֻ�
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtfranchiser_order_handle_phone" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �������&nbsp;&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                ������Ʒ����&nbsp;&nbsp;&nbsp; </td>
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
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="��һ��" />
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="����" />
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
