
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.Catalog;

/**
 * 分類DAO接口
 * @author ldapeng
 *
 */
public interface CatalogDao extends Dao {

    /**
     * Retrieves all of the catalogs
     * @param catalog 過濾條件
     * @return List 返回分類列表
     */
    public List<Catalog> getCatalogs(Catalog catalog);

    /**
     * Gets catalog's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if 
     * nothing is found.
     * 
     * @param id the catalog's id
     * @return catalog populated catalog object
     */
    public Catalog getCatalog(final Long id);

    /**
     * Saves a catalog's information
     * @param catalog the object to be saved
     */    
    public void saveCatalog(Catalog catalog);

    /**
     * Removes a catalog from the database by id
     * @param id the catalog's id
     */
    public void removeCatalog(final Long id);
}

