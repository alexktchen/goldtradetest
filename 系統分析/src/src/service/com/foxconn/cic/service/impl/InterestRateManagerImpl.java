
package com.foxconn.cic.service.impl;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchHelper;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.dao.InterestRateDao;
import com.foxconn.cic.model.InterestRate;
import com.foxconn.cic.service.InterestRateManager;

public class InterestRateManagerImpl extends BaseManager implements InterestRateManager {
    private InterestRateDao dao;
    private CompassSearchHelper searchHelper;
    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setInterestRateDao(InterestRateDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.InterestRateManager#getInterestRates(com.foxconn.cic.model.InterestRate)
     */
    public List getInterestRates(final InterestRate interestRate) {
        return dao.getInterestRates(interestRate);
    }

    /**
     * @see com.foxconn.cic.service.InterestRateManager#getInterestRate(String id)
     */
    public InterestRate getInterestRate(final String id) {
        return dao.getInterestRate(new Long(id));
    }

    /**
     * @see com.foxconn.cic.service.InterestRateManager#saveInterestRate(InterestRate interestRate)
     */
    public InterestRate saveInterestRate(InterestRate interestRate) {
        return dao.saveInterestRate(interestRate);
    }

    /**
     * @see com.foxconn.cic.service.InterestRateManager#removeInterestRate(String id)
     */
    public void removeInterestRate(final String id) {
        dao.removeInterestRate(new Long(id));
    }
    
    public void setSearchHelper(CompassSearchHelper searchHelper) {
		this.searchHelper = searchHelper;
	}
    
    public CompassSearchResults search(CompassSearchCommand searchCommand) {		
		return searchHelper.search(searchCommand);
	}
}
