package com.foxconn.cic.model;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.StringWriter;
import java.net.URI;
import java.net.URISyntaxException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerConfigurationException;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.TransformerFactoryConfigurationError;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

/**
 * 將News XML解析成News
 * @author ldapeng
 *
 */
public final class NewsParser {
	/**
	 * 用來將xml轉換成News對象
	 * @param element 描述News的Dom對象
	 * @return News集合
	 * @throws ParseException 解析publishDate可能會拋出此Exception
	 */
	public static News parse(Element element) throws ParseException{

		News news = null;
		if (element.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS)) {
			news = new News();
		} else {
			System.err.println("沒有找到根節點<News>");
			return null;
		}
		NodeList notes = element.getChildNodes();
		for (int i = 0; i < notes.getLength(); i++) {
			Node node = notes.item(i);
			if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_ID)
					&& node.getTextContent() != null
					&& !node.getTextContent().equals("")) {
				news.setId(Long.parseLong(node.getTextContent()));
			} else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_TITLE)) {
				news.setTitle(node.getTextContent());
			} else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_SUMMARY)) {
				news.setSummary(node.getTextContent());
			} else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_CONTENT)) {
				StringWriter output = new StringWriter();
				 try {
					Transformer transformer=TransformerFactory.newInstance().newTransformer();
					transformer.setOutputProperty(OutputKeys.METHOD,"html");
					transformer.transform(new DOMSource(node.getFirstChild()), new StreamResult(output));
				} catch (TransformerConfigurationException e) {
					e.printStackTrace();
					return null;
				} catch (TransformerException e) {
					e.printStackTrace();
					return null;
				} catch (TransformerFactoryConfigurationError e) {
					e.printStackTrace();
					return null;
				}
				 String elementString=output.toString();
				 news.setContent(elementString);
			} else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_PUBLISHDATE)
					&& node.getTextContent() != null
					&& !node.getTextContent().equals("")) {
				//解析publishDate
				//根據指定的日期格式parse日期
				String format = node.getAttributes().getNamedItem(NewsConstants.XMLATTRIBUTE_NEWS_PUBLISHDATE_FORMAT).getTextContent();
				String language =null;
				if(node.getAttributes().getNamedItem(NewsConstants.XMLATTRIBUTE_NEWS_PUBLISHDATE_LOCALELANGUAGE)!=null){
					language= node.getAttributes().getNamedItem(NewsConstants.XMLATTRIBUTE_NEWS_PUBLISHDATE_LOCALELANGUAGE).getTextContent();
				}
				if (format == null || format.trim().equals("")) {
					format = "yyyy/MM/dd";
				}
				SimpleDateFormat dateFormat = new SimpleDateFormat(format);
				if (language != null && !language.trim().equals("")) {
					dateFormat = new SimpleDateFormat(format,new Locale(language));
				}
				news.setPublishDate(dateFormat.parse(node.getTextContent()));

			}  else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_AUTHOR)) {
				news.setAuthor(node.getTextContent());
			} else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_PUBLISHER)) {
				news.setPublisher(node.getTextContent());
			} else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_URL)) {
				news.setUrl(node.getTextContent());
			} else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_BASEURL)) {
				news.setBaseUrl(node.getTextContent());
			} else if (node.getNodeName().equalsIgnoreCase(WebsiteConstants.XMLTAG_WEBSITE)) {
				NodeList website = node.getChildNodes();
				Website site = new Website();
				for (int j = 0; j < website.getLength(); j++) {
					Node n = website.item(j);
					if (n.getNodeName().equalsIgnoreCase(WebsiteConstants.XMLTAG_WEBSITE_ID)
							&& n.getTextContent() != null
							&& !n.getTextContent().equals("")) {
						site.setId(n.getTextContent());
						news.setWebsite(site);
					} else if (n.getNodeName().equalsIgnoreCase(
							WebsiteConstants.XMLTAG_WEBSITE_NAME)) {
						site.setName(n.getTextContent());
					}
				}
				news.setWebsite(site);
			}else if (node.getNodeName().equalsIgnoreCase(NewsConstants.XMLTAG_NEWS_IMAGES)) {
				NodeList imageNodes=node.getChildNodes();
				Set<NewsImage> images=new HashSet<NewsImage>();
				for(int j=0;j<imageNodes.getLength();j++){
					Node imageNode = imageNodes.item(j);
						String postionString = imageNode.getAttributes().getNamedItem(NewsConstants.XMLATTRIBUTE_NEWSIMAGE_POSITION).getTextContent();
						int postion=Integer.parseInt(postionString);
						String typeString = imageNode.getAttributes().getNamedItem(NewsConstants.XMLATTRIBUTE_NEWSIMAGE_TYPE).getTextContent();
						Integer type=new Integer(typeString);
						String titleString = imageNode.getAttributes().getNamedItem(NewsConstants.XMLATTRIBUTE_NEWSIMAGE_TITLE).getTextContent();
						String url = imageNode.getTextContent();
						NewsImage image = new NewsImage();
						image.setTitle(titleString);
						image.setPosition(postion);
						image.setType(type);
						image.setUrl(url);
						image.setFixedUrl(assembleUrl(news.getUrl(),url));
						images.add(image);
						image.setNewsId(news.getId());
				}
				news.setImages(images);
			}
		}

		return news;
	}

	/**
	 * 解析News字符串，將其轉換成News。
	 * @param string 描述News的字符串
	 * @return News集合
	 * @throws ParserConfigurationException @todo
	 * @throws SAXException @todo
	 * @throws IOException @todo
	 * @throws ParseException @todo
	 */
	public static News parse(String string) throws ParserConfigurationException, SAXException, IOException, ParseException{
		DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
		DocumentBuilder builder=factory.newDocumentBuilder();
		Document doc= builder.parse(new ByteArrayInputStream(string.getBytes("UTF-8")));
		return parse(doc.getDocumentElement());
	}

	/**
	 * 根據新聞url和新聞圖片url生成新聞圖片絕對地址
	 * @param newsUrl 新聞原始url
	 * @param imageUrl 新聞圖片原始url
	 * @return 返回重組后的url
	 */
	public static String assembleUrl(String newsUrl,String imageUrl){
		
		if(newsUrl==null){
			return imageUrl;
		}
		
		if(imageUrl==null){
			System.out.println(newsUrl);
			return "";
		}
		
		newsUrl=newsUrl.trim();
		imageUrl=imageUrl.trim();
		
		String _imageUrl=imageUrl.trim().toLowerCase();

		if(_imageUrl.startsWith("http")){
			return imageUrl;
		}		
		URI _newsUrl=null;
		try {
			_newsUrl=new URI(newsUrl);

		} catch (URISyntaxException e) {
			e.printStackTrace();
			return imageUrl;
		}
		if(_newsUrl==null)return imageUrl;
		
		URI newsUri;
		URI imageUri;
		try {
			newsUri=new URI(newsUrl);
			imageUri=new URI(imageUrl);
			imageUri=newsUri.resolve(imageUri);
			System.out.println(imageUri);
			return imageUri.toString();
		} catch (URISyntaxException e) {
			e.printStackTrace();
			return imageUrl;
		}

	}
}
