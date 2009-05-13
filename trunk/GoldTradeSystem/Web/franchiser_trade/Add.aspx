<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_trade.Add"
    Title="增加页" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div runat="server" id="divType">
        请选择你要交易的类型：
        <asp:ImageButton ID="ibGold" ImageUrl="~/image/1_1.jpg" runat="server" OnClick="ibGold_Click" />
        <asp:ImageButton ID="ibSilver" ImageUrl="~/image/1_2.jpg" runat="server" OnClick="ibSilver_Click" />
        <asp:HiddenField ID="hfType" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <div runat="server" id="divGold">
        <table width="100%" align="center">
            <tr>
                <td align="left">
                    <anthem:GridView ID="gvTrade" runat="server" AutoGenerateColumns="False" BackColor="White"
                        DataKeyNames="product_type_id" AutoUpdateAfterCallBack="True" BorderColor="#DEDFDE"
                        BorderStyle="Inset" BorderWidth="1px" Width="100%" CellPadding="1" OnDataBound="gvTrade_DataBound"
                        ForeColor="Black" UpdateAfterCallBack="True">
                        <FooterStyle BackColor="#CCCC99" />
                        <RowStyle BackColor="#F7F7DE" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="product_type_name" HeaderText="产品名称" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px">
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                                </ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="product_spec_weight" HeaderText="规格(克)" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="realtime_base_price" HeaderText="基础金价(元/克)" ItemStyle-HorizontalAlign="Center"
                                DataFormatString="{0:#0.00}">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="trade_add_price" HeaderText="交易加价(元/克)" ItemStyle-HorizontalAlign="Center"
                                DataFormatString="{0:#0.00}">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock_num" HeaderText="库存数量" ItemStyle-HorizontalAlign="Center"
                                DataFormatString="{0:#0}">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock_left" HeaderText="库存重量(克)" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="数量" ItemStyle-HorizontalAlign="left" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtProdNum" AutoPostBack="true" OnTextChanged="ProdNumChg" Width="50px"
                                        runat="server"></asp:TextBox>
                                    <asp:Label ID="lblProdNum" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="重量小计(克)" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdWht" runat="server" Width="100px" Text="0 g"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="价格小计(元)" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblMoneyCount" runat="server" Width="100px" Text="0 元"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    </anthem:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div runat="server" id="divSilver">
        <table width="100%" align="center">
            <tr>
                <td align="left">
                    <anthem:GridView ID="gvTrade2" runat="server" AutoGenerateColumns="False" BackColor="White"
                        DataKeyNames="product_type_id" AutoUpdateAfterCallBack="True" BorderColor="#DEDFDE"
                        BorderStyle="Inset" BorderWidth="1px" Width="100%" CellPadding="1" OnDataBound="gvTrade2_DataBound"
                        ForeColor="Black" UpdateAfterCallBack="True">
                        <FooterStyle BackColor="#CCCC99" />
                        <RowStyle BackColor="#F7F7DE" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="product_type_name" HeaderText="产品名称" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px">
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" Wrap="false">
                                </ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="product_spec_weight" HeaderText="规格(克)" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="price" HeaderText="价格(元/克)" ItemStyle-HorizontalAlign="Center"
                                DataFormatString="{0:#0.00}">
                                <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock_num" HeaderText="库存数量" ItemStyle-HorizontalAlign="Center"
                                DataFormatString="{0:#0}">
                                <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock_left" HeaderText="库存重量(克)" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="数量" ItemStyle-HorizontalAlign="left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtProdNum2" AutoPostBack="true" OnTextChanged="ProdNumChg2" Width="50px"
                                        runat="server"></asp:TextBox>
                                    <asp:Label ID="lblProdNum2" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="重量小计(克)" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdWht2" runat="server" Width="100px" Text="0 g"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="价格小计(元/克)" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblMoneyCount2" runat="server" Width="100px" Text="0 元"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    </anthem:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" runat="server" id="divBtn">
        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" Style="cursor: pointer;"
            ToolTip="请保存后提交" />
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" Style="cursor: pointer;"
            ToolTip="请先保存再提交" /><br />
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnSubmit"
            DisplayModalPopupID="ModalPopupExtender1" />
        <br />
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnSubmit"
            PopupControlID="PNL" OkControlID="ButtonOk" CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
        <asp:Panel ID="PNL" runat="server" Style="display: none; width: 200px; background-color: White;
            border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
            你的账户可用余额为：<asp:Label ID="lblCanUseMoney" runat="server" Text=""></asp:Label><br />
            你的交易总总量为：<asp:Label ID="lblTotalWeight" runat="server" Text=""></asp:Label><br />
            你的交易总金额为：<asp:Label ID="lblTotalMoney" runat="server" Text=""></asp:Label><br />
            确定要提交吗？
            <br />
            <br />
            <div style="text-align: right;">
                <asp:Button ID="ButtonOk" runat="server" Text="是" />
                <asp:Button ID="ButtonCancel" runat="server" Text="否" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
