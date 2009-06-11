package com.foxconn.cic.importnews;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import javax.security.auth.callback.Callback;
import javax.security.auth.callback.CallbackHandler;
import javax.security.auth.callback.UnsupportedCallbackException;

import org.apache.ws.security.WSPasswordCallback;

import com.foxconn.cic.util.StringUtil;

/**
 * <a href="mailto:tsztelak@gmail.com">Tomasz Sztelak</a>
 *
 */
public class ClientPasswordHandler implements CallbackHandler {

	private Map passwords = new HashMap();

	public ClientPasswordHandler() {
		passwords.put("mraible", "tomcat");
        passwords.put("tomcat","tomcat");

	}

	public void handle(Callback[] callbacks) throws IOException,
			UnsupportedCallbackException {
		
		WSPasswordCallback pc = (WSPasswordCallback) callbacks[0];
		String id = pc.getIdentifer();
		pc.setPassword(StringUtil.encodePassword((String) passwords.get(id),"SHA"));
	}

}
