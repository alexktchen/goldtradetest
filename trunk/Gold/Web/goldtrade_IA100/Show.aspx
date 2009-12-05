<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.goldtrade_IA100.Show" Title="查看认证锁" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table width="100%">
<tr>
<td align="center">
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td style="width: 8%"></td>
	<td align="center" height="25" style="width: 628px" >
		<fieldset><legend>查看认证锁</legend>
		<table style="width:83%;">
            <tr>            
                <td style="width: 244px">
                    &nbsp;</td>
                <td style="width: 583px">
                    <asp:Label ID="GUID" runat="server" Text="认证锁ID"></asp:Label>
                </td>
                <td colspan="2" align="left">
		<asp:TextBox ID="txt_IA100_guid" runat="server" Width="342px"></asp:TextBox>
		        </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 244px">
                    &nbsp;</td>
                <td style="width: 583px">
                    <asp:Label ID="GUIDState" runat="server" Text="认证锁状态 "></asp:Label>
                </td>
                <td colspan="2" align="left">
		            <asp:ListBox ID="lstIA100_State" runat="server" Height="51px" Width="136px">
                        <asp:ListItem Value="2" Selected="True">全部</asp:ListItem>
                        <asp:ListItem Value="0">可用</asp:ListItem>
                        <asp:ListItem Value="1">禁用</asp:ListItem>
                    </asp:ListBox>
	            </td>
                <td style="width: 348px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 244px">
                    &nbsp;</td>
                <td style="width: 583px">
                    &nbsp;</td>
                <td style="width: 111px">
		<asp:Button ID="btnAdd" runat="server" Text="· 查询 ·" OnClick="btnAdd_Click" ></asp:Button>
		        </td>
                <td style="width: 328px" align="left">
		<input id="Reset1" type="reset" value="· 重设· " /></td>
                <td style="width: 348px">
                    &nbsp;
		</td>
            </tr>
        </table></fieldset></td>
	<td align="center" height="25" >
		&nbsp;</td></tr>
</table>

</td>
</tr>
<tr>
<td align="center">
                    &nbsp;</td>
</tr>
<tr>
<td align="center">
    <div>
    
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            onpageindexchanging="GridView1_PageIndexChanging" PageSize="8">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="IA100GUID" HeaderText="认证锁唯一ID" />
                <asp:BoundField DataField="IA100Key" HeaderText="认证锁密钥" />
                <asp:BoundField DataField="IA100SuperPswd" HeaderText="认证锁超级密码" />
                <asp:BoundField DataField="IA100State" HeaderText="认证锁状态" />
                <asp:BoundField DataField="StateChangeReason" HeaderText="锁改动原因" />
                <asp:HyperLinkField DataNavigateUrlFields="IA100GUID,IA100Key,IA100SuperPswd,IA100State,StateChangeReason" 
                    DataNavigateUrlFormatString="Modify.aspx?guid={0}&amp;key={1}&amp;spwsd={2}&amp;state={3}&amp;rsn={4}" 
                    HeaderText="修改" Target="_blank" Text="修改" />
            </Columns>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
        
    </div>

</td>
</tr>
</table>
</asp:Content>
