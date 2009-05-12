<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" 
AutoEventWireup="true" CodeBehind="OrderTest.aspx.cs" 
Inherits="GoldTradeNaming.Web.franchiser_order_desc.OrderTest" Title="订货预估" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td height="25" align="center">
                <asp:Label ID="Label1" runat="server" Text="订货评估"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="center">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/1_1.jpg" 
                    onclick="ImageButton1_Click" ToolTip="黄金" />
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/image/1_2.jpg" 
                    onclick="ImageButton2_Click" ToolTip="白银" />
            </td>
        </tr>
        <tr>
            <td height="25" align="center">
                <asp:Panel ID="Panel1" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <anthem:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoUpdateAfterCallBack="True"
                                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" OnRowDataBound="GridView1_RowDataBound" UpdateAfterCallBack="True"
                                    OnRowCreated="GridView1_RowCreated" ForeColor="Black" GridLines="Vertical">
                                    <FooterStyle BackColor="#CCCC99" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="product_type_id" HeaderText="产品ID" />
                                        <asp:BoundField DataField="product_type_name" HeaderText="产品名称" />
                                        <asp:BoundField DataField="product_spec_weight" HeaderText="规格" />
                                        <asp:TemplateField HeaderText="数量">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtProdNum" runat="server" AutoPostBack="true" 
                                                    OnTextChanged="ProdNumChge"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="重量小计">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProdWht" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="order_add_price" HeaderText="订货加价" />
                                        <asp:BoundField DataField="price_appraise" HeaderText="预估单价" />
                                        <asp:TemplateField HeaderText="预估金额小计">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmountMoney" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#F7F7DE" />
                                </anthem:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td height="25">
                                <div align="center">
                                    <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="25">
                                <asp:Button ID="Next" runat="server" onclick="Next_Click" Text="计算" 
                                    Width="100px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td height="25">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
