<%@page language="java" contentType="text/xml;charset=UTF-8"%>
<%@page import="org.ajaxtags.helpers.AjaxXmlBuilder" %>
<%@page import="com.foxconn.cic.model.Catalog" %>
<jsp:useBean id="catalog" type="com.foxconn.cic.model.Catalog" scope="request"></jsp:useBean>
<%
AjaxXmlBuilder xmlBuilder = new AjaxXmlBuilder();
xmlBuilder.addItemAsCData(
        "Callout Header",
        "<p>This is a test of the 'callout.view'</p><p>You asked about:<br/><b>"
            + catalog.getName() + "</b>.</p>");
response.getWriter().print(xmlBuilder.toString());
%>