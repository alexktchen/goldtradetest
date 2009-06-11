package com.foxconn.cic.service.advice;

import java.lang.reflect.Method;

import com.foxconn.cic.model.ExchangeRate;
import com.foxconn.cic.model.UserActivityLogConstants;

public class ExchangeRateAdvice extends UserActivityAdvice{

	@Override
	public String getActivity(Object returnValue, Method method, Object[] args,
			Object target) {
		if(method.getName().equals("getExchangeRate")){
			return UserActivityLogConstants.ACTIVITY_EXCHANGERATE_BROWSE;
		}else if(method.getName().equals("search")){
			return UserActivityLogConstants.ACTIVITY_EXCHANGERATE_SEARCH;
		}
		return method.getName();
	}

	@Override
	public String getMetaData(Object returnValue, Method method, Object[] args,
			Object target) {
		if(method.getName().equals("getExchangeRate")){
			if (returnValue != null && returnValue instanceof ExchangeRate) {
				return ((ExchangeRate) returnValue).getId().toString();
			}
		}else if(method.getName().equals("search")){
			if(args[0]!=null){
				return args[0].toString();
			}
		}
		if(returnValue!=null){
			return returnValue.toString();
		}else {
			return "";
		}
	}

}
