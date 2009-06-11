package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.ExchangeRate;

public class ExchangeRateDaoTest extends BaseDaoTestCase {
    private Long exchangeRateId = new Long("1");
    private ExchangeRateDao dao = null;

    public void setExchangeRateDao(ExchangeRateDao dao) {
        this.dao = dao;
    }

    public void testAddExchangeRate() throws Exception {
        ExchangeRate exchangeRate = new ExchangeRate();

        // set required fields

        dao.saveExchangeRate(exchangeRate);

        // verify a primary key was assigned
        assertNotNull(exchangeRate.getId());

        // verify set fields are same after save
    }

    public void testGetExchangeRate() throws Exception {
        ExchangeRate exchangeRate = dao.getExchangeRate(exchangeRateId);
        assertNotNull(exchangeRate);
    }

    public void testGetExchangeRates() throws Exception {
        ExchangeRate exchangeRate = new ExchangeRate();

        List results = dao.getExchangeRates(exchangeRate);
        assertTrue(results.size() > 0);
    }

    public void testSaveExchangeRate() throws Exception {
        ExchangeRate exchangeRate = dao.getExchangeRate(exchangeRateId);

        // update required fields

        dao.saveExchangeRate(exchangeRate);

    }

    public void testRemoveExchangeRate() throws Exception {
        Long removeId = new Long("3");
        dao.removeExchangeRate(removeId);
        try {
            dao.getExchangeRate(removeId);
            fail("exchangeRate found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
