<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="exchangeRateDetail.title"/></title>
<content tag="heading"><fmt:message key="exchangeRateDetail.heading"/></content>

<spring:bind path="exchangeRate.*">
    <c:if test="${not empty status.errorMessages}">
    <div class="error">    
        <c:forEach var="error" items="${status.errorMessages}">
            <img src="<c:url value="/images/iconWarning.gif"/>"
                alt="<fmt:message key="icon.warning"/>" class="icon" />
            <c:out value="${error}" escapeXml="false"/><br />
        </c:forEach>
    </div>
    </c:if>
</spring:bind>

<form:form commandName="exchangeRate" method="post" action="editExchangeRate.html" onsubmit="return validateExchangeRate(this)" id="exchangeRateForm">
<ul>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.unitCurrency"/>
        <form:errors path="unitCurrency" cssClass="fieldError"/>
        <form:input path="unitCurrency" id="unitCurrency" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.priceCurrency"/>
        <form:errors path="priceCurrency" cssClass="fieldError"/>
        <form:input path="priceCurrency" id="priceCurrency" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.amout"/>
        <form:errors path="amout" cssClass="fieldError"/>
        <form:input path="amout" id="amout" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.priceType"/>
        <form:errors path="priceType" cssClass="fieldError"/>
        <form:input path="priceType" id="priceType" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.price"/>
        <form:errors path="price" cssClass="fieldError"/>
        <form:input path="price" id="price" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.quotationType"/>
        <form:errors path="quotationType" cssClass="fieldError"/>
        <form:input path="quotationType" id="quotationType" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.publisher"/>
        <form:errors path="publisher" cssClass="fieldError"/>
        <form:input path="publisher" id="publisher" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.publishDate"/>
        <form:errors path="publishDate" cssClass="fieldError"/>
        <form:input path="publishDate" id="publishDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.createdDate"/>
        <form:errors path="createdDate" cssClass="fieldError"/>
        <form:input path="createdDate" id="createdDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.updatedDate"/>
        <form:errors path="updatedDate" cssClass="fieldError"/>
        <form:input path="updatedDate" id="updatedDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="exchangeRate.website"/>
        <form:errors path="website" cssClass="fieldError"/>
        <form:input path="website" id="website" cssClass="text medium"/>
    </li>

<form:hidden path="id"/>

    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('ExchangeRate')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('exchangeRateForm'));
</script>

<v:javascript formName="exchangeRate" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
