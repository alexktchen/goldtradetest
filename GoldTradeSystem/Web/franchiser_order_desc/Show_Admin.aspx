<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show_Admin.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order_desc.Show_Amdin" Title="订单详细" %>
<%@ Register assembly="Anthem" namespace="Anthem" tagprefix="anthem" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <anthem:GridView ID="GridView2" runat="server" 
           AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" UpdateAfterCallBack="True" ForeColor="Black" 
        GridLines="Vertical" >
        <FooterStyle BackColor="#CCCC99" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="product_type_name" HeaderText="产品名称" />
            <asp:BoundField  DataField="product_spec_weight" HeaderText = "规格" />
            <asp:BoundField DataField="order_product_amount" HeaderText="订购数量" />
            <asp:BoundField DataField="order_weight" HeaderText="订购重量"  Visible="False" />
            <asp:BoundField DataField="product_received" HeaderText="已收重量" Visible="False"  />
            <asp:BoundField DataField="product_unreceived" HeaderText="未收重量" Visible="False"  />
            <asp:BoundField DataField="received_num" HeaderText="已收数量" />
            <asp:BoundField DataField="unreceived_num" HeaderText="未收数量" />
            <asp:BoundField DataField="product_id" HeaderText="产品ID" Visible="False" />
        </Columns>
        <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F7DE" />
    </anthem:GridView>
    <input type="button" value="关闭" onclick="window.close()" />
</asp:Content>
