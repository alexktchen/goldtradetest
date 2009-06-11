package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.UserActivityLog;

public class UserActivityLogDaoTest extends BaseDaoTestCase {
    private Long userActivityLogId = new Long("1");
    private UserActivityLogDao dao = null;

    public void setUserActivityLogDao(UserActivityLogDao dao) {
        this.dao = dao;
    }

    public void testAddUserActivityLog() throws Exception {
        UserActivityLog userActivityLog = new UserActivityLog();

        // set required fields

        dao.saveUserActivityLog(userActivityLog);

        // verify a primary key was assigned
        assertNotNull(userActivityLog.getId());

        // verify set fields are same after save
    }

    public void testGetUserActivityLog() throws Exception {
        UserActivityLog userActivityLog = dao.getUserActivityLog(userActivityLogId);
        assertNotNull(userActivityLog);
    }

    public void testGetUserActivityLogs() throws Exception {
        UserActivityLog userActivityLog = new UserActivityLog();

        List results = dao.getUserActivityLogs(userActivityLog);
        assertTrue(results.size() > 0);
    }

    public void testSaveUserActivityLog() throws Exception {
        UserActivityLog userActivityLog = dao.getUserActivityLog(userActivityLogId);

        // update required fields

        dao.saveUserActivityLog(userActivityLog);

    }

    public void testRemoveUserActivityLog() throws Exception {
        Long removeId = new Long("3");
        dao.removeUserActivityLog(removeId);
        try {
            dao.getUserActivityLog(removeId);
            fail("userActivityLog found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
