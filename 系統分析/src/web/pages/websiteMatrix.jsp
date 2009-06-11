<?xml version="1.0"?>
<%@ page language="java" errorPage="/error.jsp" pageEncoding="UTF-8" contentType="text/xml; charset=utf-8" %>
<%@ taglib uri="http://java.sun.com/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jstl/fmt" prefix="fmt" %>

<ajaxresponse>
<c:forEach items="${websiteList}" varStatus="a">
<item>
<text><![CDATA[<strong>
<strong><c:out value="${a.current.name}"/><strong><br/>
<c:out value="${a.current.id}"/>
]]>
</text>
<value>
<c:out value="${a.current.name}"/>
</value>
<id>
<c:out value="${a.current.id}"/>
</id>
<name>
<c:out value="${a.current.name}"/>
</name>
<url>
<c:out value="${a.current.url}"/>
</url>
</item>
</c:forEach>
</ajaxresponse>