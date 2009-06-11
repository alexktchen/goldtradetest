package com.foxconn.cic.service;

import com.foxconn.cic.model.Price;
/**
 *
 * @author ldapeng
 * @aegis.mapping
 */
public interface PriceWebService {

	public PriceSearchResults search(String query,Integer page);

	public Price getPrice(final String id);

	/**
	 * 判斷新聞是否存在
	 * @param title
	 * @param url
	 * @return
	 */
	public boolean isExisted(Price price,String condition);
}
