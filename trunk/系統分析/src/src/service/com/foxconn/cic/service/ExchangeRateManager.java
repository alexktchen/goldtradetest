
package com.foxconn.cic.service;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.ExchangeRate;

public interface ExchangeRateManager extends Manager {
    /**
     * Retrieves all of the exchangeRates
     */
    public List getExchangeRates(ExchangeRate exchangeRate);

    /**
     * Gets exchangeRate's information based on id.
     * @param id the exchangeRate's id
     * @return exchangeRate populated exchangeRate object
     */
    public ExchangeRate getExchangeRate(final String id);

    /**
     * Saves a exchangeRate's information
     * @param exchangeRate the object to be saved
     */
    public ExchangeRate saveExchangeRate(ExchangeRate exchangeRate);

    /**
     * Removes a exchangeRate from the database by id
     * @param id the exchangeRate's id
     */
    public void removeExchangeRate(final String id);
    
    public CompassSearchResults search(CompassSearchCommand searchCommand);
}

