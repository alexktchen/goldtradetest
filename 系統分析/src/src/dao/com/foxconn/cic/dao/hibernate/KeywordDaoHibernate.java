
package com.foxconn.cic.dao.hibernate;

import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.KeywordDao;
import com.foxconn.cic.model.Keyword;

public class KeywordDaoHibernate extends BaseDaoHibernate implements KeywordDao {

    /**
     * @see com.foxconn.cic.dao.KeywordDao#getKeywords(com.foxconn.cic.model.Keyword)
     */
    public List getKeywords(final Keyword keyword) {
        return getHibernateTemplate().find("from Keyword");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.
        if (keyword == null) {
            return getHibernateTemplate().find("from Keyword");
        } else {
            // filter on properties set in the keyword
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(keyword).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(Keyword.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.KeywordDao#getKeyword(Long id)
     */
    public Keyword getKeyword(final Long id) {
        Keyword keyword = (Keyword) getHibernateTemplate().get(Keyword.class, id);
        if (keyword == null) {
            log.warn("uh oh, keyword with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(Keyword.class, id);
        }

        return keyword;
    }

    /**
     * @see com.foxconn.cic.dao.KeywordDao#saveKeyword(Keyword keyword)
     */    
    public void saveKeyword(final Keyword keyword) {
        getHibernateTemplate().saveOrUpdate(keyword);
    }

    /**
     * @see com.foxconn.cic.dao.KeywordDao#removeKeyword(Long id)
     */
    public void removeKeyword(final Long id) {
        getHibernateTemplate().delete(getKeyword(id));
    }
}
