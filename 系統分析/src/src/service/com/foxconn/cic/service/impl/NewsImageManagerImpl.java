
package com.foxconn.cic.service.impl;

import java.util.List;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import com.foxconn.cic.dao.NewsImageDao;
import com.foxconn.cic.model.News;
import com.foxconn.cic.model.NewsImage;
import com.foxconn.cic.model.NewsParser;
import com.foxconn.cic.service.NewsImageManager;
import com.foxconn.cic.service.NewsManager;

public class NewsImageManagerImpl extends BaseManager implements NewsImageManager {
	private final Log log = LogFactory.getLog(NewsImageManagerImpl.class);
	private NewsImageDao dao;
	private NewsManager newsManager;
    private String filePath;
    private int gt;
    private int lt;

	public void setGt(int gt) {
		this.gt = gt;
	}

	public void setLt(int lt) {
		this.lt = lt;
	}

	/**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setNewsImageDao(NewsImageDao dao) {
        this.dao = dao;
    }

    public void setNewsManager(NewsManager newsManager){
    	this.newsManager=newsManager;
    }
    /**
     * @see com.foxconn.cic.service.NewsImageManager#getNewsImages(com.foxconn.cic.model.NewsImage)
     */
    public List getNewsImages(final NewsImage newsImage) {
        return dao.getNewsImages(newsImage);
    }

    /**
     * @see com.foxconn.cic.service.NewsImageManager#getNewsImage(String id)
     */
    public NewsImage getNewsImage(final String id) {
        return dao.getNewsImage(new Long(id));
    }

    /**
     * @see com.foxconn.cic.service.NewsImageManager#saveNewsImage(NewsImage newsImage)
     */
    public void saveNewsImage(NewsImage newsImage) {
        dao.saveNewsImage(newsImage);
    }

    /**
     * @see com.foxconn.cic.service.NewsImageManager#removeNewsImage(String id)
     */
    public void removeNewsImage(final String id) {
        dao.removeNewsImage(new Long(id));
    }


	
	
	public void setFilePath(String path) {
		filePath=path;
	}

	public String getFilePath() {
		return filePath;
	}

	public List<NewsImage> getFilepathIsNullNewsImages() {
		List<NewsImage> images = dao.getFilepathIsNullNewsImages(gt, lt);
		for (NewsImage image : images) {
			News news=newsManager.getNews(image.getNewsId().toString());
			image.setUrl(NewsParser.assembleUrl(news.getUrl(), image.getUrl()));
		}
		return images;
	}

}
