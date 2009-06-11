<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="materialList.title"/></title>
<content tag="heading"><fmt:message key="materialList.heading"/></content>
<meta name="menu" content="MaterialMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editMaterial.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<authz:authorize ifAllGranted="admin">
<c:out value="${buttons}" escapeXml="false"/>
</authz:authorize>

<display:table name="materialList" cellspacing="0" cellpadding="0" requestURI=""
    id="materialList" pagesize="25" class="table materialList" export="true">

    <display:column property="id" escapeXml="true" sortable="true"
        url="/editMaterial.html" paramId="id" paramProperty="id"
        titleKey="material.id"/>
    <display:column property="name" escapeXml="true" sortable="true"
         titleKey="material.name"/>
    <display:column property="spec" escapeXml="true" sortable="true"
         titleKey="material.spec"/>
    <display:setProperty name="paging.banner.item_name" value="material"/>
    <display:setProperty name="paging.banner.items_name" value="materials"/>
</display:table>

<authz:authorize ifAllGranted="admin">
<c:out value="${buttons}" escapeXml="false"/>
</authz:authorize>

<script type="text/javascript">
    highlightTableRows("materialList");
</script>
