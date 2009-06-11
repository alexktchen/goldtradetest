package com.foxconn.cic.webapp.view;

import java.io.PrintWriter;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.view.AbstractView;

public class TextView extends AbstractView {

	@Override
	protected void renderMergedOutputModel(Map model, HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String text=(String)model.get("text");
		SimpleDateFormat format=new SimpleDateFormat("yyyyMMdd hh:mm");
		
		PrintWriter output=response.getWriter();
		response.setContentType("text/plain;charset=UTF-8");
		output.println("# "+format.format(new Date()));
		output.print(text);
		output.close();
	}

}
