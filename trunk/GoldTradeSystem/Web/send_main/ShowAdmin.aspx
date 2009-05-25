<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ShowAdmin.aspx.cs" Inherits="GoldTradeNaming.Web.send_main.ShowAdmin" Title="查看发货" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="width: 100%;">
        <tr>
            <td style="width: 24%;">
                &nbsp;
            </td>
            <td align="right">
                &nbsp;</td>
            <td style="width: 20%;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 24%">
                &nbsp;
            </td>
            <td>
                <fieldset>
                    <legend>发货查询</legend>
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 17%;" align="right">
                                    经销商编号</td>
                                <td style="width: 50%;" align="left">
                                    <asp:TextBox ID="txtFranID"   runat="server" Width="202px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 17%;" align="right">
                                    订单号
                                </td>
                                <td style="width: 50%;" align="left">
                                    <asp:TextBox ID="txtfranchiser_order_id" runat="server" Width="204px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 17%;" align="right">
                                    发货单号
                                </td>
                                <td style="width: 50%;" align="left">
                                    <asp:TextBox ID="txtsend_id" runat="server" Width="204px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 17%">
                                    发货状态
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpfranchiser_order_state" runat="server">
                                        <asp:ListItem Value="0">未收货</asp:ListItem>
                                        <asp:ListItem Value="1">已收货</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">全部</asp:ListItem>
                                  
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 17%">
                                    <asp:Button ID="query" runat="server" Text=" 查询" OnClick="query_Click" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="reset" runat="server" Text="重置" onclick="reset_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                &nbsp;
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging"
                    ForeColor="Black" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                    
                        <asp:BoundField DataField="franchiser_name" HeaderText="经销商" />
                          <asp:BoundField DataField="send_id" HeaderText="发货单号" />
                          <asp:BoundField DataField="franchiser_order_id" HeaderText="订单号" />
                        <asp:BoundField DataField="send_time" HeaderText="发货时间" />
                        <asp:BoundField DataField="send_amount_weight" HeaderText="发货重量" />
                        <asp:BoundField DataField="state" HeaderText="发货状态" />
                       <asp:HyperLinkField HeaderText="查看" DataNavigateUrlFields="send_id"
                            DataNavigateUrlFormatString="../send_desc/ShowAdmin.aspx?sendid={0}" Target="_blank"  Text="查看" />
                      
                      
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
