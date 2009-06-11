
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.ExchangeRateDao;
import com.foxconn.cic.model.ExchangeRate;
import com.foxconn.cic.service.impl.ExchangeRateManagerImpl;

public class ExchangeRateManagerTest extends BaseManagerTestCase {
    private final String exchangeRateId = "1";
    private ExchangeRateManagerImpl exchangeRateManager = new ExchangeRateManagerImpl();
    private Mock exchangeRateDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        exchangeRateDao = new Mock(ExchangeRateDao.class);
        exchangeRateManager.setExchangeRateDao((ExchangeRateDao) exchangeRateDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        exchangeRateManager = null;
    }

    public void testGetExchangeRates() throws Exception {
        List results = new ArrayList();
        ExchangeRate exchangeRate = new ExchangeRate();
        results.add(exchangeRate);

        // set expected behavior on dao
        exchangeRateDao.expects(once()).method("getExchangeRates")
            .will(returnValue(results));

        List exchangeRates = exchangeRateManager.getExchangeRates(null);
        assertTrue(exchangeRates.size() == 1);
        exchangeRateDao.verify();
    }

    public void testGetExchangeRate() throws Exception {
        // set expected behavior on dao
        exchangeRateDao.expects(once()).method("getExchangeRate")
            .will(returnValue(new ExchangeRate()));
        ExchangeRate exchangeRate = exchangeRateManager.getExchangeRate(exchangeRateId);
        assertTrue(exchangeRate != null);
        exchangeRateDao.verify();
    }

    public void testSaveExchangeRate() throws Exception {
        ExchangeRate exchangeRate = new ExchangeRate();

        // set expected behavior on dao
        exchangeRateDao.expects(once()).method("saveExchangeRate")
            .with(same(exchangeRate)).isVoid();

        exchangeRateManager.saveExchangeRate(exchangeRate);
        exchangeRateDao.verify();
    }

    public void testAddAndRemoveExchangeRate() throws Exception {
        ExchangeRate exchangeRate = new ExchangeRate();

        // set required fields

        // set expected behavior on dao
        exchangeRateDao.expects(once()).method("saveExchangeRate")
            .with(same(exchangeRate)).isVoid();
        exchangeRateManager.saveExchangeRate(exchangeRate);
        exchangeRateDao.verify();

        // reset expectations
        exchangeRateDao.reset();

        exchangeRateDao.expects(once()).method("removeExchangeRate").with(eq(new Long(exchangeRateId)));
        exchangeRateManager.removeExchangeRate(exchangeRateId);
        exchangeRateDao.verify();

        // reset expectations
        exchangeRateDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(ExchangeRate.class, exchangeRate.getId());
        exchangeRateDao.expects(once()).method("removeExchangeRate").isVoid();
        exchangeRateDao.expects(once()).method("getExchangeRate").will(throwException(ex));
        exchangeRateManager.removeExchangeRate(exchangeRateId);
        try {
            exchangeRateManager.getExchangeRate(exchangeRateId);
            fail("ExchangeRate with identifier '" + exchangeRateId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        exchangeRateDao.verify();
    }
}
