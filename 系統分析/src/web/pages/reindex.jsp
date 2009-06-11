<%@ include file="/common/taglibs.jsp"%>
<meta name="menu" content="AdminMenu"/>
<P>
<H2>Compass Index</H2>
<P>
Use the Index button to index the database using Compass::Gps. The
operation will
delete the current index and reindex the database based on the
mappings and devices
defined in the Compass::Gps configuration context.
<FORM method="POST" action="<c:url value="/reindex.html"/>">
	<INPUT type="hidden" name="doIndex" value="true" />
	<INPUT type="submit" value="reindex"/>
</FORM>
<c:if test="${(! empty indexResults) && (! empty indexCommand.doIndex)}">
        <P>Indexing took: <c:out value="${indexResults.indexTime}" />ms.
</c:if>
<P>
<hr/>
<P>
<H2>Index KPI</H2>
<FORM method="POST" action="<c:url value="/indexManager.html"/>">
    <INPUT type="submit" value="Index Info"/>
</FORM>
<P>
indexDocumentSize:<c:out value="${indexDocumentSize}" /><br/>
indexDocumentMaxNumber:<c:out value="${indexDocumentMaxNumber}" />
</P>
<hr/>
<P>
<H2>Index Update</H2>
<FORM method="POST" action="<c:url value="/indexManager.html?method=updateIndex"/>">
BeginId:<INPUT type="text"idden" name="beginId" />
EndId:<INPUT type="text" name="endId" />
	<INPUT type="submit" value="Update Index"/>
</FORM>
<c:if test="${(! empty indexResults) && (! empty indexCommand.beginId)}">
BeginId:<c:out value="${indexCommand.beginId}"/>
EndId:<c:out value="${indexCommand.endId}"/>
<P>Indexing took: <c:out value="${indexResults.indexTime}" />ms.
</c:if>
<P>
<hr/>
<P>
<H2>Index Synchronize</H2>
<FORM method="POST" action="<c:url value="/indexManager.html?method=syncNews"/>">
	<INPUT type="hidden" name="syncIndex" value="true" />
	<INPUT type="submit" value="Sync Index"/>
</FORM>
<c:if test="${(! empty indexResults) && (! empty indexCommand.syncIndex)}">
	<P>Indexing took: <c:out value="${indexResults.indexTime}" />ms.
	<c:forEach items="newsIds" var="id">
		<c:out value="${id}"></c:out>,
	</c:forEach>
</c:if>
<P>
<H2>Index Manager</H2>
<form:form commandName="indexCommand" method="post" action="indexManager.html?method=deleteNews">
	NewsID:<INPUT type="text" name="resourceId" />
	<input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('News')" value="<fmt:message key="button.delete"/>" />
</form:form>
<v:javascript formName="website" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
<c:if test="${(! empty indexResults) && (! empty indexCommand.resourceId)}">
	resourceId:<c:out value="${indexCommand.resourceId}"/><br/>
	<c:if test="${! empty news}">
		News[<c:out value="${news.title}"/>] is removed successfully!
	</c:if>
	<c:if test="${empty news}">
		No news
	</c:if>
	<P>Indexing took: <c:out value="${indexResults.indexTime}" />ms.
</c:if>