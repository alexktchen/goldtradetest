<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="userActivityLogList.title"/></title>
<content tag="heading"><fmt:message key="userActivityLogList.heading"/></content>
<meta name="menu" content="UserActivityLogMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editUserActivityLog.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="userActivityLogList" cellspacing="0" cellpadding="0" requestURI=""
    id="userActivityLogList" pagesize="25" class="table userActivityLogList" export="true">

    <display:column property="id" escapeXml="true" sortable="true"
        url="/editUserActivityLog.html" paramId="id" paramProperty="id"
        titleKey="userActivityLog.id"/>
    <display:column property="userName" escapeXml="true" sortable="true"
         titleKey="userActivityLog.userName"/>
    <display:column property="activity" escapeXml="true" sortable="true"
         titleKey="userActivityLog.activity"/>
    <display:column property="metaData" escapeXml="true" sortable="true"
         titleKey="userActivityLog.metaData"/>
    <display:column property="createdDate" escapeXml="true" sortable="true"
         titleKey="userActivityLog.createdDate"/>
    <display:column property="ipAddress" escapeXml="true" sortable="true"
         titleKey="userActivityLog.ipAddress"/>
    <display:column property="type" escapeXml="true" sortable="true"
         titleKey="userActivityLog.type"/>
    <display:setProperty name="paging.banner.item_name" value="userActivityLog"/>
    <display:setProperty name="paging.banner.items_name" value="userActivityLogs"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("userActivityLogList");
</script>
