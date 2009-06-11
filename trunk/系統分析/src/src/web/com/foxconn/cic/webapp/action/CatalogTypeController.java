package com.foxconn.cic.webapp.action;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.beanutils.BeanUtils;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.CatalogType;
import com.foxconn.cic.service.CatalogTypeManager;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

public class CatalogTypeController implements Controller {
    private final Log log = LogFactory.getLog(CatalogTypeController.class);
    private CatalogTypeManager catalogTypeManager = null;

    public void setCatalogTypeManager(CatalogTypeManager catalogTypeManager) {
        this.catalogTypeManager = catalogTypeManager;
    }

    public ModelAndView handleRequest(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        CatalogType catalogType = new CatalogType();
        // populate object with request parameters
        BeanUtils.populate(catalogType, request.getParameterMap());

        List catalogTypes = catalogTypeManager.getCatalogTypes(catalogType);

        return new ModelAndView("catalogTypeList", Constants.CATALOGTYPE_LIST, catalogTypes);
    }
}
