

<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="websiteList.title"/></title>
<content tag="heading"><fmt:message key="websiteList.heading"/></content>
<meta name="menu" content="WebsiteMenu"/>

<c:set var="buttons">
	<p/>
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editWebsite.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
    <input type="button" onclick="location.href='<c:url value="/websites.html?method=exportOPML"/>'"
        value="Export OPML"/>
        
</c:set>

<FORM method="GET" action="searchWebsite.html">
<spring:bind path="command.query">
	<INPUT type="text" class="text large" name="query" value="<c:out value="${status.value}"/>" />
</spring:bind>
<INPUT type="submit" value="Search" />
</FORM>
<hr/>
<p />
<c:if test="${! empty searchResults}">
	<P />Search took <c:out value="${searchResults.searchTime}" /> ms
</c:if>	
<authz:authorize ifAllGranted="admin">
<c:out value="${buttons}" escapeXml="false"/>
</authz:authorize>


<c:if test="${! empty searchResults}">
<display:table defaultsort="1" name="searchResults.hits" cellspacing="0" cellpadding="0" requestURI=""
    id="hit" pagesize="50" class="table websiteList" export="true" sort="list">
	<display:column sortable="true" title="Score">
		<fmt:formatNumber type="percent" value="${hit.score}" />
	</display:column>
    <display:column property="data.name" escapeXml="true" sortable="true"
    	url="/editWebsite.html" paramId="id" paramProperty="data.id"
         titleKey="website.name"/>
    <display:column property="data.parent.name" escapeXml="true" sortable="true"
        url="/editWebsite.html" paramId="id" paramProperty="data.parent.id"
        titleKey="website.parent"/>
    <display:column property="data.status" escapeXml="true" sortable="true"
         titleKey="website.status"/>
    <display:column escapeXml="true" sortable="true"
         titleKey="website.type">
         <c:if test="${hit.data.type == 1}">News</c:if>
         <c:if test="${hit.data.type == 2}">Price</c:if>
    </display:column>
     <display:column sortable="true" titleKey="website.url">
    	<a target="_blank" href="<c:out value='${hit.data.url}'/>">URL</a>
    </display:column>
    <display:column  escapeXml="true" sortable="true" titleKey="website.createdDate">
         <fmt:formatDate value="${hit.data.createdDate}" type="date"/>
    </display:column>
    <display:column escapeXml="true" sortable="true" titleKey="website.updatedDate">
         <fmt:formatDate value="${hit.data.updatedDate}" type="date"/>
    </display:column>
    <display:column>
    	<a target="_blank" href="websites.html?method=exportProperties&id=<c:out value='${hit.data.id}'/>">Properties</a>
    </display:column>
    <display:setProperty name="paging.banner.item_name" value="website"/>
    <display:setProperty name="paging.banner.items_name" value="websites"/>
</display:table>
<authz:authorize ifAllGranted="admin">
<c:out value="${buttons}" escapeXml="false"/>
</authz:authorize>
</c:if>


<script type="text/javascript">
    highlightTableRows("websiteList");
</script>
