package com.foxconn.cic.model;

import java.util.Date;
import java.util.Set;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * 引用者<br/>
 * 
 * @hibernate.class
 * @aegis.mapping
 */
public class Quoter extends BaseObject {

	/**Serial ID*/
	private static final long serialVersionUID = -7597057074076649616L;
	/**ID*/
	private String id;
	/**名稱*/
	private String name;
	/**引用者縮寫*/
	private String key;
	/**引用的網站*/
	private Set<Website> websites;
	/**創建日期*/
	private Date createdDate;
	/**更新日期*/
	private Date updatedDate;

	/**
	 * @hibernate.property type = "timestamp"
	 * @return 創建日期
	 */
	public Date getCreatedDate() {
		return createdDate;
	}
	
	/**
	 * 
	 * @param createdDate 創建日期
	 */
	public void setCreatedDate(Date createdDate) {
		this.createdDate = createdDate;
	}

	/**
	 * @hibernate.property type = "timestamp"
	 * @return 更新日期
	 */
	public Date getUpdatedDate() {
		return updatedDate;
	}

	/**
	 * 
	 * @param updatedDate 更新日期
	 */
	public void setUpdatedDate(Date updatedDate) {
		this.updatedDate = updatedDate;
	}

	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("name", name)
				.append("key", key).toString();
	}

	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (!(other instanceof Quoter))
			return false;
		Quoter castOther = (Quoter) other;
		return new EqualsBuilder().append(id, castOther.id).append(name,
				castOther.name).append(key, castOther.key).isEquals();
	}

	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder().append(id).append(name).append(key)
				.toHashCode();
	}

	/**
	 * @hibernate.id column="id" generator-class="uuid.hex" unsaved-value="null"
	 * @return id
	 * 
	 */
	public String getId() {
		return id;
	}

	/**
	 * 
	 * @param id id
	 */
	public void setId(String id) {
		this.id = id;
	}

	/**
	 * @hibernate.property
	 * @return 名稱
	 */
	public String getName() {
		return name;
	}

	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param name 名稱
	 */
	public void setName(String name) {
		this.name = name;
	}

	/**
	 * @hibernate.property
	 * @return 引用者縮寫
	 */
	public String getKey() {
		return key;
	}

	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param key 引用者縮寫
	 */
	public void setKey(String key) {
		this.key = key;
	}

	/**
	 * @hibernate.set table="website_quoter" cascade="save-update" lazy="false"
	 * @hibernate.collection-key column="quoter_id"
	 * @hibernate.collection-many-to-many class="com.foxconn.cic.model.Website"
	 *                                    column="website_id"
	 * @return 引用的網站
	 */
	public Set<Website> getWebsites() {
		return websites;
	}

	/**
	 * 
	 * @param websites 引用的網站
	 */
	public void setWebsites(Set<Website> websites) {
		this.websites = websites;
	}
}
