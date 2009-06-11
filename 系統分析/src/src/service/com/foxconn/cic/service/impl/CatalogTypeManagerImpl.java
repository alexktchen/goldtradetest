
package com.foxconn.cic.service.impl;

import java.util.List;

import com.foxconn.cic.dao.CatalogTypeDao;
import com.foxconn.cic.model.CatalogType;
import com.foxconn.cic.service.CatalogTypeManager;

public class CatalogTypeManagerImpl extends BaseManager implements CatalogTypeManager {
    private CatalogTypeDao dao;

    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setCatalogTypeDao(CatalogTypeDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.CatalogTypeManager#getCatalogTypes(com.foxconn.cic.model.CatalogType)
     */
    public List getCatalogTypes(final CatalogType catalogType) {
        return dao.getCatalogTypes(catalogType);
    }

    /**
     * @see com.foxconn.cic.service.CatalogTypeManager#getCatalogType(String id)
     */
    public CatalogType getCatalogType(final String id) {
        return dao.getCatalogType(new Long(id));
    }

    /**
     * @see com.foxconn.cic.service.CatalogTypeManager#saveCatalogType(CatalogType catalogType)
     */
    public void saveCatalogType(CatalogType catalogType) {
        dao.saveCatalogType(catalogType);
    }

    /**
     * @see com.foxconn.cic.service.CatalogTypeManager#removeCatalogType(String id)
     */
    public void removeCatalogType(final String id) {
        dao.removeCatalogType(new Long(id));
    }
}
