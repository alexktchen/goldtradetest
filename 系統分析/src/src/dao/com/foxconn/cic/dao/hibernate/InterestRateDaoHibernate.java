
package com.foxconn.cic.dao.hibernate;

import java.util.Date;
import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.InterestRateDao;
import com.foxconn.cic.model.InterestRate;

public class InterestRateDaoHibernate extends BaseDaoHibernate implements InterestRateDao {

    /**
     * @see com.foxconn.cic.dao.InterestRateDao#getInterestRates(com.foxconn.cic.model.InterestRate)
     */
    public List getInterestRates(final InterestRate interestRate) {
        return getHibernateTemplate().find("from InterestRate");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.
        if (interestRate == null) {
            return getHibernateTemplate().find("from InterestRate");
        } else {
            // filter on properties set in the interestRate
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(interestRate).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(InterestRate.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.InterestRateDao#getInterestRate(Long id)
     */
    public InterestRate getInterestRate(final Long id) {
        InterestRate interestRate = (InterestRate) getHibernateTemplate().get(InterestRate.class, id);
        if (interestRate == null) {
            log.warn("uh oh, interestRate with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(InterestRate.class, id);
        }

        return interestRate;
    }

    /**
     * @see com.foxconn.cic.dao.InterestRateDao#saveInterestRate(InterestRate interestRate)
     */    
    public InterestRate saveInterestRate(final InterestRate interestRate) {
    	if(interestRate.getId()==null){
    		interestRate.setCreatedDate(new Date());
    	}else{
    		interestRate.setUpdatedDate(new Date());
    	}
    	getHibernateTemplate().saveOrUpdate(interestRate);
    	return interestRate;
    }

    /**
     * @see com.foxconn.cic.dao.InterestRateDao#removeInterestRate(Long id)
     */
    public void removeInterestRate(final Long id) {
        getHibernateTemplate().delete(getInterestRate(id));
    }
}
