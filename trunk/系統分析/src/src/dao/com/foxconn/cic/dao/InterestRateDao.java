
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.InterestRate;

public interface InterestRateDao extends Dao {

    /**
     * Retrieves all of the interestRates
     */
    public List getInterestRates(InterestRate interestRate);

    /**
     * Gets interestRate's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if 
     * nothing is found.
     * 
     * @param id the interestRate's id
     * @return interestRate populated interestRate object
     */
    public InterestRate getInterestRate(final Long id);

    /**
     * Saves a interestRate's information
     * @param interestRate the object to be saved
     */    
    public InterestRate saveInterestRate(InterestRate interestRate);

    /**
     * Removes a interestRate from the database by id
     * @param id the interestRate's id
     */
    public void removeInterestRate(final Long id);
}

