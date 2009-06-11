package com.foxconn.cic.model;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Vector;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.apache.commons.lang.StringUtils;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

/**
 * 將InterestRate XML解析成InterestRate
 * @author ldapeng
 *
 */
public final class InterestRateParser {
	
	/**
	 * 解析InterestRate Dom，將其轉換成InterestRate。
	 * @param element 描述InterestRate的Dom對象
	 * @return InterestRate集合
	 * @throws ParseException 解析publishDate可能會拋出此Exception
	 */
	public static Vector<InterestRate> parse(Element element) throws ParseException{
		Vector<InterestRate> rates = null;
		if (element.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATES)) {
			rates = new Vector<InterestRate>();
		} else {
			System.err.println("沒有找到根節點<"+InterestRateConstants.XMLTAG_INTERESTRATES+">");
			return null;
		}
		NodeList rateNodes = element.getChildNodes();
		for (int i = 0; i < rateNodes.getLength(); i++) {
			Node rateNode = rateNodes.item(i);
			if (rateNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE)){
				NodeList propertyNodes = rateNode.getChildNodes();
				InterestRate rate=new InterestRate();
				for (int j = 0; j < propertyNodes.getLength(); j++) {
					Node propertyNode = propertyNodes.item(j);
					if (propertyNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE_ID)
							&& propertyNode.getTextContent() != null
							&& !propertyNode.getTextContent().equals("")) {
						rate.setId(Long.parseLong(propertyNode.getTextContent()));
					} else if (propertyNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE_NAME)) {
						rate.setName(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE_CURRENCY)) {
						rate.setCurrency(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE_TYPE)) {
						rate.setType(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE_TIMEPERIOD)) {
						rate.setTimePeriod(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE_RATE)) {
						String t=propertyNode.getTextContent().trim();
						if(!StringUtils.isEmpty(t)){
							Float f=null;
							try {
								f=new Float(t);
							} catch (NumberFormatException e) {
							}
							rate.setRate(f);
						}
					} else if (propertyNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE_PUBLISHER)) {
						rate.setPublisher(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(InterestRateConstants.XMLTAG_INTERESTRATE_PUBLISHDATE)
							&& propertyNode.getTextContent() != null
							&& !propertyNode.getTextContent().equals("")) {
						//解析publishDate
						//根據指定的日期格式parse日期
						String format = propertyNode.getAttributes().getNamedItem(InterestRateConstants.XMLATTRIBUTE_INTERESTRATE_PUBLISHDATE_FORMAT).getTextContent();
						String language =null;
						if(propertyNode.getAttributes().getNamedItem(InterestRateConstants.XMLATTRIBUTE_INTERESTRATE_PUBLISHDATE_LOCALELANGUAGE)!=null){
							language= propertyNode.getAttributes().getNamedItem(InterestRateConstants.XMLATTRIBUTE_INTERESTRATE_PUBLISHDATE_LOCALELANGUAGE).getTextContent();
						}
						if (format == null || format.trim().equals("")) {
							format = "yyyy/MM/dd";
						}
						SimpleDateFormat dateFormat = new SimpleDateFormat(format);
						if (language != null && !language.trim().equals("")) {
							dateFormat = new SimpleDateFormat(format,new Locale(language));
						}
						rate.setPublishDate(dateFormat.parse(propertyNode.getTextContent()));

					} else if (propertyNode.getNodeName().equalsIgnoreCase(WebsiteConstants.XMLTAG_WEBSITE)) {
						NodeList website = propertyNode.getChildNodes();
						Website site = new Website();
						for (int k = 0; k < website.getLength(); k++) {
							Node n = website.item(k);
							if (n.getNodeName().equalsIgnoreCase(WebsiteConstants.XMLTAG_WEBSITE_ID)
									&& n.getTextContent() != null
									&& !n.getTextContent().equals("")) {
								site.setId(n.getTextContent());
								rate.setWebsite(site);
							} else if (n.getNodeName().equalsIgnoreCase(
									WebsiteConstants.XMLTAG_WEBSITE_NAME)) {
								site.setName(n.getTextContent());
							}
						}
						rate.setWebsite(site);
					} 
				}
				rates.add(rate);
			}
		}			
		return rates;
	}
	
	/**
	 * 解析InterestRate字符串，將其轉換成InterestRate。
	 * @param string 描述InterestRate的字符串
	 * @return InterestRate集合
	 * @throws ParserConfigurationException @todo
	 * @throws SAXException @todo
	 * @throws IOException @todo
	 * @throws ParseException @todo
	 */
	public static Vector<InterestRate> parse(String string) throws ParserConfigurationException, SAXException, IOException, ParseException{
		DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
		DocumentBuilder builder=factory.newDocumentBuilder();
		Document doc= builder.parse(new ByteArrayInputStream(string.getBytes("UTF-8")));
		return parse(doc.getDocumentElement());
	}
	
}
