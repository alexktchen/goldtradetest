package com.foxconn.cic.service.impl;

import java.util.List;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.compass.core.Compass;
import org.compass.core.CompassCallback;
import org.compass.core.CompassException;
import org.compass.core.CompassSession;
import org.compass.core.CompassTemplate;
import org.compass.core.lucene.engine.LuceneSearchEngineInternalSearch;
import org.compass.core.lucene.util.LuceneHelper;

import com.foxconn.cic.model.News;
import com.foxconn.cic.service.IndexManager;
import com.foxconn.cic.service.NewsManager;

public class IndexManagerImpl implements IndexManager {

	private final Log log = LogFactory.getLog(IndexManagerImpl.class);
	private Compass compass;
	CompassTemplate compassTemplate;
	private NewsManager newsManager;

	public void setNewsManager(NewsManager newsManager) {
		this.newsManager = newsManager;
	}

	public int getDocumentMaxNumber() {
		CompassTemplate compassTemplate=new CompassTemplate(compass);
		Object o =compassTemplate.execute(new CompassCallback() {
			public Object doInCompass(CompassSession session) throws CompassException {
				LuceneSearchEngineInternalSearch internalSearch = LuceneHelper.getLuceneInternalSearch(session);
				return internalSearch.getReader().maxDoc()+"";
			}
		}
		);
		return Integer.parseInt(o.toString());

	}

	public int getDocumentSize() {
		Object o =compassTemplate.execute(new CompassCallback() {
			public Object doInCompass(CompassSession session) throws CompassException {
				LuceneSearchEngineInternalSearch internalSearch = LuceneHelper.getLuceneInternalSearch(session);
				return internalSearch.getReader().numDocs()+"";
			}
		}
		);
		return Integer.parseInt(o.toString());
	}

	public void setCompass(Compass compass) {
		this.compass = compass;
		compassTemplate=new CompassTemplate(compass);
	}

	public void syncIndex(String beginId, String endId) {
		int begin=Integer.parseInt(beginId);
		int end=Integer.parseInt(endId);
		//出于減少對系統性能影響，每次查詢只獲得100條
		for(;begin<=end;begin=begin+100){
			int e=begin+99;
			if(e>end)e=end;
			log.debug("Start index from "+begin+" to "+e);
			List<News> newsList=newsManager.getNewss(begin+"",e+"");
			for (News news : newsList) {
				log.debug("News id:"+news.getId());
				compassTemplate.save(news);
			}
		}
		
	}

	public void deleteNews(String id) {
		compassTemplate.delete(News.class,id);
	}

	public News getNews(String id) {
		return (News)compassTemplate.get(News.class, new Long(id));

	}

}
