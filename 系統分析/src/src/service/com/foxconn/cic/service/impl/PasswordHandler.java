package com.foxconn.cic.service.impl;

import java.io.IOException;

import javax.security.auth.callback.Callback;
import javax.security.auth.callback.CallbackHandler;
import javax.security.auth.callback.UnsupportedCallbackException;

import org.apache.ws.security.WSPasswordCallback;

import com.foxconn.cic.model.User;
import com.foxconn.cic.service.UserManager;


public class PasswordHandler implements CallbackHandler {

	private UserManager userManager;
	
	public UserManager getUserManager() {
		return userManager;
	}

	public void setUserManager(UserManager userManager) {
		this.userManager = userManager;
	}

	public void handle(Callback[] callbacks) throws IOException,
			UnsupportedCallbackException {
		
		WSPasswordCallback pc = (WSPasswordCallback) callbacks[0];
		String id = pc.getIdentifer();
		User user=userManager.getUserByUsername(id);
		pc.setPassword(user.getPassword());
	}

}
