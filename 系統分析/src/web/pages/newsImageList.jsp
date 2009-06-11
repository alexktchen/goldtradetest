<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="newsImageList.title"/></title>
<content tag="heading"><fmt:message key="newsImageList.heading"/></content>
<meta name="menu" content="NewsImageMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editNewsImage.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="newsImageList" cellspacing="0" cellpadding="0" requestURI=""
    id="newsImageList" pagesize="25" class="table newsImageList" export="true">

    <display:column property="filePath" escapeXml="true" sortable="true"
         titleKey="newsImage.filePath"/>
    <display:column property="id" escapeXml="true" sortable="true"
        url="/editNewsImage.html" paramId="id" paramProperty="id"
        titleKey="newsImage.id"/>
    <display:column property="position" escapeXml="true" sortable="true"
         titleKey="newsImage.position"/>
    <display:column property="url" escapeXml="true" sortable="true"
         titleKey="newsImage.url"/>
    <display:setProperty name="paging.banner.item_name" value="newsImage"/>
    <display:setProperty name="paging.banner.items_name" value="newsImages"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("newsImageList");
</script>
