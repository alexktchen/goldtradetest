<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gold_AdminLogin.aspx.cs" Inherits="GoldTradeNaming.Web.gold_AdminLogin"  ResponseEncoding="gb2312"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">




    <script type="text/vbscript" language="vbscript">

Dim Digest 
dim ErrorID
sub ShowErr(Msg)
	ErrorID = true
	Document.Writeln "<FONT COLOR='#FF0000'>"
	Document.Writeln "<P>&nbsp;</P><P>&nbsp;</P><P>&nbsp;</P><P ALIGN='CENTER'><B>ERROR:</B>"
	Document.Writeln "<P>&nbsp;</P><P ALIGN='CENTER'>"
	Document.Writeln Msg
	Document.Writeln "<P>&nbsp;</P><P>&nbsp;</P><P>&nbsp;</P>"
	Document.Writeln "<P ALIGN='CENTER'><a href='gold_AdminLogin.aspx'  class='blue01'>返回</a> "
	Document.Writeln "</FONT>"
End Sub

function CheckData()
	Digest = "0123456789abcdef"
	On Error Resume Next
	dim rtn
	dim Formtest
	Set Formtest = Document.forms("CheckForm")
	dim sIAID,sIAPWD,sRandNo
	//sRandNo=Formtest.randNo.Value
	//sRandNo=Formtest.TextBox1.Value
	sIAID = Formtest.edtiaid.Value
	sIAPWD = Formtest.edtiaupin.Value
	If (sIAID) = ""  Then
		ShowErr "账号不能为空!" 
		CheckData() = false
		Exit Function
	End If	
	If (sIAPWD) = ""  Then
		ShowErr "用户密码不能为空!"	
		CheckData = false
		Exit Function
	End If
	ErrorID = false
	
	//查找IA100锁
	rtn = IA100Client.IA100Find()
	if rtn<>0 then
		ShowErr "ErrorCode:"&CStr(IA100Client.IA100GetLastError())	
		CheckData = false
		Exit Function		
	end if 
	
	//打开IA100锁
	rtn = IA100Client.IA100OPEN(sIAID,sIAPWD)
	if rtn <> 0 then
		ShowErr "ErrorCode:"&CStr(IA100Client.IA100GetLastError())		
		CheckData = false
		Exit Function
	End If
	
	//获取GUID
	dim IAguid
	iaguid = "0123456789abcdef"
	IAguid = IA100Client.IA100GetGUID
	if IAguid = "" then
		ShowErr "ErrorCode:"&CStr(IA100Client.IA100GetLastError())		
		CheckData = false
		Exit Function
	End If	
	
	//进行硬件MD5运算
	//dim sessn 
	// sessn = Session["Message"].ToString()
	
	Digest = IA100Client.IA100MD5 ("<%=Session["Message"].ToString()%>")
		If Err Then 
				ShowErr "MD5 Error"
				CheckData = false
				Exit function
		End If	
		
			ssDigest.innerHTML = "<input type='hidden' name='Digest' Value='" & Digest & "'>"//客户端摘要
			ssIAID.innerHTML = "<input type='hidden' name='GUID' Value='" & IAGUID & "'>"  //IA100锁硬件ID
End function

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>管理员登录</title>
    <link type="text/css" rel="stylesheet" href="CSS/IATest.css" />

    
</head>
<body text="#000000" bgcolor="#FFFFFF">
<form ID="CheckForm" method="post"  action="IA100Verify.aspx" onsubmit="CheckData()">
<object classid="clsid:A3C4268D-14AD-40A1-87E0-90275DAE76B8" id = "IA100Client" name = "IA100Client" STYLE="LEFT: 0px; TOP: 0px" width=50 height=50></object>
<table width="528" border="0" align="center" cellpadding="0" cellspacing="0" class="main">



<script type="text/vbscript" language="vbscript">
		Document.Writeln "<span id=ssDigest></span>"
		Document.Writeln "<span id=ssIAID></span>"
</script>
 
      <tr>
        <td height="100" class="ctbody2"><div align="center" class="ctbody">IA100身份认证测试</div></td>
      </tr>
      <tr>
        <td height="309" ><table width="506"  border="0" cellpadding="2" cellspacing="0">
          <tr>
            <td width="187" height="33">&nbsp;</td>
            <td colspan="2">
                <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                <input id="randNo" name="randNo" type="hidden" />
               </td>
            <td width="98">&nbsp;</td>
          </tr>
          <tr>
            <td><div align="right" class="ctbody3">账号：</div></td>
            <td colspan="2"><input name="edtiaid" type="text" class="cttextboxt" id="edtiaid" size="20"/></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td><div align="right" class="ctbody3">密码：</div></td>
            <td colspan="2"><input name="edtiaupin" type="password" class="cttextboxt" id="edtiaupin" value="" size="20" />            </td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td height="25"><div align="left"><span class="ctbody3"><a href="Init.htm" class="blue01">
                </a> </span></div></td>
            <td width="76"><input type="submit" name="Submit" value="进入"/></td>
            <td width="129"><input type="reset" name="Submit2" value="重置"/></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td height="29">              <div align="center" class="blue01 style1">
              <div align="right"><span class="ctbody3"></span></div>
            </div></td>
            <td>&nbsp;</td>
            <td><span class="ctbody3"></span></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td colspan="3"><table width="386" border="0" cellspacing="0">
              <tr>
                <td width="21">&nbsp;</td>
                <td width="197"><div align="right"><span class="ctbody3"><span class="blue01 style1"><a href="Init.htm">安装IA100插件</a></span></span></div></td>
                <td width="162"><div align="center"><span class="ctbody3"><span class="blue01 style1"><a href="lib/setup.exe">下载插件安装</a></span></span></div></td>
              </tr>
            </table></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td></td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      </table>
  </form>

</body>
</html>
