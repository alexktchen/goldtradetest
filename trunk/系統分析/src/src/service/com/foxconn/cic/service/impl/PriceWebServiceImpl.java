package com.foxconn.cic.service.impl;

import java.text.SimpleDateFormat;

import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.Price;
import com.foxconn.cic.model.PriceConstants;
import com.foxconn.cic.service.PriceManager;
import com.foxconn.cic.service.PriceSearchResults;
import com.foxconn.cic.service.PriceWebService;
import com.foxconn.cic.service.PriceSearchResults.Page;

public class PriceWebServiceImpl implements PriceWebService {

	private PriceManager priceManager;


	public Price getPrice(String id) {
		return priceManager.getPrice(id);
	}

	public void setPriceManager(PriceManager priceManager) {
		this.priceManager = priceManager;
	}

	public PriceSearchResults search(String query, Integer page) {
		AdvancedSearchCommand searchCommand=new AdvancedSearchCommand();
		searchCommand.setQuery(query);
		searchCommand.setPage(page);
		searchCommand.setAnalyzer("search");
		CompassSearchResults result=priceManager.search(searchCommand);
		Price[] list=new Price[result.getHits().length];
		for(int i=0;i<result.getHits().length;i++){
			Price price=(Price)result.getHits()[i].getData();
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

		PriceSearchResults priceresult =new PriceSearchResults(list,result.getSearchTime(),result.getTotalHits());
		priceresult.setPages(pages);
		return priceresult;
	}

	public boolean isExisted(Price price,String condition) {
		StringBuffer query=new StringBuffer();
		SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
		String publishdate=format.format(price.getPublishDate());
		query.append("publishdate:"+publishdate);
		query.append(" AND ");
		query.append("websiteid:"+price.getWebsite().getId());
		query.append(" AND ");
		query.append("materialid:"+price.getMaterial().getId());

		if (condition != null && condition.length() > 0) {
			String[] conditions = condition.split(",");
			for (String string : conditions) {
				if (query.toString().trim().length() != 0) {
					query.append(" AND ");
				}
				if (PriceConstants.XMLTAG_PRICE_UNIT.equals(string)) {
					query.append("unit:" + price.getUnit());
				} else if (PriceConstants.XMLTAG_PRICE_VALUE.equals(string)) {
					query.append("value:" + price.getValue());
				} else if (PriceConstants.XMLTAG_PRICE_TYPE.equals(string)) {
					query.append("type:" + price.getType());
				} else if (PriceConstants.XMLTAG_PRICE_MARKET.equals(string)) {
					query.append("market:" + price.getMarket());
				} else if (PriceConstants.XMLTAG_PRICE_PRODUCING_AREA.equals(string)) {
					query.append("producingarea:" + price.getProducingArea());
				} else if (PriceConstants.XMLTAG_PRICE_REMARK.equals(string)) {
					query.append("remark:" + price.getRemark());
				}
			}
		}
		AdvancedSearchCommand searchCommand=new AdvancedSearchCommand();
		searchCommand.setQuery(query.toString());
		searchCommand.setAnalyzer("keyword");
		CompassSearchResults result=priceManager.search(searchCommand);
		if(result.getTotalHits()>0){
			return true;
		}else{
			return false;
		}
	}

}
