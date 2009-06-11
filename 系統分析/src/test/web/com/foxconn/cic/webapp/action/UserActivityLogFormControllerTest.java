package com.foxconn.cic.webapp.action;

import org.springframework.mock.web.MockHttpServletRequest;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.validation.BindException;
import org.springframework.validation.Errors;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.UserActivityLog;

public class UserActivityLogFormControllerTest extends BaseControllerTestCase {
    private UserActivityLogFormController c;
    private MockHttpServletRequest request;
    private ModelAndView mv;

    protected void setUp() throws Exception {
        // needed to initialize a user
        super.setUp();
        c = (UserActivityLogFormController) ctx.getBean("userActivityLogFormController");
    }

    protected void tearDown() {
        c = null;
    }

    public void testEdit() throws Exception {
        log.debug("testing edit...");
        request = newGet("/editUserActivityLog.html");
        request.addParameter("id", "1");

        mv = c.handleRequest(request, new MockHttpServletResponse());

        assertEquals("userActivityLogForm", mv.getViewName());
    }

    public void testSave() throws Exception {
        request = newGet("/editUserActivityLog.html");
        request.addParameter("id", "1");

        mv = c.handleRequest(request, new MockHttpServletResponse());

        UserActivityLog userActivityLog = (UserActivityLog) mv.getModel().get(c.getCommandName());
        assertNotNull(userActivityLog);
        request = newPost("/editUserActivityLog.html");
        super.objectToRequestParameters(userActivityLog, request);

        // update the form's fields and add it back to the request
        mv = c.handleRequest(request, new MockHttpServletResponse());
        Errors errors = (Errors) mv.getModel().get(BindException.MODEL_KEY_PREFIX + "userActivityLog");

        if (errors != null) {
            log.debug(errors);
        }
        assertNull(errors);
        assertNotNull(request.getSession().getAttribute("successMessages"));        
    }

    public void testRemove() throws Exception {
        request = newPost("/editUserActivityLog.html");
        request.addParameter("delete", "");
        request.addParameter("id", "2");
        mv = c.handleRequest(request, new MockHttpServletResponse());
        assertNotNull(request.getSession().getAttribute("successMessages"));
    }
}
