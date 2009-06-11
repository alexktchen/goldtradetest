package com.foxconn.cic.webapp.action;

import java.util.HashMap;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.compass.spring.web.mvc.AbstractCompassGpsCommandController;
import org.compass.spring.web.mvc.CompassIndexCommand;
import org.compass.spring.web.mvc.CompassIndexResults;
import org.springframework.util.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

/**
 * A general Spring's MVC Controller that perform the index operation of
 * <code>CompassGps</code>.
 * <p>
 * Will perform the index operation if the
 * {@link org.compass.spring.web.mvc.CompassIndexCommand} <code>doIndex</code>
 * property is set to true.
 * <p>
 * The controller has two views to be set, the <code>indexView</code>, which
 * is the view that holds the screen which the user will initiate the index
 * operation, and the <code>indexResultsView</code>, which will show the
 * results of the index operation.
 * <p>
 * The results of the index operation will be saved under the
 * <code>indexResultsName</code>, which defaults to "indexResults".
 * 
 * @author kimchy
 */
public class NewsIndexController extends AbstractCompassGpsCommandController {

    private String indexView;

    private String indexResultsView;

    private String indexResultsName = "indexResults";

    public NewsIndexController() {
        setCommandClass(CompassIndexCommand.class);
    }

    public void afterPropertiesSet() throws Exception {
        super.afterPropertiesSet();
        if (indexView == null) {
            throw new IllegalArgumentException("Must set the indexView property");
        }
        if (indexResultsView == null) {
            throw new IllegalArgumentException("Must set the indexResultsView property");
        }
    }

    protected ModelAndView handle(HttpServletRequest request, HttpServletResponse response, Object command,
            BindException errors) throws Exception {
        CompassIndexCommand indexCommand = (CompassIndexCommand) command;

        if (!StringUtils.hasText(indexCommand.getDoIndex()) || !indexCommand.getDoIndex().equalsIgnoreCase("true")) {
            return new ModelAndView(getIndexView(), getCommandName(), indexCommand);
        }

        long time = System.currentTimeMillis();
        
        getCompassGps().index();

        time = System.currentTimeMillis() - time;
        CompassIndexResults indexResults = new CompassIndexResults(time);
        HashMap data = new HashMap();
        data.put(getCommandName(), indexCommand);
        data.put(getIndexResultsName(), indexResults);
        return new ModelAndView(getIndexResultsView(), data);
    }

    /**
     * Returns the view that holds the screen which the user will initiate the
     * index operation.
     */
    public String getIndexView() {
        return indexView;
    }

    /**
     * Sets the view that holds the screen which the user will initiate the
     * index operation.
     */
    public void setIndexView(String indexView) {
        this.indexView = indexView;
    }

    /**
     * Returns the name of the results that the {@link CompassIndexResults} will
     * be saved under. Defaults to "indexResults".
     */
    public String getIndexResultsName() {
        return indexResultsName;
    }

    /**
     * Sets the name of the results that the {@link CompassIndexResults} will be
     * saved under. Defaults to "indexResults".
     * 
     * @param indexResultsName
     */
    public void setIndexResultsName(String indexResultsName) {
        this.indexResultsName = indexResultsName;
    }

    /**
     * Returns the view which will show the results of the index operation.
     */
    public String getIndexResultsView() {
        return indexResultsView;
    }

    /**
     * Sets the view which will show the results of the index operation.
     * 
     * @param indexResultsView
     */
    public void setIndexResultsView(String indexResultsView) {
        this.indexResultsView = indexResultsView;
    }
}
