package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.Quoter;

public class QuoterDaoTest extends BaseDaoTestCase {
    private String quoterId = new String("1");
    private QuoterDao dao = null;

    public void setQuoterDao(QuoterDao dao) {
        this.dao = dao;
    }

    public void testAddQuoter() throws Exception {
        Quoter quoter = new Quoter();

        // set required fields

        dao.saveQuoter(quoter);

        // verify a primary key was assigned
        assertNotNull(quoter.getId());

        // verify set fields are same after save
    }

    public void testGetQuoter() throws Exception {
        Quoter quoter = dao.getQuoter(quoterId);
        assertNotNull(quoter);
    }

    public void testGetQuoters() throws Exception {
        Quoter quoter = new Quoter();

        List results = dao.getQuoters(quoter);
        assertTrue(results.size() > 0);
    }

    public void testSaveQuoter() throws Exception {
        Quoter quoter = dao.getQuoter(quoterId);

        // update required fields

        dao.saveQuoter(quoter);

    }

    public void testRemoveQuoter() throws Exception {
        String removeId = new String("3");
        dao.removeQuoter(removeId);
        try {
            dao.getQuoter(removeId);
            fail("quoter found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
