package com.foxconn.cic.service.impl;

import java.security.cert.X509Certificate;
import java.util.Vector;

import javax.servlet.http.HttpServletRequest;

import org.acegisecurity.context.SecurityContextHolder;
import org.acegisecurity.providers.UsernamePasswordAuthenticationToken;
import org.acegisecurity.ui.WebAuthenticationDetails;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.ws.security.WSConstants;
import org.apache.ws.security.WSSecurityEngineResult;
import org.apache.ws.security.WSUsernameTokenPrincipal;
import org.apache.ws.security.handler.WSHandlerConstants;
import org.apache.ws.security.handler.WSHandlerResult;
import org.codehaus.xfire.MessageContext;
import org.codehaus.xfire.handler.AbstractHandler;
import org.codehaus.xfire.transport.http.XFireServletController;

import sun.security.x509.X500Name;

public class ValidateUserTokenHandler extends AbstractHandler {
	private final Log log = LogFactory.getLog(ValidateUserTokenHandler.class);
	public void invoke(MessageContext context) throws Exception {
		Vector result = (Vector) context
				.getProperty(WSHandlerConstants.RECV_RESULTS);
		for (int i = 0; i < result.size(); i++) {
			WSHandlerResult res = (WSHandlerResult) result.get(i);
			for (int j = 0; j < res.getResults().size(); j++) {
				WSSecurityEngineResult secRes = (WSSecurityEngineResult) res
						.getResults().get(j);
				int action = secRes.getAction();
				// USER TOKEN
				if ((action & WSConstants.UT) > 0) {
					WSUsernameTokenPrincipal principal = (WSUsernameTokenPrincipal) secRes
							.getPrincipal();
					// Set user property to user from UT to allow response
					// encryption
					context.setProperty(WSHandlerConstants.ENCRYPTION_USER,
							principal.getName());
//					log.debug("User : " + principal.getName()
//							+ " password : " + principal.getPassword() + "\n");
					
					// Set the Acegi Security Context
					HttpServletRequest request=XFireServletController.getRequest();
					WebAuthenticationDetails details = new WebAuthenticationDetails(request);
					UsernamePasswordAuthenticationToken auth = new UsernamePasswordAuthenticationToken(
							principal.getName(), principal.getPassword());
					auth.setDetails(details);
					SecurityContextHolder.getContext().setAuthentication(auth);
				}
				// SIGNATURE
				if ((action & WSConstants.SIGN) > 0) {
					X509Certificate cert = secRes.getCertificate();
					X500Name principal = (X500Name) secRes.getPrincipal();
					// Do something whith cert
					System.out.print("Signature for : "
							+ principal.getCommonName());
				}
			}
		}
	}
}
