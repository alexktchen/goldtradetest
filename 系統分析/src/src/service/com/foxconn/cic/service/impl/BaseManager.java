package com.foxconn.cic.service.impl;

import java.io.Serializable;
import java.util.List;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import com.foxconn.cic.dao.Dao;
import com.foxconn.cic.service.Manager;

/**
 * Base class for Business Services - use this class for utility methods and
 * generic CRUD methods.
 * 
 * <p><a href="BaseManager.java.html"><i>View Source</i></a></p>
 *
 * @author <a href="mailto:matt@raibledesigns.com">Matt Raible</a>
 */
public class BaseManager implements Manager {
    protected final Log log = LogFactory.getLog(getClass());
    protected Dao dao = null;
    
    /**
     * @see com.foxconn.cic.service.Manager#setDao(com.foxconn.cic.dao.Dao)
     */
    public void setDao(Dao dao) {
        this.dao = dao;
    }
    
    /**
     * @see com.foxconn.cic.service.Manager#getObject(java.lang.Class, java.io.Serializable)
     */
    public Object getObject(Class clazz, Serializable id) {
        return dao.getObject(clazz, id);
    }
    
    /**
     * @see com.foxconn.cic.service.Manager#getObjects(java.lang.Class)
     */
    public List getObjects(Class clazz) {
        return dao.getObjects(clazz);
    }
    
    /**
     * @see com.foxconn.cic.service.Manager#removeObject(java.lang.Class, java.io.Serializable)
     */
    public void removeObject(Class clazz, Serializable id) {
        dao.removeObject(clazz, id);
    }
    
    /**
     * @see com.foxconn.cic.service.Manager#saveObject(java.lang.Object)
     */
    public void saveObject(Object o) {
        dao.saveObject(o);
    }
}
