package com.foxconn.cic.service;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.News;

public interface NewsManager extends Manager {
	/**
	 * Retrieves all of the newss
	 */
	public List getNewss(News news);

	/**
	 * 得到指定的起始id的新聞列表
	 * 
	 * @param beginId
	 *            開始id
	 * @param endId
	 *            結束id
	 * @return
	 */
	public List<News> getNewss(final String beginId, final String endId);

	/**
	 * 獲得搜索新聞的id列表
	 * 
	 * @return
	 */
	public List<String> getNewsIds();

	/**
	 * Gets news's information based on id.
	 * 
	 * @param id
	 *            the news's id
	 * @return news populated news object
	 */
	public News getNews(final String id);

	/**
	 * Saves a news's information
	 * 
	 * @param news
	 *            the object to be saved
	 */
	public News saveNews(News news);

	/**
	 * Removes a news from the database by id
	 * 
	 * @param id
	 *            the news's id
	 */
	public void removeNews(final String id);

	/**
	 * 通過新聞Title和URL得到News，主要用於檢查信息是否已經存在，如果不存在返回null。
	 * 
	 * @param title
	 * @param url
	 * @return
	 */
	public News getNews(String title, String url);

	public CompassSearchResults search(CompassSearchCommand searchCommand);
}
