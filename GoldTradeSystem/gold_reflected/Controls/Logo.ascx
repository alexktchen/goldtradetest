<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Logo.ascx.cs" Inherits="GoldTradeNaming.Web.Controls.Logo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<style type="text/css">
.wenzi {
	font-size: 12px;
	color: #FFFFFF;
}
</style>



<div id="head">

<div id="head1"><img name="head_1" src="../image/head_1.gif" width="288" height="89" border="0"></div>

<div class="head2" >
  <table width="350" border="0" align="right">
    <tr class="wenzi">
      <td><asp:Label ID="lblDateNow" runat="server"></asp:Label></td>
      <td width="130"> <asp:Label ID="lbl" runat="server" Text="黄金实时基础金价"></asp:Label></td>
      <td width="50"><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
    </tr>
  </table>
</div>

</div>