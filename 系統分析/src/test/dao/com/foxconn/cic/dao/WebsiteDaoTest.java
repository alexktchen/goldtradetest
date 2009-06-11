package com.foxconn.cic.dao;

import java.util.List;

import org.springframework.dao.InvalidDataAccessApiUsageException;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.model.Website;

public class WebsiteDaoTest extends BaseDaoTestCase {
    private String websiteId = new String("1");
    private WebsiteDao dao = null;

    public void setWebsiteDao(WebsiteDao dao) {
        this.dao = dao;
    }

    public void testAddWebsite() throws Exception {
        Website website = new Website();

        // set required fields

        java.lang.String name = "PcCfUvKnTsGaYxBuJaTkGzOjXoUeEzTpVdSsHfZnZtBiLyVbDxZwUgGlXlXpAuOvZzKgOaKmKfPzVkCsDtJhPuCrZwBmRgCvUaEd";
        website.setName(name);

        dao.saveWebsite(website);

        // verify a primary key was assigned
        assertNotNull(website.getId());

        // verify set fields are same after save
        assertEquals(name, website.getName());
    }

    public void testGetWebsite() throws Exception {
        Website website = dao.getWebsite(websiteId);
        assertNotNull(website);
    }

    public void testGetWebsites() throws Exception {
        Website website = new Website();

        List results = dao.getWebsites(website);
        assertTrue(results.size() > 0);
    }

    public void testSaveWebsite() throws Exception {
        Website website = dao.getWebsite(websiteId);

        // update required fields
        java.lang.String name = "KxFpLtKnCiIwRuHdRxMqPgWqVzPbRwYuGuQnUrIpOkHiUrThEnXpIeFyGgPjMdUxHnRdMmVrEfGpSkOmTjOzYbBmBhRhMvMcAwVf";
        website.setName(name);

        dao.saveWebsite(website);

        assertEquals(name, website.getName());
    }

    public void testRemoveWebsite() throws Exception {
        String removeId = new String("3");
        dao.removeWebsite(removeId);
        try {
            dao.getWebsite(removeId);
            fail("website found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        } catch (InvalidDataAccessApiUsageException e) { // Spring 2.0 throws this one
            assertNotNull(e.getMessage());
        }
    }
}
