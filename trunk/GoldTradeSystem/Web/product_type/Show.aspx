<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeBehind="show.aspx.cs" Inherits="GoldTradeNaming.Web.product_type.product_type_index" Title="查看产品" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <table style="width:100%;">
    <tr>
    
     <td>
     </td>
    <td align="right">
        &nbsp;</td>
    <td></td>
    </tr>
             <tr>
            <td style="height: 185px">
                </td>
            <td style="width:80%; height: 185px;">
            <fieldset>
            <legend>查询</legend>
            <div>
            
            
            
            
            
            
                <table style="width:100%;">
                    <tr>
                        <td align="right"  style="width:50%">
                            产品类别ID</td>
                        <td  align="left"  style="width:50%">
                            <asp:TextBox ID="type_ID" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right"  style="width:50%">
                            产品类别名称</td>
                        <td  align="left"  style="width:50%">
                            <asp:TextBox ID="type_Name" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right"  style="width:50%">
                            产品规格</td>
                        <td  align="left"  style="width:50%">
                            <asp:TextBox ID="type_Kind" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right"  style="width:50%">
                            产品状态</td>
                        <td  align="left"  style="width:50%">
                            <asp:DropDownList ID="drptype_Status" runat="server">
                              <asp:ListItem  Value="">全部</asp:ListItem>
                                <asp:ListItem Value="0" >启用</asp:ListItem>
                                <asp:ListItem Value="1" >禁用</asp:ListItem>
                             
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right"  style="width:50%">
                            订货加价</td>
                        <td  align="left"  style="width:50%">
                            <asp:TextBox ID="txtorder_add_price" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right"  style="width:50%">
                            销售加价</td>
                        <td  align="left"  style="width:50%">
                            <asp:TextBox ID="txttrade_add_price" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right"  style="width:50%">
                            类别</td>
                        <td  align="left"  style="width:50%">
                            <asp:DropDownList ID="drptype" runat="server">
                                <asp:ListItem Value="">全部</asp:ListItem>
                                <asp:ListItem Value="0">黄金</asp:ListItem>
                                <asp:ListItem  Value="1">白银</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right"  style="width:50%">
                            <asp:Button ID="query" runat="server" Text="查询" onclick="query_Click" />
                        </td>
                        <td  align="left"  style="width:50%">
                            <asp:Button ID="cancel" runat="server" Text="重置" onclick="cancel_Click" />
                        </td>
                    </tr>
                </table>
            
            
            
            
            
            
            </div>
            </fieldset>   
              
              
           </td>
            <td style="height: 185px">
                </td>
        </tr>
        
        
        <tr>
         <td>
         </td>
        
         <td><div align="center">
         
         </div>

             <asp:GridView ID="showData" runat="server" BackColor="White" 
                 BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 Width="100%" AllowPaging="True" AutoGenerateColumns="False" 
                 onpageindexchanging="showData_PageIndexChanging" 
                 ForeColor="Black" GridLines="Vertical" 
                 >
                 <FooterStyle BackColor="#CCCC99" />
                 <RowStyle BackColor="#F7F7DE" />
                 <Columns>
                     <asp:BoundField DataField="product_type_id" HeaderText="产品类别ID" />
                     <asp:BoundField DataField="product_type_name" HeaderText="产品类别名称" />
                     <asp:BoundField DataField="product_spec_weight" HeaderText="产品规格" />
                     <asp:BoundField DataField="product_state" HeaderText="产品状态" />
                     <asp:BoundField DataField="order_add_price" HeaderText="订货加价" />
                     <asp:BoundField DataField="trade_add_price" HeaderText="销售加价" />
                     <asp:BoundField DataField="type" HeaderText="类别" />
                 </Columns>
                 <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                 <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                 <AlternatingRowStyle BackColor="White" />
             </asp:GridView>
             <br />
             <br />
         </td>
        
        
        <td>
        </td>
        </tr>
    </table>




</asp:Content>
