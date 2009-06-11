package com.foxconn.cic.webapp.action;

import java.beans.PropertyEditorSupport;

import org.apache.commons.lang.StringUtils;

import com.foxconn.cic.model.CatalogType;
import com.foxconn.cic.service.CatalogTypeManager;

class CatalogTypeEditor extends PropertyEditorSupport{
	private CatalogType type=null;
	 private CatalogTypeManager manager = null;
	CatalogTypeEditor(CatalogTypeManager manager){
		this.manager=manager;
	}
	@Override
	public String getAsText() {
		
		return super.getAsText();
	}
	@Override
	public void setValue(Object value) {
		type=(CatalogType)value;
	}
	@Override
	public Object getValue() {
		return type;
	}

	public void setAsText(String text){
		type=null;
		if (!StringUtils.isEmpty(text)) {
			type = manager.getCatalogType(text);
		} 
	}
}