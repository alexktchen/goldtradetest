
package com.foxconn.cic.dao.hibernate;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.criterion.Restrictions;
import org.springframework.orm.ObjectRetrievalFailureException;
import org.springframework.orm.hibernate3.HibernateCallback;

import com.foxconn.cic.dao.NewsImageDao;
import com.foxconn.cic.model.NewsImage;

public class NewsImageDaoHibernate extends BaseDaoHibernate implements NewsImageDao {

    /**
     * @see com.foxconn.cic.dao.NewsImageDao#getNewsImages(com.foxconn.cic.model.NewsImage)
     */
    public List getNewsImages(final NewsImage newsImage) {
        return getHibernateTemplate().find("from NewsImage");

        /* Remove the line above and uncomment this code block if you want
           to use Hibernate's Query by Example API.
        if (newsImage == null) {
            return getHibernateTemplate().find("from NewsImage");
        } else {
            // filter on properties set in the newsImage
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(newsImage).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(NewsImage.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.NewsImageDao#getNewsImage(Long id)
     */
    public NewsImage getNewsImage(final Long id) {
        NewsImage newsImage = (NewsImage) getHibernateTemplate().get(NewsImage.class, id);
        if (newsImage == null) {
            log.warn("uh oh, newsImage with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(NewsImage.class, id);
        }

        return newsImage;
    }

    /**
     * @see com.foxconn.cic.dao.NewsImageDao#saveNewsImage(NewsImage newsImage)
     */
    public void saveNewsImage(final NewsImage newsImage) {
    	if(newsImage.getId()==null){
    		newsImage.setCreatedDate(new Date());
    	}else{
    		newsImage.setUpdatedDate(new Date());
    	}
        getHibernateTemplate().saveOrUpdate(newsImage);
    }

    /**
     * @see com.foxconn.cic.dao.NewsImageDao#removeNewsImage(Long id)
     */
    public void removeNewsImage(final Long id) {
        getHibernateTemplate().delete(getNewsImage(id));
    }

	public List<NewsImage> getFilepathIsNullNewsImages(final int gt,final int lt) {
		SimpleDateFormat format=new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

		long current=System.currentTimeMillis();
		final Date ltDate=new Date(current-(gt*60*1000));
		final Date gtDate=new Date(current-(lt*60*1000));

//		Calendar calendar=Calendar.getInstance();
//		calendar.add(Calendar.MINUTE, -gt);
//		final Date ltDate= calendar.getTime();
//		calendar.clear();
//		calendar.add(Calendar.MINUTE, -lt);
//		final Date gtDate= calendar.getTime();

		System.out.println("當前時間:"+format.format(new Date()));
		System.out.println("lt時間:"+format.format(ltDate));
		System.out.println("gt時間:"+format.format(gtDate));
//		getHibernateTemplate().find("from NewsImage image where image");
		HibernateCallback callback = new HibernateCallback() {
            public Object doInHibernate(Session session) throws HibernateException {
            	Criteria criteria = session.createCriteria(NewsImage.class);
            	criteria.add(Restrictions.between("createdDate", gtDate,ltDate));
            	criteria.add(Restrictions.isNull("filePath"));
                return criteria.list();
            }
        };
        return (List) getHibernateTemplate().execute(callback);
	}
}
