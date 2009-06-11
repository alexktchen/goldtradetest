
package com.foxconn.cic.service;

import java.util.List;

import com.foxconn.cic.model.UserActivityLog;

public interface UserActivityLogManager extends Manager {
    /**
     * Retrieves all of the userActivityLogs
     */
    public List getUserActivityLogs(UserActivityLog userActivityLog);

    /**
     * Gets userActivityLog's information based on id.
     * @param id the userActivityLog's id
     * @return userActivityLog populated userActivityLog object
     */
    public UserActivityLog getUserActivityLog(final String id);

    /**
     * Saves a userActivityLog's information
     * @param userActivityLog the object to be saved
     */
    public void saveUserActivityLog(UserActivityLog userActivityLog);

    /**
     * Removes a userActivityLog from the database by id
     * @param id the userActivityLog's id
     */
    public void removeUserActivityLog(final String id);
}

