<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"AutoEventWireup="true" CodeBehind="stockModifyLog.aspx.cs" Inherits="GoldTradeNaming.Web.stock_main.stockModifyLog" Title="库存修改记录" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" align="right">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" >
                <asp:GridView ID="showData" runat="server" Width="100%" BackColor="White" 
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    AutoGenerateColumns="False" AllowPaging="True" 
                    onpageindexchanging="showData_PageIndexChanging" ForeColor="Black" 
                    GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="franchiser_name" HeaderText="经销商名称" />
                        <asp:BoundField DataField="product_name" HeaderText="产品名称" />
                        <asp:BoundField DataField="product_spec_id" HeaderText="产品规格" />
                        <asp:BoundField DataField="stock_total_changed" HeaderText="库存变化数" />
                        <asp:BoundField DataField="stock_left_changed" HeaderText="可用库存变化数" />
                        <asp:BoundField DataField="ins_user" HeaderText="修改人员" />
                        <asp:BoundField DataField="ins_date" HeaderText="修改日期" />
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
