package com.foxconn.cic.service;

import com.foxconn.cic.model.InterestRate;
/**
 *
 * @author ldapeng
 * @aegis.mapping
 */
public interface InterestRateWebService {

	public InterestRateSearchResults search(String query,Integer page);

	public InterestRate getInterestRate(final String id);
	
	public boolean isExisted(InterestRate rate,String condition);

}
