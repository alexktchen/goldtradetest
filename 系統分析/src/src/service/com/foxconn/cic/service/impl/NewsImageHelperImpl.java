package com.foxconn.cic.service.impl;

import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.commons.vfs.FileSystemException;
import org.apache.commons.vfs.FileSystemManager;
import org.apache.commons.vfs.FileSystemOptions;
import org.apache.commons.vfs.VFS;
import org.apache.commons.vfs.provider.ftp.FtpFileSystemConfigBuilder;

import com.foxconn.cic.model.News;
import com.foxconn.cic.model.NewsConstants;
import com.foxconn.cic.model.NewsImage;
import com.foxconn.cic.service.NewsImageHelper;
import com.foxconn.cic.service.NewsImageManager;
import com.foxconn.cic.service.NewsManager;

public class NewsImageHelperImpl implements NewsImageHelper {

	private final Log log = LogFactory.getLog(NewsImageHelperImpl.class);
	
	private NewsManager newsManager;
	private NewsImageManager newsImagemanager;
    
    private FileSystemManager fileSystemManager;
    
    private FileSystemManager getFileSystemManager(){
    	if(fileSystemManager==null){
    		FileSystemOptions opts = new FileSystemOptions();
			FtpFileSystemConfigBuilder.getInstance().setDataTimeout(opts, 60000);
			FtpFileSystemConfigBuilder.getInstance().setPassiveMode(opts, true);
			try {
				fileSystemManager= VFS.getManager();
			} catch (FileSystemException e) {
				e.printStackTrace();
			}
    	}
    	return fileSystemManager;
    }
	public NewsManager getNewsManager() {
		return newsManager;
	}

	public void setNewsManager(NewsManager newsManager) {
		this.newsManager = newsManager;
	}

	public NewsImageManager getNewsImagemanager() {
		return newsImagemanager;
	}

	public void setNewsImagemanager(NewsImageManager newsImagemanager) {
		this.newsImagemanager = newsImagemanager;
	}


	synchronized public boolean saveNewsImage(String id, byte[] bytes) {		
		NewsImage image=newsImagemanager.getNewsImage(id);
		News news=newsManager.getNews(image.getNewsId().toString());
		Date createdDate=news.getCreatedDate();
		SimpleDateFormat format=new SimpleDateFormat("yyyy.MM");
		String extension=image.getUrl().trim().substring(image.getUrl().lastIndexOf("."));
		if(extension.length()>4||extension.length()==0)extension=".img";
		String filename=image.getPosition()+extension;
		String path=news.getWebsite().getId()+"/"+format.format(createdDate)+"/"+ news.getId()+"/";

		log.debug("News ID:"+news.getId());
		log.debug("News Title:"+news.getTitle());
		log.debug("NewsImage ID:"+image.getId());
		log.debug("NewsImage Position:"+image.getPosition());
		log.debug("NewsImage URL:"+image.getUrl());
		
		// 獲得圖片的長度和寬度
		if (image.getType() == NewsConstants.NEWSIMAGE_TYPE_NORMAL) {//當圖片為一般類型時判斷其寬度和高度
			ByteArrayInputStream in = new ByteArrayInputStream(bytes);
			BufferedImage img = null;
			try {
				img = javax.imageio.ImageIO.read(in);
			} catch (IOException e2) {
				e2.printStackTrace();
			}
			if (img != null) {
				int imageWidth = img.getWidth(null);
				int imageHeight = img.getHeight(null);

				image.setWidth(imageWidth);
				image.setHeight(imageHeight);
				log.debug("NewsImage Width:" + imageWidth);
				log.debug("NewsImage Height:" + imageHeight);
			}
		}
		
		try {			
			//使用FTP方式存儲圖片
//			FileObject fileObject=null;
//			OutputStream fileout=null;
//			FileSystemOptions opts = new FileSystemOptions();
//			FtpFileSystemConfigBuilder.getInstance().setDataTimeout(opts, 60000);
//			FtpFileSystemConfigBuilder.getInstance().setPassiveMode(opts, true);
//			fileObject=getFileSystemManager().resolveFile(newsImagemanager.getFilePath()+path+filename,opts);
//			fileObject.createFile();
//			fileout = fileObject.getContent().getOutputStream();
			
			File fileFolder=new File(newsImagemanager.getFilePath()+path);
			if(!fileFolder.exists())fileFolder.mkdirs();
			File file=new File(newsImagemanager.getFilePath()+path+filename);
			file.createNewFile();
			FileOutputStream fileout=new FileOutputStream(file);
			
			fileout.write(bytes);
			image.setFilePath(path+filename);
			newsImagemanager.saveNewsImage(image);
			log.debug("NewsImage Save:"+path+filename);
			
			fileout.close();
//			fileObject.close();			
		} catch (FileSystemException e1) {
			e1.printStackTrace();
			return false;
		} catch (IOException e) {
			e.printStackTrace();
			return false;
		}
		return true;
	}

}
