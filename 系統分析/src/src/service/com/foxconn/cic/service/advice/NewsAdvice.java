package com.foxconn.cic.service.advice;

import java.lang.reflect.Method;

import org.compass.core.support.search.CompassSearchCommand;

import com.foxconn.cic.model.News;
import com.foxconn.cic.model.UserActivityLogConstants;

public class NewsAdvice extends UserActivityAdvice {

	@Override
	public String getActivity(Object returnValue, Method method, Object[] args,
			Object target) {
			
		if(method.getName().equals("browse")//NewsFacade.browse
				||method.getName().equals("getNews")//NewsWebService.getNews
				){
			return UserActivityLogConstants.ACTIVITY_NEWS_BROWSE;
		}else if(method.getName().equals("search")//NewsWebService.search&&NewsFacade.search
				){
			return UserActivityLogConstants.ACTIVITY_NEWS_SEARCH;
		}
		else if (method.getName().equals("rss")// NewsFacade.rss
		) {
			return UserActivityLogConstants.ACTIVITY_NEWS_RSS;
		}
		return method.getName();
	}

	@Override
	public String getMetaData(Object returnValue, Method method, Object[] args,
			Object target) {
		if(method.getName().equals("getNews")){//NewsWebService.getNews
			if (returnValue != null && returnValue instanceof News) {
				return ((News) returnValue).getId().toString();
			}
		}else if(method.getName().equals("search") //NewsWebService.search 
				|| method.getName().equals("rss") ){//NewsFacade.rss
			if(args[0]!=null){
				if(args[0] instanceof CompassSearchCommand){
					return ((CompassSearchCommand)args[0]).getQuery();
				}
				return args[0].toString();
			}
		}else if(method.getName().equals("browse")){//NewsController.browse
			if(args[0]!=null)return args[0].toString();
			
		}
		if(returnValue!=null){
			return returnValue.toString();
		}else {
			return "";
		}
		
	}

}
