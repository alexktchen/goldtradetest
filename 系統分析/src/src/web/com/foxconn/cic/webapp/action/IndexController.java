package com.foxconn.cic.webapp.action;

import java.util.HashMap;
import java.util.Vector;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.compass.spring.web.mvc.CompassIndexResults;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.util.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.foxconn.cic.model.News;
import com.foxconn.cic.service.IndexManager;
import com.foxconn.cic.service.NewsManager;

public class IndexController extends MultiActionController implements InitializingBean{

	private IndexManager indexManager;

	private NewsManager newsManager;

    private String indexView;

    private String indexResultsView;

    private String indexResultsName = "indexResults";

    public void afterPropertiesSet() throws Exception {
        if (indexView == null) {
            throw new IllegalArgumentException("Must set the indexView property");
        }
        if (indexResultsView == null) {
            throw new IllegalArgumentException("Must set the indexResultsView property");
        }

    }
	public ModelAndView list(HttpServletRequest arg0,
			HttpServletResponse arg1) throws Exception {
		HashMap data = new HashMap();
		data.put("indexDocumentSize", indexManager.getDocumentSize());
		data.put("indexDocumentMaxNumber", indexManager.getDocumentMaxNumber());
		return new ModelAndView(getIndexResultsView(), data);
	}

	public ModelAndView updateIndex(HttpServletRequest arg0,
			HttpServletResponse arg1,IndexCommand indexCommand) throws Exception {
		if (!StringUtils.hasText(indexCommand.getBeginId()) || !StringUtils.hasText(indexCommand.getEndId())) {
            return new ModelAndView(getIndexView(), "indexCommand", indexCommand);
        }
		long time = System.currentTimeMillis();

		indexManager.syncIndex(indexCommand.getBeginId(), indexCommand.getEndId());

		time = System.currentTimeMillis() - time;
		CompassIndexResults indexResults = new CompassIndexResults(time);
		HashMap data = new HashMap();
		data.put("indexCommand", indexCommand);
		data.put(getIndexResultsName(), indexResults);
		return new ModelAndView(getIndexResultsView(), data);
	}
	public ModelAndView deleteNews(HttpServletRequest arg0,
			HttpServletResponse arg1,IndexCommand indexCommand) throws Exception {
		if (!StringUtils.hasText(indexCommand.getResourceId())) {
            return new ModelAndView(getIndexView(), "indexCommand", indexCommand);
        }
		long time = System.currentTimeMillis();

		News news=indexManager.getNews(indexCommand.getResourceId());

		indexManager.deleteNews(indexCommand.getResourceId());

		time = System.currentTimeMillis() - time;
		CompassIndexResults indexResults = new CompassIndexResults(time);
		HashMap data = new HashMap();
		data.put("indexCommand", indexCommand);
		data.put(getIndexResultsName(), indexResults);
		data.put("news", news);
		return new ModelAndView(getIndexResultsView(), data);
	}
	public ModelAndView syncNews(HttpServletRequest arg0,
			HttpServletResponse arg1,IndexCommand indexCommand) throws Exception {
		if (!StringUtils.hasText(indexCommand.getSyncIndex()) || !indexCommand.getSyncIndex().equalsIgnoreCase("true")) {
            return new ModelAndView(getIndexView(), "indexCommand", indexCommand);
        }
		long time = System.currentTimeMillis();

		Vector ids=new Vector();

		//@todo

		time = System.currentTimeMillis() - time;
		CompassIndexResults indexResults = new CompassIndexResults(time);
		HashMap data = new HashMap();
		data.put("indexCommand", indexCommand);
		data.put(getIndexResultsName(), indexResults);
		data.put("newsIds", ids);
		return new ModelAndView(getIndexResultsView(), data);
	}
	public String getIndexResultsName() {
		return indexResultsName;
	}

	public void setIndexResultsName(String indexResultsName) {
		this.indexResultsName = indexResultsName;
	}

	public String getIndexResultsView() {
		return indexResultsView;
	}

	public void setIndexResultsView(String indexResultsView) {
		this.indexResultsView = indexResultsView;
	}

	public String getIndexView() {
		return indexView;
	}

	public void setIndexView(String indexView) {
		this.indexView = indexView;
	}

	public void setIndexManager(IndexManager indexManager) {
		this.indexManager = indexManager;
	}
	public void setNewsManager(NewsManager newsManager) {
		this.newsManager = newsManager;
	}
}
