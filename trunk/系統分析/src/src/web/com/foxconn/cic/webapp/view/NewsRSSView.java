package com.foxconn.cic.webapp.view;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.compass.core.CompassHit;
import org.springframework.web.servlet.view.AbstractView;

import com.foxconn.cic.model.News;
import com.foxconn.cic.webapp.util.RequestUtil;
import com.sun.syndication.feed.synd.SyndContent;
import com.sun.syndication.feed.synd.SyndContentImpl;
import com.sun.syndication.feed.synd.SyndEntry;
import com.sun.syndication.feed.synd.SyndEntryImpl;
import com.sun.syndication.feed.synd.SyndFeed;
import com.sun.syndication.feed.synd.SyndFeedImpl;
import com.sun.syndication.io.FeedException;
import com.sun.syndication.io.SyndFeedOutput;

public class NewsRSSView extends AbstractView {

    private static final String FEED_TYPE = "type";
    private static final String MIME_TYPE = "application/xml; charset=UTF-8";
    private static final String COULD_NOT_GENERATE_FEED_ERROR = "Could not generate feed";

    private final Log log = LogFactory.getLog(NewsRSSView.class);

    private String defaultFeedType="atom_0.3";

    private String appUrl;

	@Override
	protected void renderMergedOutputModel(Map model, HttpServletRequest request,
			HttpServletResponse response) throws Exception {

		appUrl=RequestUtil.getAppURL(request);
		CompassHit[] newsList=(CompassHit[])model.get("newsList");

        try {
            SyndFeed feed = getFeed(newsList);
            feed.setTitle("FoxconnCIC " +  "Feed (powered by iTEC)");
            feed.setDescription(model.get("query").toString());
            feed.setLink(appUrl+"/search.html?query="+ java.net.URLEncoder.encode(model.get("query").toString(),"UTF-8"));

            String feedType = request.getParameter(FEED_TYPE);
            feedType = (feedType!=null) ? feedType : defaultFeedType;
            feed.setFeedType(feedType);


            response.setContentType(MIME_TYPE);
            SyndFeedOutput output = new SyndFeedOutput();
            output.output(feed,response.getWriter());
        }
        catch (FeedException ex) {
            String msg = COULD_NOT_GENERATE_FEED_ERROR;
            log.error(msg, ex);
            response.sendError(HttpServletResponse.SC_INTERNAL_SERVER_ERROR,msg);
        }
	}

	private SyndFeed getFeed(CompassHit[] newsList) {

        SyndFeed feed = new SyndFeedImpl();



        List entries = new ArrayList();
        SyndEntry entry;
        SyndContent description;
        for (CompassHit hit : newsList) {
        	News news = (News) hit.getData();
			entry = new SyndEntryImpl();
			entry.setTitle(news.getTitle());
			String resultLink = appUrl + "/newss.html?method=browse&id="
					+ news.getId();
			entry.setLink(resultLink);
			entry.setPublishedDate(news.getPublishDate());

			description = new SyndContentImpl();
			description.setType("text/html");
			description.setValue(news.getSummary());
			entry.setDescription(description);
			entries.add(entry);
		}

         feed.setEntries(entries);

        return feed;
	}

}
