
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.NewsDao;
import com.foxconn.cic.model.News;
import com.foxconn.cic.service.impl.NewsManagerImpl;

public class NewsManagerTest extends BaseManagerTestCase {
    private final String newsId = "1";
    private NewsManagerImpl newsManager = new NewsManagerImpl();
    private Mock newsDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        newsDao = new Mock(NewsDao.class);
        newsManager.setNewsDao((NewsDao) newsDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        newsManager = null;
    }

    public void testGetNewss() throws Exception {
        List results = new ArrayList();
        News news = new News();
        results.add(news);

        // set expected behavior on dao
        newsDao.expects(once()).method("getNewss")
            .will(returnValue(results));

        List newss = newsManager.getNewss(null);
        assertTrue(newss.size() == 1);
        newsDao.verify();
    }

    public void testGetNews() throws Exception {
        // set expected behavior on dao
        newsDao.expects(once()).method("getNews")
            .will(returnValue(new News()));
        News news = newsManager.getNews(newsId);
        assertTrue(news != null);
        newsDao.verify();
    }

    public void testSaveNews() throws Exception {
        News news = new News();

        // set expected behavior on dao
        newsDao.expects(once()).method("saveNews")
            .with(same(news)).isVoid();

        newsManager.saveNews(news);
        newsDao.verify();
    }

    public void testAddAndRemoveNews() throws Exception {
        News news = new News();

        // set required fields

        // set expected behavior on dao
        newsDao.expects(once()).method("saveNews")
            .with(same(news)).isVoid();
        newsManager.saveNews(news);
        newsDao.verify();

        // reset expectations
        newsDao.reset();

        newsDao.expects(once()).method("removeNews").with(eq(new Long(newsId)));
        newsManager.removeNews(newsId);
        newsDao.verify();

        // reset expectations
        newsDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(News.class, news.getId());
        newsDao.expects(once()).method("removeNews").isVoid();
        newsDao.expects(once()).method("getNews").will(throwException(ex));
        newsManager.removeNews(newsId);
        try {
            newsManager.getNews(newsId);
            fail("News with identifier '" + newsId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        newsDao.verify();
    }
}
