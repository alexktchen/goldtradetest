package com.foxconn.cic.webapp.view;

import java.io.BufferedOutputStream;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.view.AbstractView;

import com.foxconn.cic.model.NewsImage;

public class ImageView extends AbstractView {

	@Override
	protected void renderMergedOutputModel(Map model, HttpServletRequest request,
			HttpServletResponse response) throws Exception {

		String imagePath=model.get("imagePath").toString();
		NewsImage newsImage=(NewsImage)model.get("newsImage");
		try{
			FileInputStream hFile = new FileInputStream(imagePath+newsImage.getFilePath());
			int i=hFile.available(); 
			byte data[]=new byte[i];
			hFile.read(data); 
			hFile.close();
			setContentType("image/*");
			OutputStream toClient=response.getOutputStream(); 
			toClient.write(data); 
			toClient.close();
			}
			catch(IOException e) 
			{
			PrintWriter toClient = response.getWriter();
			response.setContentType("text/html;charset=UTF8");
			toClient.write("");
			toClient.close();
			}

	}
	public void copy(InputStream in, OutputStream out) throws IOException
    {
       out = new BufferedOutputStream(out, 4096);
       byte[] buf = new byte[4096];
       int len = in.read(buf);
       while (len != -1)
       {
          out.write(buf, 0, len);
          len = in.read(buf);
       }
       out.flush();  //最后一次读取的数据可能不到4096字节
    }

}
