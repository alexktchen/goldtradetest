
package com.foxconn.cic.service.impl;

import java.util.List;

import com.foxconn.cic.dao.CatalogDao;
import com.foxconn.cic.model.Catalog;
import com.foxconn.cic.service.CatalogManager;

public class CatalogManagerImpl extends BaseManager implements CatalogManager {
    private CatalogDao dao;

    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setCatalogDao(CatalogDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.CatalogManager#getCatalogs(com.foxconn.cic.model.Catalog)
     */
    public List getCatalogs(final Catalog catalog) {
        return dao.getCatalogs(catalog);
    }

    /**
     * @see com.foxconn.cic.service.CatalogManager#getCatalog(String id)
     */
    public Catalog getCatalog(final String id) {
        return dao.getCatalog(new Long(id));
    }

    /**
     * @see com.foxconn.cic.service.CatalogManager#saveCatalog(Catalog catalog)
     */
    public void saveCatalog(Catalog catalog) {
        dao.saveCatalog(catalog);
    }

    /**
     * @see com.foxconn.cic.service.CatalogManager#removeCatalog(String id)
     */
    public void removeCatalog(final String id) {
        dao.removeCatalog(new Long(id));
    }
}
