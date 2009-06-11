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
 * @hibernate.class table="interest_rate"
 * @aegis.mapping
 */
@Searchable(alias="interestrate")
public class InterestRate extends BaseObject{

	/**Serial ID*/
	private static final long serialVersionUID = -7494693570082907883L;
	
	/**id*/
	@SearchableId
	private Long id;
	/**名稱*/
	private String name;
	/**貨幣，如：USD,JPY*/
	private String currency;
	/**存款時間，如：1y為1年、1M為1個月*/
	private String timePeriod;
	/**存款類型，如：活期存款、定期存款一年、定期存款九月等*/
	private String type;
	/**利率*/
	private Float rate;
	/**發布者*/
	private String publisher;
	/**發布時間*/
	private Date publishDate;
	/**創建時間*/
	private Date createdDate;
	/**更新時間*/
	private Date updatedDate;
	/**網站*/
	private Website website;

	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("name", name)
				.append("currency", currency).append("timePeriod", timePeriod)
				.append("publisher", publisher).append("publishDate",
						publishDate).toString();
	}

	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (!(other instanceof InterestRate))
			return false;
		InterestRate castOther = (InterestRate) other;
		return new EqualsBuilder().append(id, castOther.id).append(name,
				castOther.name).append(currency, castOther.currency).append(
				timePeriod, castOther.timePeriod).append(publisher,
				castOther.publisher).append(publishDate, castOther.publishDate)
				.isEquals();
	}
	
	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder().append(id).append(name).append(currency)
				.append(timePeriod).append(publisher).append(publishDate)
				.toHashCode();
	}

	/**
	 * @hibernate.id generator-class = "sequence" unsaved-value="null"
	 * @hibernate.generator-param value = "interestrate_sequence" name = "sequence"
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
	 * @hibernate.property
	 * @return 名稱
	 */
	@SearchableProperty
	@SearchableMetaData(name="name",index=Index.UN_TOKENIZED)
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
	 * @return 貨幣
	 */
	@SearchableProperty
	@SearchableMetaData(name="currency",index=Index.UN_TOKENIZED)
	public String getCurrency() {
		return currency;
	}

	/**
	 * 
	 * @param currency 貨幣
	 */
	public void setCurrency(String currency) {
		this.currency = currency;
	}

	/**
	 * @hibernate.property
	 * @return 存款時間段
	 */
	@SearchableProperty
	@SearchableMetaData(name="timeperiod",index=Index.UN_TOKENIZED)
	public String getTimePeriod() {
		return timePeriod;
	}

	/**
	 * 
	 * @param timePeriod 存款時間段
	 */
	public void setTimePeriod(String timePeriod) {
		this.timePeriod = timePeriod;
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
	 * 
	 * @param publisher 發布者
	 */
	public void setPublisher(String publisher) {
		this.publisher = publisher;
	}

	/**
	 * @hibernate.property type = "timestamp"
	 * @return 發布時間
	 */
	@SearchableProperty
	@SearchableMetaData(name = "publishdate",format = "yyyyMMdd HH:mm")
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
	 * @hibernate.property type = "timestamp"
	 * @return 創建時間
	 */
	@SearchableProperty
	@SearchableMetaData(name = "createddate",format = "yyyyMMdd HH:mm")
	public Date getCreatedDate() {
		return createdDate;
	}

	/**
	 * 
	 * @param createdDate 創建時間
	 */
	public void setCreatedDate(Date createdDate) {
		this.createdDate = createdDate;
	}

	/**
	 * @hibernate.property type = "timestamp"
	 * @return 更新時間
	 */
	@SearchableProperty
	@SearchableMetaData(name = "updateddate",format = "yyyyMMdd HH:mm")
	public Date getUpdatedDate() {
		return updatedDate;
	}

	/**
	 * 更新時間
	 * @param updatedDate 更新時間
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
	 * @hibernate.property
	 * @return 利率
	 */
	@SearchableProperty
	@SearchableMetaData(name="rate",index=Index.UN_TOKENIZED)
	public Float getRate() {
		return rate;
	}

	/**
	 * 
	 * @param rate 利率
	 */
	public void setRate(Float rate) {
		this.rate = rate;
	}
	
	/**
	 * @hibernate.property
	 * @return 存款類型，如：活期存款、定期存款一年、定期存款九月等
	 */
	@SearchableProperty
	@SearchableMetaData(name="type",index=Index.UN_TOKENIZED)
	public String getType() {
		return type;
	}
	
	/**
	 * 
	 * @param type 存款類型
	 */
	public void setType(String type) {
		this.type = type;
	}
}
