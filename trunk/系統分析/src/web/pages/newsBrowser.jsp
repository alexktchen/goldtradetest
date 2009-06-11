<%@ include file="/common/taglibs.jsp"%>



<spring:bind path="news.*">
	<c:if test="${not empty status.errorMessages}">
		<div class="error"><c:forEach var="error"
			items="${status.errorMessages}">
			<img src="<c:url value='/images/iconWarning.gif'/>"
				alt="<fmt:message key='icon.warning'/>" class="icon" />
			<c:out value="${error}" escapeXml="false" />
			<br />
		</c:forEach></div>
	</c:if>
</spring:bind>

<title><spring:bind path="news.title">
	<c:out value="${status.value}" escapeXml="false" />
</spring:bind></title>

<content tag="heading"><spring:bind path="news.title">
	<c:out value="${status.value}" escapeXml="false" />
</spring:bind>
</content>

<spring:bind path="news.publishDate">
	<div class="date">
		<fmt:formatDate  value="${status.value}" pattern="MMM"/>
		<span><fmt:formatDate  value="${status.value}" pattern="dd"/></span> 
		<fmt:formatDate  value="${status.value}" pattern="yyyy"/>
	</div>
</spring:bind>

<p id="info">
<spring:bind path="news.publisher">
	<c:out value="${status.value}" escapeXml="false" />
</spring:bind>
<spring:bind path="news.author">
	<c:out value="${status.value}" escapeXml="false" />
</spring:bind>
<spring:bind path="news.website.name">
	<c:out value="${status.value}" escapeXml="false" />
</spring:bind>	
<spring:bind path="news.url">
	<a href="<c:out value="${status.value}" escapeXml="false"/>"><fmt:message key="news.url"/></a>
</spring:bind>
</p>
<spring:bind path="news.summary">
	<c:if test="${not empty status.value}">
	<p id="summary">
	<c:out value="${status.value}" escapeXml="false" />
	</p>
	</c:if>
</spring:bind>

<p>
<spring:bind path="news.content">
	<c:out value="${status.value}" escapeXml="false" />
</spring:bind>
</p>
