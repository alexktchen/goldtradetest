<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_money.Manage" Title="�������" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: none">
        <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server">
        </asp:ScriptManager>
    </div> 
<script language="JavaScript" type="text/javascript" src="../rl/WdatePicker.js"></script>


    <table style="width:100%;">
        <tr>
            <td >
                </td>
            <td align="right" style="width:83%">
                &nbsp;</td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="height: 169px">
                </td>
            <td style="width: 83%; height: 169px">
            <fieldset>
            <legend>��ѯ</legend>
            <div>
            
                <table style="width:100%;">
                    <tr>
                        <td  style="width:50%" align="right">
                          �����̱��</td>
                        <td  style="width:50%" align="left">
                            <asp:TextBox ID="txtfran_id" runat="server" Width="200px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%; height: 3px;">
                            ���ʽ��</td>
                        <td align="left" style="height: 3px">
                            <asp:TextBox ID="txtadd_money" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">
                            ����ʱ��</td>
                        <td align="left">
                            <asp:TextBox ID="txttime_from" runat="server" onClick="WdatePicker()"></asp:TextBox>
                         
                            <asp:Label ID="Label1" runat="server" Text="~"></asp:Label>
                            <asp:TextBox ID="txtTime_to" runat="server" onClick="WdatePicker()"></asp:TextBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">
                            ���״̬</td>
                        <td align="left">
                            <asp:DropDownList ID="drpIsCheck" runat="server">
                                <asp:ListItem Value="">ȫ��</asp:ListItem>
                                <asp:ListItem Value="0">�����</asp:ListItem>
                                <asp:ListItem Value="1">δ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">
                            <asp:Button ID="query" runat="server" Text="��ѯ" onclick="query_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="reset" runat="server" Text="����" onclick="reset_Click" />
                        </td>
                    </tr>
                </table>
            
            </div>
            </fieldset>    
           </td>
            <td style="height: 169px">
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 83%">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                <asp:GridView ID="showDate" runat="server" Width="100%" AllowPaging="True" 
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" AutoGenerateColumns="False" 
                    onpageindexchanging="showDate_PageIndexChanging" 
                    onrowdeleting="showDate_RowDeleting" DataKeyNames="id" ForeColor="Black" 
                    GridLines="Vertical" onrowediting="showDate_RowEditing">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="id" Visible="False" />
                        <asp:BoundField DataField="franchiser_code" HeaderText="�����̱��" />
                        <asp:BoundField DataField="franchiser_name" HeaderText="����������" />
                        <asp:BoundField DataField="franchiser_added_money" HeaderText="���ʽ��" />
                        <asp:BoundField DataField="added_time" HeaderText="����ʱ��" />
                        <asp:BoundField DataField="checked" HeaderText="�Ƿ����" />
                        
                      <%--  <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton ID="del" CommandName="CmdDEL" Text="ɾ��" runat="server" ></asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                        <asp:CommandField DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('ȷ��ɾ����')&quot;&gt;ɾ��&lt;/div&gt; " 
                            ShowDeleteButton="True" />
                        <asp:CommandField EditText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('ȷ�������')&quot;&gt;���&lt;/div&gt; " 
                            ShowEditButton="True" />
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
