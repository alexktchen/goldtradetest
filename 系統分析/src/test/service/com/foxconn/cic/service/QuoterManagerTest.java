
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.QuoterDao;
import com.foxconn.cic.model.Quoter;
import com.foxconn.cic.service.impl.QuoterManagerImpl;

public class QuoterManagerTest extends BaseManagerTestCase {
    private final String quoterId = "1";
    private QuoterManagerImpl quoterManager = new QuoterManagerImpl();
    private Mock quoterDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        quoterDao = new Mock(QuoterDao.class);
        quoterManager.setQuoterDao((QuoterDao) quoterDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        quoterManager = null;
    }

    public void testGetQuoters() throws Exception {
        List results = new ArrayList();
        Quoter quoter = new Quoter();
        results.add(quoter);

        // set expected behavior on dao
        quoterDao.expects(once()).method("getQuoters")
            .will(returnValue(results));

        List quoters = quoterManager.getQuoters(null);
        assertTrue(quoters.size() == 1);
        quoterDao.verify();
    }

    public void testGetQuoter() throws Exception {
        // set expected behavior on dao
        quoterDao.expects(once()).method("getQuoter")
            .will(returnValue(new Quoter()));
        Quoter quoter = quoterManager.getQuoter(quoterId);
        assertTrue(quoter != null);
        quoterDao.verify();
    }

    public void testSaveQuoter() throws Exception {
        Quoter quoter = new Quoter();

        // set expected behavior on dao
        quoterDao.expects(once()).method("saveQuoter")
            .with(same(quoter)).isVoid();

        quoterManager.saveQuoter(quoter);
        quoterDao.verify();
    }

    public void testAddAndRemoveQuoter() throws Exception {
        Quoter quoter = new Quoter();

        // set required fields

        // set expected behavior on dao
        quoterDao.expects(once()).method("saveQuoter")
            .with(same(quoter)).isVoid();
        quoterManager.saveQuoter(quoter);
        quoterDao.verify();

        // reset expectations
        quoterDao.reset();

        quoterDao.expects(once()).method("removeQuoter").with(eq(new String(quoterId)));
        quoterManager.removeQuoter(quoterId);
        quoterDao.verify();

        // reset expectations
        quoterDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(Quoter.class, quoter.getId());
        quoterDao.expects(once()).method("removeQuoter").isVoid();
        quoterDao.expects(once()).method("getQuoter").will(throwException(ex));
        quoterManager.removeQuoter(quoterId);
        try {
            quoterManager.getQuoter(quoterId);
            fail("Quoter with identifier '" + quoterId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        quoterDao.verify();
    }
}
