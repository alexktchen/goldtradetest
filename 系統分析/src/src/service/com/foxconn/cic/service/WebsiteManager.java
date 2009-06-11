
package com.foxconn.cic.service;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.Website;

public interface WebsiteManager extends Manager {
    /**
     * Retrieves all of the websites
     */
    public List getWebsites(Website website);

    /**
     * Gets website's information based on id.
     * @param id the website's id
     * @return website populated website object
     */
    public Website getWebsite(final String id);

    /**
     * Saves a website's information
     * @param website the object to be saved
     */
    public void saveWebsite(Website website);

    /**
     * Removes a website from the database by id
     * @param id the website's id
     */
    public void removeWebsite(final String id);
    
    public CompassSearchResults search(CompassSearchCommand searchCommand);
}

