
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.Material;

public interface MaterialDao extends Dao {

    /**
     * Retrieves all of the materials
     */
    public List getMaterials(Material material);

    /**
     * Gets material's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if 
     * nothing is found.
     * 
     * @param id the material's id
     * @return material populated material object
     */
    public Material getMaterial(final String id);

    /**
     * Saves a material's information
     * @param material the object to be saved
     */    
    public void saveMaterial(Material material);

    /**
     * Removes a material from the database by id
     * @param id the material's id
     */
    public void removeMaterial(final String id);
}

