<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="priceDetail.title"/></title>
<content tag="heading"><fmt:message key="priceDetail.heading"/></content>

<spring:bind path="price.*">
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

<form:form commandName="price" method="post" action="editPrice.html" onsubmit="return validatePrice(this)" id="priceForm">
<ul>

<form:hidden path="id"/>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.material"/>
        <form:errors path="material" cssClass="fieldError"/>
        <form:input path="material" id="material" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.value"/>
        <form:errors path="value" cssClass="fieldError"/>
        <form:input path="value" id="value" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.type"/>
        <form:errors path="type" cssClass="fieldError"/>
        <form:input path="type" id="type" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.publishDate"/>
        <form:errors path="publishDate" cssClass="fieldError"/>
        <form:input path="publishDate" id="publishDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.unit"/>
        <form:errors path="unit" cssClass="fieldError"/>
        <form:input path="unit" id="unit" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.website"/>
        <form:errors path="website" cssClass="fieldError"/>
        <form:input path="website" id="website" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.createdDate"/>
        <form:errors path="createdDate" cssClass="fieldError"/>
        <form:input path="createdDate" id="createdDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.updatedDate"/>
        <form:errors path="updatedDate" cssClass="fieldError"/>
        <form:input path="updatedDate" id="updatedDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.market"/>
        <form:errors path="market" cssClass="fieldError"/>
        <form:input path="market" id="market" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.remark"/>
        <form:errors path="remark" cssClass="fieldError"/>
        <form:input path="remark" id="remark" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="price.producingArea"/>
        <form:errors path="producingArea" cssClass="fieldError"/>
        <form:input path="producingArea" id="producingArea" cssClass="text medium"/>
    </li>

    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('Price')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('priceForm'));
</script>

<v:javascript formName="price" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
