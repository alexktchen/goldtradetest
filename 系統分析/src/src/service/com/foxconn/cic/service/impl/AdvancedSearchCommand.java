package com.foxconn.cic.service.impl;

import org.compass.core.CompassQuery;
import org.compass.core.support.search.CompassSearchCommand;

public class AdvancedSearchCommand extends CompassSearchCommand {
	private String analyzer="search";
	private String sortProperty;
	private CompassQuery.SortPropertyType sortPropertyType;
	private CompassQuery.SortDirection sortDircation;

	public String getAnalyzer() {
		return analyzer;
	}

	public void setAnalyzer(String analyzer) {
		this.analyzer = analyzer;
	}

	public String getSortProperty() {
		return sortProperty;
	}

	public void setSortProperty(String sortProperty) {
		this.sortProperty = sortProperty;
	}

	public CompassQuery.SortPropertyType getSortPropertyType() {
		return sortPropertyType;
	}

	public void setSortPropertyType(
			CompassQuery.SortPropertyType sortPropertyType) {
		this.sortPropertyType = sortPropertyType;
	}

	public CompassQuery.SortDirection getSortDircation() {
		return sortDircation;
	}

	public void setSortDircation(CompassQuery.SortDirection sortDircation) {
		this.sortDircation = sortDircation;
	}

}
