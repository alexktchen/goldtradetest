
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.CatalogDao;
import com.foxconn.cic.model.Catalog;
import com.foxconn.cic.service.impl.CatalogManagerImpl;

public class CatalogManagerTest extends BaseManagerTestCase {
    private final String catalogId = "1";
    private CatalogManagerImpl catalogManager = new CatalogManagerImpl();
    private Mock catalogDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        catalogDao = new Mock(CatalogDao.class);
        catalogManager.setCatalogDao((CatalogDao) catalogDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        catalogManager = null;
    }

    public void testGetCatalogs() throws Exception {
        List results = new ArrayList();
        Catalog catalog = new Catalog();
        results.add(catalog);

        // set expected behavior on dao
        catalogDao.expects(once()).method("getCatalogs")
            .will(returnValue(results));

        List catalogs = catalogManager.getCatalogs(null);
        assertTrue(catalogs.size() == 1);
        catalogDao.verify();
    }

    public void testGetCatalog() throws Exception {
        // set expected behavior on dao
        catalogDao.expects(once()).method("getCatalog")
            .will(returnValue(new Catalog()));
        Catalog catalog = catalogManager.getCatalog(catalogId);
        assertTrue(catalog != null);
        catalogDao.verify();
    }

    public void testSaveCatalog() throws Exception {
        Catalog catalog = new Catalog();

        // set expected behavior on dao
        catalogDao.expects(once()).method("saveCatalog")
            .with(same(catalog)).isVoid();

        catalogManager.saveCatalog(catalog);
        catalogDao.verify();
    }

    public void testAddAndRemoveCatalog() throws Exception {
        Catalog catalog = new Catalog();

        // set required fields

        // set expected behavior on dao
        catalogDao.expects(once()).method("saveCatalog")
            .with(same(catalog)).isVoid();
        catalogManager.saveCatalog(catalog);
        catalogDao.verify();

        // reset expectations
        catalogDao.reset();

        catalogDao.expects(once()).method("removeCatalog").with(eq(new Long(catalogId)));
        catalogManager.removeCatalog(catalogId);
        catalogDao.verify();

        // reset expectations
        catalogDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(Catalog.class, catalog.getId());
        catalogDao.expects(once()).method("removeCatalog").isVoid();
        catalogDao.expects(once()).method("getCatalog").will(throwException(ex));
        catalogManager.removeCatalog(catalogId);
        try {
            catalogManager.getCatalog(catalogId);
            fail("Catalog with identifier '" + catalogId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        catalogDao.verify();
    }
}
