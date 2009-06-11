package com.foxconn.cic.model;

/**
 * News相關靜態變量
 * <PRE>
*&lt;NEWS&gt;&lt;ID /&gt;<br/>
*&lt;TITLE&gt;安森美NCP3065高亮LED SEPIC 方案&lt;/TITLE&gt;<br/>
*&lt;SUMMARY /&gt;<br/>
*&lt;CONTENT&gt;
*&lt;td align=\&quot;right\&quot; bgcolor=\&quot;#F7F7F4\&quot;&gt; 
*&lt;table border=\&quot;0\&quot; cellpadding=\&quot;0\&quot; cellspacing=\&quot;0\&quot; width=\&quot;98%\&quot;&gt;
*&lt;tr&gt;                 
*&lt;td&gt;&lt;br /&gt; 安森美的NCP3065是?片????器，能?高亮度LED提供恒定?流，集成了1.5 A??，?入???3.0 V到 40 V。本文介?了NCP3065的主要性能，典型?用?路?，以及?外接??的降?演示板?用?路?；同??介?了?端初??感??器（SEPIC） ??原理，?算公式等??要?。&lt;br /&gt;&lt;br /&gt;The NCP3065 is a monolithic switching regulator designed to deliver constant current for powering high brightness LEDs. The device has a very low feedback voltage of 235 mV (nominal) which is used to regulate the average current of the LED string. In addition, the NCP3065 has a wide input voltage up to 40 V to allow it to operate from 12 Vac or 12 Vdc supplies commonly used for lighting applications as well as unregulated supplies such as Lead Acid batteries. The device can be configured in a controller topology with the addition of an external transistor to support higher LED currents beyond the 1.5_A rated switch current of the internal transistor. The&lt;br /&gt;NCP3065 switching regulator can be configured in Step-Down (Buck) and Step-Up (boost) topologies with a minimum number of external components.&lt;br /&gt;&lt;br /&gt;&lt;/td&gt;              &lt;/tr&gt;              &lt;tr&gt;                &lt;td align=\&quot;right\&quot; height=\&quot;24\&quot;&gt;                 &lt;/td&gt;              &lt;/tr&gt;              &lt;tr&gt;                 &lt;td align=\&quot;right\&quot; height=\&quot;24\&quot;&gt;                                     &lt;!--						第 [&lt;font color=\&quot;#FF0000\&quot;&gt;&lt;a href=\&quot;./sa_detail.asp?id=1304\&quot;&gt;1&lt;/a&gt;&lt;/font&gt;] ?&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;--&gt;                                  &lt;/td&gt;              &lt;/tr&gt;            &lt;/table&gt;&lt;/td&gt;&lt;/CONTENT&gt;<br/>
*&lt;PUBLISHDATE FORMAT=\&quot;yyyy-MM-dd\&quot;&gt;2007-12-20&lt;/PUBLISHDATE&gt;<br/>
*&lt;AUTHOR /&gt;&lt;PUBLISHER /&gt;<br/>
*&lt;URL&gt;http://solution.eccn.com/sa_detail.asp?id=1304&lt;/URL&gt;<br/>
*&lt;IMAGES&gt;&lt;IMAGE TYPE=\&quot;1\&quot; TITLE='?此查看全文' POSITION=\&quot;0\&quot;&gt;http://solution.eccn.com/pdf/jjfa_075141_1.pdf&lt;/IMAGE&gt;&lt;/IMAGES&gt;<br/>
*&lt;WEBSITE&gt;&lt;ID&gt;8a1998de17bd92be0117bde6e1190002&lt;/ID&gt;&lt;NAME&gt;中電網-解決方案-電源管理&lt;/NAME&gt;&lt;/WEBSITE&gt;&lt;/NEWS&gt;&quot;;
*</PRE>
 * @author ldapeng
 *
 */
public final class NewsConstants {

	/**
	 * XML標簽，描述News的相關信息<br/>
	 * 包含下列Tag：
	 * <ul>
	 * 		<li>ID</li>
	 * 		<li>TITLE</li>
	 * 		<li>SUMMARY</li>
	 * 		<li>CONTENT</li>
	 * 		<li>PUBLISHDATE</li>
	 * 		<li>AUTHOR</li>
	 * 		<li>PUBLISHER</li>
	 * 		<li>URL</li>
	 * 		<li>BASEURL</li>
	 * 		<li>IMAGES</li>
	 * </ul>
	 * */
	public final static String XMLTAG_NEWS="NEWS";
	/**XML標簽，描述id*/
	public final static String XMLTAG_NEWS_ID="ID";
	/**XML標簽，描述標題*/
	public final static String XMLTAG_NEWS_TITLE="TITLE";
	/**XML標簽，描述新聞摘要*/
	public final static String XMLTAG_NEWS_SUMMARY="SUMMARY";
	/**XML標簽，描述新聞內容*/
	public final static String XMLTAG_NEWS_CONTENT="CONTENT";
	/**XML標簽，描述發布時間*/
	public final static String XMLTAG_NEWS_PUBLISHDATE="PUBLISHDATE";
	/**PUBLISHDATE標簽的屬性，描述發布日期的日期格式*/
	public final static String XMLATTRIBUTE_NEWS_PUBLISHDATE_FORMAT="FORMAT";
	/**PUBLISHDATE標簽的屬性，描述發布日期的locale*/
	public final static String XMLATTRIBUTE_NEWS_PUBLISHDATE_LOCALELANGUAGE="LANGUAGE";
	/**XML標簽，描述作者*/
	public final static String XMLTAG_NEWS_AUTHOR="AUTHOR";
	/**XML標簽，描述發布者*/
	public final static String XMLTAG_NEWS_PUBLISHER="PUBLISHER";
	/**XML標簽，描述原始url*/
	public final static String XMLTAG_NEWS_URL="URL";
	/**XML標簽，描述baseurl*/
	public final static String XMLTAG_NEWS_BASEURL="BASEURL";
	/**XML標簽，描述ExchangeRate集合，包含一個或多個<IMAGE>*/
	public final static String XMLTAG_NEWS_IMAGES="IMAGES";
	/**XML標簽，描述新聞圖片的相關信息*/
	public final static String XMLTAG_NEWS_IMAGE="IMAGE";
	/**IMAGE標簽的屬性，描述圖片id*/
	public final static String XMLATTRIBUTE_NEWSIMAGE_ID="ID";
	/**IMAGE標簽的屬性，描述圖片標題*/
	public final static String XMLATTRIBUTE_NEWSIMAGE_TITLE="TITLE";
	/**IMAGE標簽的屬性，描述圖片位置*/
	public final static String XMLATTRIBUTE_NEWSIMAGE_POSITION="POSITION";
	/**IMAGE標簽的屬性，描述圖片類型。0為一般圖片，1為附件（如PDF等）*/
	public final static String XMLATTRIBUTE_NEWSIMAGE_TYPE="TYPE";
	/**新聞圖片類型，0為一般圖片*/
	public static final int NEWSIMAGE_TYPE_NORMAL=0;
	/**新聞圖片類型，1為附件（如PDF等）*/
	public static final int NEWSIMAGE_TYPE_ATTACHMENT=1;
}
