
package com.foxconn.cic.service;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.InterestRate;

public interface InterestRateManager extends Manager {
    /**
     * Retrieves all of the interestRates
     */
    public List getInterestRates(InterestRate interestRate);

    /**
     * Gets interestRate's information based on id.
     * @param id the interestRate's id
     * @return interestRate populated interestRate object
     */
    public InterestRate getInterestRate(final String id);

    /**
     * Saves a interestRate's information
     * @param interestRate the object to be saved
     */
    public InterestRate saveInterestRate(InterestRate interestRate);

    /**
     * Removes a interestRate from the database by id
     * @param id the interestRate's id
     */
    public void removeInterestRate(final String id);
    
    public CompassSearchResults search(CompassSearchCommand searchCommand);
}

