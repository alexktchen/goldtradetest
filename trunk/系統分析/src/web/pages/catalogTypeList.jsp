<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="catalogTypeList.title"/></title>
<content tag="heading"><fmt:message key="catalogTypeList.heading"/></content>
<meta name="menu" content="CatalogTypeMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editCatalogType.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="catalogTypeList" cellspacing="0" cellpadding="0" requestURI=""
    id="catalogTypeList" pagesize="25" class="table catalogTypeList" export="true">

    <display:column property="id" escapeXml="true" sortable="true"
        url="/editCatalogType.html" paramId="id" paramProperty="id"
        titleKey="catalogType.id"/>
    <display:column property="name" escapeXml="true" sortable="true"
         titleKey="catalogType.name"/>
    <display:setProperty name="paging.banner.item_name" value="catalogType"/>
    <display:setProperty name="paging.banner.items_name" value="catalogTypes"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("catalogTypeList");
</script>
