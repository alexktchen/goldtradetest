<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" 
Inherits="GoldTradeNaming.Web.franchiser_order_desc.Show" Title="订货系统--订单详细资料" %>
<%@ Register assembly="Anthem" namespace="Anthem" tagprefix="anthem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		&nbsp;</td>
	<td height="25" width="*" align="left">


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
                <asp:BoundField DataField="order_weight" HeaderText="订购重量" Visible="false" />
                <asp:BoundField DataField="product_received" HeaderText="已发重量"  Visible="false" />
                <asp:BoundField DataField="product_unreceived" HeaderText="未发重量"  Visible="false" />     
                
                <asp:BoundField DataField="received_num" HeaderText="已发数量" />
                <asp:BoundField DataField="unreceived_num" HeaderText="未发数量" />         
           
             <asp:BoundField DataField="product_id" HeaderText="产品ID" Visible="False" />        
            </Columns>
            <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F7DE" />
        </anthem:GridView>
        
	       
	</td></tr>
</table>
<input type="button" value="关闭" onclick="window.close()" />
</asp:Content>
