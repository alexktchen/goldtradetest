package com.foxconn.cic.model;

/**
 * ExchangeRate相關靜態變量
 * <pre>
*&lt;EXCHANGE_RATES&gt;<br/>
*	&lt;EXCHANGE_RATE&gt;<br/>
*  	&lt;UNIT_CURRENCY&gt;GBP&lt;/UNIT_CURRENCY&gt; <br/>
*  	&lt;AMOUNT&gt;100&lt;/AMOUNT&gt; <br/>
*		&lt;PRICE_CURRENCY&gt;CNY&lt;/PRICE_CURRENCY&gt; <br/>
*		&lt;QUOTATION_TYPE&gt;1&lt;/QUOTATION_TYPE&gt; <br/>
*		&lt;PRICE_TYPE&gt;中行折算价&lt;/PRICE_TYPE&gt; <br/>
*		&lt;PRICE&gt;1530.45&lt;/PRICE&gt; <br/>
*		&lt;PUBLISHER&gt;中國銀行&lt;/PUBLISHER&gt; <br/>
*		&lt;PUBLISHDATE FORMAT=\&quot;yyyy/MM/dd\&quot;&gt;2007/07/09&lt;/PUBLISHDATE&gt; <br/>
*		&lt;WEBSITE&gt;<br/>
*			&lt;ID&gt;8a199ae813715f2601137523c72d0002&lt;/ID&gt; <br/>
*			&lt;NAME&gt;中國銀行-外匯牌價&lt;/NAME&gt; <br/>
*		&lt;/WEBSITE&gt;<br/>
*	&lt;/EXCHANGE_RATE&gt;<br/>
*	&lt;EXCHANGE_RATE&gt;<br/>
*		&lt;UNIT_CURRENCY&gt;GBP&lt;/UNIT_CURRENCY&gt; <br/>
*		&lt;AMOUNT&gt;100&lt;/AMOUNT&gt; <br/>
*		&lt;PRICE_CURRENCY&gt;CNY&lt;/PRICE_CURRENCY&gt; <br/>
*		&lt;QUOTATION_TYPE&gt;1&lt;/QUOTATION_TYPE&gt; <br/>
*		&lt;PRICE_TYPE&gt;基准价&lt;/PRICE_TYPE&gt; <br/>
*		&lt;PRICE&gt;1530.45&lt;/PRICE&gt; <br/>
*		&lt;PUBLISHER&gt;中國銀行&lt;/PUBLISHER&gt; <br/>
*		&lt;PUBLISHDATE FORMAT=\&quot;yyyy/MM/dd\&quot;&gt;2007/07/09&lt;/PUBLISHDATE&gt; <br/>
*		&lt;WEBSITE&gt;<br/>
*			&lt;ID&gt;8a199ae813715f2601137523c72d0002&lt;/ID&gt; <br/>
*			&lt;NAME&gt;中國銀行-外匯牌價&lt;/NAME&gt; <br/>
*		&lt;/WEBSITE&gt;<br/>
*	&lt;/EXCHANGE_RATE&gt;<br/>
*	&lt;EXCHANGE_RATE&gt;<br/>
*		&lt;UNIT_CURRENCY&gt;GBP&lt;/UNIT_CURRENCY&gt; <br/>
*		&lt;AMOUNT&gt;100&lt;/AMOUNT&gt; <br/>
*		&lt;PRICE_CURRENCY&gt;CNY&lt;/PRICE_CURRENCY&gt; <br/>
*		&lt;QUOTATION_TYPE&gt;1&lt;/QUOTATION_TYPE&gt; <br/>
*		&lt;PRICE_TYPE&gt;?出价&lt;/PRICE_TYPE&gt; <br/>
*		&lt;PRICE&gt;  &lt;/PRICE&gt; <br/>
*		&lt;PUBLISHER&gt;中國銀行&lt;/PUBLISHER&gt; <br/>
*		&lt;PUBLISHDATE FORMAT=\&quot;yyyy/MM/dd\&quot;&gt;2007/07/09&lt;/PUBLISHDATE&gt; <br/>
*		&lt;WEBSITE&gt;<br/>
*			&lt;ID&gt;8a199ae813715f2601137523c72d0002&lt;/ID&gt; <br/>
*			&lt;NAME&gt;中國銀行-外匯牌價&lt;/NAME&gt; <br/>
*		&lt;/WEBSITE&gt;<br/>
*	&lt;/EXCHANGE_RATE&gt;<br/>
*&lt;/EXCHANGE_RATES&gt;
*</pre>
 * @author ldapeng
 *
 */
public final class ExchangeRateConstants {
	/**
	 * XML標簽，描述ExchangeRate集合，包含一個或多個<EXCHANGE_RATE>
	 * */
	public final static String XMLTAG_EXCHANGERATES = "EXCHANGE_RATES";
	/**
	 * XML標簽，描述ExchangeRate的相關信息<br/>
	 * 包含下列Tag：
	 * <ul>
	 * 		<li>ID</li>
	 * 		<li>UNIT_CURRENCY</li>
	 * 		<li>PRICE_CURRENCY</li>
	 * 		<li>AMOUNT</li>
	 * 		<li>PRICE_TYPE</li>
	 * 		<li>PRICE</li>
	 * 		<li>QUOTATION_TYPE</li>
	 * 		<li>PUBLISHER</li>
	 * 		<li>PUBLISHDATE</li>
	 * </ul>
	 * */
	public final static String XMLTAG_EXCHANGERATE = "EXCHANGE_RATE";
	
	/**XML標簽，描述id*/
	public final static String XMLTAG_EXCHANGERATE_ID = "ID";
	/**XML標簽，描述單位貨幣*/
	public final static String XMLTAG_EXCHANGERATE_UNITCURRENCY = "UNIT_CURRENCY";
	/**XML標簽，描述價格貨幣*/
	public final static String XMLTAG_EXCHANGERATE_PRICECURRENCY = "PRICE_CURRENCY";
	/**XML標簽，描述數量*/
	public final static String XMLTAG_EXCHANGERATE_AMOUNT = "AMOUNT";
	/**XML標簽，描述價格類型*/
	public final static String XMLTAG_EXCHANGERATE_PRICETYPE = "PRICE_TYPE";
	/**XML標簽，描述價格*/
	public final static String XMLTAG_EXCHANGERATE_PRICE = "PRICE";
	/**XML標簽，描述報價類型*/
	public final static String XMLTAG_EXCHANGERATE_QUOTATIONTYPE = "QUOTATION_TYPE";
	/**XML標簽，描述發布者*/
	public final static String XMLTAG_EXCHANGERATE_PUBLISHER = "PUBLISHER";
	/**XML標簽，描述發布日期*/
	public final static String XMLTAG_EXCHANGERATE_PUBLISHDATE = "PUBLISHDATE";
	/**PUBLISHDATE標簽的屬性，描述發布日期的日期格式*/
	public final static String XMLATTRIBUTE_EXCHANGERATE_PUBLISHDATE_FORMAT = "FORMAT";
	/**PUBLISHDATE標簽的屬性，描述發布日期的locale*/
	public final static String XMLATTRIBUTE_EXCHANGERATE_PUBLISHDATE_LOCALELANGUAGE = "LANGUAGE";
}
