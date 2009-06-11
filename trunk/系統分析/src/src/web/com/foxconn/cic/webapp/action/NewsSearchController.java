package com.foxconn.cic.webapp.action;

import java.util.HashMap;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.compass.core.support.search.CompassSearchResults;
import org.compass.spring.web.mvc.AbstractCompassCommandController;
import org.springframework.util.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.service.NewsFacade;
import com.foxconn.cic.service.impl.AdvancedSearchCommand;

/**
 * <p> *此class是參照 <code>org.compass.spring.web.mvc.CompassSearchController</code> 改寫而成.
 *
 * <p> 原來方式搜索采用 <code>searchHelper</code> 屬性設置的CompassSearchHelper來進行搜索，現
 * 改成使用NewsManager代替原有方式。
 */
public class NewsSearchController extends AbstractCompassCommandController {

    private String searchView;

    private String searchResultsView;

    private String searchResultsName = "searchResults";

    private Integer pageSize;

    private NewsFacade newsFacade;

    public NewsSearchController() {
        setCommandClass(AdvancedSearchCommand.class);
    }

    public void afterPropertiesSet() throws Exception {
        super.afterPropertiesSet();
        if (searchView == null) {
            throw new IllegalArgumentException("Must set the searchView property");
        }
        if (searchResultsView == null) {
            throw new IllegalArgumentException("Must set the serachResultsView property");
        }

    }

    protected ModelAndView handle(HttpServletRequest request, HttpServletResponse response, Object command,
                                  BindException errors) throws Exception {
        final AdvancedSearchCommand searchCommand = (AdvancedSearchCommand) command;
        if (!StringUtils.hasText(searchCommand.getQuery())) {
            return new ModelAndView(getSearchView(), getCommandName(), searchCommand);
        }
        CompassSearchResults searchResults = newsFacade.search(searchCommand);
        HashMap data = new HashMap();
        data.put(getCommandName(), searchCommand);
        data.put(getSearchResultsName(), searchResults);
        return new ModelAndView(getSearchResultsView(), data);
    }

    /**
     * Returns the view that holds the screen which the user will initiate the
     * search operation.
     */
    public String getSearchView() {
        return searchView;
    }

    /**
     * Sets the view that holds the screen which the user will initiate the
     * search operation.
     */
    public void setSearchView(String searchView) {
        this.searchView = searchView;
    }

    /**
     * Returns the name of the results that the {@link org.compass.core.support.search.CompassSearchResults}
     * will be saved under. Defaults to "searchResults".
     */
    public String getSearchResultsName() {
        return searchResultsName;
    }

    /**
     * Sets the name of the results that the {@link org.compass.core.support.search.CompassSearchResults} will
     * be saved under. Defaults to "searchResults".
     */
    public void setSearchResultsName(String searchResultsName) {
        this.searchResultsName = searchResultsName;
    }

    /**
     * Returns the view which will show the results of the search operation.
     */
    public String getSearchResultsView() {
        return searchResultsView;
    }

    /**
     * Sets the view which will show the results of the search operation.
     */
    public void setSearchResultsView(String resultsView) {
        this.searchResultsView = resultsView;
    }

    /**
     * Sets the page size for the pagination of the results. If not set, not
     * pagination will be used.
     */
    public Integer getPageSize() {
        return pageSize;
    }

    /**
     * Returns the page size for the pagination of the results. If not set, not
     * pagination will be used.
     *
     * @param pageSize The page size when using paginated results
     */
    public void setPageSize(Integer pageSize) {
        this.pageSize = pageSize;
    }

	public void setNewsFacade(NewsFacade newsFacade) {
		this.newsFacade = newsFacade;
	}

}
