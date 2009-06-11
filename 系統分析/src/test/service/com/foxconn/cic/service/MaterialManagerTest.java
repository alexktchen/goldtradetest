
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.MaterialDao;
import com.foxconn.cic.model.Material;
import com.foxconn.cic.service.impl.MaterialManagerImpl;

public class MaterialManagerTest extends BaseManagerTestCase {
    private final String materialId = "1";
    private MaterialManagerImpl materialManager = new MaterialManagerImpl();
    private Mock materialDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        materialDao = new Mock(MaterialDao.class);
        materialManager.setMaterialDao((MaterialDao) materialDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        materialManager = null;
    }

    public void testGetMaterials() throws Exception {
        List results = new ArrayList();
        Material material = new Material();
        results.add(material);

        // set expected behavior on dao
        materialDao.expects(once()).method("getMaterials")
            .will(returnValue(results));

        List materials = materialManager.getMaterials(null);
        assertTrue(materials.size() == 1);
        materialDao.verify();
    }

    public void testGetMaterial() throws Exception {
        // set expected behavior on dao
        materialDao.expects(once()).method("getMaterial")
            .will(returnValue(new Material()));
        Material material = materialManager.getMaterial(materialId);
        assertTrue(material != null);
        materialDao.verify();
    }

    public void testSaveMaterial() throws Exception {
        Material material = new Material();

        // set expected behavior on dao
        materialDao.expects(once()).method("saveMaterial")
            .with(same(material)).isVoid();

        materialManager.saveMaterial(material);
        materialDao.verify();
    }

    public void testAddAndRemoveMaterial() throws Exception {
        Material material = new Material();

        // set required fields

        // set expected behavior on dao
        materialDao.expects(once()).method("saveMaterial")
            .with(same(material)).isVoid();
        materialManager.saveMaterial(material);
        materialDao.verify();

        // reset expectations
        materialDao.reset();

        materialDao.expects(once()).method("removeMaterial").with(eq(new Long(materialId)));
        materialManager.removeMaterial(materialId);
        materialDao.verify();

        // reset expectations
        materialDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(Material.class, material.getId());
        materialDao.expects(once()).method("removeMaterial").isVoid();
        materialDao.expects(once()).method("getMaterial").will(throwException(ex));
        materialManager.removeMaterial(materialId);
        try {
            materialManager.getMaterial(materialId);
            fail("Material with identifier '" + materialId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        materialDao.verify();
    }
}
