<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true" CodeBehind="franchiserMoneyShow.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_money.franchiserMoneyShow" Title="我的入账" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div style="display: none">
        <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server">
        </asp:ScriptManager>
    </div> 
    <table style="width:100%;">
        <tr>
            <td style="width:20%">
                &nbsp;</td>
            <td>
             <fieldset>
                    <legend>我的入帐</legend>
                <div>
                     <table style="width:100%;">
                    <tr>
                        <td align="right" class="style1">
                          </td>
                        <td  style="width:70%" align="left">
                            <asp:TextBox ID="txtfran_id" runat="server" Width="200px" BackColor="Silver"  Visible="false"
                                BorderColor="Silver" ReadOnly="True" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
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
                        <td align="right" class="style1">
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="query" runat="server" Text="查询" onclick="query_Click" />
                        </td>
                    </tr>
                </table>
            
            </div>  
            </fieldset> 
           </td>
            <td style="width:20%"">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="showData" runat="server" Width="100%" AllowPaging="True" 
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" AutoGenerateColumns="False" 
                    onpageindexchanging="showData_PageIndexChanging" 
                    onrowdeleting="showData_RowDeleting" DataKeyNames="id" ForeColor="Black" 
                    GridLines="Vertical" onselectedindexchanged="showData_SelectedIndexChanged">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="id" Visible="False" />
                        <asp:BoundField DataField="franchiser_code" HeaderText="经销商编号" />
                        <asp:BoundField DataField="franchiser_name" HeaderText="经销商名称" />
                        <asp:BoundField DataField="franchiser_added_money" HeaderText="入帐金额" />
                        <asp:BoundField DataField="added_time" HeaderText="入帐时间" />
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
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 42%;
        }
    </style>

</asp:Content>
