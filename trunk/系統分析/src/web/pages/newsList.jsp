<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="newsList.title"/></title>
<content tag="heading"><fmt:message key="newsList.heading"/></content>
<meta name="menu" content="NewsMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editNews.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="newsList" cellspacing="0" cellpadding="0" requestURI=""
    id="newsList" pagesize="25" class="table newsList" export="true" defaultsort="5" defaultorder="descending" sort="list">

    <display:column property="id" escapeXml="true" sortable="true"
        url="/editNews.html" paramId="id" paramProperty="id"
        titleKey="news.id"/>
    <display:column property="title" escapeXml="true" sortable="true"
         titleKey="news.title"/>
    <display:column property="publishDate" escapeXml="true" sortable="true"
         titleKey="news.publishDate"/>
    <display:column property="website.name" escapeXml="true" sortable="true"
         titleKey="news.website"/>     
    <display:column escapeXml="false" sortable="true" 
         titleKey="news.url">
         <a target="_blank" href="<c:out value='${newsList.url}'/>"><fmt:message key="news.url"/></a>
	</display:column>      
    
    <display:setProperty name="paging.banner.item_name" value="news"/>
    <display:setProperty name="paging.banner.items_name" value="newss"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("newsList");
</script>
