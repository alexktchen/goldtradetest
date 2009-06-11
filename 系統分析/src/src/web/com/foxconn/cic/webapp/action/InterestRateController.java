package com.foxconn.cic.webapp.action;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.beanutils.BeanUtils;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.InterestRate;
import com.foxconn.cic.service.InterestRateManager;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

public class InterestRateController implements Controller {
    private final Log log = LogFactory.getLog(InterestRateController.class);
    private InterestRateManager interestRateManager = null;

    public void setInterestRateManager(InterestRateManager interestRateManager) {
        this.interestRateManager = interestRateManager;
    }

    public ModelAndView handleRequest(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        InterestRate interestRate = new InterestRate();
        // populate object with request parameters
        BeanUtils.populate(interestRate, request.getParameterMap());

        List interestRates = interestRateManager.getInterestRates(interestRate);

        return new ModelAndView("interestRateList", Constants.INTERESTRATE_LIST, interestRates);
    }
}
