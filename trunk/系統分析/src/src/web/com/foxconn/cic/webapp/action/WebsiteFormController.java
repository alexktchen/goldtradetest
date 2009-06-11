package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.Website;
import com.foxconn.cic.service.WebsiteManager;

public class WebsiteFormController extends BaseFormController {
    private WebsiteManager websiteManager = null;

    public void setWebsiteManager(WebsiteManager websiteManager) {
        this.websiteManager = websiteManager;
    }
    public WebsiteFormController() {
        setCommandName("website");
        setCommandClass(Website.class);
    }

    @Override
	protected void initBinder(HttpServletRequest request, ServletRequestDataBinder binder) {
		super.initBinder(request, binder);
		binder.registerCustomEditor(Website.class,"parent",new WebsiteEditor(websiteManager));

	}
    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        Website website = null;

        if (!StringUtils.isEmpty(id)) {
            website = websiteManager.getWebsite(id);
        } else {
            website = new Website();
        }

        return website;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        Website website = (Website) command;
        if(website.getId()!=null && website.getId().trim().equals("")) website.setId(null);
        boolean isNew = (website.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            websiteManager.removeWebsite(website.getId());

            saveMessage(request, getText("website.deleted", locale));
        } else {
        	if(isNew && website.getParent()!=null){
        		website.getParent().getChildren().add(website);
        	}
            websiteManager.saveWebsite(website);

            String key = (isNew) ? "website.added" : "website.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editWebsite.html", "id", website.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
}
