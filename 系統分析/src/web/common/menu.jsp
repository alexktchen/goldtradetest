<%@ include file="/common/taglibs.jsp"%>

<menu:useMenuDisplayer name="Velocity" config="WEB-INF/classes/cssHorizontalMenu.vm" permissions="rolesAdapter">
<ul id="primary-nav" class="menuList">
    <menu:displayMenu name="SearchMenu"/>
    
    <c:if test="${empty pageContext.request.remoteUser}">
   	<menu:displayMenu name="Login"/>
    </c:if>
    
    <c:if test="${not empty pageContext.request.remoteUser}">

    <menu:displayMenu name="UserMenu"/>
    
    <!--Website-START-->
    <menu:displayMenu name="WebsiteMenu"/>
    <!--Website-END-->
    
	<!--Material-START-->
    <menu:displayMenu name="MaterialMenu"/>
    <!--Material-END-->
    
    <!--Quoter-START-->
    <menu:displayMenu name="QuoterMenu"/>
    <!--Quoter-END-->
    <menu:displayMenu name="AdminMenu"/>
    <menu:displayMenu name="Logout"/>
    </c:if>  
    
</ul>
</menu:useMenuDisplayer>
