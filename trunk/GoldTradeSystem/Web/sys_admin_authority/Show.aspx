<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.sys_admin_authority.Show"
    Title="��ʾҳ" %>
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
                                            <asp:Label ID="Label1" runat="server" Text="����Ա��� "></asp:Label>
                                        </td>
                                        <td colspan="2" align="left">
                                            <asp:TextBox ID="txt_sysadmin_id" runat="server" Width="245px" MaxLength="9"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 431px" align="right">
                                            <asp:Label ID="Label2" runat="server" Text="����Ա���� "></asp:Label>
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
                                            <asp:Button ID="btnSearch1" runat="server" Text="�� ��ѯ ��" 
                                                onclick="btnSearch_Click" ></asp:Button>
                                        </td>
                                        <td style="width: 364px" align="left">
                                            <asp:Button ID="Reset" runat="server" Text="�� ���衤 " onclick="Reset_Click"  />
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
                            <PagerSettings FirstPageText="��һҳ" LastPageText="���һҳ" NextPageText="��һҳ" PreviousPageText="ǰһҳ" />
                            <FooterStyle BackColor="#CCCC99" />
                            <RowStyle BackColor="#F7F7DE" />
                            <Columns>
                                <asp:BoundField DataField="sys_admin_id" HeaderText="����Ա���" />
                                <asp:BoundField DataField="sys_admin_name" HeaderText="����Ա����" />
                                <asp:BoundField DataField="sys_admin_tel" HeaderText="����Ա�绰" />
                                <asp:BoundField DataField="sys_admin_cellphone" HeaderText="����Ա�ֻ�" />
                                <asp:ButtonField ButtonType="Link" CommandName="select"  HeaderText="�޸�Ȩ��" Text="�޸�" />
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
                    <asp:Label ID="lblAdminName" runat="server" Text=""></asp:Label>��Ȩ�����£�
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td rowspan="2">
                                ��۹���
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbChgPrice" Text="�޸�ʵʱ���"  runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbViewPrice" Text="�鿴ʵʱ���" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                                ��������
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewOrder" Text="�鿴����" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbConOrder" Text="ȷ�϶���" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbChgOrder" Text="�޸Ķ���" runat="server"  Visible="false"/>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                                ��Ʒ����
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewProduct" Text="�鿴��Ʒ" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbChgProduct" Text="�޸Ĳ�Ʒ" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAddProduct" Text="��Ӳ�Ʒ" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                                �������
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewAddMoney" Text="�鿴����" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAddMoney" Text="�������� " runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbCheckAddMoney" Text="������� " runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td rowspan="3">
                                �����̹���
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewFran" Text="�鿴������" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbChgFran" Text="�޸ľ�����" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAddFran" Text="��Ӿ�����" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="3">
                                ���׹���
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewTrade" Text="�鿴����" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbTradeReport" Text="���۱���" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbTradeLock" Text="����ʱ������" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="5">
                                ϵͳ����
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbAddAdmin" Text="��ӹ���Ա" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbViewAdmin" Text="�鿴����Ա" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAuthMgn" Text="Ȩ�޹���" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbSearchIA" Text="��֤����ѯ" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:CheckBox ID="ckbAddIA" Text="��֤�����" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                ������
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbStockMgn" Text="�޸Ŀ��" runat="server" />
                            </td>
                        </tr>
                          <tr>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbViewStockLog" Text="�鿴����޸ļ�¼" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="1">
                                ���߷���
                            </td>
                            <td colspan="1" align="left">
                                <asp:CheckBox ID="ckbSend" Text="���߷���" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnSave" runat="server" Text="����" onclick="btnSave_Click" />
                    <asp:Button ID="btnCancle" runat="server"
                        Text="ȡ��" onclick="btnCancle_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
