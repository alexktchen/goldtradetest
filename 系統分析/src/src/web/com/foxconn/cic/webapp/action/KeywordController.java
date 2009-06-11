package com.foxconn.cic.webapp.action;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.beanutils.BeanUtils;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.Keyword;
import com.foxconn.cic.service.KeywordManager;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

public class KeywordController implements Controller {
    private final Log log = LogFactory.getLog(KeywordController.class);
    private KeywordManager keywordManager = null;

    public void setKeywordManager(KeywordManager keywordManager) {
        this.keywordManager = keywordManager;
    }

    public ModelAndView handleRequest(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        Keyword keyword = new Keyword();
        // populate object with request parameters
        BeanUtils.populate(keyword, request.getParameterMap());

        List keywords = keywordManager.getKeywords(keyword);

        return new ModelAndView("keywordList", Constants.KEYWORD_LIST, keywords);
    }
}
