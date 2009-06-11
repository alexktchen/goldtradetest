<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="quoterList.title"/></title>
<content tag="heading"><fmt:message key="quoterList.heading"/></content>
<meta name="menu" content="QuoterMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editQuoter.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="quoterList" cellspacing="0" cellpadding="0" requestURI=""
    id="quoter" pagesize="25" class="table quoterList" export="true">
    <display:column property="name" escapeXml="true" sortable="true"
    	url="/editQuoter.html" paramId="id" paramProperty="id"
         titleKey="quoter.name"/>
    <display:column property="key" escapeXml="true" sortable="true"
         titleKey="quoter.key"/>
    <display:column  escapeXml="true" sortable="true" titleKey="quoter.createdDate">
         <fmt:formatDate value="${quoter.createdDate}" type="date"/>
    </display:column>
    <display:column escapeXml="true" sortable="true" titleKey="quoter.updatedDate">
         <fmt:formatDate value="${quoter.updatedDate}" type="date"/>
    </display:column>
    <display:setProperty name="paging.banner.item_name" value="quoter"/>
    <display:setProperty name="paging.banner.items_name" value="quoters"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("quoterList");
</script>
