package com.foxconn.cic.webapp.action;

import org.compass.spring.web.mvc.CompassIndexCommand;

public class IndexCommand extends CompassIndexCommand {
	private String beginId;

	private String endId;

	private String resourceId;

	private String syncIndex;

	public String getResourceId() {
		return resourceId;
	}

	public void setResourceId(String resourceId) {
		this.resourceId = resourceId;
	}

	public String getBeginId() {
		return beginId;
	}

	public void setBeginId(String beginId) {
		this.beginId = beginId;
	}

	public String getEndId() {
		return endId;
	}

	public void setEndId(String endId) {
		this.endId = endId;
	}

	public String getSyncIndex() {
		return syncIndex;
	}

	public void setSyncIndex(String syncIndex) {
		this.syncIndex = syncIndex;
	}
}
