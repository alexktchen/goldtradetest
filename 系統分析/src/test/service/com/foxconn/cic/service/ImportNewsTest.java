package com.foxconn.cic.service;

import javax.xml.parsers.ParserConfigurationException;

import org.xml.sax.SAXException;

import com.foxconn.cic.importnews.ImportNews;

import junit.framework.TestCase;

public class ImportNewsTest extends TestCase {

	protected void setUp() throws Exception {
		try {
			ImportNews.init("http://10.153.26.104:8080/FoxconnCIC/");
		} catch (ParserConfigurationException e1) {
			e1.printStackTrace();
			System.exit(0);
		} catch (SAXException e1) {
			e1.printStackTrace();
			System.exit(0);
		}
	}

	public void testIsExisted() {
		String title1="巨蛋背書保證 東森損失3.18億";
		String url1="http://tw.news.yahoo.com/article/url/d/a/070822/4/j75i.html";
		boolean b=ImportNews.isExisted(title1,url1);
		assertEquals(true, b);
		
	}

	public void testSaveOrUpdateWithString() {
		fail("Not yet implemented");
	}

	public void testSaveNewsImage() {
		fail("Not yet implemented");
	}

}
