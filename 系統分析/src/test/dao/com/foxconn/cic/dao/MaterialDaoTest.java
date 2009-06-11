package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.Material;

public class MaterialDaoTest extends BaseDaoTestCase {
    private String materialId = "1";
    private MaterialDao dao = null;

    public void setMaterialDao(MaterialDao dao) {
        this.dao = dao;
    }

    public void testAddMaterial() throws Exception {
        Material material = new Material();

        // set required fields

        dao.saveMaterial(material);

        // verify a primary key was assigned
        assertNotNull(material.getId());

        // verify set fields are same after save
    }

    public void testGetMaterial() throws Exception {
        Material material = dao.getMaterial(materialId);
        assertNotNull(material);
    }

    public void testGetMaterials() throws Exception {
        Material material = new Material();

        List results = dao.getMaterials(material);
        assertTrue(results.size() > 0);
    }

    public void testSaveMaterial() throws Exception {
        Material material = dao.getMaterial(materialId);

        // update required fields

        dao.saveMaterial(material);

    }

    public void testRemoveMaterial() throws Exception {
        String removeId = "3";
        dao.removeMaterial(removeId);
        try {
            dao.getMaterial(removeId);
            fail("material found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
