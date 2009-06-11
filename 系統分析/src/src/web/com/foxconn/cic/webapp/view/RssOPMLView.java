package com.foxconn.cic.webapp.view;

import java.text.DateFormat;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
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

import org.springframework.web.servlet.view.AbstractView;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;

import com.foxconn.cic.model.Website;

public class RssOPMLView extends AbstractView {

	private String server;
	private String url;
	private String contextPath;
	@Override
	protected void renderMergedOutputModel(Map model, HttpServletRequest request,
			HttpServletResponse response) throws Exception {

		List<Website> sites=(List<Website>)model.get("websiteList");
		server=request.getServerName();
		url="http://"+server;
		if(request.getServerPort()!=-1){
			url="http://"+server+":"+request.getServerPort();
		}
		contextPath=request.getContextPath();
		Document doc;
		try {
			doc = DocumentBuilderFactory.newInstance().newDocumentBuilder().newDocument();
		} catch (ParserConfigurationException e) {
			e.printStackTrace();
			return ;
		}

		Element opml= doc.createElement("opml");
		opml.setAttribute("version", "1.1");
		Element head= doc.createElement("head");
		Element title= doc.createElement("title");
		Node titletext=doc.createTextNode(url+contextPath);
		title.appendChild(titletext);
		Element dateCreated= doc.createElement("dateCreated");
		Locale locale=  request.getLocale();
		DateFormat format=DateFormat.getDateTimeInstance(DateFormat.LONG,DateFormat.SHORT, locale);
		String time=format.format(new Date());
		Node datetext=doc.createTextNode(time);
		dateCreated.appendChild(datetext);
		Element ownerName= doc.createElement("ownerName");
		head.appendChild(title);
		head.appendChild(dateCreated);
		head.appendChild(ownerName);
		opml.appendChild(head);
		Element body= doc.createElement("body");
		Element rootoutline= doc.createElement("outline");
		rootoutline.setAttribute("text", "Foxconn News Center");
		body.appendChild(rootoutline);
		opml.appendChild(body);
		for (Website website : sites) {
			if(website.getParent()==null){
				Element e=genXmlElement(doc, website);
				rootoutline.appendChild(e);
			}
		}
		doc.appendChild(opml);
		Transformer transformer;
		try {
			transformer = TransformerFactory.newInstance().newTransformer();
			transformer.setOutputProperty(OutputKeys.METHOD,"xml");
			response.setContentType("application/xml; charset=UTF-8");
			transformer.transform(new DOMSource(doc),new StreamResult(response.getOutputStream()));
		} catch (TransformerConfigurationException e) {
			e.printStackTrace();
			return ;
		} catch (TransformerFactoryConfigurationError e) {
			e.printStackTrace();
			return ;
		} catch (TransformerException e) {
			e.printStackTrace();
			return ;
		}

	}
	private Element genXmlElement(Document doc, Website site){
		if(site == null) return null;
		Element element=doc.createElement("outline");
		element.setAttribute("text", site.getName());
		if(site.getChildren().size()==0){
			element.setAttribute("title", site.getName());
			element.setAttribute("type", "rss");
			element.setAttribute("xmlUrl", url+contextPath+"/newss.html?method=rss&websiteid="+site.getId());
			element.setAttribute("rssOwlUpdateInterval", "60");
			element.setAttribute("htmlUrl", url+contextPath);
			element.setAttribute("description", "description");
		}
		List<Website> children=site.getChildren();
		for (Website website : children) {
			Element e=genXmlElement(doc, website);
			element.appendChild(e);
		}
		return element;
	}
}
