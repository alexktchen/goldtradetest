
package com.foxconn.cic.dao.hibernate;

import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.CatalogTypeDao;
import com.foxconn.cic.model.CatalogType;

public class CatalogTypeDaoHibernate extends BaseDaoHibernate implements CatalogTypeDao {

    /**
     * @see com.foxconn.cic.dao.CatalogTypeDao#getCatalogTypes(com.foxconn.cic.model.CatalogType)
     */
    public List getCatalogTypes(final CatalogType catalogType) {
        return getHibernateTemplate().find("from CatalogType");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.
        if (catalogType == null) {
            return getHibernateTemplate().find("from CatalogType");
        } else {
            // filter on properties set in the catalogType
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(catalogType).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(CatalogType.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.CatalogTypeDao#getCatalogType(Long id)
     */
    public CatalogType getCatalogType(final Long id) {
        CatalogType catalogType = (CatalogType) getHibernateTemplate().get(CatalogType.class, id);
        if (catalogType == null) {
            log.warn("uh oh, catalogType with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(CatalogType.class, id);
        }

        return catalogType;
    }

    /**
     * @see com.foxconn.cic.dao.CatalogTypeDao#saveCatalogType(CatalogType catalogType)
     */    
    public void saveCatalogType(final CatalogType catalogType) {
        getHibernateTemplate().saveOrUpdate(catalogType);
    }

    /**
     * @see com.foxconn.cic.dao.CatalogTypeDao#removeCatalogType(Long id)
     */
    public void removeCatalogType(final Long id) {
        getHibernateTemplate().delete(getCatalogType(id));
    }
}
