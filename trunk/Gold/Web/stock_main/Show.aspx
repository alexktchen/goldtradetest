<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.stock_main.Show" Title="����޸�" %>
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
                 <legend>��ѯҳ��</legend>
                <div>
                    <table style="width:100%;">
                     
                        <tr>
                             <td style="width: 50%" align="right">
                               �����̱��</td>
                            <td>
                                <asp:TextBox ID="txtFran_ID" runat="server" Width="200px" 
                                    BackColor="White" Height="22px"></asp:TextBox>
                             </td>
                        </tr>
                        
                        <tr>
                          <td style="width: 50%" align="right">
                               <asp:Button ID="query" runat="server" Text="��ѯ" onclick="query_Click" />
                            </td>
                            <td>
                                <asp:Button ID="reset" runat="server" Text="����" onclick="reset_Click" 
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
                        <asp:BoundField DataField="franchiser_name" HeaderText="����������" />
                        <asp:BoundField DataField="product_id" HeaderText="��Ʒ���ID" Visible="False" />
                        <asp:BoundField DataField="product_type_name" HeaderText="��Ʒ�������" />
                        <asp:BoundField DataField="product_spec_id" HeaderText="��Ʒ���" />
                        <asp:BoundField DataField="stock_total" HeaderText="�������" />
                        <asp:BoundField DataField="count_total" HeaderText="�������" />
                        <asp:BoundField DataField="stock_left" HeaderText="���ÿ��" />
                        <asp:BoundField DataField="count_left" HeaderText="���ÿ������" />
                        <asp:BoundField DataField="ins_user" HeaderText="������Ա" Visible="False" />
                        <asp:BoundField DataField="ins_date" HeaderText="��������" Visible="False" />
                        <asp:BoundField DataField="upd_user" HeaderText="������Ա" Visible="False" />
                        <asp:BoundField DataField="upd_date" HeaderText="��������" Visible="False" />
                        <asp:HyperLinkField DataNavigateUrlFields="id,franchiser_code" 
                            DataNavigateUrlFormatString="../stock_main/Modify.aspx?id={0}&amp;franchiser_code={1}" 
                            HeaderText="�޸Ŀ��" Text="�޸Ŀ��" />
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
