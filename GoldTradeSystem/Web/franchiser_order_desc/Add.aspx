<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order_desc.Add"
    Title="在线订货" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="keyType" runat="server" Visible="false" />
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td height="25" align="center">
                <asp:Label ID="Label1" runat="server" Text="请填写订货产品信息"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="center">
                <asp:Label ID="Label2" runat="server" ForeColor="#CC3300"></asp:Label>
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
                                        <asp:TemplateField HeaderText="条数">
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
                                    <asp:Button ID="Button1" runat="server" Text="上一步"  Width="100px" 
                                        onclick="Button1_Click"/>
                                    <asp:Button ID="Next" runat="server" Text="下一步" onclick="Next_Click"   Width="100px" />
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"   Width="100px"
                                        Text="重填" />
                                </div>
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
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    
</asp:Content>

