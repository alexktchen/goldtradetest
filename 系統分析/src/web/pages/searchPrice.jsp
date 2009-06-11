<%@ include file="/common/taglibs.jsp"%>
<title>Search</title>
<content tag="heading">
Search:
</content>
<FORM method="POST" action="searchPrice.html">
<spring:bind path="command.query">
	<INPUT type="text" size="50" name="query" value="<c:out value="${status.value}"/>" />
</spring:bind>
<INPUT type="submit" value="Search" />
</FORM>
<p />
<c:if test="${! empty searchResults}">
<jsp:useBean id="command" type="org.compass.core.support.search.CompassSearchCommand" scope="request"></jsp:useBean>
	<c:forEach items="${searchResults.pages}" varStatus="a">
		<c:if test="${a.current.selected}">
			<c:set var="form" value="${a.current.from}"></c:set>
			<c:set var="to" value="${a.current.to}"></c:set>
			<c:set var="currentPage" value="${a.index}"></c:set>
		</c:if>
		<c:set var="pageSize" value="${pageSize+1}"></c:set>
		<c:set var="resultSize" value="${resultSize+a.current.size}"></c:set>
	</c:forEach>
<c:set var="pager">
	<c:set var="pageBegin" value="0"/>
	<c:set var="pageEnd" value="${pageSize}"/>
	<c:if test="${(currentPage-0)>10}">
		<c:set var="pageBegin" value="${currentPage-10}"/>
	</c:if>
	<c:if test="${(pageSize-currentPage)>10}">
		<c:set var="pageEnd" value="${currentPage+10}"/>
	</c:if>
	<table border="0" cellpadding="2" cellspacing="0">
	<tr>
	<td><nobr>Result Page:</nobr></td>
	<td>
	<c:if test="${pageBegin>0}">
		<a href="searchPrice.html?page=<c:out value='${0}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>">&lt;|</a>
		<a href="searchPrice.html?page=<c:out value='${currentPage-1}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>">&lt;</a>
	</c:if>
	</td>
	<c:forEach items="${searchResults.pages}" varStatus="a" begin="${pageBegin}" end="${pageEnd}">
		<td>
		<c:choose>
		<c:when test="${a.current.selected}">
			<c:out value="${a.index+1}"></c:out>
		</c:when>
		<c:otherwise>
			<a href="searchPrice.html?page=<c:out value='${a.index}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>"><c:out value="${a.index+1}"></c:out></a>
		</c:otherwise>
		</c:choose>
		</td>
	</c:forEach>
	<td>
	<c:if test="${pageSize>pageEnd+1}">
		<a href="searchPrice.html?page=<c:out value='${currentPage+1}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>">&gt;</a>
		<a href="searchPrice.html?page=<c:out value='${pageSize-1}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>">|&gt;</a>
	</c:if>
	</td>
	</tr>
	</table>
</c:set>
<hr />

Results <c:out value="${form}"/> - <c:out value="${to}"/> of about <c:out value="${resultSize+1}"/> for <c:out value="${command.query}"/> . (<c:out value="${searchResults.searchTime}"/> ms)
&nbsp&nbsp <a href="newss.html?method=rss&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>"><img align="bottom" src="images/rss.gif"/> </a>
<c:out value="${pager}" escapeXml="false"/>

	<c:forEach items="${searchResults.hits}" varStatus="a" var="hit">
		<table>
			<tr>
				<td><fmt:formatDate pattern="yyyy-MM-dd" value="${a.current.data.publishDate}" />&nbsp;
				<c:out value="${a.current.data.material.name}" />(<c:out value="${a.current.data.material.spec}" />)&nbsp;
				<c:out value="${a.current.data.type}"/>&nbsp;
				<c:out value="${a.current.data.value}" /><c:out value="${a.current.data.unit}" />&nbsp;
				<c:out value="${a.current.data.market}"/>&nbsp;<c:out value="${a.current.data.remark}"/></td>				
				
			</tr>
			<tr>
				<td>[<c:out	value="${a.current.data.website.name}" />]</td>
			</tr>

		</table>
	</c:forEach>
	<c:out value="${pager}" escapeXml="false"/>
</c:if>