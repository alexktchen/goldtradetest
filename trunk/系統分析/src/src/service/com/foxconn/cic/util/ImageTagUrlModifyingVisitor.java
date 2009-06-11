package com.foxconn.cic.util;

import java.util.HashMap;
import java.util.Map;

import org.htmlparser.Parser;
import org.htmlparser.Tag;
import org.htmlparser.tags.ImageTag;
import org.htmlparser.util.NodeList;
import org.htmlparser.util.ParserException;
import org.htmlparser.visitors.NodeVisitor;

/**
 * 用於替換新聞内容中img標簽的src,
 * 
 * @author ldapeng
 *
 */
public class ImageTagUrlModifyingVisitor extends NodeVisitor {
	/**
	 * 替換的前綴
	 */
	private String prefix;

	/**
	 * 替換的後綴
	 */
	private String suffix;

	private Map<Integer, String> imageMap;

	
	
	@Override
	public void beginParsing() {
		super.beginParsing();
		imageMap.clear();
	}

	/**
	 * 替換的前後綴，例如：prefix為"{$"，後綴為"}"，第一個圖片的src="{0}"
	 * @param prefix 替換的前綴
	 * @param suffix 替換的後綴
	 */
	public ImageTagUrlModifyingVisitor(String prefix, String suffix) {
		super(true, true);
		this.prefix = prefix;
		this.suffix = suffix;
		imageMap = new HashMap<Integer, String>();
	}

	public void visitTag(Tag tag) {
		if (tag instanceof ImageTag) {
			Integer position = Integer.valueOf(imageMap.size());
			imageMap.put(position, ((ImageTag) tag).getImageURL());
			((ImageTag) tag).setImageURL(prefix + position + suffix);
		}

	}

	/**
	 * 返回替換的結果
	 * @return key為postion,value為原始url
	 */
	public Map<Integer, String> getImageMap() {
		return imageMap;
	}

	public static void main(String[] args) {
		String html = "<tr><td align=left><table border=0 align=right cellpadding=5 cellspacing=0><tr><td width=80 align=center valign=top><a href='http://news.sina.com.tw/politics/sinacn/cn/2007-02-01/15533467891.shtml' id=r-0-0i_1107136115><img src=http://news.google.com/news?imgefp=dSTAGFi9NvkJ&imgurl=image2.sina.com.cn/dy/o/2007-02-01/a0c9a4c957b757d665a11bfccd755ca2.jpg width=80 height=60 alt='' border=1><br><font size=-2>臺灣新浪網</font></a></td></tr></table><a href='http://big5.xinhuanet.com/gate/big5/news.xinhuanet.com/tai_gang_ao/2007-02/02/content_5688156.htm' id=r-0-0_1107136115 target=_blank><b>&quot;機要費&quot;案六度開庭吳淑珍連續第五次請病假</b></a><br><font size=-1><font color=#6f6f6f><b>新華網海南頻道&nbsp;-</font> <nobr>31分鐘前</nobr></b></font><br><font size=-1>新華網北京２月２日電（記者茆雷磊）綜合臺灣媒體報道，臺北地方法院２日第六度開庭審理陳水扁“機要費”貪腐案，身為被告的陳水扁之妻吳淑珍連續第五次以身體不適為由請假。 ２日庭訊的主要內容是對於“機要費”貪腐案中被查扣的兩千多張相關發票進行勘驗，並核對發票正本與 <b>...</b></font><br><font size=-1><a href='http://www.ctitv.com.tw/new/news/news02.html?id=3&cno=0&sno=301670' target=_blank>《政治》不耐吳淑珍再請假，檢方出奇招</a> <font size=-1 color=#6f6f6f><nobr>中天電視網</nobr></font></font><br><font size=-1><a href='http://news.chinatimes.com/Chinatimes/newslist/newslist-content/0,3546,130501+132007020200981,00.html' target=_blank>吳淑珍五度不出庭藍營：應以視訊應訊</a> <font size=-1 color=#6f6f6f><nobr>中時電子報</nobr></font></font><br><font size=-1 class=p><a href='http://www.echinanews.com.tw/shownews.asp?news_id=75555' target=_blank><nobr>中國網路電子報</nobr></a>&nbsp;- <a href='http://www.ettoday.com/2007/02/02/301-2049661.htm' target=_blank><nobr>東森新聞報</nobr></a>&nbsp;- <a href='http://c.yam.com/news/nlink/r.c?http://news.yam.com/cna/society/200702/20070202905373.html' target=_blank><nobr>蕃薯藤新聞</nobr></a>&nbsp;- <a href='http://news.sina.com.tw/politics/cna/tw/2007-02-02/131912331369.shtml' target=_blank><nobr>臺灣新浪網</nobr></a></font><br/><font class=p size=-1><a class=p href='http://news.google.com/news?ned=tw&ncl=1107136115&hl=zh-TW'><nobr><b>所有60條相關新聞&nbsp;&raquo;</b></nobr></a></font><br clear=all> <br><table border=0 align=right cellpadding=5 cellspacing=0><tr><td width=80 align=center valign=top><a href='http://www.chinareviewnews.com/crn-webapp/doc/docDetail.jsp?coluid=0&kindid=0&docid=100301042' id=r-0-1i_1107133931><img src=http://news.google.com/news?imgefp=_5uePI1KpLoJ&imgurl=www.chinareviewnews.com/upload/200702/2/100301051.jpg width=79 height=53 alt='' border=1><br><font size=-2>中國評論</font></a></td></tr></table><a href='http://www.rti.org.tw/News/NewsContentHome.aspx?NewsID=61515&t=1' id=r-0-1_1107133931 target=_blank><b>國民黨澄清馬律師沒有透露消息...</b></a><br><font size=-1><font color=#6f6f6f><b>中央廣播電台 Rti&nbsp;-</font> <nobr>1小時前</nobr></b></font><br><font size=-1>對於媒體報導，關於國民黨主席馬英九的特別費，馬英九律師團成員向綠營高層透露消息，國民黨秘書長吳敦義，還有馬英九特別費的委任律師宋耀明，2日特別澄清，媒體報導並非事實。 國民黨主席馬英九的特別費案何時偵結，持續引起各界關注。不過對於媒體報導，馬英九的律師團 <b>...</b></font><br><font size=-1><a href='http://www.echinanews.com.tw/shownews.asp?news_id=75554' target=_blank>連戰回鍋代理？林郁方：人選最好是對選下屆總統的興趣不太大</a> <font size=-1 color=#6f6f6f><nobr>中國網路電子報</nobr></font></font><br><font size=-1><a href='http://c.yam.com/news/nlink/r.c?http://news.yam.com/cna/politics/200702/20070202905973.html' target=_blank>國民黨引用法務部函說明馬英九特別費案</a> <font size=-1 color=#6f6f6f><nobr>蕃薯藤新聞</nobr></font></font><br><font size=-1 class=p><a href='http://www.ettoday.com/2007/02/02/301-2049821.htm' target=_blank><nobr>東森新聞報</nobr></a>&nbsp;- <a href='http://news.chinatimes.com/Chinatimes/newslist/newslist-content/0,3546,130501+132007020200976,00.html' target=_blank><nobr>中時電子報</nobr></a>&nbsp;- <a href='http://www.bcc.com.tw/news/newsview.asp?cde=390208' target=_blank><nobr>中廣新聞網</nobr></a>&nbsp;- <a href='http://www.takungpao.com/news/07/02/02/TM-687453.htm' target=_blank><nobr>大公報</nobr></a></font><br/><font class=p size=-1><a class=p href='http://news.google.com/news?ned=tw&ncl=1107133931&hl=zh-TW'><nobr><b>所有65條相關新聞&nbsp;&raquo;</b></nobr></a></font><br clear=all> </td></tr>";
		Parser parser = Parser.createParser(html, null);
		NodeList list;
		try {
			list = parser.parse(null);
			ImageTagUrlModifyingVisitor visitor = new ImageTagUrlModifyingVisitor(
					"{$", "}");

			list.visitAllNodesWith(visitor);
			String result = list.toHtml();
			Map imageMap = visitor.getImageMap();
			System.out.println(result);
		} catch (ParserException e) {
			e.printStackTrace();
		}

	}

}
