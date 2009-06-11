
package com.foxconn.cic.service;

import java.util.List;

import com.foxconn.cic.model.CatalogType;

public interface CatalogTypeManager extends Manager {
    /**
     * Retrieves all of the catalogTypes
     */
    public List getCatalogTypes(CatalogType catalogType);

    /**
     * Gets catalogType's information based on id.
     * @param id the catalogType's id
     * @return catalogType populated catalogType object
     */
    public CatalogType getCatalogType(final String id);

    /**
     * Saves a catalogType's information
     * @param catalogType the object to be saved
     */
    public void saveCatalogType(CatalogType catalogType);

    /**
     * Removes a catalogType from the database by id
     * @param id the catalogType's id
     */
    public void removeCatalogType(final String id);
}

