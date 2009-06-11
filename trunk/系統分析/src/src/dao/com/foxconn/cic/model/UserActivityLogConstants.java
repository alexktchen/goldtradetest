package com.foxconn.cic.model;

/**
 * 用戶行為記錄常量
 * @author ldapeng
 *
 */
public class UserActivityLogConstants {
	/**登錄*/
	static public final String ACTIVITY_LOGIN = "Login";
	/**登出*/
	static public final String ACTIVITY_LOGOUT = "Logout";
	
	/**新聞搜索*/
	static public final String ACTIVITY_NEWS_SEARCH = "News.Search";
	/**新聞瀏覽*/
	static public final String ACTIVITY_NEWS_BROWSE = "News.Browse";
	/**RSS訂閱*/
	static public final String ACTIVITY_NEWS_RSS = "News.Rss";
	
	/**原物料價格搜索*/
	static public final String ACTIVITY_PRICE_SEARCH = "Price.Search";
	/**原物料價格瀏覽*/
	static public final String ACTIVITY_PRICE_BROWSE = "Price.Browse";
	
	/**匯率搜索*/
	static public final String ACTIVITY_EXCHANGERATE_SEARCH = "ExchangeRate.Search";
	/**匯率瀏覽*/
	static public final String ACTIVITY_EXCHANGERATE_BROWSE = "ExchangeRate.Browse";
	
	/**利率搜索*/
	static public final String ACTIVITY_INTERESTRATE_SEARCH = "InterestRate.Search";
	/**利率瀏覽*/
	static public final String ACTIVITY_INTERESTRATE_BROWSE = "InterestRate.Browse";
	
	/**通過web訪問*/
	static public final String TYPE_WEB = "Web";
	/**通過webservice訪問*/
	static public final String TYPE_WEBSERVCIE = "WebService";
}
