package com.foxconn.cic.importdata;

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

public class TestImportInterestRate {

	/**
	 * @param args
	 */
	public static void main(String[] args) {

		try {
			ImportInterestRate.init("http://localhost:8080/FoxconnCIC/");
		} catch (ParserConfigurationException e1) {
			e1.printStackTrace();
			System.exit(0);
		} catch (SAXException e1) {
			e1.printStackTrace();
			System.exit(0);
		}

		String rateXML = null;
		rateXML = ""
				+ "<INTEREST_RATES>"
				+ "	<INTEREST_RATE>"
				+ "		<NAME>外幣存款利率</NAME> "
				+ "  		<CURRENCY>USD</CURRENCY> "
				+ "  		<TYPE>定期存款一年</TYPE> "
				+ "  		<TIME_PERIOD>1y</TIME_PERIOD> "
				+ "  		<RATE>5.00</RATE> "
				+ "  		<PUBLISHER>萬泰商業銀行</PUBLISHER> "
				+ "  		<PUBLISHDATE FORMAT=\"yyyy/MM/dd\">2007/07/10</PUBLISHDATE>"
				+ " 		<WEBSITE>"
				+ "  			<ID>8a199ae813715f2601137523c72d0002</ID> "
				+ "  			<NAME>萬泰商業銀行-外幣存款利率</NAME> "
				+ "  		</WEBSITE>"
				+ "  	</INTEREST_RATE>"
				+ " 	<INTEREST_RATE>"
				+ "  		<NAME>外幣存款利率</NAME> "
				+ "  		<CURRENCY>THB</CURRENCY> "
				+ "  		<TYPE>定期存款一年</TYPE> "
				+ "  		<TIME_PERIOD>1y</TIME_PERIOD> "
				+ "  		<RATE>0.50</RATE> "
				+ "  		<PUBLISHER>萬泰商業銀行</PUBLISHER> "
				+ "  		<PUBLISHDATE FORMAT=\"yyyy/MM/dd\">2007/07/10</PUBLISHDATE> "
				+ " 		<WEBSITE>"
				+ "  			<ID>8a199ae813715f2601137523c72d0002</ID> "
				+ "  			<NAME>萬泰商業銀行-外幣存款利率</NAME> "
				+ "  		</WEBSITE>"
				+ "  	</INTEREST_RATE>"
				+ " 	<INTEREST_RATE>"
				+ "  		<NAME>外幣存款利率</NAME> "
				+ "  		<CURRENCY>SGD</CURRENCY> "
				+ "  		<TYPE>定期存款一年</TYPE> "
				+ "  		<TIME_PERIOD>1y</TIME_PERIOD> "
				+ "  		<RATE>0.50</RATE> "
				+ "  		<PUBLISHER>萬泰商業銀行</PUBLISHER> "
				+ "  		<PUBLISHDATE FORMAT=\"yyyy/MM/dd\">2007/07/10</PUBLISHDATE> "
				+ " 		<WEBSITE>"
				+ "  			<ID>8a199ae813715f2601137523c72d0002</ID> "
				+ "  		<NAME>萬泰商業銀行-外幣存款利率</NAME> " + "  		</WEBSITE>"
				+ "  	</INTEREST_RATE>" + "</INTEREST_RATES>";

		try {
			// 获得一个XML文件的解析器
			System.out.println(rateXML);
			DocumentBuilderFactory factory = DocumentBuilderFactory
					.newInstance();

			// 解析XML文件生成DOM文档的接口类，以便访问DOM。

			DocumentBuilder builder = factory.newDocumentBuilder();
			Document document = builder.parse(new ByteArrayInputStream(rateXML
					.getBytes("UTF-8")));
			boolean b = ImportInterestRate.saveOrUpdateWithElement(document
					.getDocumentElement(), null);

			// searchWebService.search("搜索利率", null);

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
