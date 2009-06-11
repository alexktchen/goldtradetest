package com.foxconn.cic.webapp.action;

import java.beans.PropertyEditorSupport;
import java.util.List;
import java.util.Vector;

import com.foxconn.cic.model.Catalog;
import com.foxconn.cic.service.CatalogManager;

class CatalogsEditor extends PropertyEditorSupport {
	private List<Catalog> catalogs = null;

	private CatalogManager manager = null;

	CatalogsEditor(CatalogManager manager) {
		this.manager = manager;
	}

	@Override
	public Object getValue() {
		return catalogs;
	}

	@Override
	public void setValue(Object value) {
		catalogs = (List<Catalog>) value;
	}

	@Override
	public String getAsText() {
		if (catalogs == null) {
			return "";
		}
		StringBuffer s = new StringBuffer();
		for (Catalog t : catalogs) {
			s.append(t.getId());
			s.append(",");
		}
		return s.toString();
	}

	public void setAsText(String text) {
		catalogs = null;
		catalogs = new Vector<Catalog>();
		String[] catalogArray = text.split(",");
		List<Catalog> cataloglist = manager.getCatalogs(null);
		for (String c : catalogArray) {
			if (c == null || c.trim().length() == 0) {
				continue;
			}
			Catalog catalog = new Catalog();
			catalog.setId(Long.parseLong(c));
			int index = cataloglist.indexOf(catalog);
			if (index != -1) {
				catalog = cataloglist.get(index);
			}
			catalogs.add(catalog);
		}
	}
}