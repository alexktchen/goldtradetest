
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.KeywordDao;
import com.foxconn.cic.model.Keyword;
import com.foxconn.cic.service.impl.KeywordManagerImpl;

public class KeywordManagerTest extends BaseManagerTestCase {
    private final String keywordId = "1";
    private KeywordManagerImpl keywordManager = new KeywordManagerImpl();
    private Mock keywordDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        keywordDao = new Mock(KeywordDao.class);
        keywordManager.setKeywordDao((KeywordDao) keywordDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        keywordManager = null;
    }

    public void testGetKeywords() throws Exception {
        List results = new ArrayList();
        Keyword keyword = new Keyword();
        results.add(keyword);

        // set expected behavior on dao
        keywordDao.expects(once()).method("getKeywords")
            .will(returnValue(results));

        List keywords = keywordManager.getKeywords(null);
        assertTrue(keywords.size() == 1);
        keywordDao.verify();
    }

    public void testGetKeyword() throws Exception {
        // set expected behavior on dao
        keywordDao.expects(once()).method("getKeyword")
            .will(returnValue(new Keyword()));
        Keyword keyword = keywordManager.getKeyword(keywordId);
        assertTrue(keyword != null);
        keywordDao.verify();
    }

    public void testSaveKeyword() throws Exception {
        Keyword keyword = new Keyword();

        // set expected behavior on dao
        keywordDao.expects(once()).method("saveKeyword")
            .with(same(keyword)).isVoid();

        keywordManager.saveKeyword(keyword);
        keywordDao.verify();
    }

    public void testAddAndRemoveKeyword() throws Exception {
        Keyword keyword = new Keyword();

        // set required fields

        // set expected behavior on dao
        keywordDao.expects(once()).method("saveKeyword")
            .with(same(keyword)).isVoid();
        keywordManager.saveKeyword(keyword);
        keywordDao.verify();

        // reset expectations
        keywordDao.reset();

        keywordDao.expects(once()).method("removeKeyword").with(eq(new Long(keywordId)));
        keywordManager.removeKeyword(keywordId);
        keywordDao.verify();

        // reset expectations
        keywordDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(Keyword.class, keyword.getId());
        keywordDao.expects(once()).method("removeKeyword").isVoid();
        keywordDao.expects(once()).method("getKeyword").will(throwException(ex));
        keywordManager.removeKeyword(keywordId);
        try {
            keywordManager.getKeyword(keywordId);
            fail("Keyword with identifier '" + keywordId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        keywordDao.verify();
    }
}
