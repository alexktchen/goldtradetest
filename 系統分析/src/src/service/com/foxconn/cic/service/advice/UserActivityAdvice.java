package com.foxconn.cic.service.advice;

import java.lang.reflect.Method;

import org.acegisecurity.Authentication;
import org.acegisecurity.context.SecurityContext;
import org.acegisecurity.context.SecurityContextHolder;
import org.acegisecurity.ui.WebAuthenticationDetails;
import org.acegisecurity.userdetails.UserDetails;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.aop.AfterReturningAdvice;

import com.foxconn.cic.model.UserActivityLog;
import com.foxconn.cic.model.UserActivityLogConstants;
import com.foxconn.cic.service.UserActivityLogManager;

public abstract class UserActivityAdvice implements AfterReturningAdvice {

	protected final Log log = LogFactory.getLog(UserActivityAdvice.class);
	
	protected UserActivityLogManager userActivityLogManager;
	public void setUserActivityLogManager(
			UserActivityLogManager userActivityLogManager) {
		this.userActivityLogManager = userActivityLogManager;
	}
	public void afterReturning(Object returnValue, Method method,
			Object[] args, Object target) throws Throwable {
		
		SecurityContext ctx = SecurityContextHolder.getContext();

		if (ctx.getAuthentication() != null) {
			Authentication auth = ctx.getAuthentication();
			String currentUser;
            if (auth.getPrincipal() instanceof UserDetails) {
                currentUser = ((UserDetails) auth.getPrincipal()).getUsername();
            } else {
        		currentUser = String.valueOf(auth.getPrincipal());    
            }            
            String ipAddress=null;
            if(auth.getDetails() !=null && auth.getDetails() instanceof WebAuthenticationDetails){
            	ipAddress=((WebAuthenticationDetails)auth.getDetails()).getRemoteAddress();
            }
            String type;
            if(auth.isAuthenticated()){
    			type=UserActivityLogConstants.TYPE_WEB;
        	}else{
        		type=UserActivityLogConstants.TYPE_WEBSERVCIE;
        	}
            UserActivityLog activityLog=new UserActivityLog();
            activityLog.setUserName(currentUser);
            activityLog.setIpAddress(ipAddress);
            activityLog.setType(type);
            activityLog.setActivity(getActivity(returnValue, method, args, target));
            activityLog.setMetaData(getMetaData(returnValue, method, args, target));
            try {
                saveUserActivityLog(activityLog);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

	}
	public abstract String getActivity(Object returnValue, Method method,
			Object[] args, Object target);
	public abstract String getMetaData(Object returnValue, Method method,
			Object[] args, Object target);
	
	protected void saveUserActivityLog(UserActivityLog activityLog){
		userActivityLogManager.saveUserActivityLog(activityLog);
	}

}
