package com.foxconn.cic.service;

import com.foxconn.cic.model.ExchangeRate;

/**
 * The results object returned by
 * {@link org.compass.core.support.search.CompassSearchHelper} when the search
 * operation on <code>Compass</code> is executed.
 * <p>
 * Holds the time it took to perform the search operation (in milliseconds), an
 * array of <code>CompassHit</code> (which might be all the hits, or only
 * paginated hits) and an array of <code>Page</code>s if using the pagination
 * feature.
 * 
 * @author kimchy
 */
public class ExchangeRateSearchResults {


	protected ExchangeRate[] exchangeRates;

	private Page[] pages;

	private long searchTime;

	private int total;

	public ExchangeRateSearchResults(){
		
	}
	
	public ExchangeRateSearchResults(ExchangeRate[] hits, long searchTime, int totalHits) {
		this.exchangeRates = hits;
		this.searchTime = searchTime;
		this.total = totalHits;
	}

	/**
	 * Returns the hits that resulted from the search operation. Might hold all
	 * the hits (not using pagination) or only the hits that belong to the
	 * selected page (if using pagination).
	 * 
	 * @return The hits
	 */
	public ExchangeRate[] getExchangeRates() {
		return exchangeRates;
	}

	/**
	 * Returns the time that it took to perform the search operation (in
	 * milliseconds).
	 * 
	 * @return How long it took to perform the serarch in milli-seconds.
	 */
	public long getSearchTime() {
		return searchTime;
	}

	/**
	 * Returns the total number of hits resulted from this search query.
	 * 
	 * @return The total number of hits
	 */
	public int getTotal() {
		return this.total;
	}

	/**
	 * Returns the pages that construct all the results.
	 * 
	 * @return The pages that holds all the results
	 */
	public Page[] getPages() {
		return pages;
	}

	/**
	 * Sets the pages that contruct all the results.
	 * 
	 * @param pages
	 */
	public void setPages(Page[] pages) {
		this.pages = pages;
	}

	public void setExchangeRateSearchs(
			ExchangeRate[] exchangeRates) {
		this.exchangeRates = exchangeRates;
	}

	public void setSearchTime(long searchTime) {
		this.searchTime = searchTime;
	}

	public void setTotal(int total) {
		this.total = total;
	}

	public void setExchangeRates(ExchangeRate[] exchangeRates) {
		this.exchangeRates = exchangeRates;
	}
}

