package com.foxconn.cic.util;

import org.compass.core.converter.ConversionException;
import org.compass.core.converter.basic.AbstractBasicConverter;
import org.compass.core.mapping.ResourcePropertyMapping;
import org.compass.core.marshall.MarshallingContext;
import org.htmlparser.Parser;
import org.htmlparser.util.ParserException;
import org.htmlparser.visitors.TextExtractingVisitor;

public class HTMLConverter  extends AbstractBasicConverter {

	
	@Override
	public String toString(Object arg0, ResourcePropertyMapping arg1) {

		Parser parser=Parser.createParser(arg0.toString(), "UTF-8");
		
		TextExtractingVisitor visitor = new TextExtractingVisitor();

		try {
			parser.visitAllNodesWith(visitor);
		} catch (ParserException e) {
			e.printStackTrace();
		}
        String textInPage = visitor.getExtractedText();
		return textInPage;
	}

	public Object fromString(String arg0, ResourcePropertyMapping arg1) throws ConversionException {
		return null;
	}

	@Override
	protected Object doFromString(String arg0, ResourcePropertyMapping arg1,
			MarshallingContext arg2) throws ConversionException {
		return null;
	}

}
