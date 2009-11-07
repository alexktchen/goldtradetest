<%@ Page Language="C#"MasterPageFile="~/Franchiser.master" AutoEventWireup="true" CodeBehind="send_produc_show.aspx.cs" Inherits="GoldTradeNaming.Web.send_desc.send_produc_show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div style="display: none">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>

    <table style="width:100%;">
      <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" align="right">
              
            </td>
            <td style="width: 20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <fieldset>
                 <legend></legend>
                <div>
                    <table style="width:100%;">
                     
                        <tr>
                             <td style="width: 50%" align="right">
                             经销商名称
                               </td>
                            <td>
                                <asp:TextBox ID="txtFranchiserName" runat="server" Width="200px" 
                                    BackColor="Silver" Visible="true" ReadOnly="True"></asp:TextBox>
                             </td>
                        </tr>
                        
                        <tr>
                          <td style="width: 50%" align="right">
                              发货单号</td>
                            <td>
                                <asp:TextBox ID="txtSendId" runat="server" Width="200px"
                                BackColor="Silver" Visible="true" ReadOnly=true></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                        <td style="width:50%" align="right">发货总重量</td>
                        <td><asp:TextBox ID="txtTotalWeight" runat="server" Width="200px"
                        BackColor="Silver" Visible="true" ReadOnly="true"></asp:TextBox></td>
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
            <td >
                <asp:GridView ID="showData" runat="server" Width="100%" BackColor="White" 
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    AutoGenerateColumns="False" AllowPaging="True" 
                    onpageindexchanging="showData_PageIndexChanging" ForeColor="Black" 
                    GridLines="Vertical" Height="45px">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:BoundField DataField="product_spec_id" HeaderText="产品规格" />
                        <asp:BoundField DataField="product_name" HeaderText="产品名称" />
                        <asp:BoundField DataField="send_amount" HeaderText="发货数量" />
                        <asp:BoundField DataField="ins_date" HeaderText="发货时间" />
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <input type="button" onclick="javascript:window.close()" value="关闭" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>