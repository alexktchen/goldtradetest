<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="interestRateList.title"/></title>
<content tag="heading"><fmt:message key="interestRateList.heading"/></content>
<meta name="menu" content="InterestRateMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editInterestRate.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="interestRateList" cellspacing="0" cellpadding="0" requestURI=""
    id="interestRateList" pagesize="25" class="table interestRateList" export="true">

    <display:column property="id" escapeXml="true" sortable="true"
        url="/editInterestRate.html" paramId="id" paramProperty="id"
        titleKey="interestRate.id"/>
    <display:column property="name" escapeXml="true" sortable="true"
         titleKey="interestRate.name"/>
    <display:column property="currency" escapeXml="true" sortable="true"
         titleKey="interestRate.currency"/>
    <display:column property="timePeriod" escapeXml="true" sortable="true"
         titleKey="interestRate.timePeriod"/>
    <display:column property="publisher" escapeXml="true" sortable="true"
         titleKey="interestRate.publisher"/>
    <display:column property="publishDate" escapeXml="true" sortable="true"
         titleKey="interestRate.publishDate"/>
    <display:column property="createdDate" escapeXml="true" sortable="true"
         titleKey="interestRate.createdDate"/>
    <display:column property="updatedDate" escapeXml="true" sortable="true"
         titleKey="interestRate.updatedDate"/>
    <display:setProperty name="paging.banner.item_name" value="interestRate"/>
    <display:setProperty name="paging.banner.items_name" value="interestRates"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("interestRateList");
</script>
