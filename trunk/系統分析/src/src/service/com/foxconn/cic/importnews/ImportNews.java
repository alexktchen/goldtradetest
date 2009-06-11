package com.foxconn.cic.importnews;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.StringWriter;
import java.lang.reflect.Proxy;
import java.util.List;
import java.util.Properties;
import java.util.Set;

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

import org.apache.ws.security.WSConstants;
import org.apache.ws.security.handler.WSHandlerConstants;
import org.codehaus.xfire.client.Client;
import org.codehaus.xfire.client.XFireProxy;
import org.codehaus.xfire.security.wss4j.WSS4JOutHandler;
import org.codehaus.xfire.spring.remoting.XFireClientFactoryBean;
import org.codehaus.xfire.util.dom.DOMOutHandler;
import org.springframework.beans.MutablePropertyValues;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.beans.factory.support.BeanDefinitionRegistry;
import org.springframework.beans.factory.support.DefaultListableBeanFactory;
import org.springframework.beans.factory.support.RootBeanDefinition;
import org.springframework.remoting.httpinvoker.HttpInvokerProxyFactoryBean;
import org.w3c.dom.DOMException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.xml.sax.SAXException;

import com.foxconn.cic.importdata.CharacterUtil;
import com.foxconn.cic.model.News;
import com.foxconn.cic.model.NewsConstants;
import com.foxconn.cic.model.NewsImage;
import com.foxconn.cic.model.NewsParser;
import com.foxconn.cic.service.NewsImageHelper;
import com.foxconn.cic.service.NewsImageManager;
import com.foxconn.cic.service.NewsManager;
import com.foxconn.cic.service.NewsWebService;

public class ImportNews {

	private static NewsManager newsManager = null;

	private static NewsImageManager newsImageManager = null;
	private static NewsImageHelper newsImageHelper = null;
	
	private static NewsWebService searchWebService = null;

	private static String serviceURL = "";
	private static String newsServiceURL ="";
	private static String newsImageServiceURL ="";
	private static String newsWebServiceURL="";
	private static String newsImageHelperServiceURL="";

	public static void setServiceURL(String url) {
		serviceURL = url;
		newsServiceURL = serviceURL+"news.service";
		newsImageServiceURL = serviceURL+"newsImage.service";
		newsImageHelperServiceURL = serviceURL+"newsImageHelper.service";
		newsWebServiceURL = serviceURL+"services/NewsWebService?wsdl";
	}

	public static void init(String url) throws ParserConfigurationException, SAXException {
		setServiceURL(url);

		//news 設置屬性
		MutablePropertyValues properties = new MutablePropertyValues();
		properties.addPropertyValue("serviceUrl", newsServiceURL);
		properties.addPropertyValue("serviceInterface",
				"com.foxconn.cic.service.NewsManager");
		RootBeanDefinition definition = new RootBeanDefinition(
				HttpInvokerProxyFactoryBean.class, properties);
		BeanDefinitionRegistry reg = new DefaultListableBeanFactory();
		reg.registerBeanDefinition("newsManagerClient", definition);

		//newsImage 設置屬性
		properties = new MutablePropertyValues();
		properties.addPropertyValue("serviceUrl", newsImageServiceURL);
		properties.addPropertyValue("serviceInterface",
				"com.foxconn.cic.service.NewsImageManager");
		definition = new RootBeanDefinition(
				HttpInvokerProxyFactoryBean.class, properties);
		reg.registerBeanDefinition("newsImageManagerClient", definition);

		//newsImageHelper 設置屬性
		properties = new MutablePropertyValues();
		properties.addPropertyValue("serviceUrl", newsImageHelperServiceURL);
		properties.addPropertyValue("serviceInterface",
				"com.foxconn.cic.service.NewsImageHelper");
		definition = new RootBeanDefinition(
				HttpInvokerProxyFactoryBean.class, properties);
		reg.registerBeanDefinition("newsImageHelperClient", definition);
		//newsWebService
		properties = new MutablePropertyValues();
		properties.addPropertyValue("serviceClass", "com.foxconn.cic.service.NewsWebService");
		properties.addPropertyValue("wsdlDocumentUrl",newsWebServiceURL);
		definition = new RootBeanDefinition(
				XFireClientFactoryBean.class, properties);
		reg.registerBeanDefinition("searchWebService", definition);

		BeanFactory factory = (BeanFactory) reg;

		newsManager = (NewsManager) factory.getBean("newsManagerClient");
		newsImageManager = (NewsImageManager) factory.getBean("newsImageManagerClient");
		newsImageHelper = (NewsImageHelper) factory.getBean("newsImageHelperClient");
		searchWebService = (NewsWebService) factory.getBean("searchWebService");
		
		Client client = ((XFireProxy) Proxy.getInvocationHandler(searchWebService)).getClient();

		client.addOutHandler(new DOMOutHandler());
		Properties properties1 = new Properties();
		// Action to perform : user token
		properties1.setProperty(WSHandlerConstants.ACTION,WSHandlerConstants.USERNAME_TOKEN);
		// Set password type to hashed
		properties1.setProperty(WSHandlerConstants.PASSWORD_TYPE,WSConstants.PW_DIGEST);
		// Username in keystore
		properties1.setProperty(WSHandlerConstants.USER, "mraible");
		// Used do retrive password for given user name
		properties1.setProperty(WSHandlerConstants.PW_CALLBACK_CLASS,ClientPasswordHandler.class.getName());
		client.addOutHandler(new WSS4JOutHandler(properties1));
	}

	public static boolean isExisted(String title,String url){
		
		title=CharacterUtil.replaceInvalidWhiteSpace(title);

		News news = new News();
		news.setTitle(title);
		news.setUrl(url);
		return searchWebService.isExisted(news);
		
	}

	public static String saveOrUpdate(News news){
		String title=CharacterUtil.replaceInvalidWhiteSpace(news.getTitle().trim()).trim();
		String url=CharacterUtil.replaceInvalidWhiteSpace(news.getUrl().trim()).trim();
		if (isExisted(title,news.getUrl())) {
			System.out.println("已經存在此新聞:" + title);
			return null;
		}
		news.setTitle(title);
		news.setUrl(url);
		News newNews;
		try {
			newNews=newsManager.saveNews(news);
			System.out.println(newNews.getId());
		} catch (Exception e) {
			return null;
		}
		return toImagesXML(newNews);
	}
	public static String toImagesXML (News news){
		Set<NewsImage> images=news.getImages();
		Document doc;
		try {
			doc = DocumentBuilderFactory.newInstance().newDocumentBuilder().newDocument();
		} catch (ParserConfigurationException e) {
			e.printStackTrace();
			return null;
		}
		Element imagesElement=doc.createElement(NewsConstants.XMLTAG_NEWS_IMAGES);
		for (NewsImage image : images) {
			Element imageElement=doc.createElement(NewsConstants.XMLTAG_NEWS_IMAGE);
			Node urlNode=doc.createTextNode(image.getFixedUrl());
			imageElement.setAttribute(NewsConstants.XMLATTRIBUTE_NEWSIMAGE_ID, image.getId().toString());
			imageElement.setAttribute(NewsConstants.XMLATTRIBUTE_NEWSIMAGE_POSITION, image.getPosition()+"");
			imageElement.appendChild(urlNode);
			imagesElement.appendChild(imageElement);
		}
		Transformer transformer;
		try {
			transformer = TransformerFactory.newInstance().newTransformer();
			transformer.setOutputProperty(OutputKeys.METHOD,"html");
			StringWriter output = new StringWriter();
			transformer.transform(new DOMSource(imagesElement), new StreamResult(output));
			return output.toString();
		} catch (TransformerConfigurationException e) {
			e.printStackTrace();
			return "";
		} catch (TransformerFactoryConfigurationError e) {
			e.printStackTrace();
			return "";
		} catch (TransformerException e) {
			e.printStackTrace();
			return "";
		}

	}
	public static String saveOrUpdateWithElement(Element element) throws DOMException, java.text.ParseException {
		News news = NewsParser.parse(element);
		return saveOrUpdate(news);
	}

	public static String saveOrUpdateWithString(String newsXML)
			throws SAXException, IOException, DOMException, ParserConfigurationException, java.text.ParseException {

		News news=NewsParser.parse(newsXML);
		return saveOrUpdate(news);
	}
	public static boolean saveNewsImage(String id,ByteArrayOutputStream out){

		return newsImageHelper.saveNewsImage(id, out.toByteArray());
	}
	public static boolean saveNewsImageByteArray(String id,byte[] out){

		return newsImageHelper.saveNewsImage(id, out);
	}
	public static List<NewsImage> getFilepathIsNullNewsImages(){
		return newsImageManager.getFilepathIsNullNewsImages();
	}
}
