<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeBehind="show.aspx.cs" Inherits="GoldTradeNaming.Web.product_type.Show" Title="�鿴��Ʒ" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
            </td>
            <td align="right">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 185px">
            </td>
            <td style="width: 80%; height: 185px;">
                <fieldset>
                    <legend>��ѯ</legend>
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 50%">
                                    ��Ʒ���ID
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:TextBox ID="type_ID" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    ��Ʒ�������
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:TextBox ID="type_Name" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    ��Ʒ���
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:TextBox ID="type_Kind" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    ��Ʒ״̬
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:DropDownList ID="drptype_Status" runat="server">
                                        <asp:ListItem Value="">ȫ��</asp:ListItem>
                                        <asp:ListItem Value="0">����</asp:ListItem>
                                        <asp:ListItem Value="1">����</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    �����Ӽ�
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:TextBox ID="txtorder_add_price" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    ���ۼӼ�
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:TextBox ID="txttrade_add_price" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    ���
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:DropDownList ID="drptype" runat="server">
                                        <asp:ListItem Value="">ȫ��</asp:ListItem>
                                        <asp:ListItem Value="0">��ˮ</asp:ListItem>
                                        <asp:ListItem Value="1">����ˮ</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    <asp:Button ID="query" runat="server" Text="��ѯ" OnClick="query_Click" />
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:Button ID="cancel" runat="server" Text="����" OnClick="cancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </td>
            <td style="height: 185px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <div align="center">
                </div>
                <asp:GridView ID="showData" runat="server" BackColor="White" BorderColor="#DEDFDE"
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AllowPaging="True"
                    AutoGenerateColumns="False" OnPageIndexChanging="showData_PageIndexChanging"
                       OnRowDataBound="GridView1_RowDataBound" 
                    ForeColor="Black" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="product_type_id" HeaderText="��Ʒ���ID" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                            ItemStyle-BorderWidth="2px">
                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                            </ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="product_type_name" HeaderText="��Ʒ�������" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                            ItemStyle-BorderWidth="2px">
                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                            </ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="product_spec_weight" HeaderText="��Ʒ���" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                            ItemStyle-BorderWidth="2px">
                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                            </ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="product_state" HeaderText="��Ʒ״̬" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                            ItemStyle-BorderWidth="2px">
                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                            </ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="order_add_price" HeaderText="�����Ӽ�" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                            ItemStyle-BorderWidth="2px">
                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                            </ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="trade_add_price" HeaderText="���ۼӼ�" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                            ItemStyle-BorderWidth="2px">
                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                            </ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="type" HeaderText="���" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                            ItemStyle-BorderWidth="2px">
                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                            </ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <br />
                <br />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
