<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="BaseInfo.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_info.BaseInfo" Title="经销商基本信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="plSource" runat="server">
    <asp:HiddenField ID="keyFranId" runat="server" Visible="false" />
    <asp:HiddenField ID="keyFranName" runat="server" Visible="false" />
        <table width="100%">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25" width="45%">
                                经销商名称 
                            </td>
                            <td align="left" height="25" width="*">
                                <asp:TextBox ID="txtfranchiser_name" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25" width="45%">
                                帐面余额</td>
                            <td align="left" height="25" width="*">
                                <asp:TextBox ID="txtBalance" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25" width="45%">
                                担保款 
                            </td>
                            <td align="left" height="25" width="*">
                                <asp:TextBox ID="txtfranchiser_asure_money" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25" width="45%">
                                经销商座机 
                            </td>
                            <td align="left" height="25" width="*">
                                <asp:TextBox ID="txtfranchiser_tel" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25" width="45%">
                                经销商手机 
                            </td>
                            <td align="left" height="25" width="*">
                                <asp:TextBox ID="txtfranchiser_cellphone" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25" width="45%">
                                经销商地址 
                            </td>
                            <td align="left" height="25" width="*">
                                <asp:TextBox ID="txtfranchiser_address" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="25" width="45%">
                                认证锁ID
                            </td>
                            <td align="left" height="25" width="*">
                                <asp:TextBox ID="txtIA100GUID" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnReturn" runat="server" onclick="btnReturn_Click" Text="返回" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="25">
                                <div align="center">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
