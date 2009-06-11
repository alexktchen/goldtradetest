package com.foxconn.cic.model;

import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * @hibernate.class table = "catalog_type"
 */
public class CatalogType extends BaseObject{

	/**
	 * 
	 */
	private static final long serialVersionUID = -4202597922840690347L;
	
	/**id*/
	private Long id;
	
	/**名稱*/
	private String name;
	
	/**
     * @return 返回toString結果
     */
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("name", name)
				.toString();
	}
	
	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	public boolean equals(final Object other) {
		if (this == other)
			return true;
		if (!(other instanceof CatalogType))
			return false;
		CatalogType castOther = (CatalogType) other;
		return new EqualsBuilder().append(id, castOther.id).append(name,
				castOther.name).isEquals();
	}
	
	/**
     * @return hash code
     */
	public int hashCode() {
		return new HashCodeBuilder(17, 37).append(id).append(name).toHashCode();
	}
	/**
	 * @hibernate.id generator-class = "sequence" unsaved-value="null"
	 * @hibernate.generator-param  value = "catalog_type_sequence" name = "sequence"
	 * @return id
	 */
	public Long getId() {
		return id;
	}
	/**
	 * @hibernate.property
	 * @return 名稱
	 */
	public String getName() {
		return name;
	}
	
	/**
	 * 
	 * @param id id
	 */
	public void setId(Long id) {
		this.id = id;
	}
	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param name 名稱
	 */
	public void setName(String name) {
		this.name = name;
	}
}
