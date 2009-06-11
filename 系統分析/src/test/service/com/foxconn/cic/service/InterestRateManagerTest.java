
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.InterestRateDao;
import com.foxconn.cic.model.InterestRate;
import com.foxconn.cic.service.impl.InterestRateManagerImpl;

public class InterestRateManagerTest extends BaseManagerTestCase {
    private final String interestRateId = "1";
    private InterestRateManagerImpl interestRateManager = new InterestRateManagerImpl();
    private Mock interestRateDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        interestRateDao = new Mock(InterestRateDao.class);
        interestRateManager.setInterestRateDao((InterestRateDao) interestRateDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        interestRateManager = null;
    }

    public void testGetInterestRates() throws Exception {
        List results = new ArrayList();
        InterestRate interestRate = new InterestRate();
        results.add(interestRate);

        // set expected behavior on dao
        interestRateDao.expects(once()).method("getInterestRates")
            .will(returnValue(results));

        List interestRates = interestRateManager.getInterestRates(null);
        assertTrue(interestRates.size() == 1);
        interestRateDao.verify();
    }

    public void testGetInterestRate() throws Exception {
        // set expected behavior on dao
        interestRateDao.expects(once()).method("getInterestRate")
            .will(returnValue(new InterestRate()));
        InterestRate interestRate = interestRateManager.getInterestRate(interestRateId);
        assertTrue(interestRate != null);
        interestRateDao.verify();
    }

    public void testSaveInterestRate() throws Exception {
        InterestRate interestRate = new InterestRate();

        // set expected behavior on dao
        interestRateDao.expects(once()).method("saveInterestRate")
            .with(same(interestRate)).isVoid();

        interestRateManager.saveInterestRate(interestRate);
        interestRateDao.verify();
    }

    public void testAddAndRemoveInterestRate() throws Exception {
        InterestRate interestRate = new InterestRate();

        // set required fields

        // set expected behavior on dao
        interestRateDao.expects(once()).method("saveInterestRate")
            .with(same(interestRate)).isVoid();
        interestRateManager.saveInterestRate(interestRate);
        interestRateDao.verify();

        // reset expectations
        interestRateDao.reset();

        interestRateDao.expects(once()).method("removeInterestRate").with(eq(new Long(interestRateId)));
        interestRateManager.removeInterestRate(interestRateId);
        interestRateDao.verify();

        // reset expectations
        interestRateDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(InterestRate.class, interestRate.getId());
        interestRateDao.expects(once()).method("removeInterestRate").isVoid();
        interestRateDao.expects(once()).method("getInterestRate").will(throwException(ex));
        interestRateManager.removeInterestRate(interestRateId);
        try {
            interestRateManager.getInterestRate(interestRateId);
            fail("InterestRate with identifier '" + interestRateId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        interestRateDao.verify();
    }
}
