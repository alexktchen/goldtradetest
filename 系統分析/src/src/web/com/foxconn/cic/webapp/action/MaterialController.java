package com.foxconn.cic.webapp.action;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.beanutils.BeanUtils;

import com.foxconn.cic.Constants;
import com.foxconn.cic.model.Material;
import com.foxconn.cic.service.MaterialManager;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

public class MaterialController implements Controller {
    private final Log log = LogFactory.getLog(MaterialController.class);
    private MaterialManager materialManager = null;

    public void setMaterialManager(MaterialManager materialManager) {
        this.materialManager = materialManager;
    }

    public ModelAndView handleRequest(HttpServletRequest request,
                                      HttpServletResponse response)
    throws Exception {
        if (log.isDebugEnabled()) {
            log.debug("entering 'handleRequest' method...");
        }

        Material material = new Material();
        // populate object with request parameters
        BeanUtils.populate(material, request.getParameterMap());

        List materials = materialManager.getMaterials(material);

        return new ModelAndView("materialList", Constants.MATERIAL_LIST, materials);
    }
}
