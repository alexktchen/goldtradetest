
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.NewsImageDao;
import com.foxconn.cic.model.NewsImage;
import com.foxconn.cic.service.impl.NewsImageManagerImpl;

public class NewsImageManagerTest extends BaseManagerTestCase {
    private final String newsImageId = "1";
    private NewsImageManagerImpl newsImageManager = new NewsImageManagerImpl();
    private Mock newsImageDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        newsImageDao = new Mock(NewsImageDao.class);
        newsImageManager.setNewsImageDao((NewsImageDao) newsImageDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        newsImageManager = null;
    }

    public void testGetNewsImages() throws Exception {
        List results = new ArrayList();
        NewsImage newsImage = new NewsImage();
        results.add(newsImage);

        // set expected behavior on dao
        newsImageDao.expects(once()).method("getNewsImages")
            .will(returnValue(results));

        List newsImages = newsImageManager.getNewsImages(null);
        assertTrue(newsImages.size() == 1);
        newsImageDao.verify();
    }

    public void testGetNewsImage() throws Exception {
        // set expected behavior on dao
        newsImageDao.expects(once()).method("getNewsImage")
            .will(returnValue(new NewsImage()));
        NewsImage newsImage = newsImageManager.getNewsImage(newsImageId);
        assertTrue(newsImage != null);
        newsImageDao.verify();
    }

    public void testSaveNewsImage() throws Exception {
        NewsImage newsImage = new NewsImage();

        // set expected behavior on dao
        newsImageDao.expects(once()).method("saveNewsImage")
            .with(same(newsImage)).isVoid();

        newsImageManager.saveNewsImage(newsImage);
        newsImageDao.verify();
    }

    public void testAddAndRemoveNewsImage() throws Exception {
        NewsImage newsImage = new NewsImage();

        // set required fields

        // set expected behavior on dao
        newsImageDao.expects(once()).method("saveNewsImage")
            .with(same(newsImage)).isVoid();
        newsImageManager.saveNewsImage(newsImage);
        newsImageDao.verify();

        // reset expectations
        newsImageDao.reset();

        newsImageDao.expects(once()).method("removeNewsImage").with(eq(new Long(newsImageId)));
        newsImageManager.removeNewsImage(newsImageId);
        newsImageDao.verify();

        // reset expectations
        newsImageDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(NewsImage.class, newsImage.getId());
        newsImageDao.expects(once()).method("removeNewsImage").isVoid();
        newsImageDao.expects(once()).method("getNewsImage").will(throwException(ex));
        newsImageManager.removeNewsImage(newsImageId);
        try {
            newsImageManager.getNewsImage(newsImageId);
            fail("NewsImage with identifier '" + newsImageId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        newsImageDao.verify();
    }
}
