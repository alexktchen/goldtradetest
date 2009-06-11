
package com.foxconn.cic.dao.hibernate;

import java.util.Date;
import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.PriceDao;
import com.foxconn.cic.model.Price;

public class PriceDaoHibernate extends BaseDaoHibernate implements PriceDao {

    /**
     * @see com.foxconn.cic.dao.PriceDao#getPrices(com.foxconn.cic.model.Price)
     */
    public List getPrices(final Price price) {
        return getHibernateTemplate().find("from Price");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.
        if (price == null) {
            return getHibernateTemplate().find("from Price");
        } else {
            // filter on properties set in the price
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(price).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(Price.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.PriceDao#getPrice(Long id)
     */
    public Price getPrice(final Long id) {
        Price price = (Price) getHibernateTemplate().get(Price.class, id);
        if (price == null) {
            log.warn("uh oh, price with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(Price.class, id);
        }

        return price;
    }

    /**
     * @see com.foxconn.cic.dao.PriceDao#savePrice(Price price)
     */    
    public Price savePrice(final Price price) {
    	if(price.getId()==null){
    		price.setCreatedDate(new Date());
    	}else{
    		price.setUpdatedDate(new Date());
    	}
       getHibernateTemplate().saveOrUpdate(price);
       return price;
       
    }

    /**
     * @see com.foxconn.cic.dao.PriceDao#removePrice(Long id)
     */
    public void removePrice(final Long id) {
        getHibernateTemplate().delete(getPrice(id));
    }
}
