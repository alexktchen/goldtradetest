<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ShowAdmin.aspx.cs" Inherits="GoldTradeNaming.Web.send_desc.ShowAdmin" Title="发货信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="display: none">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>

    <table style="width:100%;">
   
        <tr>
        <td>
                &nbsp;</td>
            <td >
                <asp:GridView ID="showData" runat="server" Width="100%" BackColor="White" 
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    AutoGenerateColumns="False" ForeColor="Black" 
                    GridLines="Vertical" Height="45px">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="product_spec_id" HeaderText="产品规格" />
                        <asp:BoundField DataField="product_name" HeaderText="产品名称" />
                        <asp:BoundField DataField="send_amount" HeaderText="发货数量" />
                        <asp:BoundField DataField="ins_date" HeaderText="发货时间" />
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <input type="button" onclick="javascript:window.close()" value="关闭" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
