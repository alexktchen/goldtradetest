<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true" CodeBehind="franchiserStockShow.aspx.cs" Inherits="GoldTradeNaming.Web.stock_main.franchiserStockShow" Title="显示库存" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <table style="width:100%;">
     <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" align="right">
              
            </td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <fieldset>
                 <legend></legend>
                <div>
                    <table style="width:100%;">
                     
                        <tr>
                             <td style="width: 50%" align="right">
                                 &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtProudctName" runat="server" Width="200px" 
                                    BackColor="White"  Visible="False" ReadOnly="false" ></asp:TextBox>
                             </td>
                        </tr>
                        
                        <tr>
                          <td style="width: 50%" align="right">
                               &nbsp;</td>
                            <td>
                               <asp:TextBox ID="txtProductSpec" runat="server" Width="200px"
                               BackColor="White" Visible="False" ReadOnly="false" ></asp:TextBox></td>
                        </tr>
                        <tr>
                        <td style="width:50%" align="right">
                        
                            &nbsp;</td>
                        <td tyle="width: 50%" align="left">
                        
                            &nbsp;</td>
                        </tr>
                    </table>
                    </div>
                </fieldset>
                
                
                </td>
            <td>
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
                        <asp:BoundField DataField="id" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="franchiser_name" HeaderText="经销商名称" Visible="False" />
                        <asp:BoundField DataField="product_id" HeaderText="产品类别ID" Visible="False" />
                        <asp:BoundField DataField="product_type_name" HeaderText="产品类别名称" />
                        <asp:BoundField DataField="product_spec_id" HeaderText="产品规格" />
                        <asp:BoundField DataField="stock_total" HeaderText="库存重量" />
                        <asp:BoundField DataField="count_total" HeaderText="库存数量" />
                        <asp:BoundField DataField="stock_left" HeaderText="可用库存重量" />
                        <asp:BoundField DataField="count_left" HeaderText="可用库存数量" />
                        <asp:BoundField DataField="ins_user" HeaderText="新增人员" Visible="False" />
                        <asp:BoundField DataField="ins_date" HeaderText="新增日期" Visible="False" />
                        <asp:BoundField DataField="upd_user" HeaderText="更新人员" Visible="False" />
                        <asp:BoundField DataField="upd_date" HeaderText="更新日期" Visible="False" />
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
