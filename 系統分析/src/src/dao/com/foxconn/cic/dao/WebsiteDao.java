
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.Website;

public interface WebsiteDao extends Dao {

    /**
     * Retrieves all of the websites
     */
    public List getWebsites(Website website);

    /**
     * Gets website's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if
     * nothing is found.
     *
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
}

