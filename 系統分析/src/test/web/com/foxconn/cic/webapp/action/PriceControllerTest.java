package com.foxconn.cic.webapp.action;

import java.util.Map;

import javax.servlet.http.HttpServletResponse;

import org.springframework.mock.web.MockHttpServletRequest;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.Constants;

public class PriceControllerTest extends BaseControllerTestCase {

    public void testHandleRequest() throws Exception {
        PriceController c = 
            (PriceController) ctx.getBean("priceController");
        ModelAndView mav = c.handleRequest(new MockHttpServletRequest(),
                                           (HttpServletResponse) null);
        Map m = mav.getModel();
        assertNotNull(m.get(Constants.PRICE_LIST));
        assertEquals(mav.getViewName(), "priceList");
    }
}
