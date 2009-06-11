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
 * 將ExchangeRate XML解析成ExchangeRate
 * @author ldapeng
 *
 */
public final class ExchangeRateParser {
	
	/**
	 * 解析ExchangeRate Dom，將其轉換成ExchangeRate。
	 * @param element 描述ExchangeRate的Dom對象
	 * @return ExchangeRate集合
	 * @throws ParseException 解析publishDate可能會拋出此Exception
	 */
	public static Vector<ExchangeRate> parse(Element element) throws ParseException{
		Vector<ExchangeRate> rates = null;
		if (element.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATES)) {
			rates = new Vector<ExchangeRate>();
		} else {
			System.err.println("沒有找到根節點<"+ExchangeRateConstants.XMLTAG_EXCHANGERATES+">");
			return null;
		}
		NodeList rateNodes = element.getChildNodes();
		for (int i = 0; i < rateNodes.getLength(); i++) {
			Node rateNode = rateNodes.item(i);
			if (rateNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE)){
				NodeList propertyNodes = rateNode.getChildNodes();
				ExchangeRate rate=new ExchangeRate();
				for (int j = 0; j < propertyNodes.getLength(); j++) {
					Node propertyNode = propertyNodes.item(j);
					if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_ID)
							&& propertyNode.getTextContent() != null
							&& !propertyNode.getTextContent().equals("")) {
						rate.setId(Long.parseLong(propertyNode.getTextContent()));
					} else if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_UNITCURRENCY)) {
						rate.setUnitCurrency(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_PRICECURRENCY)) {
						rate.setPriceCurrency(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_AMOUNT)) {
						rate.setAmout(new Integer(propertyNode.getTextContent()));
					} else if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_PRICETYPE)) {
						rate.setPriceType(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_PRICE)) {
						String t=propertyNode.getTextContent().trim();
						if(!StringUtils.isEmpty(t)){
							Float price=null;
							try {
								price=new Float(t);
							} catch (NumberFormatException e) {
							}
							rate.setPrice(price);
						}						
					} else if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_QUOTATIONTYPE)) {
						rate.setQuotationType(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_PUBLISHER)) {
						rate.setPublisher(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(ExchangeRateConstants.XMLTAG_EXCHANGERATE_PUBLISHDATE)
							&& propertyNode.getTextContent() != null
							&& !propertyNode.getTextContent().equals("")) {
						//解析publishDate
						//根據指定的日期格式parse日期
						String format = propertyNode.getAttributes().getNamedItem(ExchangeRateConstants.XMLATTRIBUTE_EXCHANGERATE_PUBLISHDATE_FORMAT).getTextContent();
						String language =null;
						if(propertyNode.getAttributes().getNamedItem(ExchangeRateConstants.XMLATTRIBUTE_EXCHANGERATE_PUBLISHDATE_LOCALELANGUAGE)!=null){
							language= propertyNode.getAttributes().getNamedItem(ExchangeRateConstants.XMLATTRIBUTE_EXCHANGERATE_PUBLISHDATE_LOCALELANGUAGE).getTextContent();
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
	 * 解析ExchangeRate字符串，將其轉換成ExchangeRate。
	 * @param string 描述ExchangeRate的字符串
	 * @return ExchangeRate集合
	 * @throws ParserConfigurationException @todo
	 * @throws SAXException @todo
	 * @throws IOException @todo
	 * @throws ParseException @todo
	 */
	public static Vector<ExchangeRate> parse(String string) throws ParserConfigurationException,SAXException, IOException,ParseException{
		DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
		DocumentBuilder builder=factory.newDocumentBuilder();
		Document doc= builder.parse(new ByteArrayInputStream(string.getBytes("UTF-8")));
		return parse(doc.getDocumentElement());
	}
	
}
