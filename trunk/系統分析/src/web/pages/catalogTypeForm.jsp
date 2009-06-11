<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="catalogTypeDetail.title"/></title>
<content tag="heading"><fmt:message key="catalogTypeDetail.heading"/></content>

<spring:bind path="catalogType.*">
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

<form:form commandName="catalogType" method="post" action="editCatalogType.html" onsubmit="return validateCatalogType(this)" id="catalogTypeForm">
<ul>

<form:hidden path="id"/>

    <li>
        <FoxconnCIC:label styleClass="desc" key="catalogType.name"/>
        <form:errors path="name" cssClass="fieldError"/>
        <form:input path="name" id="name" cssClass="text medium"/>
    </li>

    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('CatalogType')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('catalogTypeForm'));
</script>

<v:javascript formName="catalogType" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
