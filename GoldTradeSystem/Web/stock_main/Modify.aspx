<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GoldTradeNaming.Web.stock_main.Modify" Title="�޸�ҳ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		
	</td>
	<td height="25" width="*" align="left">
		<asp:label id="lblid" runat="server" Visible="False"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		�����̱��
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtfranchiser_code" runat="server" Width="200px" 
            ReadOnly="True" BackColor="Silver"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		����������
	</td>
	<td height="25" width="*" align="left">
	<asp:TextBox ID="txtFranchiser_name" runat="server" Width="200px"
	     ReadOnly="true" BackColor="Silver"></asp:TextBox>
	</td>
	</tr>
	<tr>
	<td height="25" width="30%" align="right">
		��Ʒ���ID
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtproduct_id" runat="server" Width="200px" ReadOnly="True" 
            BackColor="Silver"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		��Ʒ���ID
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtproduct_spec_id" runat="server" Width="200px" 
            ReadOnly="True" BackColor="Silver"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
	    ��Ʒ����
	</td>
	<td height="25" width="*" align="left">
	 <asp:TextBox id="txtproduct_name" runat="server" Width="200px" ReadOnly="True" 
            BackColor="Silver"></asp:TextBox>
	</td>
	</tr>
	<tr>
	<td height="25" width="30%" align="right">
		�������
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtstock_total" runat="server" Width="200px" 
            BackColor="Silver"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		���ÿ��
	</td>
	<td height="25" width="*" align="left">
	<asp:TextBox id="txtstock_left" runat="server" Width="200px" 
            ontextchanged="txtstock_left_TextChanged"></asp:TextBox>
            </td></tr>
            <tr>
            <td height="25" width="30%" align="right">
	
	      </td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtins_user" runat="server" Width="200px" ReadOnly="True" 
            Visible="False"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtins_date" runat="server" Width="200px" ReadOnly="True" 
            Visible="False"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
	
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtupd_user" runat="server" Width="200px" ReadOnly="True" 
            Visible="False"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtupd_date" runat="server" Width="200px" ReadOnly="True" 
            Visible="False"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" colspan="2"><div>
		<asp:Button ID="btnAdd" runat="server" Text="�ύ" OnClick="btnAdd_Click" 
            Width="45px" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="ȡ��" onclick="btnCancel_Click" />
	&nbsp;</div></td></tr>
</table>

</asp:Content>
