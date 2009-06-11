package com.foxconn.cic.webapp.action;

import java.util.Map;

import javax.servlet.http.HttpServletResponse;

import org.springframework.mock.web.MockHttpServletRequest;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.Constants;

public class CatalogTypeControllerTest extends BaseControllerTestCase {

    public void testHandleRequest() throws Exception {
        CatalogTypeController c = 
            (CatalogTypeController) ctx.getBean("catalogTypeController");
        ModelAndView mav = c.handleRequest(new MockHttpServletRequest(),
                                           (HttpServletResponse) null);
        Map m = mav.getModel();
        assertNotNull(m.get(Constants.CATALOGTYPE_LIST));
        assertEquals(mav.getViewName(), "catalogTypeList");
    }
}
