package com.foxconn.cic.model;

import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * @hibernate.class 
 */
public class Keyword extends BaseObject implements IKeyword {

	/**
	 * 
	 */
	private static final long serialVersionUID = -3682632548459255754L;
	
	/**id*/
	private Long id;
	/**名稱*/
	private String name;
	
	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (this == other)
			return true;
		if (!(other instanceof Keyword))
			return false;
		Keyword castOther = (Keyword) other;
		return new EqualsBuilder().append(name, castOther.name).isEquals();
	}

	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder(17, 37).append(name).toHashCode();
	}

	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("name", name)
				.toString();
	}

	/**
	 *@hibernate.id column="id"  generator-class="sequence" unsaved-value="null"
	 * @hibernate.generator-param name ="sequence"  value = "keyword_sequence" 
	 * @return id
	 */
	public Long getId() {
		return id;
	}
	
	/**
     * @hibernate.property unique = "true"  length="100"
     * @hibernate.index 
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
