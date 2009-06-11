
package com.foxconn.cic.dao.hibernate;

import java.util.Date;
import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.ExchangeRateDao;
import com.foxconn.cic.model.ExchangeRate;

public class ExchangeRateDaoHibernate extends BaseDaoHibernate implements ExchangeRateDao {

    /**
     * @see com.foxconn.cic.dao.ExchangeRateDao#getExchangeRates(com.foxconn.cic.model.ExchangeRate)
     */
    public List getExchangeRates(final ExchangeRate exchangeRate) {
        return getHibernateTemplate().find("from ExchangeRate");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.
        if (exchangeRate == null) {
            return getHibernateTemplate().find("from ExchangeRate");
        } else {
            // filter on properties set in the exchangeRate
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(exchangeRate).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(ExchangeRate.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.ExchangeRateDao#getExchangeRate(Long id)
     */
    public ExchangeRate getExchangeRate(final Long id) {
        ExchangeRate exchangeRate = (ExchangeRate) getHibernateTemplate().get(ExchangeRate.class, id);
        if (exchangeRate == null) {
            log.warn("uh oh, exchangeRate with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(ExchangeRate.class, id);
        }

        return exchangeRate;
    }

    /**
     * @see com.foxconn.cic.dao.ExchangeRateDao#saveExchangeRate(ExchangeRate exchangeRate)
     */    
    public ExchangeRate saveExchangeRate(final ExchangeRate exchangeRate) {
    	if(exchangeRate.getId()==null){
    		exchangeRate.setCreatedDate(new Date());
    	}else{
    		exchangeRate.setUpdatedDate(new Date());
    	}
    	getHibernateTemplate().saveOrUpdate(exchangeRate);
    	return exchangeRate;
    }

    /**
     * @see com.foxconn.cic.dao.ExchangeRateDao#removeExchangeRate(Long id)
     */
    public void removeExchangeRate(final Long id) {
        getHibernateTemplate().delete(getExchangeRate(id));
    }
}
