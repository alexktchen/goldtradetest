<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" AutoEventWireup="true" CodeBehind="Add_Type.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order.Add_Type" Title="在线订货" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<br>
请选择你要交易的类型：<br>
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="黄金" 
                    onclick="ImageButton1_Click" ImageUrl="~/image/1_1.jpg" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="ImageButton2" runat="server"  ToolTip="白银"
                    onclick="ImageButton2_Click" ImageUrl="~/image/1_2.jpg" />
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
    </table>

<style>

.box3{position:relative;zoom:1;padding:1em 1.5em;margin:.5em 0 1em 0; background:#f1f6de;width:400px}
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
订货注意事项：<br>
1.请确认好订货产品和金额，提交以后无法修改。

</div>
<span class="bl"></span><span class="br"></span>
</div>
</asp:Content>
