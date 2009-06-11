package com.foxconn.cic.model;

import java.util.Date;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;
import org.compass.annotations.Index;
import org.compass.annotations.Searchable;
import org.compass.annotations.SearchableComponent;
import org.compass.annotations.SearchableId;
import org.compass.annotations.SearchableMetaData;
import org.compass.annotations.SearchableProperty;

/**
 * @hibernate.class
 * @aegis.mapping
 */
@Searchable(alias="price")
public class Price extends BaseObject{

	/**Serial ID*/
	private static final long serialVersionUID = 7378326827204646717L;
	
	/**ID*/
	@SearchableId
	private Long id;
	/**原物料*/
	private Material material;
	/**發布日期*/
	private Date publishDate;
	/**計量單位*/
	private String unit;
	/**價格值*/
	private String value;
	/**報價類型*/
	private String type;
	/**產地*/
	private String producingArea;
	/**交易市場*/
	private String market;
	/**備注*/
	private String remark;
	/**網站*/
	private Website website;
	/**創建日期*/
	private Date createdDate;
	/**更新日期*/
	private Date updatedDate;
	
	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("material",
				material).append("publishDate", publishDate).append("unit",
				unit).append("value", value).append("type", type).append(
				"website", website).toString();
	}
	
	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (!(other instanceof Price))
			return false;
		Price castOther = (Price) other;
		return new EqualsBuilder().append(id, castOther.id).append(publishDate,
				castOther.publishDate).append(unit, castOther.unit).append(
				value, castOther.value).append(type, castOther.type).isEquals();
	}
	
	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder().append(id).append(publishDate)
				.append(unit).append(value).append(type).toHashCode();
	}
	
	/**
	 * @hibernate.id generator-class = "sequence" unsaved-value="null"
	 * @hibernate.generator-param
	 *   value = "price_sequence"
	 *   name = "sequence"
	 * @return id
	 */
	public Long getId() {
		return id;
	}
	
	/**
	 * 
	 * @param id id
	 */
	public void setId(Long id) {
		this.id = id;
	}
	
	/**
	 * @hibernate.many-to-one cascade="none" class =
	 *                        "com.foxconn.cic.model.Material" outer-join="true"
	 * column = "material_id"
	 * @return 原物料
	 */
	@SearchableComponent (refAlias = "material")
	public Material getMaterial() {
		return material;
	}
	
	/**
	 * 
	 * @param material 原物料
	 */
	public void setMaterial(Material material) {
		this.material = material;
	}
	
	/**
	 * @hibernate.property
	 * @return 價格值
	 */
	@SearchableProperty
	@SearchableMetaData(name="value",index=Index.UN_TOKENIZED)
	public String getValue() {
		return value;
	}
	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param value 價格值
	 */
	public void setValue(String value) {
		this.value = value;
	}
	/**
	 * @hibernate.property
	 * @return 價格類型
	 */
	@SearchableProperty
	@SearchableMetaData(name="type",index=Index.UN_TOKENIZED)
	public String getType() {
		return type;
	}
	
	/**
	 * 
	 * @param type 價格類型
	 */
	public void setType(String type) {
		this.type = type;
	}
	
	/**
	 * @hibernate.property type = "timestamp"
	 * @return 發布時間
	 */
	@SearchableProperty
	@SearchableMetaData(name = "publishdate", format = "yyyyMMdd")
	public Date getPublishDate() {
		return publishDate;
	}
	
	/**
	 * 
	 * @param publishDate 發布時間
	 */
	public void setPublishDate(Date publishDate) {
		this.publishDate = publishDate;
	}
	/**
	 * @hibernate.property
	 * @return 計量單位
	 */
	@SearchableProperty
	@SearchableMetaData(name="unit",index=Index.UN_TOKENIZED)
	public String getUnit() {
		return unit;
	}
	
	/**
	 * 
	 * @param unit 計量單位
	 */
	public void setUnit(String unit) {
		this.unit = unit;
	}
	
	/**
	 * @hibernate.many-to-one cascade="none" class =
	 *                        "com.foxconn.cic.model.Website" outer-join="true"
	 * column = "website_id"
	 * @return 網站
	 */
	@SearchableComponent (refAlias = "website")
	public Website getWebsite() {
		return website;
	}
	
	/**
	 * 
	 * @param website 網站
	 */
	public void setWebsite(Website website) {
		this.website = website;
	}
	/**
	 * @hibernate.property type = "timestamp"
	 * @return 創建日期
	 */
	@SearchableProperty
	@SearchableMetaData(name = "createddate",format = "yyyyMMdd HH:mm")
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
	@SearchableProperty
	@SearchableMetaData(name = "updateddate", format = "yyyyMMdd HH:mm")
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
	 * @hibernate.property
	 * @return 交易市場
	 */
	@SearchableProperty
	@SearchableMetaData(name="market",index=Index.UN_TOKENIZED)
	public String getMarket() {
		return market;
	}
	
	/**
	 * 
	 * @param market 交易市場
	 */
	public void setMarket(String market) {
		this.market = market;
	}
	
	/**
	 * @hibernate.property
	 * @return 備注
	 */
	@SearchableProperty
	@SearchableMetaData(name="remark",index=Index.UN_TOKENIZED)
	public String getRemark() {
		return remark;
	}
	
	/**
	 * 
	 * @param remark 備注
	 */
	public void setRemark(String remark) {
		this.remark = remark;
	}
	
	/**
	 * @hibernate.property
	 * @return 產地
	 */
	@SearchableProperty
	@SearchableMetaData(name="producingarea",index=Index.UN_TOKENIZED)
	public String getProducingArea() {
		return producingArea;
	}
	
	/**
	 * 
	 * @param producingArea 產地
	 */
	public void setProducingArea(String producingArea) {
		this.producingArea = producingArea;
	}
}
