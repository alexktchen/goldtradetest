
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.Keyword;

public interface KeywordDao extends Dao {

    /**
     * Retrieves all of the keywords
     */
    public List getKeywords(Keyword keyword);

    /**
     * Gets keyword's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if 
     * nothing is found.
     * 
     * @param id the keyword's id
     * @return keyword populated keyword object
     */
    public Keyword getKeyword(final Long id);

    /**
     * Saves a keyword's information
     * @param keyword the object to be saved
     */    
    public void saveKeyword(Keyword keyword);

    /**
     * Removes a keyword from the database by id
     * @param id the keyword's id
     */
    public void removeKeyword(final Long id);
}

