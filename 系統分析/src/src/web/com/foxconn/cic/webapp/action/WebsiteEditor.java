package com.foxconn.cic.webapp.action;

import java.beans.PropertyEditorSupport;

import org.apache.commons.lang.StringUtils;

import com.foxconn.cic.model.Website;
import com.foxconn.cic.service.WebsiteManager;

class WebsiteEditor extends PropertyEditorSupport{
	private Website website=null;
	 private WebsiteManager manager = null;
	WebsiteEditor(WebsiteManager manager){
		this.manager=manager;
	}
	@Override
	public String getAsText() {		
		return (website==null)?"":website.getId();
	}
	@Override
	public void setValue(Object value) {
		website=(Website)value;
	}
	@Override
	public Object getValue() {
		return website;
	}

	public void setAsText(String text){
		website=null;
		if (!StringUtils.isEmpty(text)) {
			website = manager.getWebsite(text);
		} 
	}
}