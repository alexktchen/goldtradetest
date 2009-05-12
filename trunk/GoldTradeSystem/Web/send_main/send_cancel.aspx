<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="send_cancel.aspx.cs" Inherits="GoldTradeNaming.Web.send_main.send_cancel" Title="无标题页" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
        <tr>
            <td height="25" align="right" style="width: 18%">
		&nbsp;</td>
            <td height="25" align="left" style="width: 1069px">
		        &nbsp;</td>
            <td height="25" align="left" style="width: 192px">
		&nbsp;</td>
            <td height="25" width="*" align="left">
		&nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 18%">
		&nbsp;</td>
            <td height="25" align="center" style="width: 1069px">
                <asp:HiddenField ID="hdnSendState" runat="server" Visible="False" />
                <asp:Label ID="Label4" runat="server" Text="查询发货单"></asp:Label>
            </td>
            <td height="25" align="left" style="width: 192px">
		&nbsp;</td>
            <td height="25" width="*" align="left">
		&nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 18%">
		&nbsp;</td>
            <td height="25" align="left" style="width: 1069px">
                <table style="width:100%;">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="订单号："></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtOrderId" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="发货单号："></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSendId" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="发货状态："></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="128px">
                                <asp:ListItem Value="0">已发货</asp:ListItem>
                                <asp:ListItem Value="1">已收货</asp:ListItem>
                                <asp:ListItem Value="2">已取消</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
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
		&nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 18%">
		&nbsp;</td>
            <td height="25" align="left" style="width: 1069px">
		&nbsp;</td>
            <td height="25" align="left" style="width: 192px">
		&nbsp;</td>
            <td height="25" width="*" align="left">
		&nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 18%">
		&nbsp;</td>
            <td height="25" align="center" style="width: 1069px">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound">
                    <PagerSettings Mode="NumericFirstLast" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <Columns>
                   
                     <asp:HyperLinkField HeaderText="发货单号" DataNavigateUrlFields="send_id" 
                        DataNavigateUrlFormatString="../send_desc/send_product_show.aspx?sendid={0}" 
                        Target = "_blank" DataTextField ="send_id" /> 
                   
                   <asp:HyperLinkField HeaderText="订单号" DataNavigateUrlFields="franchiser_order_id" 
                        DataNavigateUrlFormatString="../send_desc/Show.aspx?id={0}"  
                        Target = "_blank" DataTextField="franchiser_order_id" /> 
                   
                        <asp:BoundField DataField="send_time" HeaderText="发货时间"  />
                        
                        <asp:BoundField DataField="send_amount_weight" HeaderText="发货总重量" />
                         <asp:TemplateField HeaderText="取消发货" >
                        <ItemTemplate>  
                        <asp:Button runat="server" Text="取消" CommandName="CancelSend" />          
                           
                        </ItemTemplate>
                        </asp:TemplateField>                        
                        
                        <asp:TemplateField HeaderText="取消原因" >
                        <ItemTemplate>             
                            <asp:TextBox ID="txtCnclRsn"  runat="server"></asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
                      
                        <asp:BoundField DataField="send_state" HeaderText="发货状态" Visible="false" />
                      
                      
                    </Columns>
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
            <td height="25" align="left" style="width: 192px">
		&nbsp;</td>
            <td height="25" width="*" align="left">
		&nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 18%">
		&nbsp;</td>
            <td height="25" align="left" style="width: 1069px">
		&nbsp;</td>
            <td height="25" align="left" style="width: 192px">
		&nbsp;</td>
            <td height="25" width="*" align="left">
		&nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 18%">
		&nbsp;</td>
            <td height="25" align="left" style="width: 1069px">
		&nbsp;</td>
            <td height="25" align="left" style="width: 192px">
		&nbsp;</td>
            <td height="25" width="*" align="left">
		&nbsp;</td>
        </tr>
    </table>
</asp:Content>
