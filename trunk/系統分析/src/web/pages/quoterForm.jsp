<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="quoterDetail.title"/></title>
<content tag="heading"><fmt:message key="quoterDetail.heading"/></content>

<spring:bind path="quoter.*">
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

<form:form commandName="quoter" method="post" action="editQuoter.html" onsubmit="return validateQuoter(this)" id="quoterForm">
<ul>
<form:hidden path="id"/>
   	<li>
        <FoxconnCIC:label styleClass="desc" key="quoter.id"/>
        <form:errors path="id" cssClass="fieldError"/>
        <c:out value="${quoter.id}"></c:out>
    </li>
    <li>
        <FoxconnCIC:label styleClass="desc" key="quoter.name"/>
        <form:errors path="name" cssClass="fieldError"/>
        <form:input path="name" id="name" cssClass="text medium"/>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="quoter.key"/>
        <form:errors path="key" cssClass="fieldError"/>
        <form:input path="key" id="key" cssClass="text medium"/>
    </li>

    <li>
    	<FoxconnCIC:label styleClass="desc" key="quoter.websites"/>
    	
    	<div style="position: absolute; left:360px;" class="group">
        <strong>Patent Website:</Strong>   
        <input id='websiteselector' type='text' class="text large">       
		<FoxconnCIC:label styleClass="desc" key="website.id"/><div id="websiteid" name="id"></div><br />
		<FoxconnCIC:label styleClass="desc" key="website.name"/><div id="websitename"></div><br />
		<FoxconnCIC:label styleClass="desc" key="website.url"/><div id="websiteurl"></div>
        <script type="text/javascript">
		var cityCode = function(data) {
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
			
			$("select#websites").sortOptions();
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
				onSelect : cityCode,
				onShow : fadeInSuggestion,
				onHide : fadeOutSuggestion
			});
			$("#add").click(function() {
				if(jQuery.trim($('#websiteid').html())== "" || jQuery.trim($('#websitename').html())== ""){
					return;
				}
				if($("#websites").containsOption(jQuery.trim($('#websiteid').html()))){		
					return;
				}
				$("#websites").addOption( $('#websiteid').html(),$('#websitename').html(),true);
				$("select#websites").sortOptions();
			});
			$("#remove").click(function() {
				$("#websites").removeOption($("#websites").selectedValues()[0]);
				$("select#websites").sortOptions();
			});
			$("#save").bind("click",function() {
				$("#websites").selectOptions(/./);
			});
			$("select#websites").change(function() {
				$("div#websiteid").html(jQuery.trim(this.value));
				$("div#websitename").html(this.options[this.selectedIndex].text);
				$("#websiteselector").val(this.options[this.selectedIndex].text);
				$("div#websiteurl").html("");
			});
		});
		</script>    
		<br/>   
		<input id="add" value="Add" type="button"></input>
		<input id="remove" value="Remove" type="button"></input> 
		</div>
		<form:select path="websites" size="15" cssClass="text large" multiple="multiple">
			<form:options items="${quoter.websites}" itemValue="id" itemLabel="name" />
		</form:select>
        <form:errors path="websites" cssClass="fieldError"/>
        
    </li>
	<li>
        <FoxconnCIC:label styleClass="desc" key="quoter.createdDate"/>
        <form:errors path="createdDate" cssClass="fieldError"/>
        <form:hidden path="createdDate"/>
        <c:out value="${quoter.createdDate}"></c:out>
    </li>

    <li>
        <FoxconnCIC:label styleClass="desc" key="quoter.updatedDate"/>
        <form:errors path="updatedDate" cssClass="fieldError"/>
        <form:hidden path="updatedDate"/>
        <c:out value="${quoter.updatedDate}"></c:out>
    </li>

    <li class="buttonBar bottom">
        <input type="submit" class="button" name="save"  id="save" onclick="bCancel=false" value="<fmt:message key="button.save"/>" />
        <input type="submit" class="button" name="delete" onclick="bCancel=true;return confirmDelete('Quoter')" value="<fmt:message key="button.delete"/>" />
        <input type="submit" class="button" name="cancel" onclick="bCancel=true" value="<fmt:message key="button.cancel"/>" />
    </li>
</ul>
</form:form>

<script type="text/javascript">
    Form.focusFirstElement($('quoterForm'));
</script>

<v:javascript formName="quoter" cdata="false" dynamicJavascript="true" staticJavascript="false"/>
<script type="text/javascript"  src="<c:url value="/scripts/validator.jsp"/>"></script>
