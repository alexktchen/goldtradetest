package com.foxconn.cic.webapp.action;

import org.springframework.mock.web.MockHttpServletRequest;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.validation.BindException;
import org.springframework.validation.Errors;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.Website;

public class WebsiteFormControllerTest extends BaseControllerTestCase {
    private WebsiteFormController c;
    private MockHttpServletRequest request;
    private ModelAndView mv;

    protected void setUp() throws Exception {
        // needed to initialize a user
        super.setUp();
        c = (WebsiteFormController) ctx.getBean("websiteFormController");
    }

    protected void tearDown() {
        c = null;
    }

    public void testEdit() throws Exception {
        log.debug("testing edit...");
        request = newGet("/editWebsite.html");
        request.addParameter("id", "1");

        mv = c.handleRequest(request, new MockHttpServletResponse());

        assertEquals("websiteForm", mv.getViewName());
    }

    public void testSave() throws Exception {
        request = newGet("/editWebsite.html");
        request.addParameter("id", "1");

        mv = c.handleRequest(request, new MockHttpServletResponse());

        Website website = (Website) mv.getModel().get(c.getCommandName());
        assertNotNull(website);
        request = newPost("/editWebsite.html");
        super.objectToRequestParameters(website, request);

        // update the form's fields and add it back to the request
        website.setName("EvZtDlTpLmEzBiZfAvAsAyCpCnJmSwJdXrEaUqGbCfVaQyVbGaJpOiUsAhZwGmSfGeQgBaEdUaXcPkSdLhJnTzIeQeKbJpNsMtUe");
        mv = c.handleRequest(request, new MockHttpServletResponse());
        Errors errors = (Errors) mv.getModel().get(BindException.MODEL_KEY_PREFIX + "website");

        if (errors != null) {
            log.debug(errors);
        }
        assertNull(errors);
        assertNotNull(request.getSession().getAttribute("successMessages"));        
    }

    public void testRemove() throws Exception {
        request = newPost("/editWebsite.html");
        request.addParameter("delete", "");
        request.addParameter("id", "2");
        mv = c.handleRequest(request, new MockHttpServletResponse());
        assertNotNull(request.getSession().getAttribute("successMessages"));
    }
}
