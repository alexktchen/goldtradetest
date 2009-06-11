
package com.foxconn.cic.service;

import java.util.ArrayList;
import java.util.List;

import org.jmock.Mock;
import org.springframework.orm.ObjectRetrievalFailureException;

import com.foxconn.cic.dao.WebsiteDao;
import com.foxconn.cic.model.Website;
import com.foxconn.cic.service.impl.WebsiteManagerImpl;

public class WebsiteManagerTest extends BaseManagerTestCase {
    private final String websiteId = "1";
    private WebsiteManagerImpl websiteManager = new WebsiteManagerImpl();
    private Mock websiteDao = null;

    protected void setUp() throws Exception {
        super.setUp();
        websiteDao = new Mock(WebsiteDao.class);
        websiteManager.setWebsiteDao((WebsiteDao) websiteDao.proxy());
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        websiteManager = null;
    }

    public void testGetWebsites() throws Exception {
        List results = new ArrayList();
        Website website = new Website();
        results.add(website);

        // set expected behavior on dao
        websiteDao.expects(once()).method("getWebsites")
            .will(returnValue(results));

        List websites = websiteManager.getWebsites(null);
        assertTrue(websites.size() == 1);
        websiteDao.verify();
    }

    public void testGetWebsite() throws Exception {
        // set expected behavior on dao
        websiteDao.expects(once()).method("getWebsite")
            .will(returnValue(new Website()));
        Website website = websiteManager.getWebsite(websiteId);
        assertTrue(website != null);
        websiteDao.verify();
    }

    public void testSaveWebsite() throws Exception {
        Website website = new Website();

        // set expected behavior on dao
        websiteDao.expects(once()).method("saveWebsite")
            .with(same(website)).isVoid();

        websiteManager.saveWebsite(website);
        websiteDao.verify();
    }

    public void testAddAndRemoveWebsite() throws Exception {
        Website website = new Website();

        // set required fields
        website.setName("PqSfCbXgGvEvCyAjMzBrJzBhOtKlYxAjQtAwMlDmXdRrZxGmPzOmGwSrOgPrLiNkApZzKlDxOtWtCsUuDjYlYhVnAdZdCiMuVwRn");

        // set expected behavior on dao
        websiteDao.expects(once()).method("saveWebsite")
            .with(same(website)).isVoid();
        websiteManager.saveWebsite(website);
        websiteDao.verify();

        // reset expectations
        websiteDao.reset();

        websiteDao.expects(once()).method("removeWebsite").with(eq(new Long(websiteId)));
        websiteManager.removeWebsite(websiteId);
        websiteDao.verify();

        // reset expectations
        websiteDao.reset();
        // remove
        Exception ex = new ObjectRetrievalFailureException(Website.class, website.getId());
        websiteDao.expects(once()).method("removeWebsite").isVoid();
        websiteDao.expects(once()).method("getWebsite").will(throwException(ex));
        websiteManager.removeWebsite(websiteId);
        try {
            websiteManager.getWebsite(websiteId);
            fail("Website with identifier '" + websiteId + "' found in database");
        } catch (ObjectRetrievalFailureException e) {
            assertNotNull(e.getMessage());
        }
        websiteDao.verify();
    }
}
