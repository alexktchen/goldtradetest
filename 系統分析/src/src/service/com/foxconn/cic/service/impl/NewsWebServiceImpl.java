package com.foxconn.cic.service.impl;

import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.News;
import com.foxconn.cic.service.NewsManager;
import com.foxconn.cic.service.NewsSearchResults;
import com.foxconn.cic.service.NewsWebService;
import com.foxconn.cic.service.NewsSearchResults.Page;
import com.foxconn.cic.util.ImageTagHelper;

public class NewsWebServiceImpl implements NewsWebService {

	private NewsManager newsManager;
	private ImageTagHelper imageTagHelper;


	public News getNews(String id) {
		return newsManager.getNews(id);
	}

	public void setNewsManager(NewsManager newsManager) {
		this.newsManager = newsManager;
	}

	public NewsSearchResults search(String query, Integer page) {
		AdvancedSearchCommand searchCommand=new AdvancedSearchCommand();
		searchCommand.setQuery(query);
		searchCommand.setPage(page);
		searchCommand.setAnalyzer("search");
		CompassSearchResults result=newsManager.search(searchCommand);
		News[] list=new News[result.getHits().length];
		for(int i=0;i<result.getHits().length;i++){
			News news=(News)result.getHits()[i].getData();
			list[i]=news;
		}
		Page[] pages=new Page[result.getPages().length];
		for(int i=0;i<result.getPages().length;i++){
			Page resultPage=new Page();
			resultPage.setFrom(result.getPages()[i].getFrom());
			resultPage.setTo(result.getPages()[i].getTo());
			resultPage.setSize(result.getPages()[i].getSize());
			resultPage.setSelected(result.getPages()[i].isSelected());
			pages[i]=resultPage;
		}
		NewsSearchResults newsresult =new NewsSearchResults(list,result.getSearchTime(),result.getTotalHits());
		newsresult.setPages(pages);
		return newsresult;
	}

	public News getNews(String id, String virtualDirectory) {
		News news=getNews(id);
		return imageTagHelper.restoreWithFilePath(news, virtualDirectory);
	}

	public void setImageTagHelper(ImageTagHelper imageTagHelper) {
		this.imageTagHelper = imageTagHelper;
	}

	public boolean isExisted(News news) {
		String title=news.getTitle();
		String url=news.getUrl();
		title=replaceSlash(title);
		url=replaceSlash(url);
		int index = title.indexOf("\"");
		while (index != -1) {
			StringBuffer buffer = new StringBuffer(title);
			buffer.insert(index, "\\");
			title = buffer.toString();
			index = title.indexOf("\"", index + 2);
		}
		AdvancedSearchCommand searchCommand=new AdvancedSearchCommand();
		searchCommand.setQuery("untokenizedtitle:\"" + title + "\" AND untokenizedurl:\""
				+ url + "\"");
		searchCommand.setAnalyzer("keyword");
		CompassSearchResults result = newsManager.search(searchCommand);
		if (result.getTotalHits() > 0) {
			return true;
		} else {
			return false;
		}
	}
	/**
	 * 將一個斜杠替換成兩個斜杠<br>
	 * 因為Lucene 2.2中的QueryParser會將去掉一個斜杠
	 * @param str
	 * @return
	 */
	
	private String replaceSlash(String str){
		return str.replace("\\", "\\\\");
	}
}
