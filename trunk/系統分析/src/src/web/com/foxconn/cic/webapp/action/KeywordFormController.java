package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.Keyword;
import com.foxconn.cic.service.KeywordManager;

public class KeywordFormController extends BaseFormController {
    private KeywordManager keywordManager = null;

    public void setKeywordManager(KeywordManager keywordManager) {
        this.keywordManager = keywordManager;
    }
    public KeywordFormController() {
        setCommandName("keyword");
        setCommandClass(Keyword.class);
    }

    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        Keyword keyword = null;

        if (!StringUtils.isEmpty(id)) {
            keyword = keywordManager.getKeyword(id);
        } else {
            keyword = new Keyword();
        }

        return keyword;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        Keyword keyword = (Keyword) command;
        boolean isNew = (keyword.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            keywordManager.removeKeyword(keyword.getId().toString());

            saveMessage(request, getText("keyword.deleted", locale));
        } else {
            keywordManager.saveKeyword(keyword);

            String key = (isNew) ? "keyword.added" : "keyword.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editKeyword.html", "id", keyword.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
}
