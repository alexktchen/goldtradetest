<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="materialDetail.title"/></title>
<content tag="heading"><fmt:message key="materialDetail.heading"/></content>

<spring:bind path="material.*">
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

<authz:authorize ifAllGranted="admin">
<form:form commandName="material" method="post" action="editMaterial.html" onsubmit="return validateMaterial(this)" id="materialForm">
<ul>

<form:hidden path="id"/>
	<li>
        <FoxconnCIC:label styleClass="desc" key="material.id"/>
        <form:errors path="id" cssClass="fieldError"/>
        <c:out value="${material.id}"></c:out>
    </li>
    <li>
        <FoxconnCIC:label styleClass="desc" key="material.name"/>
        <form:errors path="name" cssClass="fieldError"/>
        <form:input path="name" id="name" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="material.spec"/>
        <form:errors path="spec" cssClass="fieldError"/>
        <form:input path="spec" id="spec" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="material.createdDate"/>
        <form:errors path="createdDate" cssClass="fieldError"/>
        <form:hidden path="createdDate"/>
        <c:out value="${material.createdDate}"></c:out>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="material.updatedDate"/>
        <form:errors path="updatedDate" cssClass="fieldError"/>
        <form:hidden path="updatedDate"/>
        <c:out value="${material.updatedDate}"></c:out>
    </li>

    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('Material')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>
</authz:authorize>

<authz:authorize ifNotGranted="admin">
	<p>
        <FoxconnCIC:label styleClass="desc" key="material.id"/>
        <c:out value="${material.id}"></c:out>
    </p>
    <p>
        <FoxconnCIC:label styleClass="desc" key="material.name"/>
        <c:out value="${material.name}"></c:out>
    </p>

    <p>
        <FoxconnCIC:label styleClass="desc" key="material.spec"/>
        <c:out value="${material.spec}"></c:out>
    </p>

    <p>
        <FoxconnCIC:label styleClass="desc" key="material.createdDate"/>
        <c:out value="${material.createdDate}"></c:out>
    </p>

    <p>
        <FoxconnCIC:label styleClass="desc" key="material.updatedDate"/>
        <c:out value="${material.updatedDate}"></c:out>
    </p>
</authz:authorize>
<script type="text/javascript">
    Form.focusFirstElement($('materialForm'));
</script>

<v:javascript formName="material" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
