package com.foxconn.cic.importnews;

import java.lang.reflect.Proxy;
import java.util.Properties;

import org.apache.ws.security.WSConstants;
import org.apache.ws.security.handler.WSHandlerConstants;
import org.codehaus.xfire.client.Client;
import org.codehaus.xfire.client.XFireProxy;
import org.codehaus.xfire.security.wss4j.WSS4JOutHandler;
import org.codehaus.xfire.util.dom.DOMOutHandler;
import org.springframework.beans.factory.xml.XmlBeanFactory;
import org.springframework.core.io.ClassPathResource;
import org.springframework.core.io.Resource;

import com.foxconn.cic.model.News;
import com.foxconn.cic.service.NewsSearchResults;
import com.foxconn.cic.service.NewsWebService;

public class TestSearchWebService {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
//		連接至FOXCONNCIC遠端調用接口
		Resource is =new ClassPathResource("com/foxconn/cic/importnews/TestSearchWebServiceContext.xml");
		XmlBeanFactory factory = new XmlBeanFactory(is);
		NewsWebService searchWebService = (NewsWebService) factory.getBean("searchWebService");

		Client client = ((XFireProxy) Proxy.getInvocationHandler(searchWebService)).getClient();

		client.addOutHandler(new DOMOutHandler());
		Properties properties = new Properties();
		// Action to perform : user token
		properties.setProperty(WSHandlerConstants.ACTION,WSHandlerConstants.USERNAME_TOKEN);
		// Set password type to hashed
		properties.setProperty(WSHandlerConstants.PASSWORD_TYPE,WSConstants.PW_DIGEST);
		// Username in keystore
		properties.setProperty(WSHandlerConstants.USER, "tomcat");
		// Used do retrive password for given user name
		properties.setProperty(WSHandlerConstants.PW_CALLBACK_CLASS,ClientPasswordHandler.class.getName());
		client.addOutHandler(new WSS4JOutHandler(properties));
		
		System.err.println("測試開始...");
		System.err.println("測試 search(CompassSearchCommand searchCommand)接口...");

		NewsSearchResults result=searchWebService.search("8a199ae811f7e3d30111f856aff3000c AND 20071009",null);
		System.out.println("搜索時間:"+result.getSearchTime());
		System.out.println("總數量:"+result.getTotal());
		News[] news= result.getNews();
		for(int i=0;i<news.length;i++){
			System.out.println(news[i].getTitle());
		}
		System.err.println("測試getNews(final String id)接口...");
		News newsbyid=searchWebService.getNews("231","/images/");
		System.out.println(newsbyid.getTitle());
		System.out.println(newsbyid.getContent());
		
		System.err.println("測試isExisted(News news)接口...");
		News news1=new News();
		news1.setTitle("測試巨哼網中新聞的url中包含斜杠");
		news1.setUrl("http://news.cnyes.com/dspnewsS.asp?rno=2&fi=\\NEWSBASE\\20071009\\WEB1732&vi=33863&sdt=20070929&edt=20071009&top=50&date=20071009&time=15:46:09&cls=index1_tech");
		System.out.println(searchWebService.isExisted(news1)); 
//		CompassSearchResults result=searchWebService.search(command);
//		CompassHit[] hits= result.getHits();
//		for(int i=0;i<hits.length;i++){
//			News news=(News)hits[i].getData();
//			System.out.println(news.getTitle());
//		}
//		List result=searchWebService.search(command);
//		System.out.println(result.size());
//		for(int i=0;i<result.size();i++){
//			News news=(News)result.get(i);
//			System.out.println(news.getTitle());
//		}
	}

}
