<%@ Page Language="C#" ResponseEncoding="gb2312" %>
<%
//随机数生成
	Random randomGenerator = new Random(DateTime.Now.Millisecond);
	String RndStr = "";
	for(int i=0; i<32; i++)
		RndStr += Convert.ToChar(randomGenerator.Next(97,122));
	Session["Message"] = RndStr;
%>

<script  language="vbscript" type="text/vbscript">
<!--
Dim Digest 
dim ErrorID
sub ShowErr(Msg)
	ErrorID = true
	Document.Writeln "<FONT COLOR='#FF0000'>"
	Document.Writeln "<P>&nbsp;</P><P>&nbsp;</P><P>&nbsp;</P><P ALIGN='CENTER'><B>ERROR:</B>"
	Document.Writeln "<P>&nbsp;</P><P ALIGN='CENTER'>"
	Document.Writeln Msg
	Document.Writeln "<P>&nbsp;</P><P>&nbsp;</P><P>&nbsp;</P>"
	Document.Writeln "<P ALIGN='CENTER'><a href='AdminLogin.aspx'  class='blue01'>返回</a> "
	Document.Writeln "</FONT>"
End Sub

function CheckData()
	Digest = "0123456789abcdef"
	On Error Resume Next
	dim rtn
	dim Formtest
	Set Formtest = Document.forms("CheckForm")
	dim sIAID,sIAPWD
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
	Digest = IA100Client.IA100MD5 ("<%=Session["Message"].ToString()%>")
		If Err Then 
				ShowErr "MD5 Error"
				CheckData = false
				Exit function
		End If
		
		
			ssDigest.innerHTML = "<input type='hidden' name='Digest' Value='" & Digest & "'>"//客户端摘要
			ssIAID.innerHTML = "<input type='hidden' name='GUID' Value='" & IAGUID & "'>"  //IA100锁硬件ID
End function
-->
</script>



<html>
<head id="Head1" runat="server">
    <title>管理员入口</title>
    
<style type="text/css">

body {
	margin:0 auto;
	background-color:#000000;
	color:#000;
	font-size: 12px;
	line-height: 28px;
	text-align: center;
}

td{

	font-size: 12px;
}


#dengl1 {
	width:900px;
	height:554px;
	z-index:1;
	background-image: url(../image/dengl_bg.gif);
}
#dengl2 {
	width:900px;
	height:29px;
	z-index:2;
}

#foot {
	position:relative;
	left:0px;
	width:900px;
	height:31px;
	z-index:4;
	background-image: url(../image/foot_bg.gif);
	text-align: center;
	color: #FFFFFF;
	font-size: 12px;
	line-height: 31px;
}

</style>
</head>
<body text="1000">
  
<form id="CheckForm" method="post" action="AdminVerify.aspx" onSubmit="CheckData()">
    
        <script language="VBScript" type="text/vbscript">
		Document.Writeln "<span id=ssDigest></span>"
		Document.Writeln "<span id=ssIAID></span>"
        </script>
        
        
<div id="dengl1">

<table border="0" cellpadding="0" cellspacing="0" width="520">
<!-- fwtable fwsrc="未命名" fwpage="页面 1" fwbase="dengl_1_r1_c1.gif" fwstyle="Dreamweaver" 

fwdocid = "2033459842" fwnested="1" -->
  <tr>
   <td width="79" height="116"></td>
   <td><img name="dengl_1_r1_c1_r1_c2" src="../image/dengl_1_r1_c1_r1_c2.gif" width="347" 

height="116" border="0" id="dengl_1_r1_c1_r1_c2" alt="" /></td>
   <td width="94" height="116"></td>
  </tr>
  <tr>
   <td><img name="dengl_1_r1_c1_r2_c1" src="../image/dengl_1_r1_c1_r2_c1.gif" width="79" 

height="326" border="0" id="dengl_1_r1_c1_r2_c1" alt="" /></td>
   <td>
   
   
   <table align="left" border="0" cellpadding="0" cellspacing="0" width="347">
	  <tr>
	   <td><img name="dengl_1_r1_c1_r2_c2" src="../image/dengl_1_r1_c1_r2_c2.gif" width="347" 

height="54" border="0" id="dengl_1_r1_c1_r2_c2" alt="" /></td>
	  </tr>
	  <tr>
	   <td width="347" height="272" background="../image/dengl_1_r1_c1_r3_c2.gif">
       
       <table width="300" border="0" align="center">
                                    <tr>
                                        <td width="106" align="right">
                                            <asp:Label ID="Label1" runat="server" Text="管理员ID"></asp:Label>                                        </td>
                                        <td width="184" align="left">
                                            <input name="edtiaid" type="text" class="cttextboxt" id="edtiaid" maxlength="16" size="15">                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Text="管理员密码"></asp:Label>                                        </td>
                                        <td align="left">
                                           <input name="edtiaupin" type="password" class="cttextboxt" id="edtiaupin" value="" maxlength="16" size="15">                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                           <input type="submit" name="Submit" value="登录"/> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                             <input type="reset" name="Submit2" value="重置"/>                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            
                                            <span class="ctbody3"><span class="blue01"><br><a href="lib/setup.exe">下载插件安装</a></span></span>                                        </td>
                                    </tr>
                                </table>
                                
                                
              </td>
	  </tr>
	</table></td>
   <td><img name="dengl_1_r1_c1_r2_c3" src="../image/dengl_1_r1_c1_r2_c3.gif" width="94" 

height="326" border="0" id="dengl_1_r1_c1_r2_c3" alt="" /></td>
  </tr>
</table>


</div>

  </form>

   <div id="foot">技术支持：13625778033 Copyright &copy;2009-2010 金牛企业</div>
   <object classid="clsid:A3C4268D-14AD-40A1-87E0-90275DAE76B8" id="IA100Client" name="IA100Client"
        style="left: 0px; top: 0px" width="1" height="1">
    </object>

</body>
</html>
