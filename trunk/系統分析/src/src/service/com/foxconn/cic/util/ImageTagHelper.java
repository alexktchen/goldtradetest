package com.foxconn.cic.util;

import java.lang.reflect.InvocationTargetException;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;
import java.util.Map.Entry;

import org.apache.commons.beanutils.BeanUtils;
import org.apache.commons.lang.StringUtils;
import org.htmlparser.Parser;
import org.htmlparser.util.NodeList;
import org.htmlparser.util.ParserException;

import com.foxconn.cic.model.News;
import com.foxconn.cic.model.NewsConstants;
import com.foxconn.cic.model.NewsImage;
import com.foxconn.cic.model.NewsParser;

public class ImageTagHelper {
	private ImageTagUrlModifyingVisitor modify;
	private ImageTagUrlRestoreVisitor restoreWithId;
	private ImageTagUrlRestoreVisitor restoreWithFilePath;

	public void setRestoreWithFilePath(ImageTagUrlRestoreVisitor restoreWithFilePath) {
		this.restoreWithFilePath = restoreWithFilePath;
	}
	public void setModify(ImageTagUrlModifyingVisitor modify) {
		this.modify = modify;
	}
	public void setRestore(ImageTagUrlRestoreVisitor restore) {
		this.restoreWithId = restore;
	}
	public News modify(News news){
		Parser parser = Parser.createParser(news.getContent(), null);
		NodeList list;
		try {
			//使用HtmlParser對新聞内容進行解析,
			//替換新聞内容中img標簽中的src屬性
			list = parser.parse(null);
			list.visitAllNodesWith(modify);
			String result = list.toHtml();//
			news.setContent(result);//設置修改后的新聞内容
			//設施修改后的圖片内容
			Set<NewsImage> images=new HashSet<NewsImage>();			
			Map<Integer, String> imageMap = modify.getImageMap();
			Set<Entry<Integer, String>> entries=imageMap.entrySet();
			for (Entry<Integer, String> entry : entries) {
				NewsImage image=new NewsImage();
				image.setPosition(entry.getKey());
				image.setUrl(entry.getValue());
				String newsUrl=news.getUrl();
				if(!StringUtils.isEmpty(news.getBaseUrl())){
					newsUrl=news.getBaseUrl();
				}
				image.setFixedUrl(NewsParser.assembleUrl(newsUrl, image.getUrl()));
				images.add(image);
			}
			if(news.getImages()!=null){
				for (NewsImage image : news.getImages()) {
					Integer position = Integer.valueOf(images.size());
					image.setPosition(position);
					images.add(image);
				}
			}
			news.setImages(images);
		} catch (ParserException e) {
			e.printStackTrace();
			return null;
		}
		return news;
	}

	public News restore(News news,String urlPrefix){
		restoreWithId.setUrlPrefix(urlPrefix);
		Parser parser = Parser.createParser(news.getContent(), null);
		NodeList list;
		try {
			//使用HtmlParser對新聞内容進行解析,
			//替換新聞内容中img標簽中的src屬性
			list = parser.parse(null);
			restoreWithId.setNews(news);
			list.visitAllNodesWith(restoreWithId);
			String result = list.toHtml();//
			news.setContent(result);//設置修改后的新聞内容
			insertImageHtml(news, restoreWithId);
		} catch (ParserException e) {
			e.printStackTrace();
			return null;
		}
		return news;
	}
	public News restoreWithFilePath(News news,String urlPrefix){
		restoreWithFilePath.setUrlPrefix(urlPrefix);
		Parser parser = Parser.createParser(news.getContent(), null);
		NodeList list;
		try {
			//使用HtmlParser對新聞内容進行解析,
			//替換新聞内容中img標簽中的src屬性
			list = parser.parse(null);
			restoreWithFilePath.setNews(news);
			list.visitAllNodesWith(restoreWithFilePath);
			String result = list.toHtml();//
			news.setContent(result);//設置修改后的新聞内容
			insertImageHtml(news, restoreWithFilePath);
		} catch (ParserException e) {
			e.printStackTrace();
			return null;
		}
		return news;
	}
	
	
	public void insertImageHtml(News news,ImageTagUrlRestoreVisitor visitor) {
		Set<NewsImage> images=news.getImages();
		StringBuffer imageHtml=new StringBuffer();
		for (NewsImage image : images) {
			if(image.getType()!=null && image.getType()!=NewsConstants.NEWSIMAGE_TYPE_NORMAL){
				String title=image.getTitle();
				if(title==null||title.trim().equals("")){
					title=image.getFilePath();
				}
				try {
					String parameter= BeanUtils.getProperty(image, visitor.getPropertyName());
					String t="<a target=\"_blank\" href=\""+visitor.getUrlPrefix()+ parameter+"\">"+title+"</><br/>";
					imageHtml.append(t);
				} catch (IllegalAccessException e) {
					e.printStackTrace();
				} catch (InvocationTargetException e) {
					e.printStackTrace();
				} catch (NoSuchMethodException e) {
					e.printStackTrace();
				}
			}
		}
		if(imageHtml.length()>0){
			imageHtml.insert(0, "<p>");
			imageHtml.append("</p>");
		}
		news.setContent(news.getContent()+ imageHtml.toString());
	}	
	
}
