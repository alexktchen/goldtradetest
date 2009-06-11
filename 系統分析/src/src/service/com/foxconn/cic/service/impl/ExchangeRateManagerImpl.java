
package com.foxconn.cic.service.impl;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchHelper;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.dao.ExchangeRateDao;
import com.foxconn.cic.model.ExchangeRate;
import com.foxconn.cic.service.ExchangeRateManager;

public class ExchangeRateManagerImpl extends BaseManager implements ExchangeRateManager {
    private ExchangeRateDao dao;
    private CompassSearchHelper searchHelper;
    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setExchangeRateDao(ExchangeRateDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.ExchangeRateManager#getExchangeRates(com.foxconn.cic.model.ExchangeRate)
     */
    public List getExchangeRates(final ExchangeRate exchangeRate) {
        return dao.getExchangeRates(exchangeRate);
    }

    /**
     * @see com.foxconn.cic.service.ExchangeRateManager#getExchangeRate(String id)
     */
    public ExchangeRate getExchangeRate(final String id) {
        return dao.getExchangeRate(new Long(id));
    }

    /**
     * @see com.foxconn.cic.service.ExchangeRateManager#saveExchangeRate(ExchangeRate exchangeRate)
     */
    public ExchangeRate saveExchangeRate(ExchangeRate exchangeRate) {
        return dao.saveExchangeRate(exchangeRate);
    }

    /**
     * @see com.foxconn.cic.service.ExchangeRateManager#removeExchangeRate(String id)
     */
    public void removeExchangeRate(final String id) {
        dao.removeExchangeRate(new Long(id));
    }
    
    public void setSearchHelper(CompassSearchHelper searchHelper) {
		this.searchHelper = searchHelper;
	}
    
    public CompassSearchResults search(CompassSearchCommand searchCommand) {
		return searchHelper.search(searchCommand);
	}
}
