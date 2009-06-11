
package com.foxconn.cic.service.impl;

import java.util.List;

import com.foxconn.cic.dao.UserActivityLogDao;
import com.foxconn.cic.model.UserActivityLog;
import com.foxconn.cic.service.UserActivityLogManager;

public class UserActivityLogManagerImpl extends BaseManager implements UserActivityLogManager {
    private UserActivityLogDao dao;

    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setUserActivityLogDao(UserActivityLogDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.UserActivityLogManager#getUserActivityLogs(com.foxconn.cic.model.UserActivityLog)
     */
    public List getUserActivityLogs(final UserActivityLog userActivityLog) {
        return dao.getUserActivityLogs(userActivityLog);
    }

    /**
     * @see com.foxconn.cic.service.UserActivityLogManager#getUserActivityLog(String id)
     */
    public UserActivityLog getUserActivityLog(final String id) {
        return dao.getUserActivityLog(new Long(id));
    }

    /**
     * @see com.foxconn.cic.service.UserActivityLogManager#saveUserActivityLog(UserActivityLog userActivityLog)
     */
    public void saveUserActivityLog(UserActivityLog userActivityLog) {
        dao.saveUserActivityLog(userActivityLog);
    }

    /**
     * @see com.foxconn.cic.service.UserActivityLogManager#removeUserActivityLog(String id)
     */
    public void removeUserActivityLog(final String id) {
        dao.removeUserActivityLog(new Long(id));
    }
}
