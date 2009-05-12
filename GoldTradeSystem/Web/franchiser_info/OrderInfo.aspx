<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_info.OrderInfo" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
            <td colspan="3">
                &nbsp;
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging"
                     ForeColor="Black" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="franchiser_order_id" HeaderText="订单号" />
                        <asp:BoundField DataField="franchiser_order_time" HeaderText="订货时间" />
                        <asp:BoundField DataField="franchiser_order_amount_money" HeaderText="订单总额" />
                        <asp:BoundField DataField="franchiser_order_trans_type" HeaderText="运输方式" />
                        <asp:BoundField DataField="franchiser_order_address" HeaderText="收货地址" />
                        <asp:BoundField DataField="franchiser_order_postcode" HeaderText="邮编" />
                        <asp:BoundField DataField="franchiser_order_handle_man" HeaderText="收货人" />
                        <asp:BoundField DataField="franchiser_order_handle_tel" HeaderText="收货人电话" />
                        <asp:BoundField DataField="franchiser_order_handle_phone" HeaderText="收货人手机" />
                        <asp:BoundField DataField="franchiser_order_price" HeaderText="实时金价" />
                        <asp:HyperLinkField HeaderText="查看详细" DataNavigateUrlFields="franchiser_order_id"
                            
                            DataNavigateUrlFormatString="../franchiser_order_desc/Show_Admin.aspx?id={0}" 
                            Target="_blank"  Text="查看详细" />
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:Button ID="btnReturn" runat="server" onclick="btnReturn_Click1" 
                    Text="返回" />
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
