package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.InterestRate;
import com.foxconn.cic.service.InterestRateManager;

public class InterestRateFormController extends BaseFormController {
    private InterestRateManager interestRateManager = null;

    public void setInterestRateManager(InterestRateManager interestRateManager) {
        this.interestRateManager = interestRateManager;
    }
    public InterestRateFormController() {
        setCommandName("interestRate");
        setCommandClass(InterestRate.class);
    }

    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        InterestRate interestRate = null;

        if (!StringUtils.isEmpty(id)) {
            interestRate = interestRateManager.getInterestRate(id);
        } else {
            interestRate = new InterestRate();
        }

        return interestRate;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        InterestRate interestRate = (InterestRate) command;
        boolean isNew = (interestRate.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            interestRateManager.removeInterestRate(interestRate.getId().toString());

            saveMessage(request, getText("interestRate.deleted", locale));
        } else {
            interestRateManager.saveInterestRate(interestRate);

            String key = (isNew) ? "interestRate.added" : "interestRate.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editInterestRate.html", "id", interestRate.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
}
