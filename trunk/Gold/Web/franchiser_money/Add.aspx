<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_money.Add" Title="�������" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: none">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div> 
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" align="right" style="width: 51%">
		�����̱��
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_code" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 51%">
		���ʽ��
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_added_money" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td align="right" style="width: 51%; height: 31px;">
		����ʱ��
	</td>
	<td width="*" align="left" style="height: 31px">
		<asp:TextBox ID="txtadded_time" runat="server" Width="200px"></asp:TextBox>
                            <cc1:CalendarExtender ID="dtTo_CalendarExtender" runat="server" Enabled="True" 
                               Format="yyyy-MM-dd"   TargetControlID="txtadded_time">
                            </cc1:CalendarExtender>
	</td></tr>
	
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="�� �ύ ��" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="�� ���� ��" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
	
	<tr>
	<td height="25" colspan="2">&nbsp;</td></tr>
</table>

</asp:Content>
