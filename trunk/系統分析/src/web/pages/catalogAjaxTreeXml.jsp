<?xml version="1.0"?>
<%@page language="java" contentType="text/xml;charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jstl/core" prefix="c" %>

<tree>
<c:forEach var="n" items="${catalogList}" varStatus="a">
	<c:set var="action" value="${contextPath}/catalogs.html?ajaxtreexml=true&parentid=${n.id}"/>
	<tree text="<c:out value='${n.name}'/>" src='<c:out value='catalogs.html?ajaxtreexml=true&parentid=${n.id}'/>' action="<c:out value='search.html?query=${n.queryString}'/>" />
</c:forEach>
</tree>