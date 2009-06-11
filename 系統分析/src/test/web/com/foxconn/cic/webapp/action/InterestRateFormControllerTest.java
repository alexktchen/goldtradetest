package com.foxconn.cic.webapp.action;

import org.springframework.mock.web.MockHttpServletRequest;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.validation.BindException;
import org.springframework.validation.Errors;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.InterestRate;

public class InterestRateFormControllerTest extends BaseControllerTestCase {
    private InterestRateFormController c;
    private MockHttpServletRequest request;
    private ModelAndView mv;

    protected void setUp() throws Exception {
        // needed to initialize a user
        super.setUp();
        c = (InterestRateFormController) ctx.getBean("interestRateFormController");
    }

    protected void tearDown() {
        c = null;
    }

    public void testEdit() throws Exception {
        log.debug("testing edit...");
        request = newGet("/editInterestRate.html");
        request.addParameter("id", "1");

        mv = c.handleRequest(request, new MockHttpServletResponse());

        assertEquals("interestRateForm", mv.getViewName());
    }

    public void testSave() throws Exception {
        request = newGet("/editInterestRate.html");
        request.addParameter("id", "1");

        mv = c.handleRequest(request, new MockHttpServletResponse());

        InterestRate interestRate = (InterestRate) mv.getModel().get(c.getCommandName());
        assertNotNull(interestRate);
        request = newPost("/editInterestRate.html");
        super.objectToRequestParameters(interestRate, request);

        // update the form's fields and add it back to the request
        mv = c.handleRequest(request, new MockHttpServletResponse());
        Errors errors = (Errors) mv.getModel().get(BindException.MODEL_KEY_PREFIX + "interestRate");

        if (errors != null) {
            log.debug(errors);
        }
        assertNull(errors);
        assertNotNull(request.getSession().getAttribute("successMessages"));        
    }

    public void testRemove() throws Exception {
        request = newPost("/editInterestRate.html");
        request.addParameter("delete", "");
        request.addParameter("id", "2");
        mv = c.handleRequest(request, new MockHttpServletResponse());
        assertNotNull(request.getSession().getAttribute("successMessages"));
    }
}
