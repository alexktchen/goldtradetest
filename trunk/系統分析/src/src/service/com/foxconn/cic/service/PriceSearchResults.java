package com.foxconn.cic.service;

import com.foxconn.cic.model.Price;


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
public class PriceSearchResults {

    /**
     * A class which holds the page data if using the pagination feature.
     *
     * @author kimchy
     */
    public static class Page {
        private int from;

        private int to;

        private int size;

        private boolean selected;

        /**
         * Returns the hit number the page starts from.
         */
        public int getFrom() {
            return from;
        }

        /**
         * Sets the hit number the page starts from.
         */
        public void setFrom(int from) {
            this.from = from;
        }

        /**
         * Returns <code>true</code> if the page is selected, i.e. the results
         * that are shown are part of the page.
         */
        public boolean isSelected() {
            return selected;
        }

        /**
         * Sets if the page is selected or not.
         */
        public void setSelected(boolean selected) {
            this.selected = selected;
        }

        /**
         * Returns the size of the hits in the page.
         */
        public int getSize() {
            return size;
        }

        /**
         * Sets the size of the hits in the page.
         */
        public void setSize(int size) {
            this.size = size;
        }

        /**
         * Returns the hit number that the page ends at.
         */
        public int getTo() {
            return to;
        }

        /**
         * Sets the hit number that the page ends at.
         */
        public void setTo(int to) {
            this.to = to;
        }
    }

    private Price[] price;

    private Page[] pages;

    private long searchTime;

    private int total;

    public PriceSearchResults(){
    	
    }
    
    public PriceSearchResults(Price[] price, long searchTime, int total) {
        this.price = price;
        this.searchTime = searchTime;
        this.total = total;
    }

    /**
     * Returns the hits that resulted from the search operation. Might hold all
     * the hits (not using pagination) or only the hits that belong to the
     * selected page (if using pagination).
     *
     * @return The hits
     */
    public Price[] getPrice() {
        return price;
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

	public void setPrice(Price[] price) {
		this.price = price;
	}

	public void setSearchTime(long searchTime) {
		this.searchTime = searchTime;
	}

	public void setTotal(int total) {
		this.total = total;
	}
}
