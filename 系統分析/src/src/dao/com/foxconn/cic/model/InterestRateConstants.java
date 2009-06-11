package com.foxconn.cic.model;

/**
 * InterestRate相關靜態變量
 * <PRE>
*&lt;INTEREST_RATES&gt;<br/>
*	&lt;INTEREST_RATE&gt;<br/>
*		&lt;NAME&gt;外幣存款利率&lt;/NAME&gt; <br/>
*  		&lt;CURRENCY&gt;USD&lt;/CURRENCY&gt; <br/>
*  		&lt;TYPE&gt;定期存款一年&lt;/TYPE&gt; <br/>
*  		&lt;TIME_PERIOD&gt;1y&lt;/TIME_PERIOD&gt; <br/>
*  		&lt;RATE&gt;5.00&lt;/RATE&gt; <br/>
*  		&lt;PUBLISHER&gt;萬泰商業銀行&lt;/PUBLISHER&gt; <br/>
*  		&lt;PUBLISHDATE FORMAT=\&quot;yyyy/MM/dd\&quot;&gt;2007/07/10&lt;/PUBLISHDATE&gt;<br/>
* 		&lt;WEBSITE&gt;<br/>
*  			&lt;ID&gt;8a199ae813715f2601137523c72d0002&lt;/ID&gt; <br/>
*  			&lt;NAME&gt;萬泰商業銀行-外幣存款利率&lt;/NAME&gt; <br/>
*  		&lt;/WEBSITE&gt;<br/>
*  	&lt;/INTEREST_RATE&gt;<br/>
* 	&lt;INTEREST_RATE&gt;<br/>
*  		&lt;NAME&gt;外幣存款利率&lt;/NAME&gt; <br/>
*  		&lt;CURRENCY&gt;THB&lt;/CURRENCY&gt; <br/>
*  		&lt;TYPE&gt;定期存款一年&lt;/TYPE&gt; <br/>
*  		&lt;TIME_PERIOD&gt;1y&lt;/TIME_PERIOD&gt; <br/>
*  		&lt;RATE&gt;0.50&lt;/RATE&gt; <br/>
*  		&lt;PUBLISHER&gt;萬泰商業銀行&lt;/PUBLISHER&gt; <br/>
*  		&lt;PUBLISHDATE FORMAT=\&quot;yyyy/MM/dd\&quot;&gt;2007/07/10&lt;/PUBLISHDATE&gt; <br/>
* 		&lt;WEBSITE&gt;<br/>
*  			&lt;ID&gt;8a199ae813715f2601137523c72d0002&lt;/ID&gt; <br/>
*  			&lt;NAME&gt;萬泰商業銀行-外幣存款利率&lt;/NAME&gt; <br/>
*  		&lt;/WEBSITE&gt;<br/>
*  	&lt;/INTEREST_RATE&gt;<br/>
* 	&lt;INTEREST_RATE&gt;<br/>
*  		&lt;NAME&gt;外幣存款利率&lt;/NAME&gt; <br/>
*  		&lt;CURRENCY&gt;SGD&lt;/CURRENCY&gt; <br/>
*  		&lt;TYPE&gt;定期存款一年&lt;/TYPE&gt; <br/>
*  		&lt;TIME_PERIOD&gt;1y&lt;/TIME_PERIOD&gt; <br/>
*  		&lt;RATE&gt;0.50&lt;/RATE&gt; <br/>
*  		&lt;PUBLISHER&gt;萬泰商業銀行&lt;/PUBLISHER&gt; <br/>
*  		&lt;PUBLISHDATE FORMAT=\&quot;yyyy/MM/dd\&quot;&gt;2007/07/10&lt;/PUBLISHDATE&gt; <br/>
* 		&lt;WEBSITE&gt;<br/>
*  			&lt;ID&gt;8a199ae813715f2601137523c72d0002&lt;/ID&gt; <br/>
*  		&lt;NAME&gt;萬泰商業銀行-外幣存款利率&lt;/NAME&gt; <br/>
*  		&lt;/WEBSITE&gt;<br/>
*  	&lt;/INTEREST_RATE&gt;<br/>
*&lt;/INTEREST_RATES&gt;<br/>
*</PRE>
 * @author ldapeng
 *
 */
public final class InterestRateConstants {
	/**
	 * XML標簽，描述ExchangeRate集合，包含一個或多個<INTEREST_RATE>
	 * */
	public final static String XMLTAG_INTERESTRATES = "INTEREST_RATES";
	/**
	 * XML標簽，描述InterestRate的相關信息<br/>
	 * 包含下列Tag：
	 * <ul>
	 * 		<li>ID</li>
	 * 		<li>NAME</li>
	 * 		<li>CURRENCY</li>
	 * 		<li>TYPE</li>
	 * 		<li>TIME_PERIOD</li>
	 * 		<li>RATE</li>
	 * 		<li>PUBLISHER</li>
	 * 		<li>PUBLISHDATE</li>
	 * </ul>
	 * */
	public final static String XMLTAG_INTERESTRATE = "INTEREST_RATE";
	/**XML標簽，描述id*/
	public final static String XMLTAG_INTERESTRATE_ID = "ID";
	/**XML標簽，描述名稱*/
	public final static String XMLTAG_INTERESTRATE_NAME = "NAME";
	/**XML標簽，描述貨幣名稱*/
	public final static String XMLTAG_INTERESTRATE_CURRENCY = "CURRENCY";
	/**XML標簽，描述存款類型*/
	public final static String XMLTAG_INTERESTRATE_TYPE = "TYPE";
	/**XML標簽，描述存款時間段*/
	public final static String XMLTAG_INTERESTRATE_TIMEPERIOD = "TIME_PERIOD";
	/**XML標簽，描述存款利率*/
	public final static String XMLTAG_INTERESTRATE_RATE = "RATE";
	/**XML標簽，描述發布者*/
	public final static String XMLTAG_INTERESTRATE_PUBLISHER = "PUBLISHER";
	/**XML標簽，描述發布時間*/
	public final static String XMLTAG_INTERESTRATE_PUBLISHDATE = "PUBLISHDATE";
	/**PUBLISHDATE標簽的屬性，描述發布日期的日期格式*/
	public final static String XMLATTRIBUTE_INTERESTRATE_PUBLISHDATE_FORMAT = "FORMAT";
	/**PUBLISHDATE標簽的屬性，描述發布日期的locale*/
	public final static String XMLATTRIBUTE_INTERESTRATE_PUBLISHDATE_LOCALELANGUAGE = "LANGUAGE";
}
