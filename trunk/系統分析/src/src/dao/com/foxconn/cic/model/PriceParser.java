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

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

/**
 * 將Price XML解析成Price
 * @author ldapeng
 *
 */
public final class PriceParser {
	
	/**
	 * 用來將xml轉換成Price對象
	 * @param element 描述Price的Dom對象
	 * @return News集合
	 * @throws ParseException 解析publishDate可能會拋出此Exception
	 */
	public static Vector<Price> parse(Element element) throws ParseException{
		Vector<Price> prices = null;
		if (element.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_ARRAY)) {
			prices = new Vector<Price>();
		} else {
			System.err.println("沒有找到根節點<"+PriceConstants.XMLTAG_PRICE_ARRAY+">");
			return null;
		}
		NodeList priceNodes = element.getChildNodes();
		for (int i = 0; i < priceNodes.getLength(); i++) {
			Node priceNode = priceNodes.item(i);
			if (priceNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE)){
				NodeList propertyNodes = priceNode.getChildNodes();
				Price price=new Price();
				for (int j = 0; j < propertyNodes.getLength(); j++) {
					Node propertyNode = propertyNodes.item(j);
					if (propertyNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_ID)
							&& propertyNode.getTextContent() != null
							&& !propertyNode.getTextContent().equals("")) {
						price.setId(Long.parseLong(propertyNode.getTextContent()));
					} else if (propertyNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_VALUE)) {
						price.setValue(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_TYPE)) {
						price.setType(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_UNIT)) {
						price.setUnit(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_MARKET)) {
						price.setMarket(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_PRODUCING_AREA)) {
						price.setProducingArea(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_REMARK)) {
						price.setRemark(propertyNode.getTextContent());
					} else if (propertyNode.getNodeName().equalsIgnoreCase(PriceConstants.XMLTAG_PRICE_PUBLISHDATE)
							&& propertyNode.getTextContent() != null
							&& !propertyNode.getTextContent().equals("")) {
						//解析publishDate
						//根據指定的日期格式parse日期
						String format = propertyNode.getAttributes().getNamedItem(PriceConstants.XMLATTRIBUTE_PRICE_PUBLISHDATE_FORMAT).getTextContent();
						String language =null;
						if(propertyNode.getAttributes().getNamedItem(PriceConstants.XMLATTRIBUTE_PRICE_PUBLISHDATE_LOCALELANGUAGE)!=null){
							language= propertyNode.getAttributes().getNamedItem(PriceConstants.XMLATTRIBUTE_PRICE_PUBLISHDATE_LOCALELANGUAGE).getTextContent();
						}
						if (format == null || format.trim().equals("")) {
							format = "yyyy/MM/dd";
						}
						SimpleDateFormat dateFormat = new SimpleDateFormat(format);
						if (language != null && !language.trim().equals("")) {
							dateFormat = new SimpleDateFormat(format,new Locale(language));
						}
						price.setPublishDate(dateFormat.parse(propertyNode.getTextContent()));

					} else if (propertyNode.getNodeName().equalsIgnoreCase(WebsiteConstants.XMLTAG_WEBSITE)) {
						NodeList website = propertyNode.getChildNodes();
						Website site = new Website();
						for (int k = 0; k < website.getLength(); k++) {
							Node n = website.item(k);
							if (n.getNodeName().equalsIgnoreCase(WebsiteConstants.XMLTAG_WEBSITE_ID)
									&& n.getTextContent() != null
									&& !n.getTextContent().equals("")) {
								site.setId(n.getTextContent());
								price.setWebsite(site);
							} else if (n.getNodeName().equalsIgnoreCase(
									WebsiteConstants.XMLTAG_WEBSITE_NAME)) {
								site.setName(n.getTextContent());
							}
						}
						price.setWebsite(site);
					} else if (propertyNode.getNodeName().equalsIgnoreCase(Material.XMLTAG_MATERIAL)) {
						NodeList materials = propertyNode.getChildNodes();
						Material material = new Material();
						for (int k = 0; k < materials.getLength(); k++) {
							Node n = materials.item(k);
							if (n.getNodeName().equalsIgnoreCase(Material.XMLTAG_MATERIAL_ID)
									&& n.getTextContent() != null
									&& !n.getTextContent().equals("")) {
								material.setId(n.getTextContent());
								price.setMaterial(material);
							} else if (n.getNodeName().equalsIgnoreCase(
									Material.XMLTAG_MATERIAL_NAME)) {
								material.setName(n.getTextContent());
							} else if (n.getNodeName().equalsIgnoreCase(
									Material.XMLTAG_MATERIAL_SPEC)) {
								material.setSpec(n.getTextContent());
							}
						}
						price.setMaterial(material);
					}
				}
				prices.add(price);
			}
		}			
		return prices;
	}
	
	/**
	 * 解析Price字符串，將其轉換成Price。
	 * @param string 描述Price的字符串
	 * @return Price集合
	 * @throws ParserConfigurationException @todo
	 * @throws SAXException @todo
	 * @throws IOException @todo
	 * @throws ParseException @todo
	 */
	public static Vector<Price> parse(String string) throws ParserConfigurationException, SAXException, IOException, ParseException{
		DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
		DocumentBuilder builder=factory.newDocumentBuilder();
		Document doc= builder.parse(new ByteArrayInputStream(string.getBytes("UTF-8")));
		return parse(doc.getDocumentElement());
	}
}
