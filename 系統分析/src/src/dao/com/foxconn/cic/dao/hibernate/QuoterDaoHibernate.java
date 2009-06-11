
package com.foxconn.cic.dao.hibernate;

import java.util.Date;
import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.QuoterDao;
import com.foxconn.cic.model.Quoter;

public class QuoterDaoHibernate extends BaseDaoHibernate implements QuoterDao {

    /**
     * @see com.foxconn.cic.dao.QuoterDao#getQuoters(com.foxconn.cic.model.Quoter)
     */
    public List getQuoters(final Quoter quoter) {
        return getHibernateTemplate().find("from Quoter");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.
        if (quoter == null) {
            return getHibernateTemplate().find("from Quoter");
        } else {
            // filter on properties set in the quoter
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(quoter).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(Quoter.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.QuoterDao#getQuoter(String id)
     */
    public Quoter getQuoter(final String id) {
        Quoter quoter = (Quoter) getHibernateTemplate().get(Quoter.class, id);
        if (quoter == null) {
            log.warn("uh oh, quoter with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(Quoter.class, id);
        }

        return quoter;
    }

    /**
     * @see com.foxconn.cic.dao.QuoterDao#saveQuoter(Quoter quoter)
     */    
    public void saveQuoter(final Quoter quoter) {
    	if(quoter.getId()==null){
    		quoter.setCreatedDate(new Date());
    	}else{
    		quoter.setUpdatedDate(new Date());
    	}
        getHibernateTemplate().saveOrUpdate(quoter);
    }

    /**
     * @see com.foxconn.cic.dao.QuoterDao#removeQuoter(String id)
     */
    public void removeQuoter(final String id) {
        getHibernateTemplate().delete(getQuoter(id));
    }
}
