<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FranExcel.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_trade.FranExcel" Title="交易报表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 313px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>

    <script language="JavaScript" type="text/javascript" src="../rl/WdatePicker.js"></script>

    <table align="left" width="100%">
        <tr>
            <td align="right" class="style1" >
                交易单号：
            </td>
            <td align="left">
                <asp:TextBox ID="txttrade_id" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td  align="right" class="style1">
                交易日期 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtBeginDate" runat="server" Style="margin-left: 0px" 
                    onClick="WdatePicker()"></asp:TextBox>
                ～<asp:TextBox ID="txtEndDate" runat="server"  onClick="WdatePicker()"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1" >
                产品类型：
            </td>
            <td align="left">
                <asp:DropDownList ID="drpType" runat="server">
                    <asp:ListItem Value="2">全部</asp:ListItem>
                    <asp:ListItem Value="0">升水</asp:ListItem>
                    <asp:ListItem Value="1">非升水</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td align="left" class="style1" >
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" Style="margin-left: 0px" />
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="导出EXCEL" />
            </td>
        </tr>       
        <tr align="center">
            <td  colspan="2">
                <div runat="server" id="divTradeDesc">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvTradeDesc" runat="server" AutoGenerateColumns="False" 
                                    BackColor="White" AutoUpdateAfterCallBack="true" BorderColor="#DEDFDE" BorderStyle="None"
                                    BorderWidth="1px" Width="100%" CellPadding="4"
                                    ForeColor="Black" GridLines="Vertical" 
                                    onrowdatabound="gvTradeDesc_RowDataBound" ShowFooter="True">
                                    <FooterStyle BackColor="#CCCC99" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <Columns>
                                        <asp:BoundField DataField="trade_id" HeaderText="交易单号" />
                                        <asp:BoundField DataField="trade_time" HeaderText="交易时间"  />
                                        <asp:BoundField DataField="realtime_base_price" HeaderText="实时金价"  />
                                        <asp:BoundField DataField="product_type_name" HeaderText="产品名称" />
                                        <asp:BoundField DataField="product_spec_id" HeaderText="规格" />
                                        <asp:BoundField DataField="trade_amount" HeaderText="数量" />
                                        <asp:BoundField DataField="trade_money" HeaderText="金额" />
                                    </Columns>
                                    <PagerStyle ForeColor="Black" BackColor="#F7F7DE" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
                <div runat="server" id="divSilverTradeDesc">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
