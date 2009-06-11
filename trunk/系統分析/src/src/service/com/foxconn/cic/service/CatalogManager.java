
package com.foxconn.cic.service;

import java.util.List;

import com.foxconn.cic.model.Catalog;

public interface CatalogManager extends Manager {
    /**
     * Retrieves all of the catalogs
     */
    public List getCatalogs(Catalog catalog);

    /**
     * Gets catalog's information based on id.
     * @param id the catalog's id
     * @return catalog populated catalog object
     */
    public Catalog getCatalog(final String id);

    /**
     * Saves a catalog's information
     * @param catalog the object to be saved
     */
    public void saveCatalog(Catalog catalog);

    /**
     * Removes a catalog from the database by id
     * @param id the catalog's id
     */
    public void removeCatalog(final String id);
}

