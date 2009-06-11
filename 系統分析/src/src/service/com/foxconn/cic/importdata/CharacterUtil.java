package com.foxconn.cic.importdata;

public class CharacterUtil {

	/**
	 * 處理非法空格
	 * @param str
	 * @return
	 */
	static public String replaceInvalidWhiteSpace(String str){
		StringBuffer strBuffer=new StringBuffer(str);
		for(int i=0;i<str.length();i++){
			if(Character.isWhitespace(str.charAt(i))){
				strBuffer.deleteCharAt(i);
				strBuffer.insert(i, " ");
			}
		}
		return strBuffer.toString();
	}
//	static public String replaceSlash(String str){
//		return str.replace("\\", "\\\\");
//	}
	static public void main(String[] args){
		char c1=0x1e;
		char c2=0xb;
		StringBuffer b=new StringBuffer();
		b.append("1");
		b.append(c1);
		b.append("2");
		b.append(c2);
		System.out.println("|"+b.toString()+"|");
		String s=replaceInvalidWhiteSpace(b.toString());
		System.out.println("|"+s+"|");
		
		String title="<TITLE>google\" new\"s7\" test\"</TITLE>";
//		System.out.println(replaceQuote(title));
	}
}
