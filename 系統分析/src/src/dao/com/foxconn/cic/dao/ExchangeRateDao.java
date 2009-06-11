
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.ExchangeRate;

public interface ExchangeRateDao extends Dao {

    /**
     * Retrieves all of the exchangeRates
     */
    public List getExchangeRates(ExchangeRate exchangeRate);

    /**
     * Gets exchangeRate's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if 
     * nothing is found.
     * 
     * @param id the exchangeRate's id
     * @return exchangeRate populated exchangeRate object
     */
    public ExchangeRate getExchangeRate(final Long id);

    /**
     * Saves a exchangeRate's information
     * @param exchangeRate the object to be saved
     */    
    public ExchangeRate saveExchangeRate(ExchangeRate exchangeRate);

    /**
     * Removes a exchangeRate from the database by id
     * @param id the exchangeRate's id
     */
    public void removeExchangeRate(final Long id);
}

