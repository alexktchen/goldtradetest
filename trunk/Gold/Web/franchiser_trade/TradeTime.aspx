<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeBehind="TradeTime.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_trade.TradeTime" 
Title="交易时间锁定" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="width: 100%" align="center">
       <script language="JavaScript" type="text/javascript" src="../rl/WdatePicker.js"></script>
        <table>
            <tr>
                <td colspan="2" align="left">
                    可交易时间：
                </td>
            </tr>
            <tr>
                <td>
                     <asp:TextBox ID="txtdtFrom" runat="server" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'H:mm:ss'})"  Width="130px" Height="16px">
                    </asp:TextBox>～
                </td>
                <td>
                    <asp:TextBox ID="txtdtTo" runat="server" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'H:mm:ss'})"  Width="130px" Height="16px">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblFrom" runat="server" Text="必须为24小时时间格式：(23:59:59)"></asp:Label>
                   <%-- <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtdtFrom"
                        Mask="99:99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError" MaskType="Time" AcceptAMPM="false" CultureName="en-US" />
                    <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                        ControlToValidate="txtdtFrom" IsValidEmpty="False" EmptyValueMessage="时间不能为空"
                        InvalidValueMessage="时间格式不对" ValidationGroup="Demo1" Display="Dynamic" TooltipMessage="请输入时间/24小时制" />
              --%>  </td>
                <td>
                
                   <%-- <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdtTo"
                        Mask="99:99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError" MaskType="Time" AcceptAMPM="false" CultureName="en-US" />
                    <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender3"
                        ControlToValidate="txtdtTo" IsValidEmpty="False" EmptyValueMessage="时间不能为空" InvalidValueMessage="时间格式不对"
                        ValidationGroup="Demo1" Display="Dynamic" TooltipMessage="请输入时间/24小时制" />
              --%>  </td>
            </tr>
            <tr>
                <td>
                  <%--  <asp:ValidationSummary runat="Server" ValidationGroup="Demo1" ID="validationSummary1"
                        ShowSummary="true" />--%>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
