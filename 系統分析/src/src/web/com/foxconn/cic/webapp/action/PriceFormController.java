package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.Price;
import com.foxconn.cic.service.PriceManager;

public class PriceFormController extends BaseFormController {
    private PriceManager priceManager = null;

    public void setPriceManager(PriceManager priceManager) {
        this.priceManager = priceManager;
    }
    public PriceFormController() {
        setCommandName("price");
        setCommandClass(Price.class);
    }

    protected Object formBackingObject(HttpServletRequest request)
    throws Exception {
        String id = request.getParameter("id");
        Price price = null;

        if (!StringUtils.isEmpty(id)) {
            price = priceManager.getPrice(id);
        } else {
            price = new Price();
        }

        return price;
    }

    public ModelAndView onSubmit(HttpServletRequest request,
                                 HttpServletResponse response, Object command,
                                 BindException errors)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'onSubmit' method...");
        }

        Price price = (Price) command;
        boolean isNew = (price.getId() == null);
        Locale locale = request.getLocale();

        if (request.getParameter("delete") != null) {
            priceManager.removePrice(price.getId().toString());

            saveMessage(request, getText("price.deleted", locale));
        } else {
            priceManager.savePrice(price);

            String key = (isNew) ? "price.added" : "price.updated";
            saveMessage(request, getText(key, locale));

            if (!isNew) {
                return new ModelAndView("redirect:editPrice.html", "id", price.getId());
            }
        }

        return new ModelAndView(getSuccessView());
    }
}
