
package com.foxconn.cic.service;

import java.util.List;

import com.foxconn.cic.model.Quoter;

public interface QuoterManager extends Manager {
    /**
     * Retrieves all of the quoters
     */
    public List getQuoters(Quoter quoter);

    /**
     * Gets quoter's information based on id.
     * @param id the quoter's id
     * @return quoter populated quoter object
     */
    public Quoter getQuoter(final String id);

    /**
     * Saves a quoter's information
     * @param quoter the object to be saved
     */
    public void saveQuoter(Quoter quoter);

    /**
     * Removes a quoter from the database by id
     * @param id the quoter's id
     */
    public void removeQuoter(final String id);
}

