<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="priceList.title"/></title>
<content tag="heading"><fmt:message key="priceList.heading"/></content>
<meta name="menu" content="PriceMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editPrice.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>

<c:out value="${buttons}" escapeXml="false"/>

<display:table name="priceList" cellspacing="0" cellpadding="0" requestURI=""
    id="priceList" pagesize="25" class="table priceList" export="true">

    <display:column property="id" escapeXml="true" sortable="true"
        url="/editPrice.html" paramId="id" paramProperty="id"
        titleKey="price.id"/>
    <display:column property="value" escapeXml="true" sortable="true"
         titleKey="price.value"/>
    <display:column property="type" escapeXml="true" sortable="true"
         titleKey="price.type"/>
    <display:column property="publishDate" escapeXml="true" sortable="true"
         titleKey="price.publishDate"/>
    <display:column property="unit" escapeXml="true" sortable="true"
         titleKey="price.unit"/>
    <display:column property="createdDate" escapeXml="true" sortable="true"
         titleKey="price.createdDate"/>
    <display:column property="updatedDate" escapeXml="true" sortable="true"
         titleKey="price.updatedDate"/>
    <display:column property="market" escapeXml="true" sortable="true"
         titleKey="price.market"/>
    <display:column property="remark" escapeXml="true" sortable="true"
         titleKey="price.remark"/>
    <display:setProperty name="paging.banner.item_name" value="price"/>
    <display:setProperty name="paging.banner.items_name" value="prices"/>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("priceList");
</script>
