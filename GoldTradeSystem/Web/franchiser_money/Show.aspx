<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_money.Show" Title="查看入帐" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: none">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div> 



    <table style="width:100%;">
        <tr>
            <td >
                </td>
            <td align="right" style="width:80%">
                &nbsp;</td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
            <fieldset>
            <legend>查询</legend>
            <div>
            
                <table style="width:100%;">
                    <tr>
                        <td  style="width:50%" align="right">
                          经销商编号</td>
                        <td  style="width:50%" align="left">
                            <asp:TextBox ID="txtfran_id" runat="server" Width="200px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%; height: 3px;">
                            入帐金额</td>
                        <td align="left" style="height: 3px">
                            <asp:TextBox ID="txtadd_money" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">
                            入账时间</td>
                        <td align="left">
                            <asp:TextBox ID="txttime_from" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="dtTo_CalendarExtender" runat="server" Enabled="True" 
                               Format="yyyy-MM-dd"   TargetControlID="txttime_from">
                            </cc1:CalendarExtender>
                            <asp:Label ID="Label1" runat="server" Text="~"></asp:Label>
                            <asp:TextBox ID="txtTime_to" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtTimeTo0_CalendarExtender" runat="server" 
                                 Format="yyyy-MM-dd"  Enabled="True" TargetControlID="txtTime_to">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">
                            审核状态</td>
                        <td align="left">
                            <asp:DropDownList ID="drpIsCheck" runat="server">
                                <asp:ListItem Value="">全部</asp:ListItem>
                                <asp:ListItem Value="0">已审核</asp:ListItem>
                                <asp:ListItem Value="1">未审核</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">
                            <asp:Button ID="query" runat="server" Text="查询" onclick="query_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="reset" runat="server" Text="重置" onclick="reset_Click" />
                        </td>
                    </tr>
                </table>
            
            </div>
            </fieldset>    
           </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="showDate" runat="server" Width="100%" AllowPaging="True" 
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" AutoGenerateColumns="False" 
                    onpageindexchanging="showDate_PageIndexChanging" 
                    onrowdeleting="showDate_RowDeleting" DataKeyNames="id" ForeColor="Black" 
                    GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="id" Visible="False" />
                        <asp:BoundField DataField="franchiser_code" HeaderText="经销商编号" />
                        <asp:BoundField DataField="franchiser_name" HeaderText="经销商名称" />
                        <asp:BoundField DataField="franchiser_added_money" HeaderText="入帐金额" />
                        <asp:BoundField DataField="added_time" HeaderText="入帐时间" />
                        <asp:BoundField DataField="checked" HeaderText="是否审核" />
                        <asp:CommandField DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt; " 
                            ShowDeleteButton="True" HeaderText="操作" Visible="False" />
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
