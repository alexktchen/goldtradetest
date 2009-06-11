package com.foxconn.cic.webapp.action;

import java.util.List;
import java.util.Vector;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.beanutils.BeanUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.compass.core.CompassHit;
import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchResults;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.View;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.Website;
import com.foxconn.cic.service.WebsiteManager;

public class WebsiteController extends MultiActionController {
    private final Log log = LogFactory.getLog(WebsiteController.class);
    private WebsiteManager websiteManager = null;
    private View opmlView;
    private View textView;
    public void setTextView(View textView) {
		this.textView = textView;
	}

	public void setWebsiteManager(WebsiteManager websiteManager) {
        this.websiteManager = websiteManager;
    }

    public void setOpmlView(View opmlView) {
		this.opmlView = opmlView;
	}

	public ModelAndView list(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'list' method...");
        }
        
        Website website = new Website();
        
        if(request.getParameter("ajaxMatrix")!=null && request.getParameter("ajaxMatrix").equalsIgnoreCase("true")){
        	String queryString=request.getParameter("value");
        	CompassSearchCommand command=new CompassSearchCommand();
        	command.setQuery(queryString);
        	command.setPage(null);
        	CompassSearchResults results= websiteManager.search(command);
        	Vector<Website> websites=new Vector<Website>();
        	CompassHit[] hits = results.getHits();
			for (CompassHit hit : hits) {
				websites.add((Website) hit.getData());

			}
        	return new ModelAndView("websiteMatrix", Constants.WEBSITE_LIST, websites);
        }
       
        // populate object with request parameters
        BeanUtils.populate(website, request.getParameterMap());

        List websites = websiteManager.getWebsites(website);
        
        return new ModelAndView("websiteList", Constants.WEBSITE_LIST, websites);
    }

    public ModelAndView exportOPML(HttpServletRequest request,
            HttpServletResponse response)
    throws Exception {
    	 if (log.isDebugEnabled()) {
             log.debug("entering 'exportOPML' method...");
         }

         Website website = new Website();
         // populate object with request parameters
         BeanUtils.populate(website, request.getParameterMap());

         List websites = websiteManager.getWebsites(website);

         return new ModelAndView(opmlView, Constants.WEBSITE_LIST, websites);
    }
    public ModelAndView exportProperties(HttpServletRequest request,
            HttpServletResponse response)
    throws Exception {
    	 if (log.isDebugEnabled()) {
             log.debug("entering 'exportProperties' method...");
         }

    	 String id=request.getParameter("id");
         Website website =websiteManager.getWebsite(id);
         return new ModelAndView(textView, "text", website.getProperties());
    }
}
