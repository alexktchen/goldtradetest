<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="exchangeRateList.title"/></title>
<content tag="heading"><fmt:message key="exchangeRateList.heading"/></content>
<meta name="menu" content="ExchangeRateMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editExchangeRate.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="exchangeRateList" cellspacing="0" cellpadding="0" requestURI=""
    id="exchangeRateList" pagesize="25" class="table exchangeRateList" export="true">

    <display:column property="unitCurrency" escapeXml="true" sortable="true"
         titleKey="exchangeRate.unitCurrency"/>
    <display:column property="priceCurrency" escapeXml="true" sortable="true"
         titleKey="exchangeRate.priceCurrency"/>
    <display:column property="amout" escapeXml="true" sortable="true"
         titleKey="exchangeRate.amout"/>
    <display:column property="priceType" escapeXml="true" sortable="true"
         titleKey="exchangeRate.priceType"/>
    <display:column property="price" escapeXml="true" sortable="true"
         titleKey="exchangeRate.price"/>
    <display:column property="quotationType" escapeXml="true" sortable="true"
         titleKey="exchangeRate.quotationType"/>
    <display:column property="publisher" escapeXml="true" sortable="true"
         titleKey="exchangeRate.publisher"/>
    <display:column property="publishDate" escapeXml="true" sortable="true"
         titleKey="exchangeRate.publishDate"/>
    <display:column property="createdDate" escapeXml="true" sortable="true"
         titleKey="exchangeRate.createdDate"/>
    <display:column property="updatedDate" escapeXml="true" sortable="true"
         titleKey="exchangeRate.updatedDate"/>
    <display:column property="id" escapeXml="true" sortable="true"
        url="/editExchangeRate.html" paramId="id" paramProperty="id"
        titleKey="exchangeRate.id"/>
    <display:setProperty name="paging.banner.item_name" value="exchangeRate"/>
    <display:setProperty name="paging.banner.items_name" value="exchangeRates"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("exchangeRateList");
</script>
