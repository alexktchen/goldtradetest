<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true"
    CodeBehind="Add_submit.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order_desc.Add_submit"
    Title="订单信息" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="keyType" runat="server" Visible="false" />
   <table cellspacing="0" cellpadding="0" width="100%" border="1">
        <tr>
            <td height="25" align="center" colspan="2">
                ********************************您的订单信息如下********************************</td>
        </tr>
        
        <tr>
            <td height="25" align="right" style="width: 49%">
                客户名称&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblFranName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                运输方式
            </td>
            <td height="25" width="*" align="left">
                
                <asp:Label ID="transway" runat="server" Text="transway"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                收货地址
            </td>
            <td height="25" width="*" align="left">
               
                <asp:Label ID="txtfranchiser_order_address" runat="server" Text="txtfranchiser_order_address"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                邮政编码
            </td>
            <td height="25" width="*" align="left">
                
                <asp:Label ID="txtfranchiser_order_postcode" runat="server" Text="txtfranchiser_order_postcode"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                收货人
            </td>
            <td height="25" width="*" align="left">
                
                <asp:Label ID="txtfranchiser_order_handle_man" runat="server" Text="txtfranchiser_order_handle_man"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                收货人电话（座机）
            </td>
            <td height="25" width="*" align="left">
               
                <asp:Label ID="txtfranchiser_order_handle_tel" runat="server" Text="txtfranchiser_order_handle_tel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                收货人手机
            </td>
            <td height="25" width="*" align="left">
                
                <asp:Label ID="txtfranchiser_order_handle_phone" runat="server" Text="txtfranchiser_order_handle_phone"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                基础金价&nbsp;&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                订货产品类型&nbsp;&nbsp;&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblProdType" runat="server"></asp:Label>
            </td>
        </tr>
      
        
    </table>
    
    
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td height="25" align="center">
                ********************************<asp:Label ID="Label1" runat="server" Text="订货产品信息"></asp:Label>
                ********************************</td>
        </tr>
        <tr>
            <td height="25" align="center">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
                    onrowcreated="GridView1_RowCreated">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="product_type_id" HeaderText="产品ID" />
                        <asp:BoundField DataField="product_type_name" HeaderText="产品名称" />
                        <asp:BoundField DataField="product_spec_id" HeaderText="规格" />
                        <asp:BoundField DataField="order_product_amount" HeaderText="条数" />
                        <asp:BoundField DataField="order_weight" HeaderText="重量小计" />
                        <asp:BoundField DataField="order_add_price" HeaderText="订货加价" />
                        <asp:BoundField DataField="order_appraise" HeaderText="预估单价" />
                        <asp:BoundField HeaderText="预估金额小计" DataField="AmountMoney" />
                    </Columns>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td height="25" align="center">
                你此项的订单总额为：<asp:Label ID="lblsun" runat="server" Text="lblsun"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="center">
                <asp:Button ID="Button1" runat="server" Text="上一步" Width="100px" 
                    onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="提交" Width="100px" 
                    onclick="Button2_Click"/>
                <asp:Button ID="Button3" runat="server" Text="取消" Width="100px" 
                    onclick="Button3_Click"  />
            </td>
        </tr>
        <tr>
            <td height="25">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    
</asp:Content>

