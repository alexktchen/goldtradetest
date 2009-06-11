package com.foxconn.cic.webapp.action;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.Catalog;
import com.foxconn.cic.service.CatalogManager;

public class CatalogController extends MultiActionController{
    private final Log log = LogFactory.getLog(CatalogController.class);
    private CatalogManager catalogManager = null;
    private String ajaxTreeXml = null;
    private String browserPage;

	public String getBrowserPage() {
		return browserPage;
	}

	public void setBrowserPage(String browserPage) {
		this.browserPage = browserPage;
	}
	
    public void setAjaxTreeXml(String ajaxTreeXml) {
		this.ajaxTreeXml = ajaxTreeXml;
	}

	public ModelAndView list(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }
        String parentid = request.getParameter("parentid");
        Catalog catalog = null;
        List catalogs=null;
        if(parentid != null){
        	catalog = catalogManager.getCatalog(parentid);
        	catalogs = catalog.getChildren();
        }else{
        	catalogs=catalogManager.getCatalogs(new Catalog());
        }
        String ajax= request.getParameter("ajaxtreexml");
        if(ajax!=null && ajax.equalsIgnoreCase("true")){
        	return new ModelAndView(ajaxTreeXml, Constants.CATALOG_LIST,
        			catalogs);
        }
        Map map =new HashMap();
        map.put( Constants.CATALOG_LIST, catalogs);
        if(catalog!=null)map.put("catalog", catalog);
        return new ModelAndView("catalogList",map);
    }
	public ModelAndView browse(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		if (log.isDebugEnabled()) {
			log.debug("entering 'browse' method...");
		}
		String id=request.getParameter("id");
		return new ModelAndView(browserPage, "news", catalogManager.getCatalog(id));
	}
	public void setCatalogManager(CatalogManager catalogManager) {
		this.catalogManager = catalogManager;
	}
}
