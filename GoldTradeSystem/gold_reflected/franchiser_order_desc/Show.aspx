<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" 
Inherits="GoldTradeNaming.Web.franchiser_order_desc.Show" Title="����ϵͳ--������ϸ����" %>
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
            <asp:BoundField DataField="product_type_name" HeaderText="��Ʒ����" />
            <asp:BoundField  DataField="product_spec_weight" HeaderText = "���" />
                <asp:BoundField DataField="order_product_amount" HeaderText="��������" />
                <asp:BoundField DataField="order_weight" HeaderText="��������" Visible="false" />
                <asp:BoundField DataField="product_received" HeaderText="�ѷ�����"  Visible="false" />
                <asp:BoundField DataField="product_unreceived" HeaderText="δ������"  Visible="false" />     
                
                <asp:BoundField DataField="received_num" HeaderText="�ѷ�����" />
                <asp:BoundField DataField="unreceived_num" HeaderText="δ������" />         
           
             <asp:BoundField DataField="product_id" HeaderText="��ƷID" Visible="False" />        
            </Columns>
            <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F7DE" />
        </anthem:GridView>
        
	       
	</td></tr>
</table>
<input type="button" value="�ر�" onclick="window.close()" />
</asp:Content>
