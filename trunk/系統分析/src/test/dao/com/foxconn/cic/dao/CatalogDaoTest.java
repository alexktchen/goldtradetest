package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.Catalog;

public class CatalogDaoTest extends BaseDaoTestCase {
    private Long catalogId = new Long("1");
    private CatalogDao dao = null;

    public void setCatalogDao(CatalogDao dao) {
        this.dao = dao;
    }

    public void testAddCatalog() throws Exception {
        Catalog catalog = new Catalog();

        // set required fields

        dao.saveCatalog(catalog);

        // verify a primary key was assigned
        assertNotNull(catalog.getId());

        // verify set fields are same after save
    }

    public void testGetCatalog() throws Exception {
        Catalog catalog = dao.getCatalog(catalogId);
        assertNotNull(catalog);
    }

    public void testGetCatalogs() throws Exception {
        Catalog catalog = new Catalog();

        List results = dao.getCatalogs(catalog);
        assertTrue(results.size() > 0);
    }

    public void testSaveCatalog() throws Exception {
        Catalog catalog = dao.getCatalog(catalogId);

        // update required fields

        dao.saveCatalog(catalog);

    }

    public void testRemoveCatalog() throws Exception {
        Long removeId = new Long("3");
        dao.removeCatalog(removeId);
        try {
            dao.getCatalog(removeId);
            fail("catalog found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
