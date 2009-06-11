package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.InterestRate;

public class InterestRateDaoTest extends BaseDaoTestCase {
    private Long interestRateId = new Long("1");
    private InterestRateDao dao = null;

    public void setInterestRateDao(InterestRateDao dao) {
        this.dao = dao;
    }

    public void testAddInterestRate() throws Exception {
        InterestRate interestRate = new InterestRate();

        // set required fields

        dao.saveInterestRate(interestRate);

        // verify a primary key was assigned
        assertNotNull(interestRate.getId());

        // verify set fields are same after save
    }

    public void testGetInterestRate() throws Exception {
        InterestRate interestRate = dao.getInterestRate(interestRateId);
        assertNotNull(interestRate);
    }

    public void testGetInterestRates() throws Exception {
        InterestRate interestRate = new InterestRate();

        List results = dao.getInterestRates(interestRate);
        assertTrue(results.size() > 0);
    }

    public void testSaveInterestRate() throws Exception {
        InterestRate interestRate = dao.getInterestRate(interestRateId);

        // update required fields

        dao.saveInterestRate(interestRate);

    }

    public void testRemoveInterestRate() throws Exception {
        Long removeId = new Long("3");
        dao.removeInterestRate(removeId);
        try {
            dao.getInterestRate(removeId);
            fail("interestRate found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
