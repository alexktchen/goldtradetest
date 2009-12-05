<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgreeProtol.aspx.cs" Inherits="GoldTradeNaming.Web.User_Login.AgreeProtol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网络协议</title>
    <style type="text/css">
<!--
.tongyi {
	font-size: 14px;
	border:1px solid #7AA3C4;
	overflow-y:scroll;
	scrollbar-face-color:#7AA3C4;
	scrollbar-shadow-color:#13344E;
	scrollbar-highlight-color:#ffffff;
	scrollbar-3dlight-color:#ADC4D7;
	scrollbar-darkshadow-color:#C7D8E4;
	scrollbar-track-color:#ADC4D7;
	scrollbar-arrow-color:#13344E;
	height:500px;
	width: 600px;
	text-align: left;
}

body {
	margin:0 auto;
	background-color:#fff;
	color:#000;
	font-size: 12px;
	line-height: 28px;
	text-align: center;
}
-->
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div align="center">
     <br /> <br /> 
    </div>
    
    <div class="tongyi">
    
      <p>本协议签订双方为浙江金海贵金属有限公司（下称“浙江金海”）与其签约经销商（下称“用户”）。双方签订的其它相关协议为本协议不可分割的一部分，与本协议具有同等法律效力。<br />
        浙江金海黄金交易管理电子网络系统（下称“系统”）<br/>
        用户在使用系统的同时，承诺接受并遵守浙江金海各项相关规定。
        浙江金海有权根据需要不时地制定、修改本协议。如本协议有任何变更，浙江金海将在其系统上公布。经修订的协议一经公布后，立即自动生效。继续使用系统将表示用户接受经修订的协议。除另行明确声明外，任何使系统范围扩大或功能增强的新内容均受本协议约束。<br/>
        用户确认本协议后，本使用协议即在用户和浙江金海之间产生法律效力。请用户务必在使用之前认真阅读全部协议内容，如有任何疑问，可向浙江金海咨询。 无论用户事实上是否认真阅读了本协议，只要用户点击“已认真阅读服务协议，并接受全部内容，”的 “确认”按钮，用户的行为仍然表示其同意并签署了本使用协议。<br />
        用户有义务保护其用户名和密码不被他人使用，并承诺承担以其用户名和密码登录系统而引发的相关义务和责任。如：将以其用户名和密码登录，在系统提交的订货、交易数据和相关价格等作为结算凭据。<br />
        用户明确理解并同意，如因其违反本协议之规定，使浙江金海遭受任何损失，用户应对浙江金海提供补偿。<br />
        本公司仅按现有技术提供相应的安全措施来使本公司掌握的信息不丢失，不被滥用和变造。尽管有这些安全措施，但本公司不保证这些信息的绝对安全。系统因下列状况无法正常运作，使您无法使用各项使用时，本公司不承担损害赔偿责任，该状况包括但不限于：<br />
        本公司公告系统停机维护期间。 <br />
        电信设备出现故障不能进行数据传输的。<br /> 
        因台风、地震、海啸、洪水、停电、战争、恐怖袭击等不可抗力之因素，造成本公司系统障碍不能执行业务的。 <br />
      由于黑客攻击、电信部门技术调整或故障等原因而造成的使用中断或者延迟。</p>
      <p><strong>退出系统后再将加密狗拔出，否则出现损失自负。</strong><br />
        与本协议有关的争议由温州仲裁委员会进行仲裁。<br />
        （公布日期：2009年5月1日）<br />
        </p>
    </div>
  <div align="center">
        <asp:Button ID="Button1" runat="server" Text="同意" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
