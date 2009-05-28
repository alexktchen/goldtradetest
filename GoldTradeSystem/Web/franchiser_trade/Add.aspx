<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_trade.Add"
    Title="���߽���" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div runat="server" id="divType">
        ��ѡ����Ҫ���׵����ͣ�<br>
        <asp:ImageButton ID="ibGold" ImageUrl="~/image/1_1.jpg" runat="server" OnClick="ibGold_Click" /><br>
        <br>
        <asp:ImageButton ID="ibSilver" ImageUrl="~/image/1_2.jpg" runat="server" OnClick="ibSilver_Click" />
        <asp:HiddenField ID="hfType" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <style>
        .box3
        {
            position: relative;
            zoom: 1;
            padding: 1em 1.5em;
            margin: .5em 0 1em 0;
            background: #f1f6de;
            width: 400px;
        }
        .box3 .tl, .box3 .tr, .box3 .bl, .box3 .br
        {
            width: 5px;
            height: 5px;
            position: absolute;
            background: url('../images/200901172113470.gif') no-repeat;
            overflow: hidden;
        }
        .box3 .cc
        {
            padding: 5px;
            text-align: left;
        }
        .box3 .tl
        {
            left: 0;
            top: 0;
        }
        .box3 .tr
        {
            right: 0;
            top: 0;
            background-position: 0 -5px;
        }
        .box3 .bl
        {
            left: 0;
            bottom: 0;
            _bottom: -1px;
            background-position: 0 -10px;
        }
        .box3 .br
        {
            right: 0;
            bottom: 0;
            _bottom: -1px;
            background-position: 0 -15px;
        }
    </style>
    <div class="box3">
        <span class="tl"></span><span class="tr"></span>
        <div class="cc">
            ����ע�����<br>
            1.��ȷ�Ϻö�����Ʒ�ͽ��ύ�Ժ��޷��޸ġ�(���׺󲻿��޸�)
        </div>
        <span class="bl"></span><span class="br"></span>
    </div>
    <div runat="server" id="divGold">
        <table width="100%" align="center">
            <tr>
                <td align="left">
                    <anthem:GridView ID="gvTrade" runat="server" AutoGenerateColumns="False" BackColor="White"
                        DataKeyNames="product_type_id" AutoUpdateAfterCallBack="True" BorderColor="#DEDFDE"
                        BorderStyle="Inset" BorderWidth="1px" Width="100%" CellPadding="1" ForeColor="Black"
                        UpdateAfterCallBack="True">
                        <FooterStyle BackColor="#CCCC99" />
                        <RowStyle BackColor="#F7F7DE" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="product_type_name" HeaderText="��Ʒ����" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                                ItemStyle-BorderWidth="2px">
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" BorderStyle="Solid">
                                </ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="product_spec_weight" HeaderText="���(��)" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="realtime_base_price" HeaderText="�������(Ԫ/��)" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="trade_add_price" HeaderText="���׼Ӽ�(Ԫ/��)" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock_num" HeaderText="�������" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:#0}">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock_left" HeaderText="�������(��)" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="��������" ItemStyle-HorizontalAlign="left" ItemStyle-Wrap="false" HeaderStyle-Width="80px"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtProdNum" AutoPostBack="true" OnTextChanged="ProdNumChg" Width="100%"
                                        runat="server"></asp:TextBox>
                                    <asp:Label ID="lblProdNum" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="����С��(��)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdWht" runat="server" Width="100px" Text="0 g"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�۸�С��(Ԫ)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblMoneyCount" runat="server" Width="100px" Text="0 Ԫ"></asp:Label>
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
                        BorderStyle="Inset" BorderWidth="1px" Width="100%" CellPadding="1" ForeColor="Black"
                        UpdateAfterCallBack="True">
                        <FooterStyle BackColor="#CCCC99" />
                        <RowStyle BackColor="#F7F7DE" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="product_type_name" HeaderText="��Ʒ����" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#DEDFDE" ItemStyle-BorderStyle="Solid"
                                ItemStyle-BorderWidth="2px">
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderWidth="1px" Wrap="false">
                                </ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="product_spec_weight" HeaderText="���(��)" ItemStyle-HorizontalAlign="Center"
                                Visible="false" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="price" HeaderText="�۸�(Ԫ/��)" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock_num" HeaderText="�������" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:#0}">
                                <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock_left" HeaderText="�������(��)" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="��������" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtProdNum2" AutoPostBack="true" OnTextChanged="ProdNumChg2" Width="100%"
                                        runat="server"></asp:TextBox>
                                    <asp:Label ID="lblProdNum2" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="����С��(��)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdWht2" runat="server" Width="100px" Text="0 g"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�۸�С��(Ԫ)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblMoneyCount2" runat="server" Width="100px" Text="0 Ԫ"></asp:Label>
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
        <asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click" Style="cursor: pointer;"
            ToolTip="�뱣����ύ" />
        <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_Click" Style="cursor: pointer;"
            ToolTip="���ȱ������ύ" /><br />
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnSubmit"
            DisplayModalPopupID="ModalPopupExtender1" />
        <br />
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnSubmit"
            PopupControlID="PNL" OkControlID="ButtonOk" CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
        <asp:Panel ID="PNL" runat="server" Style="display: none; width: 200px; background-color: White;
            border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
            ����˻��������Ϊ��<asp:Label ID="lblCanUseMoney" runat="server" Text=""></asp:Label><br />
            ��Ľ���������Ϊ��<asp:Label ID="lblTotalWeight" runat="server" Text=""></asp:Label><br />
            ��Ľ����ܽ��Ϊ��<asp:Label ID="lblTotalMoney" runat="server" Text=""></asp:Label><br />
            ȷ��Ҫ�ύ��
            <br />
            <br />
            <div style="text-align: right;">
                <asp:Button ID="ButtonOk" runat="server" Text="��" />
                <asp:Button ID="ButtonCancel" runat="server" Text="��" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>