package com.foxconn.cic.importdata;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.UnsupportedEncodingException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.TransformerFactoryConfigurationError;

import org.w3c.dom.DOMException;
import org.w3c.dom.Document;
import org.xml.sax.SAXException;

import com.foxconn.cic.importnews.ImportNews;

import junit.framework.TestCase;

public class ImportNewsTestCase extends TestCase {

	protected void setUp() throws Exception {
		super.setUp();
		try {
			ImportNews.init("http://localhost:8080/FoxconnCIC/");
		} catch (ParserConfigurationException e1) {
			e1.printStackTrace();
			System.exit(0);
		} catch (SAXException e1) {
			e1.printStackTrace();
			System.exit(0);
		}
	}

	protected void tearDown() throws Exception {
		super.tearDown();
	}

	public void testSaveOrUpdateWithElement() throws Exception {
		File[] newsFiles = new File[] {
				new File("test/service/com/foxconn/cic/importdata/xml/News001.xml"),
				new File("test/service/com/foxconn/cic/importdata/xml/News002.xml"),
				new File("test/service/com/foxconn/cic/importdata/xml/News003.xml"),//標題中有全角空格
				new File("test/service/com/foxconn/cic/importdata/xml/News004.xml"),
				new File("test/service/com/foxconn/cic/importdata/xml/News005.xml"),
				new File("test/service/com/foxconn/cic/importdata/xml/News006.xml"),
				new File("test/service/com/foxconn/cic/importdata/xml/News007.xml"),
				new File("test/service/com/foxconn/cic/importdata/xml/News008.xml") };
		for (File file : newsFiles) {
			System.out.println("======================================");
			FileInputStream in = new FileInputStream(file);
			try {
				// 获得一个XML文件的解析器
				DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();

				// 解析XML文件生成DOM文档的接口类，以便访问DOM。

				DocumentBuilder builder = factory.newDocumentBuilder();
				Document document = builder.parse(in);
				String imagesXML= ImportNews.saveOrUpdateWithElement(document.getDocumentElement());
				if (imagesXML != null) {
					System.out.println(imagesXML);
				}
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
}
