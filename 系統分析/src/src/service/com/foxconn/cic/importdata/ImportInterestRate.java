package com.foxconn.cic.importdata;

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

import com.foxconn.cic.importnews.ClientPasswordHandler;
import com.foxconn.cic.model.InterestRate;
import com.foxconn.cic.model.InterestRateParser;
import com.foxconn.cic.service.InterestRateManager;
import com.foxconn.cic.service.InterestRateWebService;

public class ImportInterestRate {

	private static InterestRateManager interestRateManager = null;

	private static InterestRateWebService searchWebService = null;

	private static String serviceURL = "";
	private static String interestRateServiceURL ="";
	private static String interestRateWebServiceURL="";

	public static void setServiceURL(String url) {
		serviceURL = url;
		interestRateServiceURL = serviceURL+"interestRate.service";
		interestRateWebServiceURL = serviceURL+"services/InterestRateWebService?wsdl";
	}

	public static void init(String url) throws ParserConfigurationException, SAXException {
		setServiceURL(url);

		//news 設置屬性
		MutablePropertyValues properties = new MutablePropertyValues();
		properties.addPropertyValue("serviceUrl", interestRateServiceURL);
		properties.addPropertyValue("serviceInterface",
				"com.foxconn.cic.service.InterestRateManager");

		//news 設置Bean定義
		RootBeanDefinition definition = new RootBeanDefinition(
				HttpInvokerProxyFactoryBean.class, properties);

		// 註冊Bean定義與Bean別名
		BeanDefinitionRegistry reg = new DefaultListableBeanFactory();
		reg.registerBeanDefinition("interestRateManagerClient", definition);

		properties = new MutablePropertyValues();
		properties.addPropertyValue("serviceClass", "com.foxconn.cic.service.InterestRateWebService");
		properties.addPropertyValue("wsdlDocumentUrl",interestRateWebServiceURL);
		definition = new RootBeanDefinition(
				XFireClientFactoryBean.class, properties);
		reg.registerBeanDefinition("searchWebService", definition);

		BeanFactory factory = (BeanFactory) reg;

		interestRateManager = (InterestRateManager) factory.getBean("interestRateManagerClient");
		searchWebService = (InterestRateWebService) factory.getBean("searchWebService");
		
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

	public static boolean isExisted(InterestRate rate,String condition){
		return searchWebService.isExisted(rate, condition);
	}

	public static boolean saveOrUpdate(Vector<InterestRate> rates,String condition){		
		for (InterestRate rate : rates) {
			if (isExisted(rate,condition)) {
				System.out
						.println("此匯率已經存在："+rate.toString());
				continue;
			} else {
				InterestRate newRate;
				try {
					newRate = interestRateManager.saveInterestRate(rate);
					System.out.println(newRate.getId());
				} catch (Exception e) {
					e.printStackTrace();
					return false;
				}
			}
		}		
		return true;
	}
	
	public static boolean saveOrUpdateWithElement(Element element,String condition) throws DOMException, java.text.ParseException {
		Vector<InterestRate> rates = InterestRateParser.parse(element);
		return saveOrUpdate(rates,condition);
	}

	public static boolean saveOrUpdateWithString(String newsXML,String condition)
			throws SAXException, IOException, DOMException, ParserConfigurationException, java.text.ParseException {
		Vector<InterestRate> rates=InterestRateParser.parse(newsXML);
		return saveOrUpdate(rates,condition);
	}
}
