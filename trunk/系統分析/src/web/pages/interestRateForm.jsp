<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="interestRateDetail.title"/></title>
<content tag="heading"><fmt:message key="interestRateDetail.heading"/></content>

<spring:bind path="interestRate.*">
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

<form:form commandName="interestRate" method="post" action="editInterestRate.html" onsubmit="return validateInterestRate(this)" id="interestRateForm">
<ul>

<form:hidden path="id"/>

    <li>
        <FoxconnCIC:label styleClass="desc" key="interestRate.name"/>
        <form:errors path="name" cssClass="fieldError"/>
        <form:input path="name" id="name" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="interestRate.currency"/>
        <form:errors path="currency" cssClass="fieldError"/>
        <form:input path="currency" id="currency" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="interestRate.timePeriod"/>
        <form:errors path="timePeriod" cssClass="fieldError"/>
        <form:input path="timePeriod" id="timePeriod" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="interestRate.publisher"/>
        <form:errors path="publisher" cssClass="fieldError"/>
        <form:input path="publisher" id="publisher" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="interestRate.publishDate"/>
        <form:errors path="publishDate" cssClass="fieldError"/>
        <form:input path="publishDate" id="publishDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="interestRate.createdDate"/>
        <form:errors path="createdDate" cssClass="fieldError"/>
        <form:input path="createdDate" id="createdDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="interestRate.updatedDate"/>
        <form:errors path="updatedDate" cssClass="fieldError"/>
        <form:input path="updatedDate" id="updatedDate" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="interestRate.website"/>
        <form:errors path="website" cssClass="fieldError"/>
        <form:input path="website" id="website" cssClass="text medium"/>
    </li>

    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('InterestRate')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('interestRateForm'));
</script>

<v:javascript formName="interestRate" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
