package com.foxconn.cic.webapp.action;

import java.util.Locale;
import java.util.Set;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.Quoter;
import com.foxconn.cic.service.QuoterManager;
import com.foxconn.cic.service.WebsiteManager;

public class QuoterFormController extends BaseFormController {
    private QuoterManager quoterManager = null;
    private WebsiteManager websiteManager = null;
    public void setQuoterManager(QuoterManager quoterManager) {
        this.quoterManager = quoterManager;
    }
    public QuoterFormController() {
        setCommandName("quoter");
        setCommandClass(Quoter.class);
    }

    @Override
	protected void initBinder(HttpServletRequest request, ServletRequestDataBinder binder) {
    	super.initBinder(request, binder);
		binder.registerCustomEditor(Set.class, "websites",
                new WebsitesEditor(websiteManager));
	}
    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        Quoter quoter = null;

        if (!StringUtils.isEmpty(id)) {
            quoter = quoterManager.getQuoter(id);
        } else {
            quoter = new Quoter();
        }

        return quoter;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        Quoter quoter = (Quoter) command;
        if(quoter.getId()!=null && quoter.getId().trim().equals("")) quoter.setId(null);
        boolean isNew = (quoter.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            quoterManager.removeQuoter(quoter.getId().toString());

            saveMessage(request, getText("quoter.deleted", locale));
        } else {
            quoterManager.saveQuoter(quoter);

            String key = (isNew) ? "quoter.added" : "quoter.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editQuoter.html", "id", quoter.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
	public void setWebsiteManager(WebsiteManager websiteManager) {
		this.websiteManager = websiteManager;
	}
}
