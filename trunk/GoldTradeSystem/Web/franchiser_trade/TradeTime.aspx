<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="TradeTime.aspx.cs" Inherits="GoldTradeNaming.Web.franchiser_trade.TradeTime" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%" align="center">
        <table>
            <tr>
                <td colspan="2" align="left">
                    �ɽ���ʱ�䣺
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtdtFrom" runat="server" Width="130px" Height="16px" ValidationGroup="Demo1">
                    </asp:TextBox>��
                </td>
                <td>
                    <asp:TextBox ID="txtdtTo" runat="server" Width="130px" Height="16px" ValidationGroup="Demo1">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtdtFrom"
                        Mask="99:99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError" MaskType="Time" AcceptAMPM="false" CultureName="en-US" />
                    <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                        ControlToValidate="txtdtFrom" IsValidEmpty="False" EmptyValueMessage="ʱ�䲻��Ϊ��"
                        InvalidValueMessage="ʱ���ʽ����" ValidationGroup="Demo1" Display="Dynamic" TooltipMessage="������ʱ��/24Сʱ��" />
                </td>
                <td>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdtTo"
                        Mask="99:99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError" MaskType="Time" AcceptAMPM="false" CultureName="en-US" />
                    <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender3"
                        ControlToValidate="txtdtTo" IsValidEmpty="False" EmptyValueMessage="ʱ�䲻��Ϊ��" InvalidValueMessage="ʱ���ʽ����"
                        ValidationGroup="Demo1" Display="Dynamic" TooltipMessage="������ʱ��/24Сʱ��" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary runat="Server" ValidationGroup="Demo1" ID="validationSummary1"
                        ShowSummary="true" />
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="�ύ" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
