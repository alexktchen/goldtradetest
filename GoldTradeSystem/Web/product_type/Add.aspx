<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Codebehind="Add.aspx.cs" Inherits="GoldTradeNaming.Web.product_type.Add" Title="添加产品" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
		
	<tr>
	<td height="25"  colspan="2">
    <div id="gold"  runat="server">
        <table style="width:100%;">
        <tr>
	<td height="25" align="right" style="width: 50%">
                            &nbsp;</td>
	<td height="25" width="*" align="left">
    <asp:TextBox ID="txtproduct_type_id" runat="server" Width="200px"  
            AutoPostBack="true" ontextchanged="ID_check" ReadOnly=true BackColor="Silver"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right">
		产品类别名称
	</td>
	<td height="25" width="*" align="left">
		<asp:DropDownList ID="drpproduct_type_name" runat="server" Width="200px" 
            onselectedindexchanged="name_change" AutoPostBack="true">
        </asp:DropDownList>
	    <asp:Button ID="add_product_name" runat="server" Text="添加新类别" 
            onclick="add_product_name_Click" />
	    <asp:Panel ID="Panel1" runat="server"  Width="100%">
            <asp:TextBox ID="new_name" runat="server" Width="200px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="确认" onclick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" />
        </asp:Panel>
	</td></tr>
	<tr>
	<td height="25" align="right" >
                            产品规格</td>
	<td height="25" width="*" align="left">
                            <asp:TextBox ID="txtproduct_spec_weight" runat="server" 
            Width="200px" ></asp:TextBox>
	    </td></tr>
            <tr>
                <td style="width:50%" align=right>
                    订货加价</td>
                <td  align=left>
                    <asp:TextBox ID="txtorder_add_price" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:50%" align=right>
                    销售加价</td>
                <td align=left>
                    <asp:TextBox ID="txttrade_add_price" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
    <div id="silver"   runat="server">
        <table style="width:100%;">
            <tr>
                <td  align=right style="width:50%;">
                    &nbsp;</td>
                <td align="left" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td  align=right style="width:50%;">
		产品名称</td>
                <td align="left" >
                    <asp:TextBox ID="txtSilverName" runat="server" Width="195px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  align=right style="width:50%;">
                    价格</td>
                <td align="left" >
                    <asp:TextBox ID="txtsilver" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
   </td>
	</tr>
	
	
	<tr>
	<td height="25" colspan="2"><div align="center">
		<asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click" ></asp:Button>
		<asp:Button ID="btnCancel" runat="server" Text="· 重填 ·" OnClick="btnCancel_Click" ></asp:Button>
	</div></td></tr>
	
	
	<tr>
	<td height="25" colspan="2" align="center">
        &nbsp;</td></tr>
	
</table>

</asp:Content>
