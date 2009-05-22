<%--
	@(#)projectSchedule.jsp	2008/06/06
	@author:				jet J.J.Cheng
	@version:				1.0
	Description: 			專案列表
--%>

<%@ page language="java" contentType="text/html;charset=UTF-8" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://struts.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>

<%@page import="java.util.*"%>
<spring:theme code="layout" var="layout"/>
<tiles:insert definition="${layout}" flush="true">
	<tiles:put name="title"><fmt:message key="module.pm.project.list"/></tiles:put>
	<tiles:put name="right"/>
	<tiles:put name="left"/>
	<tiles:put name="header">					
				<script type="text/javascript" src="${pageContext.request.contextPath}/scripts/prototype/prototype.js"></script>	
					<link rel="stylesheet" type="text/css" media="all"
						href="${pageContext.request.contextPath}/css/calendar/theme.css">
				<script type="text/javascript"
			src="${pageContext.request.contextPath}/scripts/calendar/calendar.js"></script>
			<script type="text/javascript"
			src="${pageContext.request.contextPath}/scripts/calendar/calendar-en.js"></script>
			<script type="text/javascript"
			src="${pageContext.request.contextPath}/scripts/calendar/calendar-setup.js"></script>	
	</tiles:put>
	<tiles:put name="body">
          <div id="content" style="padding-left: 23px;padding-top:10px">
					<table class="permission">
					 <tr>
						<th align="left">
							<font class="header">
								<fmt:message key="historyAgent.myproject.title"/>			
							</font>	
						</th>
                     	
					 </tr>
					</table>
         </div>
           
           
           <div id="content" style="overflow:auto;height:50%;width;padding-left: 23px" >
					<table class="permission" cellspacing="0">		
						<thead class="fixed">
							<tr style="font-weight: bold;">
								<th align="center"><fmt:message key="projectAgent.projectAgent.index"/></th>
								<th align="center"><fmt:message key="projectAgent.project.Name"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.agent"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.startTime"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.endTime"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.agentReason"/></th>
								<th align="center" class="last"><fmt:message key="projectAgent.projectAgent.actionstate"/></th>
								
							</tr>
						</thead>
						<tbody class="scrollable">
							
							<c:forEach var="project" items="${model.myProjectAgentHistoryList}" varStatus="status">
							  	<tr onmouseover="this.style.backgroundColor='#F1F1F1'" onmouseout="this.style.backgroundColor='#ffffff'">
							       <td align="center">${status.index+1} </td>
							       <td align="center">${project.project.name} </td>
							       <td align="center">${project.projectAgent.agent} </td>
							       <td align="center"><fmt:formatDate value="${project.projectAgent.agentTime.startTime}"  pattern="yyyy/MM/dd "/> </td>
							       <td align="center"><fmt:formatDate value="${project.projectAgent.agentTime.endTime}"  pattern="yyyy/MM/dd "/></td>
							       <td align="left" id="reasonTDResult${status.index+1}">
							           <input id="reasonInputResult${status.index+1}" type="hidden" value = "${project.projectAgent.reason}"  />
										<script type="text/javascript">
												var test = document.getElementById("reasonInputResult${status.index+1}").value;
												document.getElementById("reasonTDResult${status.index+1}").innerText = test.replace('\n','br');
										</script>
									</td>
								 
								 
								 
								 
								   <c:if test="${project.projectAgent.status=='confirm'||project.projectAgent.status=='Confirm'}">
								     <td class="last" align="center"><fmt:message key="historyAgent.status.sta1"/></td>
								   </c:if>
								    <c:if test="${project.projectAgent.status=='valid'||project.projectAgent.status=='Valid'}">
								     <td class="last" align="center"> <fmt:message key="historyAgent.status.sta2"/></td>
								   </c:if>
								    <c:if test="${project.projectAgent.status=='invalid'||project.projectAgent.status=='Invalid'}">
								     <td  class="last" align="center"><fmt:message key="historyAgent.status.sta3"/></td>
								   </c:if>
								   
								   
							   </tr> 
							</c:forEach>	
						</tbody>
					</table>
			     </div>     
                	
		<div>--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</div>
         <div id="context" style="padding-left: 23px;padding-top:10px">
				<table class="permission" style="border:0px">
						<tr align="left">
							<th align="left">
								<font  class="header">
									<fmt:message key="historyAgent.agentproject.title"/>
								</font>
							</th>
						</tr>
				</table>
			</div>
	   <div id="content" style="overflow:auto;height:40%;width;padding-left: 23px" >
					<table class="permission" cellspacing="0">	
						<thead class="fixed">
						<tr>
							<th><fmt:message key="projectAgent.projectAgent.index"/></th>
							<th>
								<fmt:message key="projectAgent.project.Name"/>
							</th>
							<th>
								<fmt:message key="projectAgent.projectAgent.owner"/>
							</th>
							<th>
								<fmt:message key="projectAgent.projectAgent.startTime"/>
							</th>					
							<th>
								<fmt:message key="projectAgent.projectAgent.endTime"/>
							</th>	
							<th>
								<fmt:message key="projectAgent.projectAgent.reason"/>
							</th>							
							<th class="last">
								<fmt:message key="projectAgent.projectAgent.actionstate"/>
							</th>
						</tr>
						</thead>
						<tbody class="scrollable">
						
							<c:forEach var="task" items="${model.projectAgentHistoryList}" varStatus="status">
							
								<tr onmouseover="this.style.backgroundColor='#F1F1F1'" onmouseout="this.style.backgroundColor='#ffffff'">
									<td align="center">${status.index+1}  </td>
									<td align="center">${task.project.name}  </td>
									<td align="center">${task.project.owner.name}  </td>
								    <td align="center"><fmt:formatDate value="${task.projectAgent.agentTime.startTime}"  pattern="yyyy/MM/dd "/></td>
							        <td align="center"><fmt:formatDate value="${task.projectAgent.agentTime.endTime}"  pattern="yyyy/MM/dd "/></td>
									<td align="left" id="TDResult${status.index+1}">
									 <input id="InputResult${status.index+1}" type="hidden" value = "${task.projectAgent.reason}" />
										<script type="text/javascript">
												var test = document.getElementById("InputResult${status.index+1}").value;
												document.getElementById("TDResult${status.index+1}").innerText = test.replace('\n','br');
										</script>
									</td>
									
									
									
									
									
									   <c:if test="${task.projectAgent.status=='confirm'||task.projectAgent.status=='Confirm'}">
								       <td class="last" align="center"><fmt:message key="historyAgent.status.sta1"/></td>
								   </c:if>
								    <c:if test="${task.projectAgent.status=='valid'||task.projectAgent.status=='Valid'}">
								      <td class="last" align="center"><fmt:message key="historyAgent.status.sta2"/></td>
								   </c:if>
								    <c:if test="${task.projectAgent.status=='invalid'||task.projectAgent.status=='Invalid'}">
								     <td class="last" align="center"><fmt:message key="historyAgent.status.sta3"/></td>
								   </c:if>
									
									
								</tr>
							</c:forEach>
						</tbody>
				</table>
			</div>	
			
		
	 
			
			
				
		
		
	</tiles:put>
</tiles:insert>