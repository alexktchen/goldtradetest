<%--
	@(#)projectSchedule.jsp	2008/06/06
	@author:				cxuchun
	@version:				1.0
	Description: 			專案列表
--%>

<%@ page language="java" contentType="text/html;charset=UTF-8" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://struts.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>

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
	<% 
		request.setAttribute("users",request.getAttribute("users"));
		request.setAttribute("pmSelectList",request.getAttribute("pmList"));
	%>
	
	
		
				
			
				<div id="content" style="padding-left: 23px;padding-top:10px">
					<table class="permission">
					 <tr>
						<th align="left">
							<font class="header">
								<fmt:message key="projectAgent.myProject"/>			
							</font>	
						</th>
						<th align="right">
                       <input  type="button" class="button"  value="<fmt:message key="projectAgent.button.myHistoryProject"/>" onclick="goHistory()"/>
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
								<th align="center"><fmt:message key="projectAgent.project.status"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.startTime"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.endTime"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.agent"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.reason"/></th>
								<th align="center"><fmt:message key="projectAgent.projectAgent.actionstate"/></th>
								<th align="center" class="last"><fmt:message key="projectAgent.projectAgent.action"/></th>
								
							</tr>
						</thead>
						<tbody class="scrollable">
							
							<c:forEach var="project" items="${model.myProjectList}" varStatus="status">
									<tr onmouseover="this.style.backgroundColor='#F1F1F1'" onmouseout="this.style.backgroundColor='#ffffff'">            	
									  <td align="center" id="seq">${status.index+1}  </td>
									  <td align="center">${project.project.name}</td>
									  <td align="center"><fmt:message key="${project.project.status.statusDesc}" /></td>
										<c:choose>
											<c:when test="${ empty project.projectAgent}"> 
											<td align="center" id="tdstartDate${status.index+1}" ondblclick="changeToEdit(tdstartDate${status.index+1},startDate${status.index+1})">&nbsp;</td>
											  <input type="hidden" id="startDate${status.index+1}" name="startDate${status.index+1}"/>
											  
											  
											  <td align="center" id="tdendDate${status.index+1}" ondblclick="changeToEdit(tdendDate${status.index+1},endDate${status.index+1})">&nbsp;</td>
											  <input type="hidden" id="endDate${status.index+1}" name="endDate${status.index+1}"/>
											  
												
												<td align="center" width="100px" onclick="showComboBox(agentPM${status.index+1},hidAgentPM${status.index+1},'agentPMDialog${status.index+1}','PmList${status.index+1}')" id="agentPM${status.index+1}">
												              &nbsp; <div dojoType="dialog" id="agentPMDialog${status.index+1}"  bgColor="#4C4C4C" bgOpacity="0.7" style="width:50em" toggle="fade" toggleDuration="250" closeOnBackgroundClick="true" >
			                                                        <div id="TabContainer${status.index+1}" dojoType="TabContainer" style="width:20em; height: 20em;" selectedChild="tab1${status.index+1}">
                                                                           <table  width="100%" border="0px">
					                                                               <tr>
					                                                                       <td> <div id="tab1${status.index+1}" dojoType="ContentPane" width="100%" label="TaiWan">
					                                                                            <select style="overflow:hidden"   dojoType="ComboBox" id="PmList${status.index+1}" name="PmList${status.index+1}">
				                                                                                  <option value=""></option>
				                                                                                  <c:forEach var="testitem" items="${pmSelectList}">
			                                                                                       <option value="${testitem.primaryKey}">${testitem.name}</option>
				                                                                                  </c:forEach>  
				                                                                                </select>
				                                                                                </div>
				                                                                            </td>
					                                                                        <td> <div id="tab2${status.index+1}" dojoType="ContentPane" width="100%" refreshOnShow="true" label="LongHua">sdfsdfs</div></td>
					                                                                </tr>
					                                                        </table>				     
				                                                   </div>
			                                                       <div align="right">
																   <input type="button"  class="button" value="sure" onclick="sure(agentPM${status.index+1},hidAgentPM${status.index+1},'agentPMDialog${status.index+1}','PmList${status.index+1}')"/>
																   <input type="button"   class="button" value="cancel" onclick="cancel('agentPMDialog${status.index+1}')"  
																   </div>
			                                                    </div>
												 &nbsp;</td>	
												<input type="hidden" id="hidAgentPM${status.index+1}" name="hidAgentPM${status.index+1}"/>
												
												
												
												
												<td align="left"  width="400px"id="agentReason${status.index+1}" ondblclick="AreaChangeToEdit(agentReason${status.index+1},agent_reason${status.index+1})">
												&nbsp;</td>
												<input type="hidden" id="agent_reason${status.index+1}" name="agent_reason${status.index+1}"/>
												
												
												
												
												<td>&nbsp;&nbsp;</td>
												<td  class="last" align="center"><input type="button" id="addProjectAgent" class="button" value="<fmt:message key="projectAgent.button.submit"/>"   
														onclick="toCommitProjectAgent(${project.project.primaryKey},${status.index+1})"/></td>
											</c:when>
											
											
											<c:when test="${project.projectAgent.status=='Confirm'}">
												<td align="center" id="tdstartDate${status.index+1}" ondblclick="changeToEdit(tdstartDate${status.index+1},startDate${status.index+1})"><fmt:formatDate value="${project.projectAgent.agentTime.startTime}" pattern="yyyy/MM/dd"/></td>
												 <input type ="hidden" id="startDate${status.index+1}" name="startDate${status.index+1}" value="<fmt:formatDate value='${project.projectAgent.agentTime.startTime}' pattern='yyyy/MM/dd'/>"/>
												
												
												
												<td align="center" id="tdendDate${status.index+1}" ondblclick="changeToEdit(tdendDate${status.index+1},endDate${status.index+1})"><fmt:formatDate value="${project.projectAgent.agentTime.endTime}" pattern="yyyy/MM/dd"/></td>
												 <input type="hidden" id="endDate${status.index+1}" name="endDate${status.index+1}" value="<fmt:formatDate value='${project.projectAgent.agentTime.endTime}' pattern='yyyy/MM/dd'/>"/>
												
												<td align="center">
													<select style="overflow:hidden"  dojoType="ComboBox" id="PmList${status.index+1}" name="PmList${status.index+1}" >
														<c:forEach var="testitem" items="${pmSelectList}">
															<option value="${testitem.primaryKey}"  <c:if test="${testitem.primaryKey==project.projectAgent.agent}">selected</c:if>>${testitem.name}</option>
														</c:forEach>  
													</select>
													
												</td>		
												<td align="left" width="400px" id="tdagent_reason${status.index+1}" ondblclick="AreaChangeToEdit(tdagent_reason${status.index+1},agent_reason${status.index+1})">
											     
												 <input id="reasonInput${status.index+1}" type="hidden" value = "${project.projectAgent.reason}" />
													<script type="text/javascript">
														var test = document.getElementById("reasonInput${status.index+1}").value;
														document.getElementById("tdagent_reason${status.index+1}").innerText = test;
													</script>
												</td>
												<input type="hidden" id="agent_reason${status.index+1}" name="agent_reason${status.index+1}" value="${project.projectAgent.reason}"/>
												
												
												
												
												<td align="center"><fmt:message key="projectAgent.projectAgent.status.confrim"/></td>
												<td class="last" align="center"><input type="button" id="addProjectAgent" class="button" value="<fmt:message key="projectAgent.button.reset"/>"  
														onclick="toUpdateProjectAgent(${project.project.primaryKey},${project.projectAgent.primaryKey},${project.projectAgent.agentTime.agentTimeId},${status.index+1})"/></td>
											</c:when>
											<c:when test="${project.projectAgent.status=='Valid'}">
												<td align="center"><fmt:formatDate value="${project.projectAgent.agentTime.startTime}" pattern="yyyy/MM/dd"/></td>
												<td align="center"><fmt:formatDate value="${project.projectAgent.agentTime.endTime}" pattern="yyyy/MM/dd"/></td>
											
												<td align="center">
													${users[project.projectAgent.agent].name}
													
												</td>
												
												<td align="left" width="400px" id="reasonTD${status.index+1}">
													<input id="reasonInput${status.index+1}" type="hidden" value = "${project.projectAgent.reason}" />
													<script type="text/javascript">
														var test = document.getElementById("reasonInput${status.index+1}").value;
														document.getElementById("reasonTD${status.index+1}").innerText = test;
													</script>
													
												</td>
												<td align="center"><fmt:message key="projectAgent.projectAgent.finish"/></td>
												<td align="center" class="last"><input type="button" id="endProjectAgent" class="button" value="<fmt:message key="projectAgent.projectAgent.endagent"/>"     
														onclick="toEndProjectAgent(${project.projectAgent.primaryKey},${project.project.primaryKey})"/></td>
											</c:when>
											
										</c:choose>
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
									<fmt:message key="projectAgent.projectAgent.myAgent"/>
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
								<fmt:message key="projectAgent.projectAgent.agentReason"/>
							</th>							
							<th class="last">
								<fmt:message key="projectAgent.projectAgent.actionstate"/>
							</th>
						</tr>
						</thead>
						<tbody class="scrollable">
						
							<c:forEach var="task" items="${model.agentProjectList}" varStatus="status">
							
								<tr onmouseover="this.style.backgroundColor='#F1F1F1'" onmouseout="this.style.backgroundColor='#ffffff'">
									<td align="center">${status.index+1}  </td>
								
									<td align="center">
										<a href="${pageContext.request.contextPath}/A220.do?action=showProject&projectId=${task.project.primaryKey}&menuDetail=section.pm.projectagent">${task.project.name}</a>
									</td>
									
									<td align="center">
										${users[task.project.owner.primaryKey].name}
									</td>
									<td align="center">
										<fmt:formatDate value="${task.projectAgent.agentTime.startTime}" pattern="yyyy/MM/dd "/>
									</td>
									<td align="center">
										<fmt:formatDate value="${task.projectAgent.agentTime.endTime}" pattern="yyyy/MM/dd "/>
									</td>
									<td align="left" id="reasonTDResult${status.index+1}">
										<input id="reasonInputResult${status.index+1}" type="hidden" value = "${task.projectAgent.reason}" />
										<script type="text/javascript">
												var test = document.getElementById("reasonInputResult${status.index+1}").value;
												document.getElementById("reasonTDResult${status.index+1}").innerText = test;
										</script>
									</td>
									<td  align="center" class="last">
										<c:if test="${task.projectAgent.status=='Confirm'}" >
											<a href="javascript:approve('${task.projectAgent.primaryKey}');"><img src="${pageContext.request.contextPath}/images/approve.gif" border="0"></a>&nbsp;&nbsp;
											<a href="javascript:disapprove('${task.projectAgent.primaryKey}');"><img src="${pageContext.request.contextPath}/images/disapprove.gif" border="0"></a>						
										</c:if>
										<c:if test="${task.projectAgent.status=='Valid'}">
											<fmt:message key="projectAgent.projectAgent.finish"/> 
										</c:if>
									</td>
								</tr>
							</c:forEach>
						</tbody>
				</table>
			</div>	
			
			<div dojoType="dialog" id="approveContent" bgColor="#4C4C4C" bgOpacity="0.7" toggle="fade" toggleDuration="250">
				<br/><h3><fmt:message key="projectAgent.projectAgent.agentConfrim"/></h3>
				<form action="${pageContext.request.contextPath}/A220.do" name="approveForm"   method="POST">						
					<table style="padding:5px">	
						<tr>							
							<td><textarea  cols="50" rows="10" id="description" name="description"></textarea></td>
							<td>&nbsp;</td>
						</tr>					
						<tr style="height:35px">
							<td colspan="2" align="left">
								<input type="submit" class="button" value="<fmt:message key="btn.finish"/>">	
								<input type="button" class="button" value="<fmt:message key="btn.cancel"/>" onclick="approveDlg.hide()">	
								<input type="hidden" id="projectAgentId" name="projectAgentId">
								<input type="hidden" name="status" id="status" value="Valid">
								<input type="hidden" name="action" value="agentComfirm">
							</td>
						</tr>
					</table>
				</form>
			</div>
		
			
			
			<div dojoType="dialog" id="disapproveContent"  bgColor="#4C4C4C" bgOpacity="0.7" toggle="fade" toggleDuration="250">
				<br/><h3><fmt:message key="projectAgent.projectAgent.agentConfrim"/></h3>
				<form action="${pageContext.request.contextPath}/A220.do" name="disapproveForm" method="POST">						
					<table style="padding:5px">
						<tr>					
							<td><textarea id="description" cols="50" rows="10" name="description"></textarea></td>
							<td>&nbsp;</td>
						</tr>					
						<tr>
							<td colspan="2" align="left">
								<input type="submit" class="button" value="<fmt:message key="btn.finish"/>">	
								<input type="button" class="button" value="<fmt:message key="btn.cancel"/>" onclick="disapproveDlg.hide()">							
								<input type="hidden" id="projectAgentId" name="projectAgentId">
								<input type="hidden" name="status" id="status" value="Cancel">
								<input type="hidden" name="action" value="agentComfirm">
							</td>
						</tr>
					</table>
				</form>
			</div>	
			
			
			<div> 
				<form action="${pageContext.request.contextPath}/A220.do" name="form1" method="POST">	
					<input type="hidden" id="action" name="action">
					<input type="hidden" id="projectId" name="projectId"/>
					<input type="hidden" id="startDate" name="startDate"/>
					<input type="hidden" id="endDate" name="endDate"/>
					<input type="hidden" id="selectPM" name="selectPM"/>					
					<input type="hidden" id="reason" name="reason"/>
					<input type="hidden" id="agentTimeId" name="agentTimeId"/>
					<input type="hidden" name="projectAgentId" id="projectAgentId" />
					
				</form>
			</div>	

			
			
		    <div dojoType="dialog" id="agentChoose1"  bgColor="#4C4C4C" bgOpacity="0.7" style="width:50em" toggle="fade" toggleDuration="250" closeOnBackgroundClick="true" >
			    <div id="mainTabContainer" dojoType="TabContainer" style="width:20em; height: 20em;" selectedChild="tab1">
                     <table  width="100%" border="0px">
					  <tr>
					  <td> <div id="tab1" dojoType="ContentPane" width="100%" label="TaiWan">
					      <select style="overflow:hidden"   dojoType="ComboBox" id="PmList" name="PmList" >
				                          <option value="" id="optionT"></option>
				                          <c:forEach var="testitem" items="${pmSelectList}">
			                               <option value="${testitem.primaryKey}">${testitem.name}</option>
				                          </c:forEach>  
				          </select>
				          </div>
				      </td>
					  <td> <div id="tab2" dojoType="ContentPane" width="100%" refreshOnShow="true" label="LongHua">sdfsdfs</div></td>
					  </tr>
					 </table>				     
				</div>
			    <div align="right"><input type="button"  value="sure" onclick="javascript:agentChoose.hide()"/></div>
			</div>
		
			
			
	
			
			<script type="text/javascript">
				var approveDlg;
				var disapproveDlg;
				var reasonInputDlg ;
				
			
				
				function init(e) {
					approveDlg = dojo.widget.byId("approveContent");	
					disapproveDlg = dojo.widget.byId("disapproveContent");
					reasonInputDlg = dojo.widget.byId("agentReasonInputContent");
					
				}
				dojo.addOnLoad(init);
				
				//buile the dojo  combox
				/*
				*/
				function  showComboBox(tdagentChoose,hidAgentPM,agentPMDialog,PmList){
				dojo.widget.byId(agentPMDialog).show();
				dojo.widget.byId(agentPMDialog).onBackgroundClick=function  go()
				{
				 var value=dojo.widget.byId(PmList).comboBoxSelectionValue.value;
				 hidAgentPM.value=value;
				 tdagentChoose.innerText=dojo.widget.byId(PmList).comboBoxValue.value+" ";
				dojo.widget.byId(agentPMDialog).hide();
				}
				}
				
				function sure(agentPM,hidAgentPM,agentPMDialog,PmList)
				{
				
				 var value=dojo.widget.byId(PmList).comboBoxSelectionValue.value;
				 hidAgentPM.value=value;
				 agentPM.innerText=dojo.widget.byId(PmList).comboBoxValue.value+" ";
				 dojo.widget.byId(agentPMDialog).hide();
				
				
				}
				function cancel(agentPMDialog)
				{
				dojo.widget.byId(agentPMDialog).hide();
				}
				
				
				
				
				
				
				// 按下同意
				approve = function (projectAgentId) {
					document.approveForm.projectAgentId.value=projectAgentId;								
					document.approveForm.description.value='Agree';	
					approveDlg.show();
				}
			
				// 按下不同意
				disapprove = function (projectAgentId) {
					document.disapproveForm.projectAgentId.value=projectAgentId;			
					document.disapproveForm.description.value='Disagree';
					disapproveDlg.show();
				}
	             function goHistory(){
				      document.location="${pageContext.request.contextPath}/A220.do?action=showHistoryAgentRecord";
				 }
				
				
				function toCommitProjectAgent(projectId,index) 
				{	
					var startTime = document.getElementById("startDate"+index).value;
					var endTime = document.getElementById("endDate"+index).value;
					var selectPM = dojo.widget.byId("PmList"+index).comboBoxSelectionValue.value;
					var reason = document.getElementById("agent_reason"+index).value;
					if(selectPM){
							
						if( startTime!=null  && endTime!=null && reason!=null && startTime!=""  && endTime!="" && reason!=""){
							if(startTime<endTime){
								document.form1.action.value="commitProjectAgent";
								document.form1.selectPM.value=selectPM;
								document.form1.projectId.value=projectId;
								document.form1.startDate.value=startTime;
								document.form1.endDate.value=endTime;
								document.form1.reason.value=reason;
								
								document.form1.submit();
								
							}else{
								showMessage("<fmt:message key='projectAgent.date'/>");
							}
							
						}else{
							showMessage("<fmt:message key='projectAgent.value'/>");
						
						}
					}
				}
				
									
				
				
				
				
				//結束專案代理
				function toEndProjectAgent(projectAgentId,projectId){
					document.form1.action.value="endProjectAgent";
					document.form1.projectAgentId.value=projectAgentId;
					document.form1.projectId.value=projectId;
					document.form1.submit();
				}
				
				
				//更改專案代理
				function toUpdateProjectAgent(projectId,projectAgentId,agentTimeId,index){
					var startTime = document.getElementById("startDate"+index).value;
					var endTime = document.getElementById("endDate"+index).value;
					var selectPM = dojo.widget.byId("PmList"+index).comboBoxSelectionValue.value;
					var reason = document.getElementById("agent_reason"+index).value;
					if(selectPM){
						var uri = "${pageContext.request.contextPath}/A220.do";	
						if( startTime!=null  && endTime!=null && reason!=null && startTime!=""  && endTime!="" && reason!=""){
							if(startTime<endTime){
								document.form1.action.value="updateProjectAgent";
								document.form1.projectAgentId.value=projectAgentId;
								document.form1.agentTimeId.value=agentTimeId;
								document.form1.selectPM.value=selectPM;
								document.form1.projectId.value=projectId;
								document.form1.startDate.value=startTime;
								document.form1.endDate.value=endTime;
								document.form1.reason.value=reason;
								document.form1.submit();

							}else{
								showMessage("<fmt:message key='projectAgent.date'/>");
							}
							
						}else{
							showMessage("<fmt:message key='projectAgent.value'/>");
						
						}
					}
				}

				
				
				function changInputStyle(index)
				{	
					if(document.getElementById("agent_reason"+index).value=="please wirte your reason here"){
						document.getElementById("agent_reason"+index).value="";
					}
					document.getElementById("agent_reason"+index).style.border="solid 1px #000000";
				}	

				
				function closeInputStyle(index){
					
					document.getElementById("agent_reason"+index).style.border="none 0px";
					
				}
				
				
				var f666Gauge;
				
				function f666TxtAreaReSize(f666ta){
					var f666obj=f666Object(f666ta);
					
					if (!f666obj){ return; }
					
					if (f666obj.tagName.toUpperCase()!='TEXTAREA'){ return; }
					
					setTimeout(function(){ f666TxtAReSize(f666obj); },100);
				}

				function f666TxtAReSize(f666obj){
					 if (!f666Gauge){
					  f666Gauge=f666Style('DIV',{position:'absolute',visibility:'hidden'});
					  document.getElementsByTagName('BODY')[0].appendChild(f666Gauge);
					 }
					 var f666txtsz=parseInt(f666obj.style.fontSize);
					 var f666ff=f666obj.style.fontFamily;
					 if (!f666txtsz||!f666ff){ return; }
					 var f666w=f666Gauge.style.width||f666obj.offsetWidth-10;
					 f666Style(f666Gauge,{fontSize:f666txtsz+'px',fontFamily:f666ff});
					 var f666re=/\n+/g;
					 f666Gauge.style.width=parseInt(f666w)+'px';
					 f666Gauge.innerHTML=f666obj.value.replace(f666re,'<br>');
					 f666obj.style.height=(f666Gauge.offsetHeight+f666txtsz)+'px';
					 if (f666obj.parentNode.className.match('f666')){ f666obj.parentNode.style.height=(f666Gauge.offsetHeight+f666txtsz)+'px'; }
				}

				function f666Style(f666ele,f666style,f666txt){
					 if (typeof(f666ele)=='string'){ f666ele=document.createElement(f666ele); }
					 for (key in f666style){ f666ele.style[key]=f666style[key]; }
					 if (f666txt){ f666ele.appendChild(document.createTextNode(f666txt)); }
					 return f666ele;
				}


				function f666Object(f666obj){
					
					 if (typeof(f666obj)=='string'){ 
					 
					 
					 f666obj=document.getElementByName(f666obj); }
					 
					 return f666obj;
				}
				
				function replaceReason(reason){
					alert("test");
					alert(reason);
					var str = reason.replace('\n','<br>');
					return str;
				}
				
			
												
				//此下代碼用來處理時間文本框								
											
				
				var inputItem; 
                /**tdobj:標誌點擊的行
				   hidobj:用來保存要提交的日期
				  
				**/
				function changeToEdit(tdobj,hidobj){
                if( !inputItem ) {
                 inputItem = document.createElement('input');
                 inputItem.type = 'text';
				 inputItem.size='8';
                 inputItem.id='DateControl';
                 inputItem.name='DateControl';
                 inputItem.style.width = '100%';
                 
                 }
				
                 inputItem.style.display = '';
                 inputItem.value = tdobj.innerText; 
                 tdobj.innerHTML = ''; 
                 tdobj.appendChild(inputItem);
                 inputItem.focus();
              
                 Calendar.setup({
														inputField     :   DateControl,   // id of the input field
														ifFormat       :    "%Y/%m/%d",       // format of the input field
														showsTime      :    true,
														weekNumbers    :  true,
														timeFormat     :    "24",				
														prevButtonImageURL:"${pageContext.request.contextPath}/images/prev_arrow.png",
														nextButtonImageURL:"${pageContext.request.contextPath}/images/next_arrow.png"
													}); 	
													
				inputItem.onblur=function changeToText(){
                   if( tdobj && inputItem ) {
                      var str = inputItem.value;
					 hidobj.value=str;
                     tdobj.innerText = str;   
                  } 
                };
                }
				
				
				
				var  textareaItem;
				function AreaChangeToEdit(tdobj,hidobj){
				
                if( !textareaItem ) {
                 textareaItem = document.createElement('textarea');
                 textareaItem.style.width = '400px ';
                 textareaItem.rows=textareaItem.value.replace(/\s+$/g,"").split("\n").length+2;
				 textareaItem.style.fontSize='12px';
				 textareaItem.style.fontFamily='Courier New';
				 }
				
				
                 textareaItem.style.display = '';
                 textareaItem.value = tdobj.innerText;
				  textareaItem.rows=textareaItem.value.replace(/\s+$/g,"").split("\n").length+2;
                 tdobj.innerHTML = ''; 
                 tdobj.appendChild(textareaItem);
                 textareaItem.focus();
				  
                  
                textareaItem.onkeypress=function  resize(){
				   var text = textareaItem.value.replace(/\s+$/g,"");   
	               var split = text.split("\n");   
				   var lines=split.length;
			        textareaItem.rows=lines+2;
				};
				
													
				textareaItem.onblur=function changeToText(){
                   if( tdobj && textareaItem ) {
                      var str = textareaItem.value;
					  tdobj.innerText = str; 
                       hidobj.value=str;					  
                  } 
                };
				
				
				
				
				
                }
				
				
				
				
				
				
				
				
				
				
				
				
			
			</script>
	</tiles:put>
</tiles:insert>