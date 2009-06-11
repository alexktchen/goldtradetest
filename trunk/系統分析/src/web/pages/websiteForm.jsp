<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="websiteDetail.title"/></title>
<content tag="heading"><fmt:message key="websiteDetail.heading"/></content>

<spring:bind path="website.*">
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
<form:form commandName="website" method="post" action="editWebsite.html" onsubmit="return validateWebsite(this)" id="websiteForm">
<ul>

<form:hidden path="id"/>
	<li>
        <FoxconnCIC:label styleClass="desc" key="website.id"/>
        <form:errors path="id" cssClass="fieldError"/>
        <c:out value="${website.id}"></c:out>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="website.name"/>
        <form:errors path="name" cssClass="fieldError"/>
        <form:input path="name" id="name" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="website.url"/>
        <form:errors path="url" cssClass="fieldError"/>
        <form:input path="url" id="url" cssClass="text medium"/>
    </li>

	<li>
        <FoxconnCIC:label styleClass="desc" key="website.type"/>
        <form:errors path="type" cssClass="fieldError"/>
        <form:select path="type" id="type" cssClass="text medium">
       		<form:option value="0">Unkown</form:option>
       		<form:option value="1">News</form:option>
       		<form:option value="2">Price</form:option>
       		<form:option value="3">Exchange Rate</form:option>
       		<form:option value="4">Interest Rate</form:option>
        </form:select>
    </li>

    <li>
    	<FoxconnCIC:label styleClass="desc" key="website.parent"/>
        <form:errors path="parent" cssClass="fieldError"/>
        <input id="parent" name="parent" type="hidden" value="<c:out value='${website.parent.id}'/>"/>
        <input id='websiteselector' type='text' class="text medium" value="<c:out value='${website.parent.name}'/>">
        <div id="websiteinfo" style="position: absolute; margin-left: 200px; margin-top: -30px;" class="group">
        <strong>Patent Website:</Strong>        
		<FoxconnCIC:label styleClass="desc" key="website.id"/><div id="websiteid" name="id"><c:out value='${website.parent.id}'/></div><br />
		<FoxconnCIC:label styleClass="desc" key="website.name"/><div id="websitename"><c:out value='${website.parent.name}'/></div><br />
		<FoxconnCIC:label styleClass="desc" key="website.url"/><div id="websiteurl"><a target="_blank" href="<c:out value='${website.parent.url}'/>"><c:out value='${website.parent.url}'/></a></div>
		<br/><input id="rootwebsite" value="Set Root" type="button"></input>
        <script type="text/javascript">
		var websiteselect = function(data) {
			$("input#parent").val(trim(data.id));
			$("div#websiteid").html(data.id);
			$("div#websitename").html(data.name);
			$("div#websiteurl").html('<a target="_blank" href="'+data.url+'"/>'+data.url+'</a>');
		};

		var fadeInSuggestion = function(suggestionBox, suggestionIframe) 
		{
			$(suggestionBox).fadeTo(300,0.8);
		};
		var fadeOutSuggestion = function(suggestionBox, suggestionIframe) 
		{
			$(suggestionBox).fadeTo(300,0);
		};

		$(document).ready(function(){
			$('#websiteinfo').hide();
			$('#websiteselector').Autocomplete(
			{
				source: 'websites.html?ajaxMatrix=true',
				delay: 500,
				fx: {
					type: 'slide',
					duration: 400
				},
				autofill: false,
				helperClass: 'autocompleter',
				selectClass: 'selectAutocompleter',
				minchars: 2,
				onSelect : websiteselect,
				onShow : fadeInSuggestion,
				onHide : fadeOutSuggestion
			});
			$('#rootwebsite').click(function(){
				$("input#parent").val("");
				$("input#websiteselector").val("");
				$("div#websiteid").html("");
				$("div#websitename").html("");
				$("div#websiteurl").html("");
			});
		});
		</script>   
	</div>
	</li>

	<li>
        <FoxconnCIC:label styleClass="desc" key="website.status"/>
        <form:errors path="status" cssClass="fieldError"/>
        <form:select path="status" id="status" cssClass="text medium">
        	<form:option value="">Unkown</form:option>
       		<form:option value="Coding">Coding</form:option>
       		<form:option value="Testing">Testing</form:option>
       		<form:option value="Released">Released</form:option>
       		<form:option value="Fixing">Fixing</form:option>
       		<form:option value="Cancelled">Cancelled</form:option>
        </form:select>
    </li>

	<li>
        <FoxconnCIC:label styleClass="desc" key="website.complication"/>
        <form:errors path="complication" cssClass="fieldError"/>
        <form:select path="complication" id="complication" cssClass="text medium">
        	<form:option value="1">Simple</form:option>
       		<form:option value="2">Normal</form:option>
       		<form:option value="3">Complicated</form:option>
        </form:select>
    </li>
	<li>
        <FoxconnCIC:label styleClass="desc" key="website.schedule"/>
        <form:errors path="schedule" cssClass="fieldError"/>
        <form:input path="schedule" id="schedule" cssClass="text medium"/>
    </li>
	<li>
        <FoxconnCIC:label styleClass="desc" key="website.period"/>
        <form:errors path="period" cssClass="fieldError"/>
        <form:input path="period" id="period" cssClass="text medium"/>*m *w *d *h
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="website.createdDate"/>
        <form:errors path="createdDate" cssClass="fieldError"/>
        <form:hidden path="createdDate"/>
        <c:out value="${website.createdDate}"></c:out>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="website.updatedDate"/>
        <form:errors path="updatedDate" cssClass="fieldError"/>
        <form:hidden path="updatedDate"/>
        <c:out value="${website.updatedDate}"></c:out>
    </li>

    <li class="buttonBar bottom">

        <input type="submit" class="button" name="save"  onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('Website')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>

</ul>
</form:form>
</authz:authorize>
<authz:authorize ifNotGranted="admin">
	<p>
        <FoxconnCIC:label styleClass="desc" key="website.id"/>
        <c:out value="${website.id}"></c:out>
    </p>

    <p>
        <FoxconnCIC:label styleClass="desc" key="website.name"/>
        <c:out value="${website.name}"></c:out>
    </p>

    <p>
        <FoxconnCIC:label styleClass="desc" key="website.url"/>
       <c:out value="${website.url}"></c:out>
    </p>
	<p>
        <FoxconnCIC:label styleClass="desc" key="website.type"/>
       <c:out value="${website.type}"></c:out>
    </p>

    <p>
        <FoxconnCIC:label styleClass="desc" key="website.parent"/>
        <c:out value="${website.parent.name}"></c:out>
    </p>

    <p>
        <FoxconnCIC:label styleClass="desc" key="website.createdDate"/>
        <c:out value="${website.createdDate}"></c:out>
    </p>

    <p>
        <FoxconnCIC:label styleClass="desc" key="website.updatedDate"/>
        <c:out value="${website.updatedDate}"></c:out>
    </p>

</ul>
</authz:authorize>
<script type="text/javascript">
    Form.focusFirstElement($('websiteForm'));
</script>

<v:javascript formName="website" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
