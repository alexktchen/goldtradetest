package com.foxconn.cic.webapp.action;

import java.beans.PropertyEditorSupport;
import java.util.List;
import java.util.Vector;

import com.foxconn.cic.model.Keyword;
import com.foxconn.cic.service.KeywordManager;

class KeywordsEditor extends PropertyEditorSupport {
	private List<Keyword> keywords = null;

	private KeywordManager manager = null;

	KeywordsEditor(KeywordManager manager) {
		this.manager = manager;
	}

	@Override
	public Object getValue() {
		return keywords;
	}

	@Override
	public void setValue(Object value) {
		keywords = (List<Keyword>) value;
	}

	@Override
	public String getAsText() {
		if (keywords == null) {
			return "";
		}
		StringBuffer s = new StringBuffer();
		for (Keyword t : keywords) {
			s.append(t.getName());
			s.append(",");
		}
		return s.toString();
	}

	public void setAsText(String text) {
		keywords = null;
		keywords = new Vector<Keyword>();
		String[] keywordArray = text.split(",");
		List<Keyword> keywordlist = manager.getKeywords(null);
		for (String keyword : keywordArray) {
			if (keyword == null || keyword.trim().length() == 0) {
				continue;
			}
			Keyword key = new Keyword();
			key.setName(keyword);
			int index = keywordlist.indexOf(key);
			if (index != -1) {
				key = keywordlist.get(index);
			}
			keywords.add(key);
		}
	}
}