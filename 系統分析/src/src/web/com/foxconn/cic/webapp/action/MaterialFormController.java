package com.foxconn.cic.webapp.action;

import java.util.Locale;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.validation.BindException;
import org.springframework.web.servlet.ModelAndView;

import com.foxconn.cic.model.Material;
import com.foxconn.cic.service.MaterialManager;

public class MaterialFormController extends BaseFormController {
	private MaterialManager materialManager = null;

	public void setMaterialManager(MaterialManager materialManager) {
		this.materialManager = materialManager;
	}

	public MaterialFormController() {
		setCommandName("material");
		setCommandClass(Material.class);
	}

	protected Object formBackingObject(HttpServletRequest request)
			throws Exception {
		String id = request.getParameter("id");
		Material material = null;

		if (!StringUtils.isEmpty(id)) {
			material = materialManager.getMaterial(id);
		} else {
			material = new Material();
		}

		return material;
	}

	public ModelAndView onSubmit(HttpServletRequest request,
			HttpServletResponse response, Object command, BindException errors)
			throws Exception {
		if (log.isDebugEnabled()) {
			log.debug("entering 'onSubmit' method...");
		}

		Material material = (Material) command;
		if (material.getId() != null && material.getId().trim().equals(""))
			material.setId(null);
		boolean isNew = (material.getId() == null);
		Locale locale = request.getLocale();

		if (request.getParameter("delete") != null) {
			materialManager.removeMaterial(material.getId());

			saveMessage(request, getText("material.deleted", locale));
		} else {
			materialManager.saveMaterial(material);

			String key = (isNew) ? "material.added" : "material.updated";
			saveMessage(request, getText(key, locale));

			if (!isNew) {
				return new ModelAndView("redirect:editMaterial.html", "id",
						material.getId());
			}
		}

		return new ModelAndView(getSuccessView());
	}
}
