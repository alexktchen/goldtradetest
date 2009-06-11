package com.foxconn.cic.importnews;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.UnsupportedEncodingException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.TransformerFactoryConfigurationError;

import org.w3c.dom.DOMException;
import org.w3c.dom.Document;
import org.xml.sax.SAXException;

public class TestImportPrice {
	public static void main(String[] args) {



		try {
			ImportPrice.init("http://localhost:8080/FoxconnCIC/");
		} catch (ParserConfigurationException e1) {
			e1.printStackTrace();
			System.exit(0);
		} catch (SAXException e1) {
			e1.printStackTrace();
			System.exit(0);
		}


		
		String priceXML = null;
//		priceXML = "" +
//		"<PRICES>" +
//		"	<PRICE>"+
//		"		<VALUE>13520</VALUE>"+	
//		"		<UNIT>元/吨</UNIT>"+	
//		"		<TYPE>最高价</TYPE>"+	
//		"		<MARKET />"+	
//		"		<PUBLISHDATE FORMAT=\"yyyy-MM-dd\">2007-05-23</PUBLISHDATE>"+	
//		"		<MATERIEL>"+	
//		"			<ID>8a199ad612c28c810112c28e6f670002</ID>"+	
//		"			<NAME>天然橡胶</NAME>"+	
//		"			<SPEC>CNR/浓缩乳胶</SPEC>"+	
//		"		</MATERIEL>"+	
//		"		<WEBSITE>"+	
//		"			<ID>8a199ad612c27a140112c27d359d0001</ID>"+	
//		"			<NAME>中橡商務網-天然橡膠行情報價</NAME>"+	
//		"		</WEBSITE>"+	
//		"	</PRICE>"+	
//		"	<PRICE>"+	
//		"		<VALUE>12750</VALUE>"+	
//		"		<UNIT>元/吨</UNIT>"+	
//		"		<TYPE>平均价</TYPE>"+	
//		"		<MARKET />"+	
//		"		<PUBLISHDATE FORMAT=\"yyyy-MM-dd\">2007-05-24</PUBLISHDATE>"+	
//		"		<MATERIEL>"+	
//		"			<ID>8a199ad612c28c810112c28e6f670002</ID>"+	
//		"			<NAME>天然橡胶</NAME>"+	
//		"			<SPEC>CNR/浓缩乳胶</SPEC>"+	
//		"		</MATERIEL>"+	
//		"		<WEBSITE>"+	
//		"			<ID>8a199ad612c27a140112c27d359d0001</ID>"+	
//		"			<NAME>中橡商務網-天然橡膠行情報價</NAME>"+	
//		"		</WEBSITE>"+	
//		"	</PRICE>"+	
//		"</PRICES>";
		priceXML = "<PRICES>" 
				+ "<PRICE>" 
				+ "<VALUE>1300</VALUE> "
				+ "<UNIT>元/吨</UNIT>" 
				+ "<TYPE>价格</TYPE>" 
				+ "<PRODUCINGAREA />"
				+ "<MARKET>鞍山</MARKET>"
				+ "<PUBLISHDATE FORMAT=\"yyyy.MM.dd\">2008.01.15</PUBLISHDATE>"
				+ "<MATERIEL>" 
				+ "<ID>8a1998de170ff9ed011710360e3a0002</ID>"
				+ "<NAME>鐵精粉</NAME>" 
				+ "<SPEC>65%酸性干基</SPEC>"
				+ "<WEB_SPEC>65%酸性干基</WEB_SPEC>" 
				+ "</MATERIEL>"
				+ "<REMARK>到厂含税</REMARK>" 
				+ "<WEBSITE>"
				+ "<ID>8a1998de170ff9ed0117103ae9580004</ID>"
				+ "<NAME>資源網-鐵精粉行情價格</NAME>" 
				+ "</WEBSITE>" 
				+ "</PRICE>"
				+ "<PRICE>" 
				+ "<VALUE>1530</VALUE>" 
				+ "<UNIT>元/吨</UNIT>"
				+ "<TYPE>价格</TYPE>" 
				+ "<PRODUCINGAREA />"
				+ "<MARKET>唐山</MARKET>"
				+ "<PUBLISHDATE FORMAT=\"yyyy.MM.dd\">2008.01.15</PUBLISHDATE>"
				+ "<MATERIEL>" 
				+ "<ID>8a1998de170ff9ed011710356a7a0001</ID>"
				+ "<NAME>鐵精粉</NAME>" 
				+ "<SPEC>66%酸性干基</SPEC>"
				+ "<WEB_SPEC>66%酸性干基</WEB_SPEC>" 
				+ "</MATERIEL>"
				+ "<REMARK>含税</REMARK>" 
				+ "<WEBSITE>"
				+ "<ID>8a1998de170ff9ed0117103ae9580004</ID>"
				+ "<NAME>資源網-鐵精粉行情價格</NAME>" 
				+ "</WEBSITE>" 
				+ "</PRICE>"
				+ "</PRICES>";
		try {
			// 获得一个XML文件的解析器
			System.out.println(priceXML);
			DocumentBuilderFactory factory = DocumentBuilderFactory
					.newInstance();

			// 解析XML文件生成DOM文档的接口类，以便访问DOM。
			DocumentBuilder builder = factory.newDocumentBuilder();
			Document document = builder.parse(new ByteArrayInputStream(priceXML
					.getBytes("UTF-8")));
			boolean imagesXML= ImportPrice.saveOrUpdateWithElement(document.getDocumentElement(),null);
//			searchWebService.search("搜索Price", null);
		} catch (UnsupportedEncodingException e) {
			e.printStackTrace();
		} catch (SAXException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		} catch (ParserConfigurationException e) {
			e.printStackTrace();
		} catch (TransformerFactoryConfigurationError e) {
			e.printStackTrace();
		} catch (DOMException e) {
			e.printStackTrace();
		} catch (java.text.ParseException e) {
			e.printStackTrace();
		}
	}
}
