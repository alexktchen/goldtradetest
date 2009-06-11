package com.foxconn.cic.service;

import com.foxconn.cic.model.ExchangeRate;
/**
 *
 * @author ldapeng
 * @aegis.mapping
 */
public interface ExchangeRateWebService {

	public ExchangeRateSearchResults search(String query,Integer page);

	public ExchangeRate getExchangeRate(final String id);
	
	public boolean isExisted(ExchangeRate exchangeRate,String condition);

}
