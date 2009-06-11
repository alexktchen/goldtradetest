package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.NewsImage;

public class NewsImageDaoTest extends BaseDaoTestCase {
    private Long newsImageId = new Long("1");
    private NewsImageDao dao = null;

    public void setNewsImageDao(NewsImageDao dao) {
        this.dao = dao;
    }

    public void testAddNewsImage() throws Exception {
        NewsImage newsImage = new NewsImage();

        // set required fields

        dao.saveNewsImage(newsImage);

        // verify a primary key was assigned
        assertNotNull(newsImage.getId());

        // verify set fields are same after save
    }

    public void testGetNewsImage() throws Exception {
        NewsImage newsImage = dao.getNewsImage(newsImageId);
        assertNotNull(newsImage);
    }

    public void testGetNewsImages() throws Exception {
        NewsImage newsImage = new NewsImage();

        List results = dao.getNewsImages(newsImage);
        assertTrue(results.size() > 0);
    }

    public void testSaveNewsImage() throws Exception {
        NewsImage newsImage = dao.getNewsImage(newsImageId);

        // update required fields

        dao.saveNewsImage(newsImage);

    }

    public void testRemoveNewsImage() throws Exception {
        Long removeId = new Long("3");
        dao.removeNewsImage(removeId);
        try {
            dao.getNewsImage(removeId);
            fail("newsImage found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());        	
        }
    }
}
