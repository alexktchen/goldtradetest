package com.foxconn.cic.model;

import java.io.Serializable;


/**
 * Base class for Model objects.  Child objects should implement toString(), 
 * equals() and hashCode();
 *
 * <p>
 * <a href="BaseObject.java.html"><i>View Source</i></a>
 * </p>
 *
 * @author <a href="mailto:matt@raibledesigns.com">Matt Raible</a>
 */
public abstract class BaseObject implements Serializable {    
	/**
	 * @return string
	 */
    public abstract String toString();
    
    /**
     * @param o 比較對象
	 * @return string
	 */
    public abstract boolean equals(Object o);
    
    /**
	 * @return hash code
	 */
    public abstract int hashCode();
}
