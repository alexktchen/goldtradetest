package com.foxconn.cic.webapp.action;

import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.News;
import com.foxconn.cic.model.Website;
import com.foxconn.cic.service.Manager;
import com.foxconn.cic.service.WebsiteManager;

public class NewsFormController extends BaseFormController {
    private Manager manager = null;
    private WebsiteManager websiteManager=null;

  
	public void setManager(Manager manager) {
        this.manager = manager;
    }
    public NewsFormController() {
        setCommandName("news");
        setCommandClass(News.class);
    }

    @Override
	protected void initBinder(HttpServletRequest request, ServletRequestDataBinder binder) {
		super.initBinder(request, binder);
		binder.registerCustomEditor(Website.class, null, 
                new WebsiteEditor(websiteManager));
	}

	@Override
	protected Map referenceData(HttpServletRequest arg0) throws Exception {
    	Map map = new HashMap();

		map.put(Constants.WEBSITE_LIST, websiteManager.getWebsites(null));
		return map;
	}

	protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        News news = null;

        if (!StringUtils.isEmpty(id)) {
            news = (News) manager.getObject(News.class, new Long(id));
        } else {
            news = new News();
        }

        return news;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        News news = (News) command;
        boolean isNew = (news.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            manager.removeObject(News.class, news.getId());

            saveMessage(request, getText("news.deleted", locale));
        } else {
            manager.saveObject(news);

            String key = (isNew) ? "news.added" : "news.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editNews.html", "id", news.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }

	public void setWebsiteManager(WebsiteManager websiteManager) {
		this.websiteManager = websiteManager;
	}
}
