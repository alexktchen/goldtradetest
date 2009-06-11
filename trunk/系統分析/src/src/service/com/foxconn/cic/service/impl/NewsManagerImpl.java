package com.foxconn.cic.service.impl;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchHelper;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.dao.NewsDao;
import com.foxconn.cic.model.News;
import com.foxconn.cic.service.NewsManager;
import com.foxconn.cic.util.ImageTagHelper;

public class NewsManagerImpl extends BaseManager implements NewsManager {
	private NewsDao dao;
	private ImageTagHelper imageTagHelper;
	private CompassSearchHelper searchHelper;

	/**
	 * Set the Dao for communication with the data layer.
	 * 
	 * @param dao
	 */
	public void setNewsDao(NewsDao dao) {
		this.dao = dao;
	}

	/**
	 * @see com.foxconn.cic.service.NewsManager#getNewss(com.foxconn.cic.model.News)
	 */
	public List getNewss(final News news) {
		return dao.getNewss(news);
	}

	/**
	 * @see com.foxconn.cic.service.NewsManager#getNews(String id)
	 */
	public News getNews(final String id) {
		return dao.getNews(new Long(id));
	}

	/**
	 * @see com.foxconn.cic.service.NewsManager#saveNews(News news)
	 */
	public News saveNews(News news) {
		if (news.getId() == null) {
			// 新聞第一加入時需替換新聞內容中<IMG>標簽中的src
			return dao.saveNews(imageTagHelper.modify(news));
		} else {
			return dao.saveNews(news);
		}

	}

	/**
	 * @see com.foxconn.cic.service.NewsManager#removeNews(String id)
	 */
	public void removeNews(final String id) {
		dao.removeNews(new Long(id));
	}

	public CompassSearchResults search(CompassSearchCommand searchCommand) {
		CompassSearchResults result = searchHelper.search(searchCommand);
		return result;
	}

	public CompassSearchHelper getSearchHelper() {
		return searchHelper;
	}

	public void setSearchHelper(CompassSearchHelper searchHelper) {
		this.searchHelper = searchHelper;
	}

	public News getNews(String title, String url) {
		return dao.getNews(title, url);
	}

	public void setImageTagHelper(ImageTagHelper imageTagHelper) {
		this.imageTagHelper = imageTagHelper;
	}

	public List<News> getNewss(String beginId, String endId) {
		return dao.getNewss(new Long(beginId), new Long(endId));
	}

	public List<String> getNewsIds() {
		return dao.getNewsIds();
	}

}
