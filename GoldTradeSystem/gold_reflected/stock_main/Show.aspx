<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.stock_main.Show" Title="库存修改" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" align="right">
                &nbsp;</td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <fieldset>
                 <legend>查询页面</legend>
                <div>
                    <table style="width:100%;">
                     
                        <tr>
                             <td style="width: 50%" align="right">
                               经销商编号</td>
                            <td>
                                <asp:TextBox ID="txtFran_ID" runat="server" Width="200px" 
                                    BackColor="White" Height="22px"></asp:TextBox>
                             </td>
                        </tr>
                        
                        <tr>
                          <td style="width: 50%" align="right">
                               <asp:Button ID="query" runat="server" Text="查询" onclick="query_Click" />
                            </td>
                            <td>
                                <asp:Button ID="reset" runat="server" Text="重置" onclick="reset_Click" 
                                    Width="40px" />
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
                        <asp:BoundField DataField="franchiser_name" HeaderText="经销商名称" />
                        <asp:BoundField DataField="product_id" HeaderText="产品类别ID" Visible="False" />
                        <asp:BoundField DataField="product_type_name" HeaderText="产品类别名称" />
                        <asp:BoundField DataField="product_spec_id" HeaderText="产品规格" />
                        <asp:BoundField DataField="stock_total" HeaderText="库存总量" />
                        <asp:BoundField DataField="count_total" HeaderText="库存数量" />
                        <asp:BoundField DataField="stock_left" HeaderText="可用库存" />
                        <asp:BoundField DataField="count_left" HeaderText="可用库存数量" />
                        <asp:BoundField DataField="ins_user" HeaderText="新增人员" Visible="False" />
                        <asp:BoundField DataField="ins_date" HeaderText="新增日期" Visible="False" />
                        <asp:BoundField DataField="upd_user" HeaderText="更新人员" Visible="False" />
                        <asp:BoundField DataField="upd_date" HeaderText="更新日期" Visible="False" />
                        <asp:HyperLinkField DataNavigateUrlFields="id,franchiser_code" 
                            DataNavigateUrlFormatString="../stock_main/Modify.aspx?id={0}&amp;franchiser_code={1}" 
                            HeaderText="修改库存" Text="修改库存" />
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>


</asp:Content>
