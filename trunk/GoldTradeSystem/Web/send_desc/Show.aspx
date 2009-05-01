<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.send_desc.Show" Title="显示页" %>
<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
function txtChg()
{
    var num = document.getElementById("txtProdNum").value;   
   
    document.getElementById("lblProdWht").value=num2;
    alert(num);
}
</script>

<asp:HiddenField EnableViewState = "true" ID = "franid" runat="server" />
<asp:HiddenField EnableViewState="true" ID="orderid" runat ="server" />
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" align="center" style="width: 542px">
		<asp:Label ID="Label1" runat="server" Text="订单详细"></asp:Label>
                                </td>
	</tr>
	<tr>
	<td height="25" align="center" style="width: 542px">
    
<table cellSpacing="0" cellPadding="0" border="0" style="width: 80%; margin-left: 0px;">
	<tr>
	<td height="25" align="right" style="width: 28%">
		经销商 	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_code" runat="server" Width="200px" 
            BackColor="#999999" ReadOnly="True"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		运输方式
	</td>
	<td height="25" width="*" align="left">
		<asp:Label ID="lbltrans" runat="server" Text="Label"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		收获地址
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_order_address" runat="server" Width="200px" BackColor="Gray" ReadOnly="True"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		邮编
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_order_postcode" runat="server" Width="200px" BackColor="Gray" ReadOnly="True"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		收获人
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_order_handle_man" runat="server" Width="200px" BackColor="Gray" ReadOnly="True"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		收获人电话（座机）
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_order_handle_tel" runat="server" Width="200px" BackColor="Gray" ReadOnly="True"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		收获人手机
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_order_handle_phone" runat="server" Width="200px" 
           BackColor="Gray" ReadOnly="True"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		黄金实时价格
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_order_price" runat="server" Width="200px" 
            BackColor="Gray" ReadOnly="True"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		订货时间
	</td>
	<td height="25" width="*" align="left"><asp:TextBox ID="txtOrderTime" runat="server" BackColor="Gray" 
            ReadOnly="True" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		订单总额
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_order_amount_money" runat="server" Width="200px" 
            BackColor="Gray" ReadOnly="True"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 28%">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		<asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
	</td></tr>
	</table>

	</td>
	</tr>
	<tr> 
	<td align="center" style="height: 56px; width: 542px;">


 <anthem:GridView ID="GridView1" runat="server" 
            onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" 
            BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Vertical" 
            UpdateAfterCallBack="True" Width="615px" >
            <FooterStyle BackColor="#CCCC99" />
            
            <AlternatingRowStyle BackColor="White" />
            
            <Columns>
            <asp:BoundField DataField="product_type_name" HeaderText="产品名称" >
                <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
            <asp:BoundField  DataField="product_spec_weight" HeaderText = "规格" />
                <asp:BoundField DataField="order_product_amount" HeaderText="订购数量" />
                <asp:BoundField DataField="received_num" HeaderText="已发数量" />
                <asp:BoundField DataField="unreceived_num" HeaderText="待发数量" />           
           
            <asp:TemplateField  HeaderText="数量">            
            <ItemTemplate>             
          <asp:TextBox ID="txtProdNum" AutoPostBack="true"  OnTextChanged = "ProdNumChg"  runat="server"></asp:TextBox>
            </ItemTemplate>
            </asp:TemplateField>     
             <asp:TemplateField Visible="false" HeaderText = "重量小计">
            <ItemTemplate>             
           <asp:Label ID="lblProdWht" runat="server"></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>    
             <asp:BoundField DataField="product_id" HeaderText="产品ID" />        
            </Columns>
            <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F7DE" />
        </anthem:GridView>
        
	   
	</td>
	</tr>
	<tr>
	<td height="25" align="center" style="width: 542px">
		<asp:Button ID="btnSave" runat="server"  Text="提交" onclick="btnSave_Click"/>
        <asp:Button ID="btnCancel" runat="server" Text="取消" onclick="btnCancel_Click" />
        </td>
	</tr>
	<tr>
	<td align="left" style="height: 9px; width: 542px;">
	</td>
	</tr>
</table>


 

    </asp:Content>
