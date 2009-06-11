package com.foxconn.cic.webapp.action;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.beanutils.BeanUtils;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.ExchangeRate;
import com.foxconn.cic.service.ExchangeRateManager;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

public class ExchangeRateController implements Controller {
    private final Log log = LogFactory.getLog(ExchangeRateController.class);
    private ExchangeRateManager exchangeRateManager = null;

    public void setExchangeRateManager(ExchangeRateManager exchangeRateManager) {
        this.exchangeRateManager = exchangeRateManager;
    }

    public ModelAndView handleRequest(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        ExchangeRate exchangeRate = new ExchangeRate();
        // populate object with request parameters
        BeanUtils.populate(exchangeRate, request.getParameterMap());

        List exchangeRates = exchangeRateManager.getExchangeRates(exchangeRate);

        return new ModelAndView("exchangeRateList", Constants.EXCHANGERATE_LIST, exchangeRates);
    }
}
