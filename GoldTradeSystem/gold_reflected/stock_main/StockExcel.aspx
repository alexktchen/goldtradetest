<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="StockExcel.aspx.cs" Inherits="GoldTradeNaming.Web.stock_main.StockExcel"
    Title="库存报表" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  

<script language="JavaScript" type="text/javascript" src="../rl/WdatePicker.js"></script>

   
          
    </script>
    <style type="text/css">
        .style1
        {
            width: 329px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtfranchiser_code"

                ServicePath="~/WebService1.asmx" CompletionSetCount="10" MinimumPrefixLength="1"
                 ServiceMethod="GetCompleteDepart">

            </cc1:AutoCompleteExtender>
    <div style="">
        <table align="left" width="100%">
            <tr>
                <td align="right">
                    <asp:Label ID="lblfranchiser_code" runat="server" Text="经销商名称："></asp:Label>
                </td>
                <td align="left">
               
                    <asp:TextBox ID="txtfranchiser_code"  runat="server" Width="308px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="产品类别名称"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPrdName" runat="server" Width="308px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="月份："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDateS" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM',minDate:'2000-1',maxDate:'2050-12'})"></asp:TextBox>
                    <asp:Label ID="k" runat="server" Text="~"></asp:Label>
                    <asp:TextBox ID="txtDateE" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM',minDate:'2000-1',maxDate:'2050-12'})"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="导出EXCEL" />
                </td>
            </tr>
            <tr align="center">
                <td colspan="2">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvTradeDesc" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        AutoUpdateAfterCallBack="true" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                                        Width="100%" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDataBound="gvTradeDesc_RowDataBound"
                                        ShowFooter="True">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <Columns>
                                            <asp:BoundField DataField="franchiser_name" HeaderText="经销商名称" />
                                            <asp:BoundField DataField="product_type_name" HeaderText="产品类别名称" />
                                            <asp:BoundField DataField="product_spec_weight" HeaderText="产品规格" />
                                            <asp:BoundField DataField="ordertoal" HeaderText="订货总量" />
                                            <asp:BoundField DataField="tradetotal" HeaderText="交易总量" />
                                            <asp:BoundField DataField="stock_left" HeaderText="可用库存数量" />
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
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>
