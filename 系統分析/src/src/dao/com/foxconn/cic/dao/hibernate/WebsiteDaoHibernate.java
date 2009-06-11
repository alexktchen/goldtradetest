
package com.foxconn.cic.dao.hibernate;

import java.util.Date;
import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.WebsiteDao;
import com.foxconn.cic.model.Website;

public class WebsiteDaoHibernate extends BaseDaoHibernate implements WebsiteDao {

    /**
     * @see com.foxconn.cic.dao.WebsiteDao#getWebsites(com.foxconn.cic.model.Website)
     */
    public List getWebsites(final Website website) {
        return getHibernateTemplate().find("from Website");

        /* Remove the line above and uncomment this code block if you want
           to use Hibernate's Query by Example API.
        if (website == null) {
            return getHibernateTemplate().find("from Website");
        } else {
            // filter on properties set in the website
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(website).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(Website.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.WebsiteDao#getWebsite(Long id)
     */
    public Website getWebsite(final String id) {
        Website website = (Website) getHibernateTemplate().get(Website.class, id);
        if (website == null) {
            log.warn("uh oh, website with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(Website.class, id);
        }

        return website;
    }

    /**
     * @see com.foxconn.cic.dao.WebsiteDao#saveWebsite(Website website)
     */
    public void saveWebsite(final Website website) {
    	if(website.getId()==null){
    		website.setCreatedDate(new Date());
    	}else{
    		website.setUpdatedDate(new Date());
    	}
        getHibernateTemplate().saveOrUpdate(website);
    }

    /**
     * @see com.foxconn.cic.dao.WebsiteDao#removeWebsite(Long id)
     */
    public void removeWebsite(final String id) {
        getHibernateTemplate().delete(getWebsite(id));
    }
}
