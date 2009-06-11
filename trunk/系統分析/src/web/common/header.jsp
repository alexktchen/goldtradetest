<%@ include file="/common/taglibs.jsp"%>
<div id="switchLocale">
<c:if test="${pageContext.request.locale.language != 'en'}">
    <a href="<c:url value='/?locale=en'/>"><fmt:message key="webapp.name"/> in English</a>
</c:if>
</div>
<div id="branding">
    <h1><a href="<c:url value="/"/>"><fmt:message key="webapp.name"/></a></h1>
</div>
<hr />

<%-- Put constants into request scope --%>
<FoxconnCIC:constants scope="request"/>
