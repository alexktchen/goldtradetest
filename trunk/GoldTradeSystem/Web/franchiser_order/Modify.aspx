<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order.Modify" Title="��������" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 100%;">
        <tr>
            <td style="width: 24%;">
                &nbsp;
            </td>
            <td align="right">
                &nbsp;</td>
            <td style="width: 20%;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 24%">
                &nbsp;
            </td>
            <td>
                <fieldset>
                    <legend>������ѯ</legend>
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 17%;" align="right">
                                    �����̱��</td>
                                <td style="width: 50%;" align="left">
                                    <asp:TextBox ID="txtFranID"   runat="server" Width="202px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 17%;" align="right">
                                    ������
                                </td>
                                <td style="width: 50%;" align="left">
                                    <asp:TextBox ID="txtfranchiser_order_id" runat="server" Width="204px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 17%">
                                    ����״̬
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpfranchiser_order_state" runat="server">
                                        <asp:ListItem Value="0">�Ѷ�</asp:ListItem>
                                        <asp:ListItem Value="1">������</asp:ListItem>
                                        <asp:ListItem Value="2">�ѷ���</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 17%">
                                    <asp:Button ID="query" runat="server" Text=" ��ѯ" OnClick="query_Click" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="reset" runat="server" Text="����" onclick="reset_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand" ForeColor="Black" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:HyperLinkField HeaderText="������" DataNavigateUrlFields="franchiser_order_id"
                            DataNavigateUrlFormatString="../franchiser_order_desc/Show_Admin.aspx?id={0}" Target="_blank" DataTextField="franchiser_order_id" />
                        <asp:BoundField DataField="franchiser_order_time" HeaderText="����ʱ��" />
                        <asp:BoundField DataField="franchiser_order_amount_money" HeaderText="�����ܶ�" />
                        <asp:BoundField DataField="franchiser_order_trans_type" HeaderText="���䷽ʽ" />
                        <asp:BoundField DataField="franchiser_order_address" HeaderText="�ջ���ַ" />
                        <asp:BoundField DataField="franchiser_order_postcode" HeaderText="�ʱ�" />
                        <asp:BoundField DataField="franchiser_order_handle_man" HeaderText="�ջ���" />
                        <asp:BoundField DataField="franchiser_order_handle_tel" HeaderText="�ջ��˵绰" />
                        <asp:BoundField DataField="franchiser_order_handle_phone" HeaderText="�ջ����ֻ�" />
                        <asp:BoundField DataField="franchiser_order_price" HeaderText="ʵʱ���" />
                        <asp:TemplateField HeaderText="ȷ�϶���" Visible="True">
                            <ItemTemplate>
                                <asp:Button ID="btnConfirm" runat="server" Text="ȷ��" CommandName="cmdConfirm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�޸Ķ���" Visible="True">
                            <ItemTemplate>
                                <asp:Button ID="btnModify" runat="server" Text="�޸�" CommandName="cmdModify" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
