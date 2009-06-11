
package com.foxconn.cic.service.impl;

import java.util.List;

import com.foxconn.cic.dao.MaterialDao;
import com.foxconn.cic.model.Material;
import com.foxconn.cic.service.MaterialManager;

public class MaterialManagerImpl extends BaseManager implements MaterialManager {
    private MaterialDao dao;

    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setMaterialDao(MaterialDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.MaterialManager#getMaterials(com.foxconn.cic.model.Material)
     */
    public List getMaterials(final Material material) {
        return dao.getMaterials(material);
    }

    /**
     * @see com.foxconn.cic.service.MaterialManager#getMaterial(String id)
     */
    public Material getMaterial(final String id) {
        return dao.getMaterial(id);
    }

    /**
     * @see com.foxconn.cic.service.MaterialManager#saveMaterial(Material material)
     */
    public void saveMaterial(Material material) {
        dao.saveMaterial(material);
    }

    /**
     * @see com.foxconn.cic.service.MaterialManager#removeMaterial(String id)
     */
    public void removeMaterial(final String id) {
        dao.removeMaterial(id);
    }
}
