<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="newsDetail.title"/></title>
<content tag="heading"><fmt:message key="newsDetail.heading"/></content>

<spring:bind path="news.*">
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

<form:form commandName="news" method="post" action="editNews.html" onsubmit="return validateNews(this)" id="newsForm">
<ul>

    

<form:hidden path="id"/>
	<li>
        <FoxconnCIC:label styleClass="desc" key="news.title"/>
        <form:errors path="title" cssClass="fieldError"/>
        <form:input path="title" id="title" cssClass="text medium"/>
    </li>
 
    <li>
        <FoxconnCIC:label styleClass="desc" key="news.summary"/>
        <form:errors path="summary" cssClass="fieldError"/>
        <form:input path="summary" id="summary" cssClass="text medium"/>
    </li>
    
    <li>
        <FoxconnCIC:label styleClass="desc" key="news.publisher"/>
        <form:errors path="publisher" cssClass="fieldError"/>
        <form:input path="publisher" id="publisher" cssClass="text medium"/>
    </li>
    
    <li>
        <FoxconnCIC:label styleClass="desc" key="news.author"/>
        <form:errors path="author" cssClass="fieldError"/>
        <form:input path="author" id="author" cssClass="text medium"/>
    </li>

	<li>
        <FoxconnCIC:label styleClass="desc" key="news.publishDate"/>
        <form:errors path="publishDate" cssClass="fieldError"/>
        <form:input path="publishDate" id="publishDate" cssClass="text medium"/>
    </li> 


    <li>
        <FoxconnCIC:label styleClass="desc" key="news.url"/>
        <form:errors path="url" cssClass="fieldError"/>
        <spring:bind path="news.url">
        <a href="<c:out value="${status.value}"/>" target="_blank"><c:out value="${status.value}"/></a>
        </spring:bind>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="news.website"/>
        <form:errors path="website" cssClass="fieldError"/>
        <form:select path="website" id="website" cssClass="text medium" disabled="true">
        	<form:options items="${websiteList}" itemValue="id" itemLabel="name"/>
        </form:select>
    </li>
    
    <li>
        <FoxconnCIC:label styleClass="desc" key="news.createdDate"/>
        <form:errors path="createdDate" cssClass="fieldError"/>
        <form:input path="createdDate" id="createdDate" cssClass="text medium"/>
    </li>    
    
    <li>
        <FoxconnCIC:label styleClass="desc" key="news.updatedDate"/>
        <form:errors path="updatedDate" cssClass="fieldError"/>
        <form:input path="updatedDate" id="updatedDate" cssClass="text medium"/>
    </li>    
    
	<li>
        <FoxconnCIC:label styleClass="desc" key="news.content"/>
        <form:errors path="content" cssClass="fieldError"/>
        <div style="font-size: 10px;border:1px dotted #000000; ">
        <spring:bind path="news.content">
        	<c:out value="${status.value}" escapeXml="false"/>
        </spring:bind>
        </div>
    </li>
    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('News')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('newsForm'));
</script>

<v:javascript formName="news" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
