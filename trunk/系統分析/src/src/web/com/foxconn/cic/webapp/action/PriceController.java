package com.foxconn.cic.webapp.action;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.beanutils.BeanUtils;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.Price;
import com.foxconn.cic.service.PriceManager;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

public class PriceController implements Controller {
    private final Log log = LogFactory.getLog(PriceController.class);
    private PriceManager priceManager = null;

    public void setPriceManager(PriceManager priceManager) {
        this.priceManager = priceManager;
    }

    public ModelAndView handleRequest(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        Price price = new Price();
        // populate object with request parameters
        BeanUtils.populate(price, request.getParameterMap());

        List prices = priceManager.getPrices(price);

        return new ModelAndView("priceList", Constants.PRICE_LIST, prices);
    }
}
