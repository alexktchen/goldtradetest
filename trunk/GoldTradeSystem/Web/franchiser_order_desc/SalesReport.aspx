<%@ Page Language="C#" AutoEventWireup="true"MasterPageFile="~/MasterPage.master" CodeBehind="SalesReport.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order_desc.SalesReport"Title="销售报表" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:100%;">
     <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 59%" align="right">
              
            </td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 59%">
                <fieldset>
                 <legend>经销商汇总</legend>
                <div>
                    <table style="width:100%;">
                     
                        <tr>
                             <td style="width: 50%" align="right">
                             经销商总余额
                               </td>
                            <td>
                                <asp:TextBox ID="leftPrice" runat="server" Width="200px" 
                                    BackColor="White" Visible="True" ReadOnly="false"></asp:TextBox>
                             </td>
                        </tr>
                        
                        <tr>
                          <td style="width: 50%" align="right">
                               经销商总交易额</td>
                            <td>
                               <asp:TextBox ID="TotalTrade" runat="server" Width="200px"
                               BackColor="White" Visible="true" ReadOnly="false"></asp:TextBox>
                               </td>
                        </tr>
                        <tr>
                        <td style="width:50%" align="right">
                        经销商入帐总额
                        </td>
                        <td>
                        <asp:TextBox ID="TotalMoney" runat="server" Width="200px"
                         BackColor="White" Visible="true" ReadOnly="false"></asp:TextBox>
                        </td>
                        </tr>
                    </table>
                    </div>
                </fieldset>
                
                
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td>
         &nbsp;
        </td>
            <td style="width: 59%">
                <asp:GridView ID="showData" runat="server" Width="100%" BackColor="Silver" 
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    AutoGenerateColumns="False" AllowPaging="True" 
                    onpageindexchanging="showData_PageIndexChanging" ForeColor="Black" 
                    GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="product_type_name" HeaderText="产品类别" />
                        <asp:BoundField DataField="product_spec_weight" HeaderText="产品规格" />
                        <asp:BoundField DataField="order_product_amount" HeaderText="总订量" />
                        <asp:BoundField DataField="stock_total" HeaderText="总库存" />
                        <asp:BoundField DataField="trade_weight" HeaderText="总销量" />
                        <asp:BoundField DataField="stock_left" HeaderText="剩余库存" />
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td>
         &nbsp;
        </td>
        </tr>
    </table>

</asp:Content>