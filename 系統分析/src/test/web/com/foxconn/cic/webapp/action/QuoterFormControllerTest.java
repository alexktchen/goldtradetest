package com.foxconn.cic.webapp.action;

import org.springframework.mock.web.MockHttpServletRequest;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.validation.BindException;
import org.springframework.validation.Errors;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.Quoter;

public class QuoterFormControllerTest extends BaseControllerTestCase {
    private QuoterFormController c;
    private MockHttpServletRequest request;
    private ModelAndView mv;

    protected void setUp() throws Exception {
        // needed to initialize a user
        super.setUp();
        c = (QuoterFormController) ctx.getBean("quoterFormController");
    }

    protected void tearDown() {
        c = null;
    }

    public void testEdit() throws Exception {
        log.debug("testing edit...");
        request = newGet("/editQuoter.html");
        request.addParameter("id", "1");

        mv = c.handleRequest(request, new MockHttpServletResponse());

        assertEquals("quoterForm", mv.getViewName());
    }

    public void testSave() throws Exception {
        request = newGet("/editQuoter.html");
        request.addParameter("id", "1");

        mv = c.handleRequest(request, new MockHttpServletResponse());

        Quoter quoter = (Quoter) mv.getModel().get(c.getCommandName());
        assertNotNull(quoter);
        request = newPost("/editQuoter.html");
        super.objectToRequestParameters(quoter, request);

        // update the form's fields and add it back to the request
        mv = c.handleRequest(request, new MockHttpServletResponse());
        Errors errors = (Errors) mv.getModel().get(BindException.MODEL_KEY_PREFIX + "quoter");

        if (errors != null) {
            log.debug(errors);
        }
        assertNull(errors);
        assertNotNull(request.getSession().getAttribute("successMessages"));        
    }

    public void testRemove() throws Exception {
        request = newPost("/editQuoter.html");
        request.addParameter("delete", "");
        request.addParameter("id", "2");
        mv = c.handleRequest(request, new MockHttpServletResponse());
        assertNotNull(request.getSession().getAttribute("successMessages"));
    }
}
