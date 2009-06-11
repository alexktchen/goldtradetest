
package com.foxconn.cic.service.impl;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchHelper;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.dao.PriceDao;
import com.foxconn.cic.model.Price;
import com.foxconn.cic.service.PriceManager;

public class PriceManagerImpl extends BaseManager implements PriceManager {
    private PriceDao dao;
    private CompassSearchHelper searchHelper;

    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setPriceDao(PriceDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.PriceManager#getPrices(com.foxconn.cic.model.Price)
     */
    public List getPrices(final Price price) {
        return dao.getPrices(price);
    }

    /**
     * @see com.foxconn.cic.service.PriceManager#getPrice(String id)
     */
    public Price getPrice(final String id) {
        return dao.getPrice(new Long(id));
    }

    /**
     * @see com.foxconn.cic.service.PriceManager#savePrice(Price price)
     */
    public Price savePrice(Price price) {
       return dao.savePrice(price);
    }

    /**
     * @see com.foxconn.cic.service.PriceManager#removePrice(String id)
     */
    public void removePrice(final String id) {
        dao.removePrice(new Long(id));
    }

	public CompassSearchResults search(CompassSearchCommand searchCommand) {
		CompassSearchResults result = searchHelper.search(searchCommand);
		return result;		
	}

	public void setSearchHelper(CompassSearchHelper searchHelper) {
		this.searchHelper = searchHelper;
	}
}
