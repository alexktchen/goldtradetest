package com.foxconn.cic.webapp.action;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.beanutils.BeanUtils;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.UserActivityLog;
import com.foxconn.cic.service.UserActivityLogManager;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

public class UserActivityLogController implements Controller {
    private final Log log = LogFactory.getLog(UserActivityLogController.class);
    private UserActivityLogManager userActivityLogManager = null;

    public void setUserActivityLogManager(UserActivityLogManager userActivityLogManager) {
        this.userActivityLogManager = userActivityLogManager;
    }

    public ModelAndView handleRequest(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        UserActivityLog userActivityLog = new UserActivityLog();
        // populate object with request parameters
        BeanUtils.populate(userActivityLog, request.getParameterMap());

        List userActivityLogs = userActivityLogManager.getUserActivityLogs(userActivityLog);

        return new ModelAndView("userActivityLogList", Constants.USERACTIVITYLOG_LIST, userActivityLogs);
    }
}
