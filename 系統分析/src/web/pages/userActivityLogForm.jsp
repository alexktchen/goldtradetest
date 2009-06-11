<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="userActivityLogDetail.title"/></title>
<content tag="heading"><fmt:message key="userActivityLogDetail.heading"/></content>

<spring:bind path="userActivityLog.*">
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

<form:form commandName="userActivityLog" method="post" action="editUserActivityLog.html" onsubmit="return validateUserActivityLog(this)" id="userActivityLogForm">
<ul>

<form:hidden path="id"/>

    <li>
        <FoxconnCIC:label styleClass="desc" key="userActivityLog.userName"/>
        <form:errors path="userName" cssClass="fieldError"/>
        <form:input path="userName" id="userName" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="userActivityLog.activity"/>
        <form:errors path="activity" cssClass="fieldError"/>
        <form:input path="activity" id="activity" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="userActivityLog.metaData"/>
        <form:errors path="metaData" cssClass="fieldError"/>
        <form:input path="metaData" id="metaData" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="userActivityLog.createdDate"/>
        <form:errors path="createdDate" cssClass="fieldError"/>
        <form:input path="createdDate" id="createdDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="userActivityLog.ipAddress"/>
        <form:errors path="ipAddress" cssClass="fieldError"/>
        <form:input path="ipAddress" id="ipAddress" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="userActivityLog.type"/>
        <form:errors path="type" cssClass="fieldError"/>
        <form:input path="type" id="type" cssClass="text medium"/>
    </li>

    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('UserActivityLog')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('userActivityLogForm'));
</script>

<v:javascript formName="userActivityLog" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
