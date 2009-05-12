<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="MoneyInfo.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_info.MoneyInfo" Title="无标题页" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td >
                &nbsp;</td>
            <td align="right" style="width:80%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
            </td>
            <td align="right" style="width:80%">
                <fieldset>
            <legend>查询</legend>
            <div>
            
                <table style="width:100%;">
                    <tr>
                        <td  style="width:50%" align="right">
                          经销商名称</td>
                        <td  style="width:50%" align="left">
                            <asp:TextBox ID="txtfran_id" runat="server" Width="200px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%; height: 3px;">
                            入帐总额</td>
                        <td align="left" style="height: 3px">
                            <asp:TextBox ID="txtadd_money" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
            
            </div>
            </fieldset>&nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="showDate" runat="server" Width="100%" AllowPaging="True" 
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" AutoGenerateColumns="False" 
                    onpageindexchanging="showDate_PageIndexChanging" 
                     DataKeyNames="id" ForeColor="Black" 
                    GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="franchiser_added_money" HeaderText="入帐金额" />
                        <asp:BoundField DataField="added_time" HeaderText="入帐时间" />
                        <asp:BoundField DataField="checked" HeaderText="审核状态" Visible="False" />
                        
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="返回" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
