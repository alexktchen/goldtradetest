<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="catalogDetail.title"/></title>
<content tag="heading"><fmt:message key="catalogDetail.heading"/></content>

<spring:bind path="catalog.*">
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

<form:form commandName="catalog" method="post" action="editCatalog.html" onsubmit="return validateCatalog(this)" id="catalogForm">
<form:hidden path="id"/>
<ul>
    <li>
        <FoxconnCIC:label styleClass="desc" key="catalog.name"/>
        <form:errors path="name" cssClass="fieldError"/>
        <form:input path="name" id="name" cssClass="text medium"/>
    </li>
    <li>
        <FoxconnCIC:label styleClass="desc" key="catalog.type"/>
        <form:errors path="type" cssClass="fieldError"/>
        <form:select path="type" id="type" cssClass="text medium">
       		<form:option value=""></form:option>
        	<form:options items="${catalogTypeList}" itemValue="id" itemLabel="name"/>
        </form:select>
    </li>
    <li>
        <FoxconnCIC:label styleClass="desc" key="catalog.description"/>
        <form:errors path="description" cssClass="fieldError"/>
        <form:input path="description" id="description" cssClass="text medium"/>
    </li>
    <li>
        <FoxconnCIC:label styleClass="desc" key="catalog.queryString"/>
        <form:errors path="queryString" cssClass="fieldError"/>
        <form:input path="queryString" id="queryString" cssClass="text medium"/>
    </li>
    <li>
        <FoxconnCIC:label styleClass="desc" key="catalog.parent"/>
        <form:errors path="parent" cssClass="fieldError"/>
        <form:select path="parent" id="parent" cssClass="text medium">
       		<form:option value=""></form:option>
        	<form:options items="${catalogList}" itemValue="id" itemLabel="name"/>
        </form:select>
    </li>
    <li>
        <FoxconnCIC:label styleClass="desc" key="catalog.children"/>
        <form:errors path="children" cssClass="fieldError"/>
        <form:input path="children" id="children" cssClass="text medium"/>
    </li>
    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('Catalog')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('catalogForm'));
</script>

<v:javascript formName="catalog" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
