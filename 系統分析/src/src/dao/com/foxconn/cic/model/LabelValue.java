package com.foxconn.cic.model;

import java.io.Serializable;
import java.util.Comparator;

/**
 * A simple JavaBean to represent label-value pairs. This is most commonly used
 * when constructing user interface elements which have a label to be displayed
 * to the user, and a corresponding value to be returned to the server. One
 * example is the <code>&lt;html:options&gt;</code> tag.
 * <p/>
 * <p/>
 * Note: this class has a natural ordering that is inconsistent with equals.
 * </p>
 *
 * @see org.apache.struts.util.LabelValueBean
 */
public class LabelValue implements Comparable, Serializable {
	/**Serial id*/
    private static final long serialVersionUID = 3689355407466181430L;

    /**
     * Comparator that can be used for a case insensitive sort of
     * <code>LabelValue</code> objects.
     */
    public static final Comparator CASE_INSENSITIVE_ORDER = new Comparator() {
        public int compare(Object o1, Object o2) {
            String label1 = ((LabelValue) o1).getLabel();
            String label2 = ((LabelValue) o2).getLabel();
            return label1.compareToIgnoreCase(label2);
        }
    };


    // ----------------------------------------------------------- Constructors


    /**
     * Default constructor.
     */
    public LabelValue() {
        super();
    }

    /**
     * Construct an instance with the supplied property values.
     *
     * @param label The label to be displayed to the user.
     * @param value The value to be returned to the server.
     */
    public LabelValue(String label, String value) {
        this.label = label;
        this.value = value;
    }


    // ------------------------------------------------------------- Properties


    /**
     * The property which supplies the option label visible to the end user.
     */
    private String label = null;

    /**
     * 
     * @return lable
     */
    public String getLabel() {
        return this.label;
    }

    /**
     * 
     * @param label label
     */
    public void setLabel(String label) {
        this.label = label;
    }


    /**
     * The property which supplies the value returned to the server.
     */
    private String value = null;

    /**
     * 
     * @return value
     */
    public String getValue() {
        return this.value;
    }

    /**
     * 
     * @param value value
     */
    public void setValue(String value) {
        this.value = value;
    }


    // --------------------------------------------------------- Public Methods

    /**
     * Compare LabelValueBeans based on the label, because that's the human
     * viewable part of the object.
     * @param o the Object to be compared. 
     * @return a negative integer, zero, or a positive integer as this object is less than, equal to, or greater than the specified object. 
     * @see Comparable
     */
    public int compareTo(Object o) {
        // Implicitly tests for the correct type, throwing
        // ClassCastException as required by interface
        String otherLabel = ((LabelValue) o).getLabel();

        return this.getLabel().compareTo(otherLabel);
    }

    /**
     * Return a string representation of this object.
     * @return 返回toString結果
     */
    public String toString() {
        StringBuffer sb = new StringBuffer("LabelValue[");
        sb.append(this.label);
        sb.append(", ");
        sb.append(this.value);
        sb.append("]");
        return (sb.toString());
    }

    /**
     * LabelValueBeans are equal if their values are both null or equal.
     * @param obj 比較的對象
     * @return 如果相等返回true，否則返回false
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }

        if (!(obj instanceof LabelValue)) {
            return false;
        }

        LabelValue bean = (LabelValue) obj;
        int nil = (this.getValue() == null) ? 1 : 0;
        nil += (bean.getValue() == null) ? 1 : 0;

        if (nil == 2) {
            return true;
        } else if (nil == 1) {
            return false;
        } else {
            return this.getValue().equals(bean.getValue());
        }

    }

    /**
     * The hash code is based on the object's value.
     *@return hash code
     * @see java.lang.Object#hashCode()
     */
    public int hashCode() {
        return (this.getValue() == null) ? 17 : this.getValue().hashCode();
    }
}
