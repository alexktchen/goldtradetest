package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.Price;

public class PriceDaoTest extends BaseDaoTestCase {
    private Long priceId = new Long("1");
    private PriceDao dao = null;

    public void setPriceDao(PriceDao dao) {
        this.dao = dao;
    }

    public void testAddPrice() throws Exception {
        Price price = new Price();

        // set required fields

        dao.savePrice(price);

        // verify a primary key was assigned
        assertNotNull(price.getId());

        // verify set fields are same after save
    }

    public void testGetPrice() throws Exception {
        Price price = dao.getPrice(priceId);
        assertNotNull(price);
    }

    public void testGetPrices() throws Exception {
        Price price = new Price();

        List results = dao.getPrices(price);
        assertTrue(results.size() > 0);
    }

    public void testSavePrice() throws Exception {
        Price price = dao.getPrice(priceId);

        // update required fields

        dao.savePrice(price);

    }

    public void testRemovePrice() throws Exception {
        Long removeId = new Long("3");
        dao.removePrice(removeId);
        try {
            dao.getPrice(removeId);
            fail("price found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
