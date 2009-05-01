<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.sys_admin_authority.Show"
    Title="显示页" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="plSearch" runat="server">
        <table width="100%">
            <tr>
                <td align="center">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td height="25" align="right" style="width: 48%">
                                <asp:HiddenField ID="hdnAdminID" runat="server" Visible="False" />
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:HiddenField ID="hdnAdminNm" runat="server" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="25" colspan="2">
                                <table style="width: 62%;">
                                    <tr>
                                        <td style="width: 431px" align="right">
                                            <asp:Label ID="Label1" runat="server" Text="管理员编号 "></asp:Label>
                                        </td>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txt_sysadmin_id" runat="server" Width="245px" MaxLength="9"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 431px" align="right">
                                            <asp:Label ID="Label2" runat="server" Text="管理员姓名 "></asp:Label>
                                        </td>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txtsys_admin_name" runat="server" Width="245px"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 431px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 111px">
                                            <asp:Button ID="btnSearch1" runat="server" Text="· 查询 ·" 
                                                onclick="btnSearch_Click" ></asp:Button>
                                        </td>
                                        <td style="width: 364px" align="left">
                                            <asp:Button ID="Reset" runat="server" Text="· 重设· " onclick="Reset_Click"  />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div>
                        <asp:GridView ID="grd_AdminInfo" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4" OnPageIndexChanging="grd_AdminInfo_PageIndexChanging" ForeColor="Black"
                            GridLines="Vertical" 
                            onselectedindexchanged="grd_AdminInfo_SelectedIndexChanged">
                            <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="前一页" />
                            <FooterStyle BackColor="#CCCC99" />
                            <RowStyle BackColor="#F7F7DE" />
                            <Columns>
                                <asp:BoundField DataField="sys_admin_id" HeaderText="管理员编号" />
                                <asp:BoundField DataField="sys_admin_name" HeaderText="管理员姓名" />
                                <asp:BoundField DataField="sys_admin_tel" HeaderText="管理员电话" />
                                <asp:BoundField DataField="sys_admin_cellphone" HeaderText="管理员手机" />
                                <asp:ButtonField ButtonType="Link" CommandName="select"  HeaderText="修改权限" Text="修改" />
                            </Columns>
                            <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="plAuth" runat="server">
        <table width="100%">
            <tr>
                <td colspan="2" align="left">
                    <asp:Label ID="lblAdminName" runat="server" Text=""></asp:Label>的权限如下：
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td rowspan="2">
                                金价管理
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbChgPrice" Text="修改实时金价"  runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbViewPrice" Text="查看实时金价" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                                订单管理
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewOrder" Text="查看订单" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbConOrder" Text="确认订单" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbChgOrder" Text="修改订单" runat="server"  Visible="false"/>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                                产品管理
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewProduct" Text="查看产品" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbChgProduct" Text="修改产品" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAddProduct" Text="添加产品" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                                财务管理
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewAddMoney" Text="查看入账" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAddMoney" Text="新增入账 " runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbCheckAddMoney" Text="审核入账 " runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td rowspan="3">
                                经销商管理
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewFran" Text="查看经销商" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbChgFran" Text="修改经销商" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAddFran" Text="添加经销商" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                                交易管理
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewTrade" Text="查看交易" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbTradeReport" Text="销售报表" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbTradeLock" Text="交易时间锁定" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="5">
                                系统管理
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbAddAdmin" Text="添加管理员" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbViewAdmin" Text="查看管理员" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAuthMgn" Text="权限管理" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbSearchIA" Text="认证锁查询" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAddIA" Text="认证锁添加" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                库存管理
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbStockMgn" Text="修改库存" runat="server" />
                            </td>
                        </tr>
                          <tr>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewStockLog" Text="查看库存修改记录" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="1">
                                在线发货
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbSend" Text="在线发货" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
                    <asp:Button ID="btnCancle" runat="server"
                        Text="取消" onclick="btnCancle_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
