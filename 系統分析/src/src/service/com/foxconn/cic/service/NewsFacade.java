package com.foxconn.cic.service;

import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.News;
import com.foxconn.cic.service.impl.AdvancedSearchCommand;

/**
 * Facade模式，用于web段调用和用户行为记录
 * @author ldapeng
 *
 */

public interface NewsFacade {

	public abstract News browse(String newsId);

	public abstract CompassSearchResults rss(AdvancedSearchCommand command);

	public abstract CompassSearchResults search(AdvancedSearchCommand command);

}