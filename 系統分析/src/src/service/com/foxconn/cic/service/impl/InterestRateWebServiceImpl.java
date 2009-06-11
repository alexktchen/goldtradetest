package com.foxconn.cic.service.impl;

import java.text.SimpleDateFormat;

import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.InterestRate;
import com.foxconn.cic.service.InterestRateManager;
import com.foxconn.cic.service.InterestRateSearchResults;
import com.foxconn.cic.service.InterestRateWebService;
import com.foxconn.cic.service.Page;

public class InterestRateWebServiceImpl implements InterestRateWebService {

	private InterestRateManager interestRateManager;


	public InterestRate getInterestRate(String id) {
		return interestRateManager.getInterestRate(id);
	}


	public void setInterestRateManager(InterestRateManager manager) {
		this.interestRateManager = manager;
	}


	public InterestRateSearchResults search(String query, Integer page) {
		AdvancedSearchCommand searchCommand=new AdvancedSearchCommand();
		searchCommand.setQuery(query);
		searchCommand.setPage(page);
		searchCommand.setAnalyzer("search");
		
		CompassSearchResults result=interestRateManager.search(searchCommand);
		InterestRate[] list=new InterestRate[result.getHits().length];
		for(int i=0;i<result.getHits().length;i++){
			InterestRate price=(InterestRate)result.getHits()[i].getData();
			list[i]=price;
		}
		Page[] pages=new Page[result.getPages().length];
		for(int i=0;i<result.getPages().length;i++){
			Page page1=new Page();
			page1.setFrom(result.getPages()[i].getFrom());
			page1.setTo(result.getPages()[i].getTo());
			page1.setSize(result.getPages()[i].getSize());
			page1.setSelected(result.getPages()[i].isSelected());
			pages[i]=page1;
		}
		
		InterestRateSearchResults priceresult =new InterestRateSearchResults(list,result.getSearchTime(),result.getTotalHits());
		priceresult.setPages(pages);
		return priceresult;
	}


	public boolean isExisted(InterestRate rate, String condition) {
		StringBuffer query=new StringBuffer();
		SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
		String publishdate=format.format(rate.getPublishDate());
		query.append("publishdate:"+publishdate);
		query.append(" AND ");
		query.append("websiteid:"+rate.getWebsite().getId());
		query.append(" AND ");
		query.append("name:"+rate.getName());
		query.append(" AND ");
		query.append("currency:"+rate.getCurrency());
		query.append(" AND ");
		query.append("type:"+rate.getType());
		if(rate.getTimePeriod()!=null && !rate.getTimePeriod().trim().equals("")){
			query.append(" AND ");
			query.append("timeperiod:"+rate.getTimePeriod());
		}
		query.append(" AND ");
		query.append("publisher:"+rate.getPublisher());
		
		AdvancedSearchCommand searchCommand=new AdvancedSearchCommand();
		searchCommand.setQuery(query.toString());
		searchCommand.setAnalyzer("keyword");
		
		CompassSearchResults result=interestRateManager.search(searchCommand);
		if(result.getTotalHits()>0){
			return true;
		}else{
			return false;
		}
	}

}
