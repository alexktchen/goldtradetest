<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="ShowM.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_trade.ShowM"
    Title="查看交易" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" width="100%">
        <tr align="center">
            <td>
                <div runat="server" id="divTrade">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="center" style="width: 50%">
                                <asp:Label ID="lblfranchiser_code" runat="server" Text="经销商编号："></asp:Label>
                                <asp:TextBox ID="txtfranchiser_code" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 50%">
                                <asp:Label ID="lblfranchiser_name" runat="server" Text="经销商名称："></asp:Label>
                                <asp:TextBox ID="txtfranchiser_name" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 50%">
                                <asp:Label ID="lbltrade_id" runat="server" Text="交易单编号："></asp:Label>
                                <asp:TextBox ID="txttrade_id" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <font color="red">
                                    <asp:Label ID="lblQueryMsg" runat="server" Width="400px"></asp:Label></font>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnReNew" runat="server" Text="重设" OnClick="btnReNew_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvTrade" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    AllowPaging="True" AutoUpdateAfterCallBack="true" BorderColor="#DEDFDE" BorderStyle="None"
                                    BorderWidth="1px" Width="100%" CellPadding="4" OnSelectedIndexChanged="gvTrade_SelectedIndexChanged"
                                    OnPageIndexChanging="gvTrade_PageIndexChanging" ForeColor="Black" GridLines="Vertical">
                                    <FooterStyle BackColor="#CCCC99" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <Columns>
                                        <asp:BoundField DataField="trade_id" HeaderText="交易单编号" />
                                        <asp:BoundField DataField="franchiser_code" HeaderText="经销商编号" />
                                        <asp:BoundField DataField="franchiser_name" HeaderText="经销商名称" />
                                        <asp:BoundField DataField="trade_time" HeaderText="交易时间" />
                                        <asp:BoundField DataField="trade_total_weight" HeaderText="交易总重量" Visible="false" />
                                        <asp:BoundField DataField="trade_total_money" HeaderText="交易总金额" DataFormatString="{0:#0.00}" />
                                        <asp:CommandField CancelText="取消" DeleteText="刪除" EditText="編輯" SelectText="查看" ShowSelectButton="True"
                                            UpdateText="更新" ShowCancelButton="False" ShowDeleteButton="False" HeaderText="操作" />
                                    </Columns>
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr align="center">
            <td>
                <div runat="server" id="divTradeDesc">
                    <br />
                    <br />
                    <br />
                    <br />
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td>
                                <asp:GridView ID="gvTradeDesc" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    AllowPaging="True" AutoUpdateAfterCallBack="true" BorderColor="#DEDFDE" BorderStyle="None"
                                    BorderWidth="1px" Width="100%" CellPadding="4" OnSelectedIndexChanged="gvTrade_SelectedIndexChanged"
                                    OnPageIndexChanging="gvTradeDesc_PageIndexChanging" ForeColor="Black" GridLines="Vertical">
                                    <FooterStyle BackColor="#CCCC99" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <Columns>
                                        <asp:BoundField DataField="trade_id" HeaderText="交易单编号" />
                                        <asp:BoundField DataField="product_id" HeaderText="产品类别ID"  Visible="false"/>
                                        <asp:BoundField DataField="product_type_name" HeaderText="产品类别名称" />
                                        <asp:BoundField DataField="product_spec_id" HeaderText="产品规格" />
                                        <asp:BoundField DataField="trade_amount" HeaderText="交易数量" />
                                        <asp:BoundField DataField="trade_weight" HeaderText="交易重量" Visible="false" />
                                        <asp:BoundField DataField="gold_trade_price" HeaderText="结算单价" DataFormatString="{0:#0.00}" />
                                        <asp:BoundField DataField="trade_money" HeaderText="交易金额" DataFormatString="{0:#0.00}" />
                                    </Columns>
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <%-- <asp:Button ID="btnCancle" runat="server" Text="确定取消" OnClick="btnCancle_Click" />--%>
                                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
