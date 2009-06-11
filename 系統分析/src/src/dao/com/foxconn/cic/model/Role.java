package com.foxconn.cic.model;

import java.io.Serializable;

import org.acegisecurity.GrantedAuthority;
import org.apache.commons.lang.builder.ToStringBuilder;
import org.apache.commons.lang.builder.ToStringStyle;

/**
 * This class is used to represent available roles in the database.</p>
 *
 * <p><a href="Role.java.html"><i>View Source</i></a></p>
 *
 * @author <a href="mailto:matt@raibledesigns.com">Matt Raible</a>
 *  Version by Dan Kibler dan@getrolling.com
 *  Extended to implement Acegi GrantedAuthority interface 
 *  	by David Carter david@carter.net
 *
 * @struts.form extends="BaseForm"
 * @hibernate.class table="role"
 * 
 * @author Decorated for use with xfire webservice by <a href="mailto:mikagoeckel@codehaus.org">Mika Goeckel</a>
 * @aegis.mapping 
 */
public class Role extends BaseObject implements Serializable, GrantedAuthority {
	
	/**Serial ID*/
    private static final long serialVersionUID = 3690197650654049848L;
    /**ID*/
    private Long id;
    /**名稱*/
    private String name;
    /**描述*/
    private String description;

    /**
     * 
     */
    public Role() {}
    
    /**
     * @param name 名稱
     */
    public Role(String name) {
        this.name = name;
    }
    
    /**
     * @hibernate.id column="id" generator-class="native" unsaved-value="null"
     * @return id
     */
    public Long getId() {
        return id;
    }

    /**
     * @see org.acegisecurity.GrantedAuthority#getAuthority()
     * @return Authority
     */
    public String getAuthority() {
        return getName();
    }
    
    /**
     * @hibernate.property column="name" length="20"
     * @return 名稱
     */
    public String getName() {
        return this.name;
    }

    /**
     * @hibernate.property column="description" length="64"
     * @return 描述
     */
    public String getDescription() {
        return this.description;
    }
    /**
     * 
     * @param id id
     */
    public void setId(Long id) {
        this.id = id;
    }

    /**
     * 
     * @param name 名稱
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * 
     * @param description 描述
     */
    public void setDescription(String description) {
        this.description = description;
    }

    /**
     * @param o 比較的對象
     * @return 如果相等返回true，否則返回false
     */
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Role)) return false;

        final Role role = (Role) o;

        return !(name != null ? !name.equals(role.name) : role.name != null);

    }

    /**
     * @return hash code
     */
    public int hashCode() {
        return (name != null ? name.hashCode() : 0);
    }

    /**
     * @return 返回toString結果
     */
    public String toString() {
        return new ToStringBuilder(this, ToStringStyle.SIMPLE_STYLE)
                .append(this.name)
                .toString();
    }

}
