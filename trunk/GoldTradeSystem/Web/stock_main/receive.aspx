<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" AutoEventWireup="true" CodeBehind="receive.aspx.cs" Inherits="GoldTradeNaming.Web.stock_main.receive" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
        <tr>
            <td height="25" width="30%" align="center">
                <asp:Label ID="Label1" runat="server" Text="您的收货单如下："></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="center">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="center">
                <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            onrowcommand="GridView1_RowCommand" ForeColor="Black" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                   
                     <asp:HyperLinkField HeaderText="收货单号" DataNavigateUrlFields="send_id" 
                        DataNavigateUrlFormatString="../send_desc/send_produc_show.aspx?sendid={0}" 
                        Target = "_blank" DataTextField ="send_id" /> 
                   
                        <asp:BoundField DataField="send_time" HeaderText="收货时间"  />
                        
                        <asp:BoundField DataField="send_amount_weight" HeaderText="收货总重量" />
                         <asp:TemplateField HeaderText="确认收货" >
                        <ItemTemplate>  
                        <asp:Button runat="server" Text="确认" CommandName="ConfirmRecv" />          
                           
                        </ItemTemplate>
                        </asp:TemplateField>  
                      
                        <asp:BoundField DataField="send_state" HeaderText="发货状态" Visible="false" />
                      <asp:BoundField DataField="franchiser_order_id" Visible="true" HeaderText="订单号" />
                      
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td height="25">
                <div align="center">
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
