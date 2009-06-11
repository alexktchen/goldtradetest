package com.foxconn.cic.service.impl;

import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.News;
import com.foxconn.cic.service.NewsFacade;
import com.foxconn.cic.service.NewsManager;


public class NewsFacadeImpl implements NewsFacade {
	private NewsManager newsManager;
	/* (non-Javadoc)
	 * @see com.foxconn.cic.webapp.action.NewsFacade#browse(java.lang.String)
	 */
	public News browse(String newsId){
		return newsManager.getNews(newsId);
	}
	/* (non-Javadoc)
	 * @see com.foxconn.cic.webapp.action.NewsFacade#rss(com.foxconn.cic.service.impl.AdvancedSearchCommand)
	 */
	public CompassSearchResults rss(AdvancedSearchCommand command){
		return newsManager.search(command);
		
	}
	/* (non-Javadoc)
	 * @see com.foxconn.cic.webapp.action.NewsFacade#search(com.foxconn.cic.service.impl.AdvancedSearchCommand)
	 */
	public CompassSearchResults search(AdvancedSearchCommand command){
		return newsManager.search(command);
		
	}
	public NewsManager getNewsManager() {
		return newsManager;
	}
	public void setNewsManager(NewsManager newsManager) {
		this.newsManager = newsManager;
	}
}
