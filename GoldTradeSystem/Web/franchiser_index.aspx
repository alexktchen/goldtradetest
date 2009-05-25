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
   
    </table>



<style>

.box3{position:relative;zoom:1;padding:1em 1.5em;margin:.5em 0 1em 0; background:#f1f6de;width:450px}
.box3 .tl,.box3 .tr,.box3 .bl,.box3 .br {width:5px;height:5px;position:absolute;background:url('../images/200901172113470.gif') no-repeat;overflow:hidden;}
.box3 .cc{
	
	padding:5px;
	text-align: left;
}
.box3 .tl {left:0;top:0;}
.box3 .tr {right:0;top:0;background-position:0 -5px;}
.box3 .bl {left:0;bottom:0;_bottom:-1px;background-position:0 -10px;}
.box3 .br {right:0;bottom:0;_bottom:-1px;background-position:0 -15px;}
</style>
<div class="box3">
<span class="tl"></span><span class="tr"></span>
<div class="cc">

本系统注意事项：<br>
1.请勿打开多个页面同时进行操作。<br>
2.离开系统时请先退出系统后再将加密狗拔出，否则出现损失自负。<br>
3.登陆后的操作时间为20分钟,请在20分钟之内完成操作。<br>
4.请勿频繁刷新操作页面。<br>
5.请勿多人同时操作同一页面。
</div>
<span class="bl"></span><span class="br"></span>
</div>

</asp:Content>
