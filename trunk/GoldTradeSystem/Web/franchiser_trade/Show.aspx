<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_trade.Show"
    Title="显示页" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
        }
        .style3
        {
            width: 322px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;<div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <table align="left" width="100%">
        <tr>
            <td align="right" class="style3">
                交易单号：
            </td>
            <td align="left">
                <asp:TextBox ID="txttrade_id" runat="server" Width="173px"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td class="style3" align="right">
                交易日期 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtBeginDate" runat="server" Style="margin-left: 0px" Width="82px"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/image/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBeginDate"
                    Format="yyyy/MM/dd" PopupButtonID="ImageButton1" />
                ～<asp:TextBox ID="txtEndDate" runat="server" Width="82px"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/image/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                    Format="yyyy/MM/dd" PopupButtonID="ImageButton2" />
            </td>
        </tr>
        <tr>
            <td align="center" class="style3">
                &nbsp;
            </td>
            <td align="left">
                <font color="red">
                    <asp:Label ID="lblQueryMsg" runat="server" Width="400px"></asp:Label></font>
            </td>
        </tr>
        <tr>
            <td align="left" class="style3">
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" Style="margin-left: 0px" />
                <asp:Button ID="btnReNew" runat="server" Text="重设" OnClick="btnReNew_Click" />
            </td>
        </tr>
        <tr align="center">
            <td class="style1" colspan="2">
                <div runat="server" id="divTrade">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                        <asp:BoundField DataField="trade_time" HeaderText="交易时间" />
                                        <asp:BoundField DataField="trade_total_weight" HeaderText="交易总重量" />
                                        <asp:BoundField DataField="trade_total_money" HeaderText="交易总金额" DataFormatString="{0:#0.00}" />
                                        <asp:CommandField CancelText="取消" DeleteText="刪除" EditText="編輯" SelectText="查看" ShowSelectButton="True"
                                            UpdateText="更新" ShowCancelButton="False" ShowDeleteButton="False" HeaderText="操作" />
                                    </Columns>
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
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
            <td class="style2" colspan="2">
                <div runat="server" id="divTradeDesc">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvTradeDesc" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    AllowPaging="True" AutoUpdateAfterCallBack="true" BorderColor="#DEDFDE" BorderStyle="None"
                                    BorderWidth="1px" Width="100%" CellPadding="4" OnSelectedIndexChanged="gvTrade_SelectedIndexChanged"
                                    OnPageIndexChanging="gvTradeDesc_PageIndexChanging" ForeColor="Black" GridLines="Vertical">
                                    <FooterStyle BackColor="#CCCC99" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <Columns>
                                        <asp:BoundField DataField="trade_id" HeaderText="交易单编号" />
                                        <asp:BoundField DataField="product_id" HeaderText="产品类别ID" />
                                        <asp:BoundField DataField="product_type_name" HeaderText="产品类别名称" />
                                        <asp:BoundField DataField="product_spec_id" HeaderText="产品规格" />
                                        <asp:BoundField DataField="trade_amount" HeaderText="交易数量" />
                                        <asp:BoundField DataField="trade_weight" HeaderText="交易重量" />
                                        <asp:BoundField DataField="gold_trade_price" HeaderText="结算单价" DataFormatString="{0:#0.00}" />
                                        <asp:BoundField DataField="trade_money" HeaderText="交易金额" DataFormatString="{0:#0.00}" />
                                    </Columns>
                                    <PagerStyle ForeColor="Black" BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
