<?xml version="1.0"?>

<%@page language="java" contentType="text/xml;charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jstl/core" prefix="c" %>
<%@ taglib uri="http://acegisecurity.org/authz" prefix="authz" %>

<%@page import="java.util.Locale"%>
<%@page import="java.text.DateFormat"%>
<%@page import="java.util.Date"%>

<%
String server=request.getServerName();
String url="http://"+server;
if(request.getServerPort()!=-1){
	url="http://"+server+":"+request.getServerPort();
}
Locale locale=  request.getLocale();
DateFormat format=DateFormat.getDateTimeInstance(DateFormat.LONG,DateFormat.SHORT, locale);
String time=format.format(new Date());
%>

<opml version="1.1">
<head>
    <title><%=url+request.getContextPath()%></title>
    <dateCreated><%=time%></dateCreated>
    <ownerName><authz:authentication operation="fullName"/></ownerName>
</head>
<body>
<outline text="Foxconn News Center">
<outline text="Today News" title="Today News" type="rss" xmlUrl="<%=url%><c:out value='${pageContext.request.contextPath}/newss.html?method=rss'/>" rssOwlUpdateInterval="60" htmlUrl="<%=url+request.getContextPath()%>" description="Description" />
<c:forEach var="n" items="${websiteList}" varStatus="a">
	<outline text="<c:out value='${n.name}'/>" title="<c:out value='${n.name}'/>" type="rss" xmlUrl="<%=url%><c:out value='${pageContext.request.contextPath}/newss.html?method=rss&websiteid=${n.id}'/>" rssOwlUpdateInterval="60" htmlUrl="<%=url+request.getContextPath()%>" description="Description" />
</c:forEach>
</outline>
</body>
</opml>