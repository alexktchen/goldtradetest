package com.foxconn.cic.service.impl;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.compass.core.Compass;
import org.compass.core.CompassHits;
import org.compass.core.CompassQuery;
import org.compass.core.CompassSession;
import org.compass.core.CompassQuery.SortDirection;
import org.compass.core.CompassQuery.SortPropertyType;
import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchHelper;
import org.compass.core.support.search.CompassSearchResults;
import org.compass.core.util.StringUtils;

public class AdvancedSearchHelper extends CompassSearchHelper {

	private final Log log = LogFactory.getLog(AdvancedSearchHelper.class);
	
	private String[] aliases ;
	private String[] highlightFields;
	
	
	public String[] getAliases() {
		return aliases.clone();
	}
	public void setAliases(String[] aliases) {
		this.aliases = aliases.clone();
	}
	public String[] getHighlightFields() {
		return highlightFields.clone();
	}
	public void setHighlightFields(String[] highlightFields) {
		this.highlightFields = highlightFields.clone();
	}
	public AdvancedSearchHelper(Compass compass) {
		super(compass, null);
	}
	public AdvancedSearchHelper(Compass compass, Integer pageSize) {
		super(compass, pageSize);
	}
	protected CompassSearchResults performSearch(CompassSearchCommand searchCommand, CompassSession session) {

		return super.performSearch(searchCommand,session);
	}
	protected CompassQuery buildQuery(CompassSearchCommand searchCommand, CompassSession session, String analyzer) {
		 if (searchCommand.getCompassQuery() != null) {
	            return searchCommand.getCompassQuery();
	        }
		 if(StringUtils.hasText(analyzer)){
			 return session.queryBuilder().queryString(searchCommand.getQuery().trim()).setAnalyzer(analyzer) .toQuery();
		 }
		 return session.queryBuilder().queryString(searchCommand.getQuery().trim()).toQuery();
	}
	@Override
	protected CompassQuery buildQuery(CompassSearchCommand searchCommand, CompassSession session) {
		String analyzer="search";
		if(searchCommand instanceof AdvancedSearchCommand){
			AdvancedSearchCommand command=(AdvancedSearchCommand)searchCommand;
			if(command.getAnalyzer()!=null && !command.getAnalyzer().trim().equals("")){
				analyzer=command.getAnalyzer();
			}
		}
		log.debug("Search analyzer:"+analyzer);
		CompassQuery query=buildQuery(searchCommand, session, analyzer);		
		query.addSort("publishdate",SortPropertyType.INT, SortDirection.REVERSE);
		query.setAliases(getAliases());
//		if(searchCommand instanceof NewsSearchCommand){
//			NewsSearchCommand command=(NewsSearchCommand)searchCommand;
//			query.addSort(command.getSortProperty(),command.getSortPropertyType(), command.getSortDircation());
//		}
		
		return query;
	}

	@Override
	protected void doProcessBeforeDetach(CompassSearchCommand searchCommand, CompassSession session, CompassHits hits, int from, int size) {
		int to =from + size;
		if(size == hits.getLength()){
			to=size;
		}
		if(highlightFields==null){
			return;
		}
		
		for (int i = from; i < to; i++) {
			for (String highlightField : highlightFields) {
                hits.highlighter(i).fragment(highlightField);
            }
		}

	}
}
