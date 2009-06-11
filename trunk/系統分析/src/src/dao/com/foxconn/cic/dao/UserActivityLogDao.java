
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.UserActivityLog;

public interface UserActivityLogDao extends Dao {

    /**
     * Retrieves all of the userActivityLogs
     */
    public List getUserActivityLogs(UserActivityLog userActivityLog);

    /**
     * Gets userActivityLog's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if 
     * nothing is found.
     * 
     * @param id the userActivityLog's id
     * @return userActivityLog populated userActivityLog object
     */
    public UserActivityLog getUserActivityLog(final Long id);

    /**
     * Saves a userActivityLog's information
     * @param userActivityLog the object to be saved
     */    
    public void saveUserActivityLog(UserActivityLog userActivityLog);

    /**
     * Removes a userActivityLog from the database by id
     * @param id the userActivityLog's id
     */
    public void removeUserActivityLog(final Long id);
}

