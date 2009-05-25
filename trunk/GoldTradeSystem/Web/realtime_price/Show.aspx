<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.realtime_price.Show"
    Title="基础金价管理" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: none">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager >
    </div>

<script language="JavaScript" type="text/javascript" src="../rl/WdatePicker.js"></script>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td height="25" align="right" style="width: 300px">
                <asp:Label ID="lblFrom" runat="server" Text="起始日期"></asp:Label>
                <asp:TextBox ID="txtTimeFrom" runat="server" onClick="WdatePicker()"></asp:TextBox>
            </td>
            <td height="25" align="left">
               
            </td>
            <td height="25" align="right" style="width: 300px">
                <asp:Label ID="lblTo" runat="server" Text="～终止日期"></asp:Label>
                <asp:TextBox ID="txtTimeTo" runat="server" onClick="WdatePicker()"></asp:TextBox>
            </td>
            <td height="25" align="left">
              
            </td>
            <td style="width: 300px" align="center">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查看" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <br />
                <br />
                <asp:GridView ID="gvList" runat="server" ackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
                    BorderWidth="1px" CellPadding="4" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                    OnPageIndexChanging="gvList_PageIndexChanging" ForeColor="Black" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="realtime_base_price" HeaderText="实时价格" HeaderStyle-Wrap="false"
                            DataFormatString="{0:#0.00}">
                            <HeaderStyle Wrap="False"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Wrap="false"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="realtime_time" HeaderText="时间" HeaderStyle-Wrap="false">
                            <HeaderStyle Wrap="False"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="sys_admin_name" HeaderText="管理员名称" HeaderStyle-Wrap="false">
                            <HeaderStyle Wrap="False"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="sys_admin_id" HeaderText="管理员编号" HeaderStyle-Wrap="false">
                            <HeaderStyle Wrap="False"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
