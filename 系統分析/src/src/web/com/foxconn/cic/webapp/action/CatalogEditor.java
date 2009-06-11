package com.foxconn.cic.webapp.action;

import java.beans.PropertyEditorSupport;

import org.apache.commons.lang.StringUtils;

import com.foxconn.cic.model.Catalog;
import com.foxconn.cic.service.CatalogManager;

class CatalogEditor extends PropertyEditorSupport{
	private Catalog catalog=null;
	 private CatalogManager manager = null;
	CatalogEditor(CatalogManager manager){
		this.manager=manager;
	}
	@Override
	public String getAsText() {
		
		return super.getAsText();
	}
	@Override
	public void setValue(Object value) {
		catalog=(Catalog)value;
	}
	@Override
	public Object getValue() {
		return catalog;
	}

	public void setAsText(String text){
		catalog=null;
		if (!StringUtils.isEmpty(text)) {
			catalog = manager.getCatalog(text);
		} 
	}
}