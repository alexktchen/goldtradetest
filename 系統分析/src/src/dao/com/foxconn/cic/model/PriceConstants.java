package com.foxconn.cic.model;

/**
 * News相關靜態變量
 * <PRE>
*&lt;PRICES&gt;+br-
*&lt;PRICE&gt;+br-
*&lt;VALUE&gt;1300&lt;/VALUE&gt; +br-
*&lt;UNIT&gt;元/吨&lt;/UNIT&gt;+br-
*&lt;TYPE&gt;价格&lt;/TYPE&gt;+br-
*&lt;PRODUCINGAREA /&gt;+br-
*&lt;MARKET&gt;鞍山&lt;/MARKET&gt;+br-
*&lt;PUBLISHDATE FORMAT=\&quot;yyyy.MM.dd\&quot;&gt;2008.01.15&lt;/PUBLISHDATE&gt;+br-
*&lt;MATERIEL&gt;+br-
*&lt;ID&gt;8a1998de170ff9ed011710360e3a0002&lt;/ID&gt;+br-
*&lt;NAME&gt;鐵精粉&lt;/NAME&gt;+br-
*&lt;SPEC&gt;65%酸性干基&lt;/SPEC&gt;+br-
*&lt;WEB_SPEC&gt;65%酸性干基&lt;/WEB_SPEC&gt;+br-
*&lt;/MATERIEL&gt;+br-
*&lt;REMARK&gt;到厂含?&lt;/REMARK&gt;+br-
*&lt;WEBSITE&gt;+br-
*&lt;ID&gt;8a1998de170ff9ed0117103ae9580004&lt;/ID&gt;+br-
*&lt;NAME&gt;資源網-鐵精粉行情價格&lt;/NAME&gt;+br-
*&lt;/WEBSITE&gt;+br-
*&lt;/PRICE&gt;+br-
*&lt;PRICE&gt;+br-
*&lt;VALUE&gt;1530&lt;/VALUE&gt;+br-
*&lt;UNIT&gt;元/吨&lt;/UNIT&gt;+br-
*&lt;TYPE&gt;价格&lt;/TYPE&gt;+br-
*&lt;PRODUCINGAREA /&gt;+br-
*&lt;MARKET&gt;唐山&lt;/MARKET&gt;+br-
*&lt;PUBLISHDATE FORMAT=\&quot;yyyy.MM.dd\&quot;&gt;2008.01.15&lt;/PUBLISHDATE&gt;+br-
*&lt;MATERIEL&gt;+br-
*&lt;ID&gt;8a1998de170ff9ed011710356a7a0001&lt;/ID&gt;+br-
*&lt;NAME&gt;鐵精粉&lt;/NAME&gt;+br-
*&lt;SPEC&gt;66%酸性干基&lt;/SPEC&gt;+br-
*&lt;WEB_SPEC&gt;66%酸性干基&lt;/WEB_SPEC&gt;+br-
*&lt;/MATERIEL&gt;+br-
*&lt;REMARK&gt;含?&lt;/REMARK&gt;+br-
*&lt;WEBSITE&gt;+br-
*&lt;ID&gt;8a1998de170ff9ed0117103ae9580004&lt;/ID&gt;+br-
*&lt;NAME&gt;資源網-鐵精粉行情價格&lt;/NAME&gt;+br-
*&lt;/WEBSITE&gt;+br-
*&lt;/PRICE&gt;+br-
*&lt;/PRICES&gt;&quot; 
*</PRE>
 * @author ldapeng
 *
 */
public final class PriceConstants {
	/**XML標簽，描述Price集合，包含一個或多個<PRICE>*/
	public final static String XMLTAG_PRICE_ARRAY="PRICES";
	/**
	 * XML標簽，描述Price的相關信息<br/>
	 * 包含下列Tag：
	 * <ul>
	 * 		<li>ID</li>
	 * 		<li>VALUE</li>
	 * 		<li>UNIT</li>
	 * 		<li>TYPE</li>
	 * 		<li>PRODUCINGAREA</li>
	 * 		<li>PUBLISHDATE</li>
	 * 		<li>MARKET</li>
	 * 		<li>REMARK</li>
	 * </ul>
	 * */
	public final static String XMLTAG_PRICE="PRICE";
	/**XML標簽，描述id*/
	public final static String XMLTAG_PRICE_ID="ID";
	/**XML標簽，描述價格*/
	public final static String XMLTAG_PRICE_VALUE="VALUE";
	/**XML標簽，描述計量單位*/
	public final static String XMLTAG_PRICE_UNIT="UNIT";
	/**XML標簽，描述價格類型*/
	public final static String XMLTAG_PRICE_TYPE="TYPE";
	/**XML標簽，描述產地*/
	public final static String XMLTAG_PRICE_PRODUCING_AREA="PRODUCINGAREA";
	/**XML標簽，描述發布時間*/
	public final static String XMLTAG_PRICE_PUBLISHDATE="PUBLISHDATE";
	/**XML標簽，描述交易市場*/
	public final static String XMLTAG_PRICE_MARKET="MARKET";
	/**XML標簽，描述備注*/
	public final static String XMLTAG_PRICE_REMARK="REMARK";
	/**PUBLISHDATE標簽的屬性，描述發布日期的日期格式*/
	public final static String XMLATTRIBUTE_PRICE_PUBLISHDATE_FORMAT="FORMAT";
	/**PUBLISHDATE標簽的屬性，描述發布日期的locale*/
	public final static String XMLATTRIBUTE_PRICE_PUBLISHDATE_LOCALELANGUAGE="LANGUAGE";
}
