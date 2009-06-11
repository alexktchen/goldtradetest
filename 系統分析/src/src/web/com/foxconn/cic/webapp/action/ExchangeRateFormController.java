package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.ExchangeRate;
import com.foxconn.cic.service.ExchangeRateManager;

public class ExchangeRateFormController extends BaseFormController {
    private ExchangeRateManager exchangeRateManager = null;

    public void setExchangeRateManager(ExchangeRateManager exchangeRateManager) {
        this.exchangeRateManager = exchangeRateManager;
    }
    public ExchangeRateFormController() {
        setCommandName("exchangeRate");
        setCommandClass(ExchangeRate.class);
    }

    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        ExchangeRate exchangeRate = null;

        if (!StringUtils.isEmpty(id)) {
            exchangeRate = exchangeRateManager.getExchangeRate(id);
        } else {
            exchangeRate = new ExchangeRate();
        }

        return exchangeRate;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        ExchangeRate exchangeRate = (ExchangeRate) command;
        boolean isNew = (exchangeRate.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            exchangeRateManager.removeExchangeRate(exchangeRate.getId().toString());

            saveMessage(request, getText("exchangeRate.deleted", locale));
        } else {
            exchangeRateManager.saveExchangeRate(exchangeRate);

            String key = (isNew) ? "exchangeRate.added" : "exchangeRate.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editExchangeRate.html", "id", exchangeRate.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
}
