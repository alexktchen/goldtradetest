<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="GoldTradeNaming.Web.product_type.Modify" Title="�޸Ĳ�Ʒ" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" align="right" style="width: 50%">
		��Ʒ���ID
	</td>
	<td height="25" width="*" align="left">
		
		<asp:TextBox id="lblproduct_type_id" runat="server" Width="200px" ReadOnly BackColor="Silver"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 50%">
		��Ʒ�������
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtproduct_type_name" runat="server" Width="200px" 
            Height="22px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 50%">
		��Ʒ���
	</td>
	<td height="25" width="*" align="left">
	
		<asp:TextBox id="lblproduct_spec_weight" runat="server" Width="200px" ReadOnly BackColor="Silver"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" style="width: 50%">
		��Ʒ״̬
	</td>
	<td height="25" width="*" align="left">
                            <asp:DropDownList ID="drptype_Status" runat="server">
                           
                                <asp:ListItem Value="0" >����</asp:ListItem>
                                <asp:ListItem Value="1" >����</asp:ListItem>
                             
                            </asp:DropDownList>
	</td></tr>
	<tr>
	<td height="25" colspan="2">
    <div id="gold" runat=server>
        <table style="width:100%;">
            <tr>
                <td align="right" style="width:50%">
                            �����Ӽ�</td>
                <td align="left">
                            <asp:TextBox ID="txtorder_add_price" runat="server"></asp:TextBox>
	                                                </td>
            </tr>
            <tr>
                 <td align="right" style="width:50%">
                            ���ۼӼ�</td>
                <td align="left">
                            <asp:TextBox ID="txttrade_add_price" runat="server"></asp:TextBox>
	                                                </td>
            </tr>
        </table>
        </div>
   
    <div id="silver" runat="server">
        <table style="width:100%;">
            <tr>
                <td align="right" style="width:50%">
                    ��������</td>
                <td align="left">
                    <asp:TextBox ID="txtsilver" runat="server"></asp:TextBox>
                                                    </td>
            </tr>
        </table>
        </div></td>
	</tr>
	<tr>
	<td height="25" align="right" style="width: 50%">
                            ���</td>
	<td height="25" width="*" align="left">
                            <asp:DropDownList ID="drptype" runat="server" Enabled=false>
                               
                                <asp:ListItem Value="0">�ƽ�</asp:ListItem>
                                <asp:ListItem  Value="1">����</asp:ListItem>
                            </asp:DropDownList>
	</td></tr>

	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="�� �ύ ��" onclick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="�� ȡ�� ��" 
            onclick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
	<tr>
	<td height="25" colspan="2"  align="center">
        &nbsp;</td></tr>
</table>
  <asp:HiddenField ID="hid_id" runat="server" />
             <asp:HiddenField ID="hid_name" runat="server" />
             <asp:HiddenField ID="hid_weight" runat="server" />
             <asp:HiddenField ID="hid_status" runat="server" />
             <asp:HiddenField ID="hid_order" runat="server" />
             <asp:HiddenField ID="hid_trade" runat="server" />
             <asp:HiddenField ID="hid_type" runat="server" />
</asp:Content>
