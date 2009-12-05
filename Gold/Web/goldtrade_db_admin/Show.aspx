<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.goldtrade_db_admin.Show" Title="查看管理员" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		<asp:HiddenField ID="hdnAdminID" runat="server" Visible="False" />
<asp:HiddenField ID="hdnAdminNm" runat="server" Visible="False" />
<table width="100%">
<tr>
<td align="center">
    <table cellSpacing="0" cellPadding="0" border="0" 
        style="height: 175px; width: 82%">
	<tr>
	<td align="center" height="25">
	 <fieldset>
            <legend>查询</legend>
		<table style="width:62%;">
            <tr>            
                <td style="width:431px" align="right">
                    <asp:Label ID="Label1" runat="server" Text="管理员编号 "></asp:Label>
                </td>
                <td colspan="2" align="left">
		<asp:TextBox ID="txt_sysadmin_id" runat="server" Width="245px" MaxLength="9"></asp:TextBox>
		        </td>
            </tr>
            <tr>
                <td style="width: 431px" align="right">
                    <asp:Label ID="Label2" runat="server" Text="管理员姓名 "></asp:Label>
                </td>
                <td colspan="2" align="left">
		<asp:TextBox id="txtsys_admin_name" runat="server" Width="245px"></asp:TextBox>
	            </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 431px">
                    &nbsp;</td>
                <td style="width: 111px">
		<asp:Button ID="btnQry" runat="server" Text="· 查询 ·" OnClick="btnQry_Click" ></asp:Button>
		        </td>
                <td style="width: 364px" align="left">
		<asp:Button ID="Reset1" runat="server" Text="· 重设· " onclick="Reset1_Click1" /></td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </fieldset>
        </td></tr>
</table>

</td>
</tr>
<tr>
<td align="center">
    <div>
    
        <asp:GridView ID="grd_AdminInfo" runat="server" AutoGenerateColumns="False" 
             AllowPaging="True" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" 
            onpageindexchanging="grd_AdminInfo_PageIndexChanging" ForeColor="Black" 
            GridLines="Vertical" PageSize="8">
            <PagerSettings FirstPageText="第一页" LastPageText="最后一页" 
                NextPageText="下一页" PreviousPageText="前一页" />
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="sys_admin_id" HeaderText="管理员编号" />
                <asp:BoundField DataField="sys_admin_name" HeaderText="管理员姓名" />
                <asp:BoundField DataField="sys_admin_tel" HeaderText="管理员电话" />
                <asp:BoundField DataField="sys_admin_cellphone" HeaderText="管理员手机" />
                <asp:BoundField DataField="IA100GUID" HeaderText="IA100认证锁ID" />
                <asp:HyperLinkField HeaderText="修改" 
                    DataNavigateUrlFields="sys_admin_id,sys_admin_name,sys_admin_tel,sys_admin_cellphone,IA100GUID" 
                    Target="_blank" Text="修改" 
                    DataNavigateUrlFormatString="Modify.aspx?id={0}&name={1}&tel={2}&phone={3}&ia={4}" />
                <asp:HyperLinkField HeaderText="更改权限" 
                    DataNavigateUrlFields="sys_admin_id,sys_admin_name,sys_admin_tel,sys_admin_cellphone,IA100GUID" 
                    Target="_blank" Text="更改权限"                     
                    DataNavigateUrlFormatString="~/sys_admin_authority/Show.aspx?id={0}&name={1}&tel={2}&phone={3}&ia={4}" />
            </Columns>
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>

</td>
</tr>
</table>

</asp:Content>
