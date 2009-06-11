package com.foxconn.cic.webapp.action;

import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.bind.ServletRequestDataBinder;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.Catalog;
import com.foxconn.cic.model.CatalogType;
import com.foxconn.cic.service.CatalogManager;
import com.foxconn.cic.service.CatalogTypeManager;
import com.foxconn.cic.service.KeywordManager;

public class CatalogFormController extends BaseFormController {
    private CatalogManager catalogManager = null;
    private KeywordManager keywordManager=null;
    private CatalogTypeManager catalogTypeManager=null;

    public void setCatalogTypeManager(CatalogTypeManager catalogTypeManager) {
		this.catalogTypeManager = catalogTypeManager;
	}
	public void setCatalogManager(CatalogManager catalogManager) {
        this.catalogManager = catalogManager;
    }
    public CatalogFormController() {
        setCommandName("catalog");
        setCommandClass(Catalog.class);
    }

    @Override
	protected void initBinder(HttpServletRequest request, ServletRequestDataBinder binder) {
		super.initBinder(request, binder);
		binder.registerCustomEditor(CatalogType.class, "type",
                new CatalogTypeEditor(catalogTypeManager));
		binder.registerCustomEditor(Catalog.class, "parent",
                new CatalogEditor(catalogManager));
		binder.registerCustomEditor(List.class, "children",
                new CatalogsEditor(catalogManager));
		binder.registerCustomEditor(List.class, "keywords",
                new KeywordsEditor(keywordManager));
	}

	@Override
	protected Map referenceData(HttpServletRequest arg0) throws Exception {
    	Map map = new HashMap();

		map.put(Constants.CATALOG_LIST, catalogManager.getCatalogs(null));
		map.put(Constants.KEYWORD_LIST, keywordManager.getKeywords(null));
		map.put(Constants.CATALOGTYPE_LIST, catalogTypeManager.getCatalogTypes(null));
		return map;
	}

    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        Catalog catalog = null;

        if (!StringUtils.isEmpty(id)) {
            catalog = catalogManager.getCatalog(id);
        } else {
            catalog = new Catalog();
        }

        return catalog;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        Catalog catalog = (Catalog) command;
        boolean isNew = (catalog.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            catalogManager.removeCatalog(catalog.getId().toString());

            saveMessage(request, getText("catalog.deleted", locale));
        } else {
        	if(isNew && catalog.getParent()!=null){
        		catalog.getParent().getChildren().add(catalog);
        	}
            catalogManager.saveCatalog(catalog);

            String key = (isNew) ? "catalog.added" : "catalog.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editCatalog.html", "id", catalog.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
	public void setKeywordManager(KeywordManager keywordManager) {
		this.keywordManager = keywordManager;
	}
}
