<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ include file="/common/taglibs.jsp"%>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
    <head>
        <%@ include file="/common/meta.jsp" %>
        <title><decorator:title/> | <fmt:message key="webapp.name"/></title>

        <link rel="stylesheet" type="text/css" media="all" href="<c:url value='/styles/${appConfig["csstheme"]}/theme1col.css'/>" />
        <link rel="stylesheet" type="text/css" media="print" href="<c:url value='/styles/${appConfig["csstheme"]}/print.css'/>" />
		
		<script type="text/javascript" src="<c:url value='/scripts/jquery/jquery-1.1.2.js'/>"></script>
		<script type="text/javascript" src="<c:url value='/scripts/jquery/interface.js'/>"></script>
		<script type="text/javascript" src="<c:url value='/scripts/jquery/jquery.selectboxes.js'/>"></script>
		
		<script type="text/javascript" src="<c:url value='/styles/niftycube/scripts/niftycube.js'/>"></script>
		<script type="text/javascript" src="<c:url value='/styles/niftycube/scripts/niftylayout.js'/>"></script>
        <decorator:head/>
    </head>
<body<decorator:getProperty property="body.id" writeEntireProperty="true"/><decorator:getProperty property="body.class" writeEntireProperty="true"/>>

    <div id="page">
        <div id="header" class="clearfix">
            <jsp:include page="/common/header.jsp"/>
        </div>

        <div id="content" class="clearfix">
        	<c:set var="currentMenu" scope="request"><decorator:getProperty property="meta.menu"/></c:set>
        	<div id="nav">
                <div class="wrapper">
                    <h2 class="accessibility">Navigation</h2>
                    <jsp:include page="/common/menu.jsp"/>
                </div>
                <hr />
            </div><!-- end nav -->
            <div id="main">
                <%@ include file="/common/messages.jsp" %>
                <h1><decorator:getProperty property="page.heading"/></h1>
                <decorator:body/>
            </div>

            
            	
            
        </div>

        <div id="footer" class="clearfix">
            <jsp:include page="/common/footer.jsp"/>
        </div>
    </div>
</body>
</html>
