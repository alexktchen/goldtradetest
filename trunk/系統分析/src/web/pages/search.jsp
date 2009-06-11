<%@ include file="/common/taglibs.jsp"%>
<title>Search</title>
<content tag="heading">Search:</content>
<meta name="menu" content="SearchMenu"/>

<FORM method="POST" action="search.html">
<spring:bind path="command.query">
	<INPUT type="text" class="text large" name="query" value="<c:out value="${status.value}"/>" />
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
		<a href="search.html?page=<c:out value='${0}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>">&lt;|</a>
		<a href="search.html?page=<c:out value='${currentPage-1}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>">&lt;</a>
	</c:if>
	</td>
	<c:forEach items="${searchResults.pages}" varStatus="a" begin="${pageBegin}" end="${pageEnd}">
		<td>
		<c:choose>
		<c:when test="${a.current.selected}">
			<c:out value="${a.index+1}"></c:out>
		</c:when>
		<c:otherwise>
			<a href="search.html?page=<c:out value='${a.index}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>"><c:out value="${a.index+1}"></c:out></a>
		</c:otherwise>
		</c:choose>
		</td>
	</c:forEach>
	<td>
	<c:if test="${pageSize>pageEnd+1}">
		<a href="search.html?page=<c:out value='${currentPage+1}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>">&gt;</a>
		<a href="search.html?page=<c:out value='${pageSize-1}'/>&query=<%=java.net.URLEncoder.encode(command.getQuery(),"UTF-8")%>">|&gt;</a>
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
				<td width="1px" rowspan="2">
					<c:set var="pre" value="${false}"></c:set>
					<c:forEach items="${a.current.data.images}"  varStatus="img" >
						<c:if test="${(not empty img.current.width ) && (not empty img.current.height) && !pre}">
							<c:if test="${img.current.width >= img.current.height}">								
							<img width="80" src="newsImages.html?method=browse&id=<c:out value='${img.current.id}'/>"/>
							</c:if>
							<c:if test="${img.current.width < img.current.height}">								
							<img height="80" src="newsImages.html?method=browse&id=<c:out value='${img.current.id}'/>"/>
							</c:if>
							<c:set var="pre" value="${true}"></c:set>
						</c:if>
						<c:set  var="imageSize" value="${img.count}"></c:set>
					</c:forEach>
				</td>
				<td align="left">
					<a href="newss.html?method=browse&id=<c:out value='${a.current.data.id}'/>" target="_blank">
					<c:choose>
						<c:when test="${not empty a.current.highlightedText['title']}"><c:out value="${a.current.highlightedText['title']}" escapeXml="false" /></c:when>
						<c:otherwise><c:out value="${a.current.data.title}" /> </c:otherwise>
					</c:choose>
					</a>
					<c:if test="${imageSize > 0}">
							(pic)
					</c:if>
					<fmt:formatNumber type="percent" value="${hit.score}" />
				</td>
			</tr>
			<tr>
				<td>
					<c:out value="${a.current.highlightedText['content']}" escapeXml="false" />
				</td>
			</tr>
			<tr>
				<td colspan="2" >
					<c:url var="websiteUrl" value="search.html">
						<c:param name="query" value="websiteid:${a.current.data.website.id}"/>
					</c:url>
					[<a href="<c:out value="${websiteUrl}" />"><c:out value="${a.current.data.website.name}" /></a>]
					<fmt:formatDate pattern="yyyy-MM-dd" value="${a.current.data.publishDate}" />&nbsp;
					<c:out value="${a.current.data.author}"></c:out> &nbsp;
					<c:out value="${a.current.data.publisher}"></c:out> &nbsp;
					<a href="<c:out value="${a.current.data.url}"/>" target="_blank">
						<fmt:message key="news.url" />
					</a>
				</td>
			</tr>
		</table>
	</c:forEach>
	<c:out value="${pager}" escapeXml="false"/>
</c:if>