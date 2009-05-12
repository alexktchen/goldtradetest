<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="goldAdminIndex.aspx.cs" Inherits="GoldTradeNaming.Web.goldAdminIndex" Title="欢迎登录黄金交易后台管理系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
        <tr align="center">
            <td height="25" align="right" class="style1">
                &nbsp;</td>
            <td height="25" align="center">
                &nbsp;</td>
            <td height="25" align="left" class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" class="style1">
                &nbsp;</td>
            <td height="25" align="left">
            
            <fieldset>
            <legend>最新消息</legend>
                <table style="width:100%;">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="franchiser_order/Modify.aspx?type=1" runat="server"></asp:HyperLink>
                          
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl="send_main/Show.aspx" runat="server"></asp:HyperLink>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HyperLink ID="HyperLink3"  NavigateUrl="franchiser_trade/ShowM.aspx" runat="server"></asp:HyperLink>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </fieldset>
            </td>
            <td height="25" align="left" class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" class="style1">
                &nbsp;</td>
            <td height="25" align="left">
                &nbsp;</td>
            <td height="25" align="left" class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" class="style1">
                &nbsp;</td>
            <td height="25" align="left">
                &nbsp;</td>
            <td height="25" align="left" class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td height="25" align="right" class="style1">
                &nbsp;</td>
            <td height="25" align="left">
                &nbsp;</td>
            <td height="25" align="left" class="style2">
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
