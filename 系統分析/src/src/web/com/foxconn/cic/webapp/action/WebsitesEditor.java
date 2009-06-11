package com.foxconn.cic.webapp.action;

import java.beans.PropertyEditorSupport;
import java.util.HashSet;
import java.util.Set;

import com.foxconn.cic.model.Website;
import com.foxconn.cic.service.WebsiteManager;

class WebsitesEditor extends PropertyEditorSupport {
	private Set<Website> websites = null;

	private WebsiteManager manager = null;

	WebsitesEditor(WebsiteManager manager) {
		this.manager = manager;
	}

	@Override
	public Object getValue() {
		return websites;
	}

	@Override
	public void setValue(Object value) {
		if (value instanceof String[]) {
			websites = new HashSet<Website>();
			String[] websiteArray = (String[]) value;
			for (String c : websiteArray) {
				if (c == null || c.trim().length() == 0) {
					continue;
				}
				Website website =  manager.getWebsite(c);
				if (website != null) {
					websites.add(website);
				}
			}
			return;
		}
		websites = (Set<Website>) value;
	}

	@Override
	public String getAsText() {
		if (websites == null) {
			return "";
		}
		StringBuffer s = new StringBuffer();
		for (Website t : websites) {
			s.append(t.getId());
			s.append(",");
		}
		return s.toString();
	}

	public void setAsText(String text) {
		websites = null;
		websites = new HashSet<Website>();
		String[] websiteArray = text.split(",");
		for (String c : websiteArray) {
			if (c == null || c.trim().length() == 0) {
				continue;
			}
			Website website =  manager.getWebsite(c);
			if (website != null) {
				websites.add(website);
			}
		}
	}
}