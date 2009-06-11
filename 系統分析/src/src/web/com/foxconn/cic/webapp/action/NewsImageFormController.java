package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.NewsImage;
import com.foxconn.cic.service.NewsImageManager;

public class NewsImageFormController extends BaseFormController {
    private NewsImageManager newsImageManager = null;

    public void setNewsImageManager(NewsImageManager newsImageManager) {
        this.newsImageManager = newsImageManager;
    }
    public NewsImageFormController() {
        setCommandName("newsImage");
        setCommandClass(NewsImage.class);
    }

    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        NewsImage newsImage = null;

        if (!StringUtils.isEmpty(id)) {
            newsImage = newsImageManager.getNewsImage(id);
        } else {
            newsImage = new NewsImage();
        }

        return newsImage;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        NewsImage newsImage = (NewsImage) command;
        boolean isNew = (newsImage.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            newsImageManager.removeNewsImage(newsImage.getId().toString());

            saveMessage(request, getText("newsImage.deleted", locale));
        } else {
            newsImageManager.saveNewsImage(newsImage);

            String key = (isNew) ? "newsImage.added" : "newsImage.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editNewsImage.html", "id", newsImage.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
}
