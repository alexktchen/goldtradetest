<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.send_main.Show" Title="在线发货" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 253px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField EnableViewState = "true" ID = "franid" runat="server" />
<asp:HiddenField EnableViewState="true" ID="orderid" runat ="server" />
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" align="right" style="width: 18%">
		&nbsp;</td>
	<td height="25" align="center" style="width: 1069px">
		<asp:Label ID="Label4" runat="server" Text="查询未发货订单"></asp:Label>
        </td>
	<td height="25" align="left" style="width: 192px">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" style="width: 18%">
		&nbsp;</td>
	<td height="25" align="left" style="width: 1069px">
		<table style="width:100%;">
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label2" runat="server" Text="经销商ID："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFranID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Label1" runat="server" Text="订单号："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    &nbsp;</td>
                <td align="left">
                    <asp:Button ID="Query" runat="server" onclick="Query_Click" Text="查询" />
                </td>
            </tr>
            </table>
	</td>
	<td height="25" align="left" style="width: 192px">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" style="width: 18%">
		&nbsp;</td>
	<td height="25" align="center" style="width: 1069px">
		<asp:Label ID="lblMsg" runat="server"></asp:Label>
        </td>
	<td height="25" align="left" style="width: 192px">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" style="width: 18%">
		&nbsp;</td>
	<td height="25" align="center" style="width: 1069px">
		<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcommand="GridView1_RowCommand" ForeColor="Black" GridLines="Vertical">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="orderID" HeaderText="订单号" />
                <asp:BoundField DataField="franchiser_code" HeaderText="经销商编号"  />
                <asp:BoundField DataField="franchiser_name" HeaderText="经销商名称" />
                <asp:BoundField DataField="franchiser_order_handle_man" HeaderText="收货人" />
                <asp:BoundField DataField="franchiser_order_state" HeaderText="订单状态ID" 
                    Visible="False" />
                <asp:HyperLinkField DataNavigateUrlFields="orderID,franchiser_code,franchiser_name" 
                    DataNavigateUrlFormatString="../send_desc/Show.aspx?id={0}&fid={1}&fnm={2}" 
                    HeaderText="查看并发货" Target="_self" Text="查看并发货" />
                  
                    
            </Columns>
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
	</td>
	<td height="25" align="left" style="width: 192px">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" style="width: 18%">
		&nbsp;</td>
	<td height="25" align="left" style="width: 1069px">
		&nbsp;</td>
	<td height="25" align="left" style="width: 192px">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" style="width: 18%">
		&nbsp;</td>
	<td height="25" align="left" style="width: 1069px">
		&nbsp;</td>
	<td height="25" align="left" style="width: 192px">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
</table>

</asp:Content>
