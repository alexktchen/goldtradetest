package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.CatalogType;

public class CatalogTypeDaoTest extends BaseDaoTestCase {
    private Long catalogTypeId = new Long("1");
    private CatalogTypeDao dao = null;

    public void setCatalogTypeDao(CatalogTypeDao dao) {
        this.dao = dao;
    }

    public void testAddCatalogType() throws Exception {
        CatalogType catalogType = new CatalogType();

        // set required fields

        dao.saveCatalogType(catalogType);

        // verify a primary key was assigned
        assertNotNull(catalogType.getId());

        // verify set fields are same after save
    }

    public void testGetCatalogType() throws Exception {
        CatalogType catalogType = dao.getCatalogType(catalogTypeId);
        assertNotNull(catalogType);
    }

    public void testGetCatalogTypes() throws Exception {
        CatalogType catalogType = new CatalogType();

        List results = dao.getCatalogTypes(catalogType);
        assertTrue(results.size() > 0);
    }

    public void testSaveCatalogType() throws Exception {
        CatalogType catalogType = dao.getCatalogType(catalogTypeId);

        // update required fields

        dao.saveCatalogType(catalogType);

    }

    public void testRemoveCatalogType() throws Exception {
        Long removeId = new Long("3");
        dao.removeCatalogType(removeId);
        try {
            dao.getCatalogType(removeId);
            fail("catalogType found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
