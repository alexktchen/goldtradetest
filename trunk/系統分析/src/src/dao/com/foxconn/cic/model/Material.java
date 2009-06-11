package com.foxconn.cic.model;

import java.util.Date;

import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * @hibernate.class
 */
public class Material extends BaseObject {

	/**Material XML標簽**/
	public final static String XMLTAG_MATERIAL="MATERIEL";
	/**XML標簽，描述id*/
	public final static String XMLTAG_MATERIAL_ID="ID";
	/**XML標簽，描述名稱*/
	public final static String XMLTAG_MATERIAL_NAME="NAME";
	/**XML標簽，描述規格*/
	public final static String XMLTAG_MATERIAL_SPEC="SPEC";
	
	/**Serial id*/
	private static final long serialVersionUID = -4582061802481135050L;
	/**id*/
	private String id;
	/**名稱*/
	private String name;
	/**規格*/
	private String spec;
	/**創建日期*/
	private Date createdDate;
	/**更新日期*/
	private Date updatedDate;

	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("name", name)
				.append("spec", spec).toString();
	}
	
	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (!(other instanceof Material))
			return false;
		Material castOther = (Material) other;
		return new EqualsBuilder().append(id, castOther.id).append(name,
				castOther.name).append(spec, castOther.spec).isEquals();
	}
	
	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder().append(id).append(name).append(spec)
				.toHashCode();
	}
	
	/**
	 * @hibernate.id column="id"  generator-class="uuid.hex" unsaved-value="null"
	 * @return id
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
	 * @return 規格
	 */
	public String getSpec() {
		return spec;
	}
	
	/**
	 * 
	 * @param spec 規格
	 */
	public void setSpec(String spec) {
		this.spec = spec;
	}
	
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
	
}
