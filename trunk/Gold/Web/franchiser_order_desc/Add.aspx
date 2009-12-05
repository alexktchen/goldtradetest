<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="WebReflector.franchiser_order_desc.Add_Reflector"
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
                <asp:Label ID="Label2"  runat="server" ForeColor="#CC3300"></asp:Label>
                <anthem:Label  ID="Label3"   AutoUpdateAfterCallBack = "true" runat="server"   ForeColor="#CC3300"></anthem:Label>
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
                                        <asp:BoundField DataField="product_type_id" HeaderText="产品ID" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                                            ItemStyle-BorderWidth="2px">
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="product_type_name" HeaderText="产品名称" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                                            ItemStyle-BorderWidth="2px">
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="product_spec_weight" HeaderText="规格" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="条数" ItemStyle-HorizontalAlign="left" ItemStyle-Wrap="false"
                                            HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtProdNum" runat="server" AutoPostBack="true" OnTextChanged="ProdNumChge"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="重量小计" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProdWht" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="order_add_price" HeaderText="订货加价" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="price_appraise" HeaderText="预估单价" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="预估金额小计" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmountMoney" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                    <asp:Button ID="Button1" runat="server" Text="上一步" Width="100px" OnClick="Button1_Click" />
                                    <asp:Button ID="Next" runat="server" Text="下一步" OnClick="Next_Click" Width="100px" />
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Width="100px"
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
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
