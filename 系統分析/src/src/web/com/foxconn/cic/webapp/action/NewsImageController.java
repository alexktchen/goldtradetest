package com.foxconn.cic.webapp.action;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.beanutils.BeanUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.View;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.NewsImage;
import com.foxconn.cic.service.NewsImageManager;

public class NewsImageController  extends MultiActionController  {
    private final Log log = LogFactory.getLog(NewsImageController.class);
    private NewsImageManager newsImageManager = null;

    private View imageView;
    public void setImageView(View imageView) {
		this.imageView = imageView;
	}

	public void setNewsImageManager(NewsImageManager newsImageManager) {
        this.newsImageManager = newsImageManager;
    }

    public ModelAndView list(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        NewsImage newsImage = new NewsImage();
        // populate object with request parameters
        BeanUtils.populate(newsImage, request.getParameterMap());

        List newsImages = newsImageManager.getNewsImages(newsImage);

        return new ModelAndView("newsImageList", Constants.NEWSIMAGE_LIST, newsImages);
    }
    public ModelAndView browse(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		if (log.isDebugEnabled()) {
			log.debug("entering 'browse' method...");
		}
		String id=request.getParameter("id");
		Map map=new HashMap<String, Object>();
		map.put("newsImage", newsImageManager.getNewsImage(id));
		map.put("imagePath", newsImageManager.getFilePath());
		return new ModelAndView(imageView,map);
	}
}
