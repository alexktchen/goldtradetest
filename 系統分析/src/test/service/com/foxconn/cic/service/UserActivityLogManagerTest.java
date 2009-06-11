
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.UserActivityLogDao;
import com.foxconn.cic.model.UserActivityLog;
import com.foxconn.cic.service.impl.UserActivityLogManagerImpl;

public class UserActivityLogManagerTest extends BaseManagerTestCase {
    private final String userActivityLogId = "1";
    private UserActivityLogManagerImpl userActivityLogManager = new UserActivityLogManagerImpl();
    private Mock userActivityLogDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        userActivityLogDao = new Mock(UserActivityLogDao.class);
        userActivityLogManager.setUserActivityLogDao((UserActivityLogDao) userActivityLogDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        userActivityLogManager = null;
    }

    public void testGetUserActivityLogs() throws Exception {
        List results = new ArrayList();
        UserActivityLog userActivityLog = new UserActivityLog();
        results.add(userActivityLog);

        // set expected behavior on dao
        userActivityLogDao.expects(once()).method("getUserActivityLogs")
            .will(returnValue(results));

        List userActivityLogs = userActivityLogManager.getUserActivityLogs(null);
        assertTrue(userActivityLogs.size() == 1);
        userActivityLogDao.verify();
    }

    public void testGetUserActivityLog() throws Exception {
        // set expected behavior on dao
        userActivityLogDao.expects(once()).method("getUserActivityLog")
            .will(returnValue(new UserActivityLog()));
        UserActivityLog userActivityLog = userActivityLogManager.getUserActivityLog(userActivityLogId);
        assertTrue(userActivityLog != null);
        userActivityLogDao.verify();
    }

    public void testSaveUserActivityLog() throws Exception {
        UserActivityLog userActivityLog = new UserActivityLog();

        // set expected behavior on dao
        userActivityLogDao.expects(once()).method("saveUserActivityLog")
            .with(same(userActivityLog)).isVoid();

        userActivityLogManager.saveUserActivityLog(userActivityLog);
        userActivityLogDao.verify();
    }

    public void testAddAndRemoveUserActivityLog() throws Exception {
        UserActivityLog userActivityLog = new UserActivityLog();

        // set required fields

        // set expected behavior on dao
        userActivityLogDao.expects(once()).method("saveUserActivityLog")
            .with(same(userActivityLog)).isVoid();
        userActivityLogManager.saveUserActivityLog(userActivityLog);
        userActivityLogDao.verify();

        // reset expectations
        userActivityLogDao.reset();

        userActivityLogDao.expects(once()).method("removeUserActivityLog").with(eq(new Long(userActivityLogId)));
        userActivityLogManager.removeUserActivityLog(userActivityLogId);
        userActivityLogDao.verify();

        // reset expectations
        userActivityLogDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(UserActivityLog.class, userActivityLog.getId());
        userActivityLogDao.expects(once()).method("removeUserActivityLog").isVoid();
        userActivityLogDao.expects(once()).method("getUserActivityLog").will(throwException(ex));
        userActivityLogManager.removeUserActivityLog(userActivityLogId);
        try {
            userActivityLogManager.getUserActivityLog(userActivityLogId);
            fail("UserActivityLog with identifier '" + userActivityLogId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        userActivityLogDao.verify();
    }
}
