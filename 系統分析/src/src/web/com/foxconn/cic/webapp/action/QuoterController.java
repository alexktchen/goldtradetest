package com.foxconn.cic.webapp.action;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.beanutils.BeanUtils;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.Quoter;
import com.foxconn.cic.service.QuoterManager;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

public class QuoterController implements Controller {
    private final Log log = LogFactory.getLog(QuoterController.class);
    private QuoterManager quoterManager = null;

    public void setQuoterManager(QuoterManager quoterManager) {
        this.quoterManager = quoterManager;
    }

    public ModelAndView handleRequest(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        Quoter quoter = new Quoter();
        // populate object with request parameters
        BeanUtils.populate(quoter, request.getParameterMap());

        List quoters = quoterManager.getQuoters(quoter);

        if(request.getParameter("ajaxMatrix")!=null && request.getParameter("ajaxMatrix").equalsIgnoreCase("true")){
        	return new ModelAndView("quoterMatrix", Constants.QUOTER_LIST, quoters);
        }
        return new ModelAndView("quoterList", Constants.QUOTER_LIST, quoters);
    }
}
