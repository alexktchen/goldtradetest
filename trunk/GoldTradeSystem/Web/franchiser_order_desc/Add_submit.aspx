<%@ Page Language="C#" MasterPageFile="~/Franchiser.master" AutoEventWireup="true"
    CodeBehind="Add_submit.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_order_desc.Add_submit"
    Title="������Ϣ" %>

<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="keyType" runat="server" Visible="false" />
   <table cellspacing="0" cellpadding="0" width="100%" border="1">
        <tr>
            <td height="25" align="center" colspan="2">
                ********************************���Ķ�����Ϣ����********************************</td>
        </tr>
        
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ͻ�����&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblFranName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                ���䷽ʽ
            </td>
            <td height="25" width="*" align="left">
                
                <asp:Label ID="transway" runat="server" Text="transway"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ջ���ַ
            </td>
            <td height="25" width="*" align="left">
               
                <asp:Label ID="txtfranchiser_order_address" runat="server" Text="txtfranchiser_order_address"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                ��������
            </td>
            <td height="25" width="*" align="left">
                
                <asp:Label ID="txtfranchiser_order_postcode" runat="server" Text="txtfranchiser_order_postcode"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ջ���
            </td>
            <td height="25" width="*" align="left">
                
                <asp:Label ID="txtfranchiser_order_handle_man" runat="server" Text="txtfranchiser_order_handle_man"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ջ��˵绰��������
            </td>
            <td height="25" width="*" align="left">
               
                <asp:Label ID="txtfranchiser_order_handle_tel" runat="server" Text="txtfranchiser_order_handle_tel"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �ջ����ֻ�
            </td>
            <td height="25" width="*" align="left">
                
                <asp:Label ID="txtfranchiser_order_handle_phone" runat="server" Text="txtfranchiser_order_handle_phone"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                �������&nbsp;&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" style="width: 49%">
                ������Ʒ����&nbsp;&nbsp;&nbsp; </td>
            <td height="25" width="*" align="left">
                <asp:Label ID="lblProdType" runat="server"></asp:Label>
            </td>
        </tr>
      
        
    </table>
    
    
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td height="25" align="center">
                ********************************<asp:Label ID="Label1" runat="server" Text="������Ʒ��Ϣ"></asp:Label>
                ********************************</td>
        </tr>
        <tr>
            <td height="25" align="center">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
                    onrowcreated="GridView1_RowCreated">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="product_type_id" HeaderText="��ƷID" />
                        <asp:BoundField DataField="product_type_name" HeaderText="��Ʒ����" />
                        <asp:BoundField DataField="product_spec_id" HeaderText="���" />
                        <asp:BoundField DataField="order_product_amount" HeaderText="����" />
                        <asp:BoundField DataField="order_weight" HeaderText="����С��" />
                        <asp:BoundField DataField="order_add_price" HeaderText="�����Ӽ�" />
                        <asp:BoundField DataField="order_appraise" HeaderText="Ԥ������" />
                        <asp:BoundField HeaderText="Ԥ�����С��" DataField="AmountMoney" />
                    </Columns>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td height="25" align="center">
                �����Ķ����ܶ�Ϊ��<asp:Label ID="lblsun" runat="server" Text="lblsun"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="center">
                <asp:Button ID="Button1" runat="server" Text="��һ��" Width="100px" 
                    onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="�ύ" Width="100px" 
                    onclick="Button2_Click"/>
                <asp:Button ID="Button3" runat="server" Text="ȡ��" Width="100px" 
                    onclick="Button3_Click"  />
            </td>
        </tr>
        <tr>
            <td height="25">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    
</asp:Content>

