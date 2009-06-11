<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="websiteList.title"/></title>
<content tag="heading"><fmt:message key="websiteList.heading"/></content>
<meta name="menu" content="WebsiteMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editWebsite.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
    <input type="button" onclick="location.href='<c:url value="/websites.html?method=exportOPML"/>'"
        value="Export OPML"/>
</c:set>

<authz:authorize ifAllGranted="admin">
<c:out value="${buttons}" escapeXml="false"/>
</authz:authorize>

<display:table defaultsort="1" name="websiteList" cellspacing="0" cellpadding="0" requestURI=""
    id="websiteList" pagesize="25" class="table websiteList" export="true" sort="list">

    <display:column property="name" escapeXml="true" sortable="true"
    	url="/editWebsite.html" paramId="id" paramProperty="id"
         titleKey="website.name"/>
    <display:column property="parent.name" escapeXml="true" sortable="true"
         titleKey="website.parent"/>
    <display:column property="status" escapeXml="true" sortable="true"
         titleKey="website.status"/>
    <display:column property="createdDate" escapeXml="true" sortable="true"
         titleKey="website.createdDate"/>
    <display:column property="updatedDate" escapeXml="true" sortable="true"
         titleKey="website.updatedDate"/>
    <display:column>
    	<a target="_blank" href="websites.html?method=exportProperties&id=<c:out value='${websiteList.id}'/>">Properties</a>
    </display:column>
    <display:setProperty name="paging.banner.item_name" value="website"/>
    <display:setProperty name="paging.banner.items_name" value="websites"/>
</display:table>

<authz:authorize ifAllGranted="admin">
<c:out value="${buttons}" escapeXml="false"/>
</authz:authorize>

<script type="text/javascript">
    highlightTableRows("websiteList");
</script>
