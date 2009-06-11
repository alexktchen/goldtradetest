<%@ include file="/common/taglibs.jsp"%>

<title><fmt:message key="catalogList.title"/></title>
<content tag="heading"><fmt:message key="catalogList.heading"/></content>
<meta name="menu" content="CatalogMenu"/>

<c:set var="buttons">
    <input type="button" style="margin-right: 5px"
        onclick="location.href='<c:url value="/editCatalog.html"/>'"
        value="<fmt:message key="button.add"/>"/>

    <input type="button" onclick="location.href='<c:url value="/mainMenu.html"/>'"
        value="<fmt:message key="button.done"/>"/>
</c:set>
<div>
<c:if test="${not empty catalog}">
</c:if>
<c:if test="${empty catlog}">
</c:if>
<script type="text/javascript">					
webFXTreeConfig.rootIcon		= "<c:url value='/images/xloadtree/xp/folder.png'/>";
webFXTreeConfig.openRootIcon	= "<c:url value='/images/xloadtree/xp/openfolder.png'/>";
webFXTreeConfig.folderIcon		= "<c:url value='/images/xloadtree/xp/folder.png'/>";
webFXTreeConfig.openFolderIcon	= "<c:url value='/images/xloadtree/xp/openfolder.png'/>";
webFXTreeConfig.fileIcon		= "<c:url value='/images/xloadtree/xp/file.png'/>";
webFXTreeConfig.lMinusIcon		= "<c:url value='/images/xloadtree/xp/Lminus.png'/>";
webFXTreeConfig.lPlusIcon		= "<c:url value='/images/xloadtree/xp/Lplus.png'/>";
webFXTreeConfig.tMinusIcon		= "<c:url value='/images/xloadtree/xp/Tminus.png'/>";
webFXTreeConfig.tPlusIcon		= "<c:url value='/images/xloadtree/xp/Tplus.png'/>";
webFXTreeConfig.iIcon			= "<c:url value='/images/xloadtree/xp/I.png'/>";
webFXTreeConfig.lIcon			= "<c:url value='/images/xloadtree/xp/L.png'/>";
webFXTreeConfig.tIcon			= "<c:url value='/images/xloadtree/xp/T.png'/>";
webFXTreeConfig.blankIcon		= "<c:url value='/images/xloadtree/xp/blank.png'/>";

<c:if test="${not empty catalog}">
var tree = new WebFXTree('<c:out value="${catalog.name}"/>');
</c:if>
<c:if test="${empty catalog}">
var tree = new WebFXTree('Catalogs');
</c:if>
tree.setBehavior('explorer');
tree.target='_blank';
var item;

<c:forEach items="${catalogList}" var="n" varStatus="a">
<c:set var="url" value="#"/>
<c:if test="${not empty n.queryString}">
<c:set var="url" value="search.html?query=${n.queryString}"/>
</c:if>
<c:out value="item=new WebFXLoadTreeItem('${n.name}','catalogs.html?ajaxtreexml=true&parentid=${n.id}','${url}');" escapeXml="false"></c:out>
tree.add(item);
</c:forEach>

document.write(tree);
</script>
</div>
  
<c:out value="${buttons}" escapeXml="false"/>

<display:table name="catalogList" cellspacing="0" cellpadding="0" requestURI=""
    id="catalogList" pagesize="25" class="table catalogList" export="true">

    <display:column property="id" escapeXml="true" sortable="true"
    	url="/catalogs.html" paramId="parentid" paramProperty="id"
        titleKey="catalog.id"/>
    <display:column property="name" escapeXml="true" sortable="true"
         titleKey="catalog.name"/>
    <display:column property="description" escapeXml="true" sortable="true"
         titleKey="catalog.description"/>
    <display:column property="position" escapeXml="true" sortable="true"
         titleKey="catalog.position"/>
    <display:setProperty name="paging.banner.item_name" value="catalog"/>
    <display:setProperty name="paging.banner.items_name" value="catalogs"/>
    <display:column>
    	<a href="<c:out value='editCatalog.html?id=${catalogList.id}'/>">Edit</a>
    </display:column>
</display:table>

<c:out value="${buttons}" escapeXml="false"/>

<script type="text/javascript">
    highlightTableRows("catalogList");
</script>
