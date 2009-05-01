<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" AutoEventWireup="true" CodeBehind="franchiser_index.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_index" Title="欢迎登录黄金交易系统" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 20%;
        }
        .style2
        {
            width: 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
                            <asp:HyperLink ID="lblSendInfo" NavigateUrl="~/stock_main/receive.aspx"  runat="server"></asp:HyperLink>
                          
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
