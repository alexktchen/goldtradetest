
package com.foxconn.cic.dao.hibernate;

import java.util.Date;
import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.MaterialDao;
import com.foxconn.cic.model.Material;

public class MaterialDaoHibernate extends BaseDaoHibernate implements MaterialDao {

    /**
     * @see com.foxconn.cic.dao.MaterialDao#getMaterials(com.foxconn.cic.model.Material)
     */
    public List getMaterials(final Material material) {
        return getHibernateTemplate().find("from Material");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.
        if (material == null) {
            return getHibernateTemplate().find("from Material");
        } else {
            // filter on properties set in the material
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(material).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(Material.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.MaterialDao#getMaterial(Long id)
     */
    public Material getMaterial(final String id) {
        Material material = (Material) getHibernateTemplate().get(Material.class, id);
        if (material == null) {
            log.warn("uh oh, material with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(Material.class, id);
        }

        return material;
    }

    /**
     * @see com.foxconn.cic.dao.MaterialDao#saveMaterial(Material material)
     */    
    public void saveMaterial(final Material material) {
    	if(material.getId()==null){
    		material.setCreatedDate(new Date());
    	}else{
    		material.setUpdatedDate(new Date());
    	}
        getHibernateTemplate().saveOrUpdate(material);
    }

    /**
     * @see com.foxconn.cic.dao.MaterialDao#removeMaterial(Long id)
     */
    public void removeMaterial(final String id) {
        getHibernateTemplate().delete(getMaterial(id));
    }
}
