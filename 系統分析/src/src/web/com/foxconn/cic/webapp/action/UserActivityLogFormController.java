package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.UserActivityLog;
import com.foxconn.cic.service.UserActivityLogManager;

public class UserActivityLogFormController extends BaseFormController {
    private UserActivityLogManager userActivityLogManager = null;

    public void setUserActivityLogManager(UserActivityLogManager userActivityLogManager) {
        this.userActivityLogManager = userActivityLogManager;
    }
    public UserActivityLogFormController() {
        setCommandName("userActivityLog");
        setCommandClass(UserActivityLog.class);
    }

    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        UserActivityLog userActivityLog = null;

        if (!StringUtils.isEmpty(id)) {
            userActivityLog = userActivityLogManager.getUserActivityLog(id);
        } else {
            userActivityLog = new UserActivityLog();
        }

        return userActivityLog;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        UserActivityLog userActivityLog = (UserActivityLog) command;
        boolean isNew = (userActivityLog.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            userActivityLogManager.removeUserActivityLog(userActivityLog.getId().toString());

            saveMessage(request, getText("userActivityLog.deleted", locale));
        } else {
            userActivityLogManager.saveUserActivityLog(userActivityLog);

            String key = (isNew) ? "userActivityLog.added" : "userActivityLog.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editUserActivityLog.html", "id", userActivityLog.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
}
