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
 * @hibernate.class table = "exchange_rate"
 * @aegis.mapping
 */
@Searchable(alias="exchangerate")
public class ExchangeRate extends BaseObject{

	/**serial id*/
	private static final long serialVersionUID = -7427488659043338888L;

	/**id*/
	@SearchableId
	private Long id;
	
	/**單位貨幣*/
	private String unitCurrency;
	
	/**價格貨幣*/
	private String priceCurrency;
	
	/**數量*/
	private Integer amout;
	
	/**價格類型*/
	private String priceType;
	
	/**價格*/
	private Float price;
	
	/**標價類型：1為直接標價法；2為間接標價法*/
	private String quotationType;
	
	/**發行者*/
	private String publisher;
	
	/**發行時間*/
	private Date publishDate;
	
	/***/
	private Date createdDate;
	
	/***/
	private Date updatedDate;
	
	/***/
	private Website website;

	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append(
				"unitCurrency", unitCurrency).append("priceCurrency",
				priceCurrency).append("amout", amout).append("priceType",
				priceType).append("price", price).append("quotationType",
				quotationType).append("publisher", publisher).append(
				"publishDate", publishDate).toString();
	}

	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (!(other instanceof ExchangeRate))
			return false;
		ExchangeRate castOther = (ExchangeRate) other;
		return new EqualsBuilder().append(id, castOther.id).append(
				unitCurrency, castOther.unitCurrency).append(priceCurrency,
				castOther.priceCurrency).append(amout, castOther.amout).append(
				priceType, castOther.priceType).append(price, castOther.price)
				.append(quotationType, castOther.quotationType).append(
						publisher, castOther.publisher).append(publishDate,
						castOther.publishDate).isEquals();
	}

	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder().append(id).append(unitCurrency).append(
				priceCurrency).append(amout).append(priceType).append(price)
				.append(quotationType).append(publisher).append(publishDate)
				.toHashCode();
	}

	/**
	 * @hibernate.property
	 * @return unitCurrency 單位貨幣
	 */
	@SearchableProperty
	@SearchableMetaData(name="unitcurrency",index=Index.UN_TOKENIZED)
	public String getUnitCurrency() {
		return unitCurrency;
	}

	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param unitCurrency 單位貨幣
	 */
	public void setUnitCurrency(String unitCurrency) {
		this.unitCurrency = unitCurrency;
	}

	/**
	 * @hibernate.property
	 * @return 價格貨幣
	 */
	@SearchableProperty
	@SearchableMetaData(name="pricecurrency",index=Index.UN_TOKENIZED)
	public String getPriceCurrency() {
		return priceCurrency;
	}

	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param priceCurrency 價格貨幣
	 */
	public void setPriceCurrency(String priceCurrency) {
		this.priceCurrency = priceCurrency;
	}

	/**
	 * @hibernate.property
	 * @return 數量
	 */
	@SearchableProperty
	@SearchableMetaData(name="amout",index=Index.UN_TOKENIZED)
	public Integer getAmout() {
		return amout;
	}

	/**
	 * 
	 * @param amout 數量
	 */
	public void setAmout(Integer amout) {
		this.amout = amout;
	}

	/**
	 * @hibernate.property
	 * @return 價格類型
	 */
	@SearchableProperty
	@SearchableMetaData(name="pricetype",index=Index.UN_TOKENIZED)
	public String getPriceType() {
		return priceType;
	}

	/**
	 * 價格類型
	 * @param priceType 價格類型
	 */
	public void setPriceType(String priceType) {
		this.priceType = priceType;
	}

	/**
	 * @hibernate.property
	 * @return 價格
	 */
	@SearchableProperty
	@SearchableMetaData(name="price",index=Index.UN_TOKENIZED)
	public Float getPrice() {
		return price;
	}

	/**
	 * @param price 價格
	 */
	public void setPrice(Float price) {
		this.price = price;
	}

	/**
	 * @hibernate.property
	 * @return 報價類型：1為直接標價法；2為間接標價法
	 */
	@SearchableProperty
	@SearchableMetaData(name = "quotationtype",index=Index.UN_TOKENIZED)
	public String getQuotationType() {
		return quotationType;
	}

	/**
	 * @param quotationType 報價類型：1為直接標價法；2為間接標價法
	 */
	public void setQuotationType(String quotationType) {
		this.quotationType = quotationType;
	}

	/**
	 * @hibernate.property
	 * @return 發布者
	 */
	@SearchableProperty
	@SearchableMetaData(name="publisher",index=Index.UN_TOKENIZED)
	public String getPublisher() {
		return publisher;
	}

	/**
	 * 發布者
	 * @param publisher 發布者
	 */
	public void setPublisher(String publisher) {
		this.publisher = publisher;
	}

	/**
	 * @hibernate.property type = "timestamp"
	 * @return 發布日期
	 */
	@SearchableProperty
	@SearchableMetaData(name = "publishdate", format = "yyyyMMdd||yyyyMMdd HH:mm")
	public Date getPublishDate() {
		return publishDate;
	}

	/**
	 * 
	 * @param publishDate 發布日期
	 */
	public void setPublishDate(Date publishDate) {
		this.publishDate = publishDate;
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
	 * @hibernate.id generator-class = "sequence" unsaved-value="null"
	 * @hibernate.generator-param
	 *   value = "exchangerate_sequence"
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

}
