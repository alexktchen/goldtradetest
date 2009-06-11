package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.News;

public class NewsDaoTest extends BaseDaoTestCase {
    private Long newsId = new Long("1");
    private NewsDao dao = null;

    public void setNewsDao(NewsDao dao) {
        this.dao = dao;
    }

    public void testAddNews() throws Exception {
        News news = new News();

        // set required fields

        dao.saveNews(news);

        // verify a primary key was assigned
        assertNotNull(news.getId());
        System.out.println("NewsID:"+news.getId());
        // verify set fields are same after save
    }

    public void testGetNews() throws Exception {
        News news = dao.getNews(newsId);
        assertNotNull(news);
    }

    public void testGetNewss() throws Exception {
        News news = new News();

        List results = dao.getNewss(news);
        assertTrue(results.size() > 0);
    }

    public void testSaveNews() throws Exception {
        News news = dao.getNews(newsId);

        // update required fields

        dao.saveNews(news);

    }

    public void testRemoveNews() throws Exception {
        Long removeId = new Long("3");
        dao.removeNews(removeId);
        try {
            dao.getNews(removeId);
            fail("news found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
