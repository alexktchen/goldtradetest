package com.foxconn.cic.webapp.action;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.compass.core.support.search.CompassSearchResults;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.View;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.News;
import com.foxconn.cic.service.NewsFacade;
import com.foxconn.cic.service.impl.AdvancedSearchCommand;
import com.foxconn.cic.util.ImageTagHelper;
import com.foxconn.cic.webapp.util.RequestUtil;

public class NewsController extends MultiActionController {
	private final Log log = LogFactory.getLog(NewsController.class);

	private String browserPage;

	private View feedView;

	private ImageTagHelper imageTagHelper;

	private NewsFacade newsFacade;
	public void setImageTagHelper(ImageTagHelper imageTagHelper) {
		this.imageTagHelper = imageTagHelper;
	}

	public String getBrowserPage() {
		return browserPage;
	}

	public void setBrowserPage(String browserPage) {
		this.browserPage = browserPage;
	}


	public ModelAndView list(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		if (log.isDebugEnabled()) {
			log.debug("entering 'list' method...");
		}

		return new ModelAndView("newsList", Constants.NEWS_LIST, newsFacade.browse(null));
	}

	public ModelAndView browse(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		if (log.isDebugEnabled()) {
			log.debug("entering 'browse' method...");
		}
		String id=request.getParameter("id");
		News news=newsFacade.browse(id);
		return new ModelAndView(browserPage, "news",imageTagHelper.restore(news, RequestUtil.getAppURL(request)+"/newsImages.html?method=browse&id="));
	}
	public ModelAndView rss(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		if (log.isDebugEnabled()) {
			log.debug("entering 'rss' method...");
		}
		AdvancedSearchCommand command=new AdvancedSearchCommand();


		String websiteId=request.getParameter("websiteid");
		String query;
		if(websiteId==null || websiteId.trim().equals("")){
			Date today=new Date();
			SimpleDateFormat format=new SimpleDateFormat("yyyyMMdd");
			query="publishdate:"+format.format(today);
		}else{
			query="websiteid:"+websiteId;
		}
		if(request.getParameter("query")!=null && !request.getParameter("query").trim().equals("")){
			query=request.getParameter("query");
		}
		command.setQuery(query);
		CompassSearchResults result = newsFacade.rss(command);
		Map models=new HashMap();
		models.put("newsList", result.getHits());
		models.put("query", query);
		return new ModelAndView(feedView, models);
	}

	public void setFeedView(View feedView) {
		this.feedView = feedView;
	}

	public void setNewsFacade(NewsFacade newsFacade) {
		this.newsFacade = newsFacade;
	}

}
