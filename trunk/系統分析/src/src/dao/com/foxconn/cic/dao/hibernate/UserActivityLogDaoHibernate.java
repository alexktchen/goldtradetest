
package com.foxconn.cic.dao.hibernate;

import java.util.Date;
import java.util.List;

import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.UserActivityLogDao;
import com.foxconn.cic.model.UserActivityLog;

public class UserActivityLogDaoHibernate extends BaseDaoHibernate implements UserActivityLogDao {

    /**
     * @see com.foxconn.cic.dao.UserActivityLogDao#getUserActivityLogs(com.foxconn.cic.model.UserActivityLog)
     */
    public List getUserActivityLogs(final UserActivityLog userActivityLog) {
        return getHibernateTemplate().find("from UserActivityLog");

        /* Remove the line above and uncomment this code block if you want 
           to use Hibernate's Query by Example API.
        if (userActivityLog == null) {
            return getHibernateTemplate().find("from UserActivityLog");
        } else {
            // filter on properties set in the userActivityLog
            HibernateCallback callback = new HibernateCallback() {
                public Object doInHibernate(Session session) throws HibernateException {
                    Example ex = Example.create(userActivityLog).ignoreCase().enableLike(MatchMode.ANYWHERE);
                    return session.createCriteria(UserActivityLog.class).add(ex).list();
                }
            };
            return (List) getHibernateTemplate().execute(callback);
        }*/
    }

    /**
     * @see com.foxconn.cic.dao.UserActivityLogDao#getUserActivityLog(Long id)
     */
    public UserActivityLog getUserActivityLog(final Long id) {
        UserActivityLog userActivityLog = (UserActivityLog) getHibernateTemplate().get(UserActivityLog.class, id);
        if (userActivityLog == null) {
            log.warn("uh oh, userActivityLog with id '" + id + "' not found...");
            throw new ObjectRetrievalFailureException(UserActivityLog.class, id);
        }

        return userActivityLog;
    }

    /**
     * @see com.foxconn.cic.dao.UserActivityLogDao#saveUserActivityLog(UserActivityLog userActivityLog)
     */    
    public void saveUserActivityLog(final UserActivityLog userActivityLog) {
    	if(userActivityLog.getId()==null){
    		userActivityLog.setCreatedDate(new Date());
    	}
        getHibernateTemplate().saveOrUpdate(userActivityLog);
    }

    /**
     * @see com.foxconn.cic.dao.UserActivityLogDao#removeUserActivityLog(Long id)
     */
    public void removeUserActivityLog(final Long id) {
        getHibernateTemplate().delete(getUserActivityLog(id));
    }
}
