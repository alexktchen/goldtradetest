package com.foxconn.cic.importnews;

import java.io.IOException;
import java.lang.reflect.Proxy;
import java.util.Properties;
import java.util.Vector;

import javax.xml.parsers.ParserConfigurationException;

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
import org.w3c.dom.Element;
import org.xml.sax.SAXException;

import com.foxconn.cic.model.Price;
import com.foxconn.cic.model.PriceParser;
import com.foxconn.cic.service.PriceManager;
import com.foxconn.cic.service.PriceWebService;

public class ImportPrice {

	private static PriceManager priceManager = null;

	private static PriceWebService searchWebService = null;

	private static String serviceURL = "";
	private static String priceServiceURL ="";
	private static String priceWebServiceURL="";

	public static void setServiceURL(String url) {
		serviceURL = url;
		priceServiceURL = serviceURL+"price.service";
		priceWebServiceURL = serviceURL+"services/PriceWebService?wsdl";

	}

	public static void init(String url) throws ParserConfigurationException, SAXException {
		setServiceURL(url);

		//news 設置屬性
		MutablePropertyValues properties = new MutablePropertyValues();
		properties.addPropertyValue("serviceUrl", priceServiceURL);
		properties.addPropertyValue("serviceInterface",
				"com.foxconn.cic.service.PriceManager");


		//news 設置Bean定義
		RootBeanDefinition definition = new RootBeanDefinition(
				HttpInvokerProxyFactoryBean.class, properties);

		// 註冊Bean定義與Bean別名
		BeanDefinitionRegistry reg = new DefaultListableBeanFactory();
		reg.registerBeanDefinition("priceManagerClient", definition);

		properties = new MutablePropertyValues();
		properties.addPropertyValue("serviceClass", "com.foxconn.cic.service.PriceWebService");
		properties.addPropertyValue("wsdlDocumentUrl",priceWebServiceURL);
		definition = new RootBeanDefinition(
				XFireClientFactoryBean.class, properties);
		reg.registerBeanDefinition("searchWebService", definition);



		BeanFactory factory = (BeanFactory) reg;

		priceManager = (PriceManager) factory.getBean("priceManagerClient");
		searchWebService = (PriceWebService) factory.getBean("searchWebService");
		
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

	public static boolean isExisted(Price price,String condition){
		return searchWebService.isExisted(price, condition);
	}

	public static boolean saveOrUpdate(Vector<Price> price,String condition){		
		for (Price price2 : price) {
			if (isExisted(price2,condition)) {
				System.out
						.println("此報價已經存在："+price2.getValue()+","+price2.getType()+",["+price2.getMaterial().getName()+"]");
				continue;
			} else {
				Price newPrice;
				try {
					newPrice = priceManager.savePrice(price2);
					System.out.println(newPrice.getId());
				} catch (Exception e) {
					e.printStackTrace();
					return false;
				}
			}
		}
		
		return true;
	}
	
	public static boolean saveOrUpdateWithElement(Element element,String condition) throws DOMException, java.text.ParseException {
		Vector<Price> price = PriceParser.parse(element);
		return saveOrUpdate(price,condition);
	}

	public static boolean saveOrUpdateWithString(String newsXML,String condition)
			throws SAXException, IOException, DOMException, ParserConfigurationException, java.text.ParseException {

		Vector<Price> price=PriceParser.parse(newsXML);
		return saveOrUpdate(price,condition);
	}
	
	
}
