<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="myModify.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order.myModify"
    Title="无标题页" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="plModify" runat="server">
        <table width="100%s">
            <tr>
                <td height="25" align="right" style="width: 20%">
                    订单号：
                </td>
                <td height="25" align="left" style="width: 20%">
                    <asp:Label ID="lblOrderNum" runat="server"></asp:Label>
                </td>
                <td height="25" align="right" style="width: 20%">
                    基础金价：
                </td>
                <td height="25" style="width: 40%" align="left">
                    <asp:Label ID="lblPrice" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    总金额：
                </td>
                <td height="25" align="left">
                    <asp:Label ID="lblTotalMoney" runat="server"></asp:Label>
                </td>
                <td height="25" align="right">
                    运输方式
                </td>
                <td height="25" align="left">
                    <asp:RadioButtonList ID="transway" runat="server" RepeatDirection="Horizontal" Width="270px">
                        <asp:ListItem Value="0">航空</asp:ListItem>
                        <asp:ListItem Value="1">邮寄</asp:ListItem>
                        <asp:ListItem Value="2">自取</asp:ListItem>
                        <asp:ListItem Value="3">其他</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    收货地址
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="txtfranchiser_order_address" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td height="25" align="right">
                    邮政编码
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="txtfranchiser_order_postcode" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    收货人
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="txtfranchiser_order_handle_man" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td height="25" align="right">
                    收货人电话
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="txtfranchiser_order_handle_tel" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    收货人手机
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="txtfranchiser_order_handle_phone" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <font color="red">
                        <asp:Label ID="lblMsg" runat="server" Width="400px"></asp:Label>
                    </font>
                </td>
                <td align="center" colspan="2" height="25">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="plSearch" runat="server">
        <table width="100%">
            <tr>
                <td align="right" style="width: 50%">
                    经销商编号
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFranID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    订单号
                </td>
                <td align="left">
                    <asp:TextBox ID="txtfranchiser_order_id" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    订单状态
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpfranchiser_order_state" runat="server">
                        <asp:ListItem Value="0">已订</asp:ListItem>
                        <asp:ListItem Value="1">发货中</asp:ListItem>
                        <asp:ListItem Value="2">已发完</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 40%">
                    <asp:Button ID="query" runat="server" Text=" 查询" OnClick="query_Click" />
                </td>
                <td align="left">
                    <asp:Button ID="reset" runat="server" Text="重置" OnClick="reset_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 100%">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                        DataKeyNames="franchiser_order_id" CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging"
                        ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <FooterStyle BackColor="#CCCC99" />
                        <RowStyle BackColor="#F7F7DE" />
                        <Columns>
                            <asp:HyperLinkField HeaderText="订单号" DataNavigateUrlFields="franchiser_order_id"
                                DataNavigateUrlFormatString="../franchiser_order_desc/Show_Admin.aspx?id={0}"
                                Target="_blank" DataTextField="franchiser_order_id" />
                            <asp:BoundField DataField="franchiser_order_time" HeaderText="订货时间" HeaderStyle-Wrap="false"
                                ItemStyle-Wrap="false" DataFormatString="{0:yyyy-MM-dd}" >
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_order_amount_money" HeaderText="订单总额" DataFormatString="{0:#0.00}"
                                HeaderStyle-Wrap="false" >
                                <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_order_trans_type" HeaderText="运输方式" 
                                HeaderStyle-Wrap="false" >
                                <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_order_address" HeaderText="收货地址" 
                                HeaderStyle-Wrap="false" >
                                <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_order_postcode" HeaderText="邮编" 
                                HeaderStyle-Wrap="false" >
                                <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_order_handle_man" HeaderText="收货人" 
                                HeaderStyle-Wrap="false" >
                                <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_order_handle_tel" HeaderText="收货人电话" 
                                HeaderStyle-Wrap="false" >
                                <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_order_handle_phone" HeaderText="收货人手机" 
                                HeaderStyle-Wrap="false" >
                                <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_order_price" HeaderText="实时金价" DataFormatString="{0:#0.00}" />
                            <asp:CommandField CancelText="取消" DeleteText="刪除" EditText="修改" SelectText="修改" ShowSelectButton="True"
                                ItemStyle-Wrap="false" ItemStyle-Width="80px" UpdateText="更新" ShowCancelButton="False"
                                ShowDeleteButton="False" HeaderText="操作" >
                                <ItemStyle Width="80px" Wrap="False" />
                            </asp:CommandField>
                        </Columns>
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
