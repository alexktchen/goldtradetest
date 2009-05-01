<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order.Modify" Title="订单管理" %>
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
                    <legend>订单查询</legend>
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 17%;" align="right">
                                    经销商编号</td>
                                <td style="width: 50%;" align="left">
                                    <asp:TextBox ID="txtFranID"   runat="server" Width="202px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 17%;" align="right">
                                    订单号
                                </td>
                                <td style="width: 50%;" align="left">
                                    <asp:TextBox ID="txtfranchiser_order_id" runat="server" Width="204px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 17%">
                                    订单状态
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpfranchiser_order_state" runat="server">
                                        <asp:ListItem Value="0">已订</asp:ListItem>
                                        <asp:ListItem Value="1">发货中</asp:ListItem>
                                        <asp:ListItem Value="2">已发完</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 17%">
                                    <asp:Button ID="query" runat="server" Text=" 查询" OnClick="query_Click" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="reset" runat="server" Text="重置" onclick="reset_Click" />
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
                        <asp:HyperLinkField HeaderText="订单号" DataNavigateUrlFields="franchiser_order_id"
                            DataNavigateUrlFormatString="../franchiser_order_desc/Show_Admin.aspx?id={0}" Target="_blank" DataTextField="franchiser_order_id" />
                        <asp:BoundField DataField="franchiser_order_time" HeaderText="订货时间" />
                        <asp:BoundField DataField="franchiser_order_amount_money" HeaderText="订单总额" />
                        <asp:BoundField DataField="franchiser_order_trans_type" HeaderText="运输方式" />
                        <asp:BoundField DataField="franchiser_order_address" HeaderText="收货地址" />
                        <asp:BoundField DataField="franchiser_order_postcode" HeaderText="邮编" />
                        <asp:BoundField DataField="franchiser_order_handle_man" HeaderText="收货人" />
                        <asp:BoundField DataField="franchiser_order_handle_tel" HeaderText="收货人电话" />
                        <asp:BoundField DataField="franchiser_order_handle_phone" HeaderText="收货人手机" />
                        <asp:BoundField DataField="franchiser_order_price" HeaderText="实时金价" />
                        <asp:TemplateField HeaderText="确认订单" Visible="True">
                            <ItemTemplate>
                                <asp:Button ID="btnConfirm" runat="server" Text="确认" CommandName="cmdConfirm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改订单" Visible="True">
                            <ItemTemplate>
                                <asp:Button ID="btnModify" runat="server" Text="修改" CommandName="cmdModify" />
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
