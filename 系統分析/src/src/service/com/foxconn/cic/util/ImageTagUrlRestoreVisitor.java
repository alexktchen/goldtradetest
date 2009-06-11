package com.foxconn.cic.util;

import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;

import org.apache.commons.beanutils.BeanUtils;
import org.apache.commons.lang.StringUtils;
import org.htmlparser.Parser;
import org.htmlparser.Tag;
import org.htmlparser.tags.ImageTag;
import org.htmlparser.util.NodeList;
import org.htmlparser.util.ParserException;
import org.htmlparser.visitors.NodeVisitor;

import com.foxconn.cic.model.News;
import com.foxconn.cic.model.NewsImage;
import com.foxconn.cic.model.NewsParser;

/**
 * 用於替換新聞内容中img標簽的src,
 *
 * @author ldapeng
 *
 */
public class ImageTagUrlRestoreVisitor extends NodeVisitor {
	protected String prefix;

	protected String suffix;

	protected String urlPrefix;

	protected String patternString;

	protected String propertyName;
	
	protected Set<NewsImage> images;

	protected News news;
	/**
	 * key值為position，Value值為filepath
	 */
	protected Map<Integer, NewsImage> imageMap;

	/**
	 * 替換的前後綴，例如：prefix為"{$"，後綴為"}"，第一個圖片的src="{0}"
	 * @param prefix 前綴
	 * @param suffix 後綴
	 * @param urlPrefix 顯示圖片的url前綴
	 */
	public ImageTagUrlRestoreVisitor(String prefix , String suffix) {
		super(true, true);
		this.prefix = prefix;
		this.suffix = suffix;

		//產生正則表達式用於判斷img標簽中src屬性值
		char[] preChars=prefix.toCharArray();
		char[] sufChars=suffix.toCharArray();
		StringBuffer p=new StringBuffer();
		for (char c : preChars) {
			p.append("\\");
			p.append(c);
		}
		p.append("\\d+");
		for (char c : sufChars) {
			p.append("\\");
			p.append(c);
		}
		patternString=p.toString();
	}

	public void visitTag(Tag tag) {
		if (tag instanceof ImageTag) {
			String url=((ImageTag) tag).getImageURL();
			if(url.matches(patternString)){
				String postion=url.substring(prefix.length(), url.length()-suffix.length());
				Integer i=new Integer(postion);
				NewsImage image=imageMap.get(i);
				if(image==null) return;
				if(image.getFilePath()==null||image.getFilePath().trim().equals("")){
					if(StringUtils.isEmpty(image.getFixedUrl())){
						((ImageTag) tag).setImageURL(NewsParser.assembleUrl(news.getUrl(), image.getUrl()));
					}else{
						((ImageTag) tag).setImageURL(image.getFixedUrl());
					}					
				}else{
					String parameter;
					try {
						parameter = BeanUtils.getProperty(image, getPropertyName());
						((ImageTag) tag).setImageURL(urlPrefix+ parameter);
					} catch (IllegalAccessException e) {
						e.printStackTrace();
					} catch (InvocationTargetException e) {
						e.printStackTrace();
					} catch (NoSuchMethodException e) {
						e.printStackTrace();
					}
				}

			}
		}

	}

	public void setNews(News news){
		images = news.getImages();
		this.news=news;
		imageMap = new HashMap<Integer, NewsImage>();
		if(images!=null){
			for (Iterator iter = images.iterator(); iter.hasNext();) {
				NewsImage image = (NewsImage) iter.next();
				imageMap.put(image.getPosition(),image);
			}
		}
	}

	public String getUrlPrefix() {
		return urlPrefix;
	}

	public void setUrlPrefix(String urlPrefix) {
		this.urlPrefix = urlPrefix;
	}

	public void setPropertyName(String propertyName) {
		this.propertyName = propertyName;
	}
	
	public String getPropertyName(){
		return this.propertyName;
	}
	public static void main(String[] args) {
//		String pattern="\\{\\d+\\}";
//		System.out.println("{}:"+"{}".matches(pattern));
//		System.out.println("{1}:"+"{1}".matches(pattern));
//		System.out.println("{11}:"+"{11}".matches(pattern));

		ImageTagUrlRestoreVisitor visitor=new ImageTagUrlRestoreVisitor("{$","}");
		visitor.setPropertyName("id");
		visitor.setUrlPrefix("http://localhost:8080/FoxconnCIC/");

		News news=new News();
		news.setUrl("http://www.domain.com/newscenter/today/news.html");

		Set<NewsImage> images=new HashSet<NewsImage>();

		NewsImage image1=new NewsImage();
		image1.setId(new Long(1));
		image1.setPosition(0);
		image1.setFilePath(null);
		image1.setUrl("hTtp://www.domain.com/image1.gif");
		image1.setNewsId(news.getId());
		images.add(image1);

		NewsImage image2=new NewsImage();
		image2.setId(new Long(2));
		image2.setPosition(1);
		image2.setFilePath("/xxx/yyy/1.gif");
		image2.setNewsId(news.getId());
		images.add(image2);

		NewsImage image3=new NewsImage();
		image3.setId(new Long(3));
		image3.setPosition(2);
		image3.setFilePath(null);
		image3.setUrl("/image3.gif");
		image3.setNewsId(news.getId());
		images.add(image3);

		NewsImage image31=new NewsImage();
		image31.setId(new Long(4));
		image31.setPosition(3);
		image31.setFilePath(null);
		image31.setUrl("../assets/getasset.aspx?ItemID=50678");
		image31.setNewsId(news.getId());
		images.add(image31);
		
		news.setImages(images);

		visitor.setNews(news);
		String html = "<TR><TD align='left'><TABLE align='right' border='0' cellpadding='5' cellspacing='0'>  <TR><TD align='center' valign='top' width='80'><A href='http://news.sina.com.tw/politics/sinacn/cn/2007-02-01/15533467891.shtml' id='r-0-0i_1107136115'><IMG alt='' border='1' height='60' src='{$0}' width='80'><BR>    <FONT size='-2'>臺灣新浪網</FONT></A></TD>  </TR></TABLE><A href='http://big5.xinhuanet.com/gate/big5/news.xinhuanet.com/tai_gang_ao/2007-02/02/content_5688156.htm' id='r-0-0_1107136115' target='_blank'><B>'機要費'案六度開庭吳淑珍連續第五次請病假</B></A><BR>  <FONT size='-1'><FONT color='#6f6f6f'>新華網海南頻道 ;-</FONT> <nobr>31分鐘前</nobr></FONT><BR>  <FONT size='-1'>新華網北京２月２日電（記者茆雷磊）綜合臺灣媒體報道，臺北地方法院２日第六度開庭審理陳水扁&ldquo;機要費&rdquo;貪腐案，身為被告的陳水扁之妻吳淑珍連續第五次以身體不適為由請假。 ２日庭訊的主要內容是對於&ldquo;機要費&rdquo;貪腐案中被查扣的兩千多張相關發票進行勘驗，並核對發票正本與 <B>...</B></FONT><BR>  <FONT size='-1'><A href='http://www.ctitv.com.tw/new/news/news02.html?id=3&cno=0&sno=301670' target='_blank'>《政治》不耐吳淑珍再請假，檢方出奇招</A> <FONT color='#6f6f6f' size='-1'><nobr>中天電視網</nobr></FONT></FONT><BR>  <FONT size='-1'><A href='http://news.chinatimes.com/Chinatimes/newslist/newslist-content/0,3546,130501+132007020200981,00.html' target='_blank'>吳淑珍五度不出庭藍營：應以視訊應訊</A> <FONT color='#6f6f6f' size='-1'><nobr>中時電子報</nobr></FONT></FONT><BR>  <FONT class='p' size='-1'><A href='http://www.echinanews.com.tw/shownews.asp?news_id=75555' target='_blank'><nobr>中國網路電子報</nobr></A> ;- <A href='http://www.ettoday.com/2007/02/02/301-2049661.htm' target='_blank'><nobr>東森新聞報</nobr></A> ;- <A href='http://c.yam.com/news/nlink/r.c?http://news.yam.com/cna/society/200702/20070202905373.html' target='_blank'><nobr>蕃薯藤新聞</nobr></A> ;- <A href='http://news.sina.com.tw/politics/cna/tw/2007-02-02/131912331369.shtml' target='_blank'><nobr>臺灣新浪網</nobr></A></FONT><BR>  <FONT class='p' size='-1'><A class='p' href='http://news.google.com/news?ned=tw&ncl=1107136115&hl=zh-TW'><nobr><B>所有60條相關新聞 ; </B></nobr></A></FONT><BR clear='all'>   <BR>  <TABLE align='right' border='0' cellpadding='5' cellspacing='0'>    <TR><TD align='center' valign='top' width='80'><A href='http://www.chinareviewnews.com/crn-webapp/doc/docDetail.jsp?coluid=0&kindid=0&docid=100301042' id='r-0-1i_1107133931'><IMG alt='' border='1' height='53' src='{$1}' width='79'><IMG alt='' border='1' height='53' src='{$2}' width='79'><BR>  <IMG alt='' border='1' height='53' src='{$3}' width='79'>    <FONT size='-2'>中國評論</FONT></A></TD>    </TR></TABLE><A href='http://www.rti.org.tw/News/NewsContentHome.aspx?NewsID=61515&t=1' id='r-0-1_1107133931' target='_blank'><B>國民黨澄清馬律師沒有透露消息...</B></A><BR>    <FONT size='-1'><FONT color='#6f6f6f'>中央廣播電台 Rti ;-</FONT> <nobr>1小時前</nobr></FONT><BR>    <FONT size='-1'>對於媒體報導，關於國民黨主席馬英九的特別費，馬英九律師團成員向綠營高層透露消息，國民黨秘書長吳敦義，還有馬英九特別費的委任律師宋耀明，2日特別澄清，媒體報導並非事實。 國民黨主席馬英九的特別費案何時偵結，持續引起各界關注。不過對於媒體報導，馬英九的律師團 <B>...</B></FONT><BR>    <FONT size='-1'><A href='http://www.echinanews.com.tw/shownews.asp?news_id=75554' target='_blank'>連戰回鍋代理？林郁方：人選最好是對選下屆總統的興趣不太大</A> <FONT color='#6f6f6f' size='-1'><nobr>中國網路電子報</nobr></FONT></FONT><BR>    <FONT size='-1'><A href='http://c.yam.com/news/nlink/r.c?http://news.yam.com/cna/politics/200702/20070202905973.html' target='_blank'>國民黨引用法務部函說明馬英九特別費案</A> <FONT color='#6f6f6f' size='-1'><nobr>蕃薯藤新聞</nobr></FONT></FONT><BR>    <FONT class='p' size='-1'><A href='http://www.ettoday.com/2007/02/02/301-2049821.htm' target='_blank'><nobr>東森新聞報</nobr></A> ;- <A href='http://news.chinatimes.com/Chinatimes/newslist/newslist-content/0,3546,130501+13207020200976,00.html' target='_blank'><nobr>中時電子報</nobr></A> ;- <A href='http://www.bcc.com.tw/news/newsview.asp?cde=390208' target='_blank'><nobr>中廣新聞網</nobr></A> ;- <A href='http://www.takungpao.com/news/07/02/02/TM-687453.htm' target='_blank'><nobr>大公報</nobr></A></FONT><BR>    <FONT class='p' size='-1'><A class='p' href='http://news.google.com/news?ned=tw&ncl=1107133931&hl=zh-TW'><nobr><B>所有65條相關新聞 ; </B></nobr></A></FONT><BR clear='all'> </TD></TR>";
		Parser parser = Parser.createParser(html, null);
		NodeList list;
		try {
			list = parser.parse(null);

			list.visitAllNodesWith(visitor);
			String result = list.toHtml();
			System.out.println(result);
		} catch (ParserException e) {
			e.printStackTrace();
		}

	}

	
}
