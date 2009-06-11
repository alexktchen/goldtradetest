
package com.foxconn.cic.service.impl;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchHelper;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.dao.WebsiteDao;
import com.foxconn.cic.model.Website;
import com.foxconn.cic.service.WebsiteManager;

public class WebsiteManagerImpl extends BaseManager implements WebsiteManager {
    private WebsiteDao dao;

    private CompassSearchHelper searchHelper;
    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setWebsiteDao(WebsiteDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.WebsiteManager#getWebsites(com.foxconn.cic.model.Website)
     */
    public List getWebsites(final Website website) {
        return dao.getWebsites(website);
    }

    /**
     * @see com.foxconn.cic.service.WebsiteManager#getWebsite(String id)
     */
    public Website getWebsite(final String id) {
        return dao.getWebsite(id);
    }

    /**
     * @see com.foxconn.cic.service.WebsiteManager#saveWebsite(Website website)
     */
    public void saveWebsite(Website website) {
        dao.saveWebsite(website);
    }

    /**
     * @see com.foxconn.cic.service.WebsiteManager#removeWebsite(String id)
     */
    public void removeWebsite(final String id) {
        dao.removeWebsite(id);
    }
    
    public CompassSearchResults search(CompassSearchCommand searchCommand) {
		CompassSearchResults result = searchHelper.search(searchCommand);
		return result;		
	}

	public void setSearchHelper(CompassSearchHelper searchHelper) {
		this.searchHelper = searchHelper;
	}
}
