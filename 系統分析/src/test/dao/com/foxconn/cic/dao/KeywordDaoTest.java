package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.Keyword;

public class KeywordDaoTest extends BaseDaoTestCase {
    private Long keywordId = new Long("1");
    private KeywordDao dao = null;

    public void setKeywordDao(KeywordDao dao) {
        this.dao = dao;
    }

    public void testAddKeyword() throws Exception {
        Keyword keyword = new Keyword();

        // set required fields

        dao.saveKeyword(keyword);

        // verify a primary key was assigned
        assertNotNull(keyword.getId());

        // verify set fields are same after save
    }

    public void testGetKeyword() throws Exception {
        Keyword keyword = dao.getKeyword(keywordId);
        assertNotNull(keyword);
    }

    public void testGetKeywords() throws Exception {
        Keyword keyword = new Keyword();

        List results = dao.getKeywords(keyword);
        assertTrue(results.size() > 0);
    }

    public void testSaveKeyword() throws Exception {
        Keyword keyword = dao.getKeyword(keywordId);

        // update required fields

        dao.saveKeyword(keyword);

    }

    public void testRemoveKeyword() throws Exception {
        Long removeId = new Long("3");
        dao.removeKeyword(removeId);
        try {
            dao.getKeyword(removeId);
            fail("keyword found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
