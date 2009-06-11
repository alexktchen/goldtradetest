
package com.foxconn.cic.service;

import java.util.List;

import com.foxconn.cic.model.Material;

public interface MaterialManager extends Manager {
    /**
     * Retrieves all of the materials
     */
    public List getMaterials(Material material);

    /**
     * Gets material's information based on id.
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

