package com.foxconn.cic.service;

import com.foxconn.cic.model.News;

/**
 *
 */
public class NewsSearchResults {

    /**
     * <p>參照<code>org.compass.core.support.search.CompassSearchResults</code>改寫。
     * <p>重要用于Webservice搜索返回結果。
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

    private News[] news;

    private Page[] pages;

    private long searchTime;

    private int total;

    public NewsSearchResults(){
    	
    }
    
    public NewsSearchResults(News[] news, long searchTime, int total) {
        this.news = news;
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
    public News[] getNews() {
        return news;
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

	public void setNews(News[] news) {
		this.news = news;
	}

	public void setSearchTime(long searchTime) {
		this.searchTime = searchTime;
	}

	public void setTotal(int total) {
		this.total = total;
	}
}
