package com.foxconn.cic.model;

/**
 * Website相關靜態變量
 * @author ldapeng
 *
 */
public class WebsiteConstants {
	/**
	 * XML標簽，描述Website的相關信息<br/>
	 * 包含下列Tag：
	 * <ul>
	 * 		<li>ID</li>
	 * 		<li>NAME</li>
	 * </ul>
	 * */
	public final static String XMLTAG_WEBSITE="WEBSITE";
	/**XML標簽，描述id*/
	public final static String XMLTAG_WEBSITE_ID="ID";
	/**XML標簽，描述名稱*/
	public final static String XMLTAG_WEBSITE_NAME="NAME";
	
	/**網站狀態：編碼*/
	public final static String STATUS_CODING="Coding";
	/**網站狀態：測試*/
	public final static String STATUS_TESTING="Testing";
	/**網站狀態：發布*/
	public final static String STATUS_RELEASED="Released";
	/**網站狀態：修正*/
	public final static String STATUS_FIXING="Fixing";
	/**網站狀態：取消*/
	public final static String STATUS_CANCELLED="Cancelled";
	
	/**網站復雜度：簡單*/
	public final static Integer COMPLICATION_SIMPLE=1;
	/**網站復雜度：一般*/
	public final static Integer COMPLICATION_NORMAL=2;
	/**網站復雜度：困難*/
	public final static Integer COMPLICATION_COMPLICATED=3;
	
	/**網站類型：新聞*/
	public final static int TYPE_NEWS=1;
	/**網站類型：原物料價格*/
	public final static int TYPE_PRICE=2;
	/**網站類型：匯率*/
	public final static int TYPE_EXCHANGERATE=3;
	/**網站類型：利率 */
	public final static int TYPE_INTERESTRATE=4;
}