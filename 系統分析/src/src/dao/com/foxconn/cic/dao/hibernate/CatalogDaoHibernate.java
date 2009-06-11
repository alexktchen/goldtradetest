
package com.foxconn.cic.dao.hibernate;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.criterion.Example;
import org.hibernate.criterion.MatchMode;
import org.springframework.orm.ObjectRetrievalFailureException;
import org.springframework.orm.hibernate3.HibernateCallback;

import com.foxconn.cic.dao.CatalogDao;
import com.foxconn.cic.model.Catalog;

public class CatalogDaoHibernate extends BaseDaoHibernate implements CatalogDao {

    /**
     * @see com.foxconn.cic.dao.CatalogDao#getCatalogs(com.foxconn.cic.model.Catalog)
     */
    public List getCatalogs(final Catalog catalog) {
    	
//        return getHibernateTemplate().find("from Catalog");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.*/
        if (catalog == null) {
            return getHibernateTemplate().find("from Catalog");
        } else {
            // filter on properties set in the catalog
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(catalog).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(Catalog.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }
    }

    /**
     * @see com.foxconn.cic.dao.CatalogDao#getCatalog(Long id)
     */
    public Catalog getCatalog(final Long id) {
        Catalog catalog = (Catalog) getHibernateTemplate().get(Catalog.class, id);
        if (catalog == null) {
            log.warn("uh oh, catalog with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(Catalog.class, id);
        }

        return catalog;
    }

    /**
     * @see com.foxconn.cic.dao.CatalogDao#saveCatalog(Catalog catalog)
     */    
    public void saveCatalog(final Catalog catalog) {
        getHibernateTemplate().saveOrUpdate(catalog);
    }

    /**
     * @see com.foxconn.cic.dao.CatalogDao#removeCatalog(Long id)
     */
    public void removeCatalog(final Long id) {
        getHibernateTemplate().delete(getCatalog(id));
    }
}
