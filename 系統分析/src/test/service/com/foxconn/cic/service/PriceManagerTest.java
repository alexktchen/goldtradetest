
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.PriceDao;
import com.foxconn.cic.model.Price;
import com.foxconn.cic.service.impl.PriceManagerImpl;

public class PriceManagerTest extends BaseManagerTestCase {
    private final String priceId = "1";
    private PriceManagerImpl priceManager = new PriceManagerImpl();
    private Mock priceDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        priceDao = new Mock(PriceDao.class);
        priceManager.setPriceDao((PriceDao) priceDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        priceManager = null;
    }

    public void testGetPrices() throws Exception {
        List results = new ArrayList();
        Price price = new Price();
        results.add(price);

        // set expected behavior on dao
        priceDao.expects(once()).method("getPrices")
            .will(returnValue(results));

        List prices = priceManager.getPrices(null);
        assertTrue(prices.size() == 1);
        priceDao.verify();
    }

    public void testGetPrice() throws Exception {
        // set expected behavior on dao
        priceDao.expects(once()).method("getPrice")
            .will(returnValue(new Price()));
        Price price = priceManager.getPrice(priceId);
        assertTrue(price != null);
        priceDao.verify();
    }

    public void testSavePrice() throws Exception {
        Price price = new Price();

        // set expected behavior on dao
        priceDao.expects(once()).method("savePrice")
            .with(same(price)).isVoid();

        priceManager.savePrice(price);
        priceDao.verify();
    }

    public void testAddAndRemovePrice() throws Exception {
        Price price = new Price();

        // set required fields

        // set expected behavior on dao
        priceDao.expects(once()).method("savePrice")
            .with(same(price)).isVoid();
        priceManager.savePrice(price);
        priceDao.verify();

        // reset expectations
        priceDao.reset();

        priceDao.expects(once()).method("removePrice").with(eq(new Long(priceId)));
        priceManager.removePrice(priceId);
        priceDao.verify();

        // reset expectations
        priceDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(Price.class, price.getId());
        priceDao.expects(once()).method("removePrice").isVoid();
        priceDao.expects(once()).method("getPrice").will(throwException(ex));
        priceManager.removePrice(priceId);
        try {
            priceManager.getPrice(priceId);
            fail("Price with identifier '" + priceId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        priceDao.verify();
    }
}
