
package com.foxconn.cic.service.impl;

import java.util.List;

import com.foxconn.cic.dao.QuoterDao;
import com.foxconn.cic.model.Quoter;
import com.foxconn.cic.service.QuoterManager;

public class QuoterManagerImpl extends BaseManager implements QuoterManager {
    private QuoterDao dao;

    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setQuoterDao(QuoterDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.QuoterManager#getQuoters(com.foxconn.cic.model.Quoter)
     */
    public List getQuoters(final Quoter quoter) {
        return dao.getQuoters(quoter);
    }

    /**
     * @see com.foxconn.cic.service.QuoterManager#getQuoter(String id)
     */
    public Quoter getQuoter(final String id) {
        return dao.getQuoter(new String(id));
    }

    /**
     * @see com.foxconn.cic.service.QuoterManager#saveQuoter(Quoter quoter)
     */
    public void saveQuoter(Quoter quoter) {
        dao.saveQuoter(quoter);
    }

    /**
     * @see com.foxconn.cic.service.QuoterManager#removeQuoter(String id)
     */
    public void removeQuoter(final String id) {
        dao.removeQuoter(new String(id));
    }
}
