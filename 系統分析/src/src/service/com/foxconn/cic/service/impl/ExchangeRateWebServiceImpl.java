package com.foxconn.cic.service.impl;

import java.text.SimpleDateFormat;

import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.ExchangeRate;
import com.foxconn.cic.service.ExchangeRateManager;
import com.foxconn.cic.service.ExchangeRateSearchResults;
import com.foxconn.cic.service.ExchangeRateWebService;
import com.foxconn.cic.service.Page;

public class ExchangeRateWebServiceImpl implements ExchangeRateWebService {

	private ExchangeRateManager exchangeRateManager;


	public ExchangeRate getExchangeRate(String id) {
		return exchangeRateManager.getExchangeRate(id);
	}


	public void setExchangeRateManager(ExchangeRateManager exchangeRateManager) {
		this.exchangeRateManager = exchangeRateManager;
	}


	public ExchangeRateSearchResults search(String query, Integer page) {
		AdvancedSearchCommand searchCommand=new AdvancedSearchCommand();
		searchCommand.setQuery(query);
		searchCommand.setPage(page);
		searchCommand.setAnalyzer("search");
		
		CompassSearchResults result=exchangeRateManager.search(searchCommand);
		ExchangeRate[] list=new ExchangeRate[result.getHits().length];
		for(int i=0;i<result.getHits().length;i++){
			ExchangeRate price=(ExchangeRate)result.getHits()[i].getData();
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

		ExchangeRateSearchResults priceresult =new ExchangeRateSearchResults(list,result.getSearchTime(),result.getTotalHits());
		priceresult.setPages(pages);
		return priceresult;
	}


	public boolean isExisted(ExchangeRate exchangeRate,String condition) {
		StringBuffer query=new StringBuffer();
		SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
		String publishdate=format.format(exchangeRate.getPublishDate());
		query.append("publishdate:"+publishdate);
		query.append(" AND ");
		query.append("websiteid:"+exchangeRate.getWebsite().getId());
		query.append(" AND ");
		query.append("unitcurrency:"+exchangeRate.getUnitCurrency());
		query.append(" AND ");
		query.append("pricecurrency:"+exchangeRate.getPriceCurrency());
		query.append(" AND ");
		query.append("amout:"+exchangeRate.getAmout());
		if(exchangeRate.getPriceType()!=null && !exchangeRate.getPriceType().trim().equals("")){
			query.append(" AND ");
			query.append("pricetype:"+exchangeRate.getPriceType());
		}
		
		AdvancedSearchCommand searchCommand=new AdvancedSearchCommand();
		searchCommand.setQuery(query.toString());
		searchCommand.setAnalyzer("keyword");
		CompassSearchResults result=exchangeRateManager.search(searchCommand);
		
		if(result.getTotalHits()>0){
			return true;
		}else{
			return false;
		}
	}

}
