<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="ShowNoEdit.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_info.ShowNoEdit"
    Title="查看经销商" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
   
        function SaveCase()
        {
        var s1=document.getElementById("ctl00_ContentPlaceHolder1_IA100");
        var s2=document.getElementById("ctl00_ContentPlaceHolder1_txtIA100");
        if(s1.value==s2.value)
        {
          if(confirm("確定要提交?")==true)
		    {   
		        var btnSave=document.getElementById("ctl00_ContentPlaceHolder1_btnSave");
				if(btnSave!=null)
					btnSave.click();		
		    }
		 }
		 else
		 {
		      if(confirm("更改认证锁ID会导致原来锁失效，確定要提交?")==true)
		    {   
		        var btnSave=document.getElementById("ctl00_ContentPlaceHolder1_btnSave");
				if(btnSave!=null)
					btnSave.click();		
		    }
		 }
        }   
    </script>

    <%--<asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" Style="display: none" />--%>
    <%--<asp:Panel ID="plShow" runat="server" Style="display: block">
        <table cellspacing="0" cellpadding="0" width="70%" border="0">
            <tr>
                <td height="25" align="right">
                    经销商编号
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="franchiser_code" runat="server"></asp:TextBox>
                </td>
                <td height="30" width="30%" align="right">
                    认证锁ID
                </td>
                <td height="25" align="right">
                    <asp:TextBox ID="IA100" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtIA100" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    经销商名称
                </td>
                <td height="25" align="left">
                    <asp:TextBox ID="franchiser_name" runat="server"></asp:TextBox>
                </td>
                <td height="25" align="left">
                    帐面余额
                </td>
                <td height="25" width="30%" align="left">
                    <asp:TextBox ID="franchiser_balance_money" runat="server"></asp:TextBox>
                </td>
                <td height="25" width="30%" align="right">
                    担保款
                </td>
                <td height="25" align="right">
                    <asp:TextBox ID="franchiser_asure_money" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    经销商座机
                </td>
                <td height="25" width="30%" align="left">
                    <asp:TextBox ID="franchiser_tel" runat="server"></asp:TextBox>
                </td>
                <td height="25" width="30%" align="right">
                    经销商手机
                </td>
                <td height="25" align="right">
                    <asp:TextBox ID="franchiser_cellphone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    经销商地址
                </td>
                <td height="25" width="30%" align="left">
                    <asp:TextBox ID="franchiser_address" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <font color="red">
                        <asp:Label ID="lblMsg" runat="server" Width="400px"></asp:Label></font>
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
                </td>
                <td>
                    <asp:Button ID="btSave" runat="server" Text="保存" />
                </td>
            </tr>
        </table>
    </asp:Panel>--%>
    
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtfranchiser_name"

                ServicePath="~/WebService1.asmx" CompletionSetCount="10" MinimumPrefixLength="1"
                 ServiceMethod="GetCompleteDepart">

            </cc1:AutoCompleteExtender>
    <asp:Panel ID="plSource" runat="server">
        <table width="100%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblfranchiser_code" runat="server" Text="经销商编号："></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtfranchiser_code" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblfranchiser_name" runat="server" Text="经销商名称："></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtfranchiser_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <font color="red">
                        <asp:Label ID="lblQueryMsg" runat="server" Width="400px"></asp:Label></font>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
                    &nbsp;
                    <asp:Button ID="btnReNew" runat="server" Text="重设" OnClick="btnReNew_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvList" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px"
                        AllowPaging="True" DataKeyNames="IA100GUID" BorderStyle="None" BorderColor="#DEDFDE"  OnRowDataBound="gvList_RowDataBound"   
                        AutoGenerateColumns="False" Width="100%" EditRowStyle-BackColor="#3399FF" OnPageIndexChanging="gvList_PageIndexChanging"
                        ForeColor="Black" GridLines="Vertical">
                        <FooterStyle BackColor="#CCCC99" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F7DE" />
                        <Columns>
                            <asp:BoundField DataField="franchiser_code" HeaderStyle-Wrap="false" HeaderText="经销商编号">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IA100GUID" HeaderStyle-Wrap="false" HeaderText="认证锁ID"
                                ItemStyle-Width="200px" Visible="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_name" HeaderStyle-Wrap="false" HeaderText="经销商名称">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_balance_money" DataFormatString="{0:#0.00}"
                                HeaderStyle-Wrap="false" HeaderText="帐面余额" >
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="订货可用余额">
                                            <ItemTemplate>
                                                <asp:Label ID="lblorder" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                             <asp:TemplateField HeaderText="点价可用余额">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltrade" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                            <asp:BoundField DataField="franchiser_asure_money" DataFormatString="{0:#0.00}" HeaderStyle-Wrap="false"
                                HeaderText="担保款" Visible="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_tel" HeaderStyle-Wrap="false" 
                                HeaderText="经销商座机" Visible="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_cellphone" HeaderStyle-Wrap="false" 
                                HeaderText="经销商手机" Visible="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="franchiser_address" HeaderStyle-Wrap="false" 
                                HeaderText="经销商地址" Visible="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="true" />
                            </asp:BoundField>
                           <%-- <asp:BoundField DataField="IA100GUID" HeaderText="fappid" Visible="false" />--%>
                            <asp:HyperLinkField HeaderText="基本信息" Text="查看" 
                                DataNavigateUrlFields="franchiser_code,franchiser_name"  DataNavigateUrlFormatString="BaseInfo.aspx?id={0}&name={1}"/>
                            <asp:HyperLinkField HeaderText="财务总额" DataTextField="TotalMoney" 
                                DataNavigateUrlFields="franchiser_code,franchiser_name"  DataNavigateUrlFormatString="MoneyInfo.aspx?id={0}&name={1}"/>
                            <asp:HyperLinkField HeaderText="订单总额"   DataTextField="OrderMoney"
                                DataNavigateUrlFields="franchiser_code,franchiser_name"  DataNavigateUrlFormatString="OrderInfo.aspx?id={0}&name={1}"/>
                            <asp:HyperLinkField HeaderText="交易总额"   DataTextField="TradeMoney"
                                DataNavigateUrlFields="franchiser_code,franchiser_name"  DataNavigateUrlFormatString="TradeInfo.aspx?id={0}&name={1}"/>
                            <asp:HyperLinkField HeaderText="库存信息" Text="查看"  
                                DataNavigateUrlFields="franchiser_code,franchiser_name"  DataNavigateUrlFormatString="StockInfo.aspx?id={0}&name={1}"/>
                        </Columns>
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#3399FF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
