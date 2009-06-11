
package com.foxconn.cic.service.impl;

import java.util.List;

import com.foxconn.cic.dao.KeywordDao;
import com.foxconn.cic.model.Keyword;
import com.foxconn.cic.service.KeywordManager;

public class KeywordManagerImpl extends BaseManager implements KeywordManager {
    private KeywordDao dao;

    /**
     * Set the Dao for communication with the data layer.
     * @param dao
     */
    public void setKeywordDao(KeywordDao dao) {
        this.dao = dao;
    }

    /**
     * @see com.foxconn.cic.service.KeywordManager#getKeywords(com.foxconn.cic.model.Keyword)
     */
    public List getKeywords(final Keyword keyword) {
        return dao.getKeywords(keyword);
    }

    /**
     * @see com.foxconn.cic.service.KeywordManager#getKeyword(String id)
     */
    public Keyword getKeyword(final String id) {
        return dao.getKeyword(new Long(id));
    }

    /**
     * @see com.foxconn.cic.service.KeywordManager#saveKeyword(Keyword keyword)
     */
    public void saveKeyword(Keyword keyword) {
        dao.saveKeyword(keyword);
    }

    /**
     * @see com.foxconn.cic.service.KeywordManager#removeKeyword(String id)
     */
    public void removeKeyword(final String id) {
        dao.removeKeyword(new Long(id));
    }
}
