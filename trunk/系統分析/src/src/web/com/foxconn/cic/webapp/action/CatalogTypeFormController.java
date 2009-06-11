package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.CatalogType;
import com.foxconn.cic.service.CatalogTypeManager;

public class CatalogTypeFormController extends BaseFormController {
    private CatalogTypeManager catalogTypeManager = null;

    public void setCatalogTypeManager(CatalogTypeManager catalogTypeManager) {
        this.catalogTypeManager = catalogTypeManager;
    }
    public CatalogTypeFormController() {
        setCommandName("catalogType");
        setCommandClass(CatalogType.class);
    }

    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        CatalogType catalogType = null;

        if (!StringUtils.isEmpty(id)) {
            catalogType = catalogTypeManager.getCatalogType(id);
        } else {
            catalogType = new CatalogType();
        }

        return catalogType;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        CatalogType catalogType = (CatalogType) command;
        boolean isNew = (catalogType.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            catalogTypeManager.removeCatalogType(catalogType.getId().toString());

            saveMessage(request, getText("catalogType.deleted", locale));
        } else {
            catalogTypeManager.saveCatalogType(catalogType);

            String key = (isNew) ? "catalogType.added" : "catalogType.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editCatalogType.html", "id", catalogType.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
}
