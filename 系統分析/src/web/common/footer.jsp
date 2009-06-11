<%@ include file="/common/taglibs.jsp" %>

    <div id="divider"><div></div></div>
    <span class="left">Version @APPVERSION@ 
        <c:if test="${pageContext.request.remoteUser != null}">
        | <fmt:message key="user.status"/> <authz:authentication operation="fullName"/>
        </c:if>
    </span>
    <span class="right">
        &copy; @COPYRIGHT-YEAR@ Hon Hai Precision Industry, Co., Ltd. ("Foxconn").All rights reserved.
    </span>
    <!-- Built on @BUILD-TIME@ -->
