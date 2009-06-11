
package com.foxconn.cic.dao.hibernate;

import java.util.Date;
import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.criterion.Example;
import org.hibernate.criterion.Expression;
import org.hibernate.criterion.MatchMode;
import org.springframework.orm.ObjectRetrievalFailureException;
import org.springframework.orm.hibernate3.HibernateCallback;

import com.foxconn.cic.dao.NewsDao;
import com.foxconn.cic.model.News;

public class NewsDaoHibernate extends BaseDaoHibernate implements NewsDao {

    /**
     * @see com.foxconn.cic.dao.NewsDao#getNewss(com.foxconn.cic.model.News)
     */
    public List getNewss(final News news) {
//        return getHibernateTemplate().find("from News");

        /* Remove the line above and uncomment this code block if you want
           to use Hibernate's Query by Example API.*/
        if (news == null) {
            return getHibernateTemplate().find("from News");
        } else {
            // filter on properties set in the news
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(news).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(News.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }
    }

    /**
     * @see com.foxconn.cic.dao.NewsDao#getNews(Long id)
     */
    public News getNews(final Long id) {
        News news = (News) getHibernateTemplate().get(News.class, id);
        if (news == null) {
            log.warn("uh oh, news with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(News.class, id);
        }

        return news;
    }

    /**
     * @see com.foxconn.cic.dao.NewsDao#saveNews(News news)
     */
    public News saveNews(News news) {
    	if(news.getId()==null){
    		news.setCreatedDate(new Date());
    	}else{
    		news.setUpdatedDate(new Date());
    	}
        getHibernateTemplate().saveOrUpdate(news);
        return news;
    }

    /**
     * @see com.foxconn.cic.dao.NewsDao#removeNews(Long id)
     */
    public void removeNews(final Long id) {
        getHibernateTemplate().delete(getNews(id));
    }

	public News getNews(String title, String url) {
		Criteria crit = getSession().createCriteria(News.class);
		crit.add(Expression.eq("title",title.trim()));
		crit.add(Expression.eq("url",url.trim()));
		List<News> list=crit.list();
		if(list==null||list.size()==0){
			return null;
		}
		return list.get(0);
	}

	public List<News> getNewss(Long beginId, Long endId) {
		return getHibernateTemplate().find(
				"from News news where news.id between " + beginId + " and "	+ endId);
	}

	public List<String> getNewsIds() {
		HibernateCallback callback = new HibernateCallback() {
            public Object doInHibernate(Session session) throws HibernateException {
                return session.createSQLQuery("select news.id from News news").list();
            }
        };
        return (List<String>) getHibernateTemplate().execute(callback);
	}
}
