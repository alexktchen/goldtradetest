<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="newsImageDetail.title"/></title>
<content tag="heading"><fmt:message key="newsImageDetail.heading"/></content>

<spring:bind path="newsImage.*">
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

<form:form commandName="newsImage" method="post" action="editNewsImage.html" onsubmit="return validateNewsImage(this)" id="newsImageForm">
<ul>

    <li>
        <FoxconnCIC:label styleClass="desc" key="newsImage.filePath"/>
        <form:errors path="filePath" cssClass="fieldError"/>
        <form:input path="filePath" id="filePath" cssClass="text medium"/>
    </li>

<form:hidden path="id"/>

    <li>
        <FoxconnCIC:label styleClass="desc" key="newsImage.news"/>
        <form:errors path="news" cssClass="fieldError"/>
        <form:input path="news" id="news" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="newsImage.position"/>
        <form:errors path="position" cssClass="fieldError"/>
        <form:input path="position" id="position" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="newsImage.url"/>
        <form:errors path="url" cssClass="fieldError"/>
        <form:input path="url" id="url" cssClass="text medium"/>
    </li>

    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('NewsImage')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('newsImageForm'));
</script>

<v:javascript formName="newsImage" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
