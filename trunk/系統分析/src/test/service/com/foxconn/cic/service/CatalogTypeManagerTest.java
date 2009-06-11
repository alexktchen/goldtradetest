
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.CatalogTypeDao;
import com.foxconn.cic.model.CatalogType;
import com.foxconn.cic.service.impl.CatalogTypeManagerImpl;

public class CatalogTypeManagerTest extends BaseManagerTestCase {
    private final String catalogTypeId = "1";
    private CatalogTypeManagerImpl catalogTypeManager = new CatalogTypeManagerImpl();
    private Mock catalogTypeDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        catalogTypeDao = new Mock(CatalogTypeDao.class);
        catalogTypeManager.setCatalogTypeDao((CatalogTypeDao) catalogTypeDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        catalogTypeManager = null;
    }

    public void testGetCatalogTypes() throws Exception {
        List results = new ArrayList();
        CatalogType catalogType = new CatalogType();
        results.add(catalogType);

        // set expected behavior on dao
        catalogTypeDao.expects(once()).method("getCatalogTypes")
            .will(returnValue(results));

        List catalogTypes = catalogTypeManager.getCatalogTypes(null);
        assertTrue(catalogTypes.size() == 1);
        catalogTypeDao.verify();
    }

    public void testGetCatalogType() throws Exception {
        // set expected behavior on dao
        catalogTypeDao.expects(once()).method("getCatalogType")
            .will(returnValue(new CatalogType()));
        CatalogType catalogType = catalogTypeManager.getCatalogType(catalogTypeId);
        assertTrue(catalogType != null);
        catalogTypeDao.verify();
    }

    public void testSaveCatalogType() throws Exception {
        CatalogType catalogType = new CatalogType();

        // set expected behavior on dao
        catalogTypeDao.expects(once()).method("saveCatalogType")
            .with(same(catalogType)).isVoid();

        catalogTypeManager.saveCatalogType(catalogType);
        catalogTypeDao.verify();
    }

    public void testAddAndRemoveCatalogType() throws Exception {
        CatalogType catalogType = new CatalogType();

        // set required fields

        // set expected behavior on dao
        catalogTypeDao.expects(once()).method("saveCatalogType")
            .with(same(catalogType)).isVoid();
        catalogTypeManager.saveCatalogType(catalogType);
        catalogTypeDao.verify();

        // reset expectations
        catalogTypeDao.reset();

        catalogTypeDao.expects(once()).method("removeCatalogType").with(eq(new Long(catalogTypeId)));
        catalogTypeManager.removeCatalogType(catalogTypeId);
        catalogTypeDao.verify();

        // reset expectations
        catalogTypeDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(CatalogType.class, catalogType.getId());
        catalogTypeDao.expects(once()).method("removeCatalogType").isVoid();
        catalogTypeDao.expects(once()).method("getCatalogType").will(throwException(ex));
        catalogTypeManager.removeCatalogType(catalogTypeId);
        try {
            catalogTypeManager.getCatalogType(catalogTypeId);
            fail("CatalogType with identifier '" + catalogTypeId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        catalogTypeDao.verify();
    }
}
