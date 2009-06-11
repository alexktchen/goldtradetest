
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.Price;

public interface PriceDao extends Dao {

    /**
     * Retrieves all of the prices
     */
    public List getPrices(Price price);

    /**
     * Gets price's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if 
     * nothing is found.
     * 
     * @param id the price's id
     * @return price populated price object
     */
    public Price getPrice(final Long id);

    /**
     * Saves a price's information
     * @param price the object to be saved
     */    
    public Price savePrice(Price price);

    /**
     * Removes a price from the database by id
     * @param id the price's id
     */
    public void removePrice(final Long id);
}

