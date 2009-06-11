package com.foxconn.cic.webapp.action;

import java.util.Map;

import javax.servlet.http.HttpServletResponse;

import org.springframework.mock.web.MockHttpServletRequest;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.Constants;

public class CatalogControllerTest extends BaseControllerTestCase {

    public void testHandleRequest() throws Exception {
        CatalogController c = 
            (CatalogController) ctx.getBean("catalogController");
        ModelAndView mav = c.handleRequest(new MockHttpServletRequest(),
                                           (HttpServletResponse) null);
        Map m = mav.getModel();
        assertNotNull(m.get(Constants.CATALOG_LIST));
        assertEquals(mav.getViewName(), "catalogList");
    }
}
