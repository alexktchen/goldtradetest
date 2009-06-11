<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="keywordList.title"/></title>
<content tag="heading"><fmt:message key="keywordList.heading"/></content>
<meta name="menu" content="KeywordMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editKeyword.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="keywordList" cellspacing="0" cellpadding="0" requestURI=""
    id="keywordList" pagesize="25" class="table keywordList" export="true">

    <display:column property="id" escapeXml="true" sortable="true"
        url="/editKeyword.html" paramId="id" paramProperty="id"
        titleKey="keyword.id"/>
    <display:column property="name" escapeXml="true" sortable="true"
         titleKey="keyword.name"/>
    <display:setProperty name="paging.banner.item_name" value="keyword"/>
    <display:setProperty name="paging.banner.items_name" value="keywords"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("keywordList");
</script>
