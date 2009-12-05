<%@ Page Language="C#" MasterPageFile="~/Franchiser.Master" AutoEventWireup="true" CodeBehind="FranChgPswd.aspx.cs" Inherits="GoldTradeNaming.Web.User_Login.FranChgPswd" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="CSS/IAtest.css" rel="stylesheet" type="text/css"/>

<script language="" type="text/vbscript">
<!--
function SetPin()
	dim rtn
	dim username,userpin,newuserpin,pass
	username = aspnetForm.edtusername.value
	userpin = aspnetForm.edtuserpin.value
	newuserpin = aspnetForm.edtnewuserpin.value
	pass = aspnetForm.edtpass.value
	rtn = aspnetForm.IA100Client.IA100Find()//查找IA100锁
	rtn = aspnetForm.IA100Client.IA100OPEN(username,userpin)
	if newuserpin = pass then
		rtn = aspnetForm.IA100Client.IA100ChangePWD(newuserpin)
		if rtn =0 then
			MsgBox "用户密码修改成功！"
		else
			MsgBox "修改出错，Error:"&CStr(aspnetForm.IA100Client.IA100GetLastError())
		end if 
	else
		MsgBox "请输入正确的确认密码！"
	end if 
end function	
-->
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table width="348" border="1" align="center" bgcolor="#dfe7df">
        <tr>
            <td class="">
    <object classid="clsid:A3C4268D-14AD-40A1-87E0-90275DAE76B8" id = "IA100Client" name = "IA100Client" STYLE="LEFT: 0px; TOP: 0px" width=50 height=50">
    </object>
    
            </td>
            <td width="155">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="">
                <div align="right" class="ctbody3">
                    帐号：</div>
            </td>
            <td width="155" align="left">
                <input name="edtusername" type="text" class="cttextboxt" id="edtusername" size="20"/></td>
        </tr>
        <tr>
            <td class="">
                <div align="right" class="ctbody3">
                    旧密码：</div>
            </td>
            <td align="left">
                <input name="edtuserpin" type="password" class="cttextboxt" id="edtuserpin" size="20"/></td>
        </tr>
        <tr>
            <td class="">
                <div align="right" class="ctbody3">
                    新密码：</div>
            </td>
            <td align="left">
                <input name="edtnewuserpin" type="password" class="cttextboxt" id="edtnewuserpin" size="20"/></td>
        </tr>
        <tr>
            <td class="">
                <div align="right" class="ctbody3">
                    确认新密码：</div>
            </td>
            <td align="left">
                <input name="edtpass" type="password" class="cttextboxt" id="edtpass" size="20"/></td>
        </tr>
        <tr>
            <td  align="right">
                    <input name="btnSetUserPin" type="button" id="btnSetUserPin3" value="修改密码" onclick="SetPin()"/></td>
            <td align="left">
                <input name="Submit" type="reset" value="全部重填"/></td>
        </tr>
    </table>

</asp:Content>
