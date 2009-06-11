package com.foxconn.cic.model;

import java.util.Date;
import java.util.Set;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * @hibernate.class dynamic-insert = "true" table = "News" batch-size = "0"
 * @aegis.mapping
 */
public class News extends BaseObject implements Infomation {

	/**Serial ID*/
	private static final long serialVersionUID = -8433324570676339906L;
	/**ID*/
	private Long id;
	/**標題*/
	private String title;
	/**摘要*/
	private String summary;
	/**內容*/
	private String content;
	/**發布日期*/
	private Date publishDate;
	/**作者*/
	private String author;
	/**發布者*/
	private String publisher;
	/**新聞原始URL*/
	private String url;
	/**新聞BaseURL*/
	private String baseUrl;
	/**網站*/
	private Website website;
	/**創建日期*/
	private Date createdDate=new Date();
	/**更新日期*/
	private Date updatedDate;
	/**新聞圖片*/
	private Set<NewsImage> images;

	/**
     * @hibernate.set cascade="all" order-by = "position asc" lazy = "false"
     * @hibernate.one-to-many class="com.foxconn.cic.model.NewsImage"
     * @hibernate.key column="news_id"
     * @aegis.property componentType="com.foxconn.cic.model.NewsImage"
	 * @return 圖片
	 */
	public Set<NewsImage> getImages() {
		return images;
	}

	/**
	 * 
	 * @param images 圖片
	 */
	public void setImages(Set<NewsImage> images) {
		this.images = images;
	}

	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id)
				.append("title", title).toString();
	}

	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (this == other)
			return true;
		if (!(other instanceof News))
			return false;
		News castOther = (News) other;
		return new EqualsBuilder().append(id, castOther.id).append(title,
				castOther.title).append(url, castOther.url).isEquals();
	}

	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder(17, 37).append(id).append(title).append(url)
				.toHashCode();
	}

	/**
	 * @hibernate.id generator-class = "sequence" unsaved-value="null"
	 * @hibernate.generator-param value = "news_sequence" name = "sequence"
	 * @return id
	 */
	public Long getId() {
		return id;
	}

	/**
	 * @hibernate.property index ="idx_news_title"  length="4000"
	 * @return 標題
	 */
	public String getTitle() {
		return title;
	}

	/**
	 * @hibernate.property type = "timestamp"
	 * @return 發布日期
	 */
	public Date getPublishDate() {
		return publishDate;
	}



	/**
	 * @hibernate.many-to-one cascade="none" class =
	 *                        "com.foxconn.cic.model.Website" outer-join="true"
	 * column = "website_id"
	 * @aegis.property ignore="true"
	 * @return 網站
	 */
	public Website getWebsite() {
		return website;
	}

	/**
	 * @hibernate.property index = "idx_news_url"
	 * @return 原始URL
	 */
	public String getUrl() {
		return url;
	}

	/**
	 * @hibernate.property type = "text"
	 * @return 新聞內容
	 *
	 */
	public String getContent() {
		return content;
	}
	
	/**
	 * 
	 * @param content 新聞內容
	 */
	public void setContent(String content) {
		this.content = content;
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
	 * @param time 發布日期
	 */
	public void setPublishDate(Date time) {
		this.publishDate = time;
	}

	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param title 標題
	 */
	public void setTitle(String title) {
		this.title = title;
	}

	/**
	 * 
	 * @param url 新聞原始URL
	 */
	public void setUrl(String url) {
		this.url = url;
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
	 * @return 作者
	 */
	public String getAuthor() {
		return author;
	}

	/**
	 * @hibernate.property type = "timestamp"
	 * @return 創建日期
	 */
	public Date getCreatedDate() {
		return createdDate;
	}

	/**
	 * @hibernate.property
	 * @return 發布日期
	 */
	public String getPublisher() {
		return publisher;
	}

	/**
	 * @hibernate.property length="4000"
	 * @return 新聞摘要
	 */
	public String getSummary() {
		return summary;
	}

	/**
	 * @hibernate.property  type = "timestamp"
	 * @return 更新日期
	 */
	public Date getUpdatedDate() {
		return updatedDate;
	}

	/**
	 * 
	 * @param author 作者
	 */
	public void setAuthor(String author) {
		this.author = author;
	}

	/**
	 * 
	 * @param createdDate 創建日期
	 */
	public void setCreatedDate(Date createdDate) {
		this.createdDate = createdDate;
	}

	/**
	 * 
	 * @param publisher 發布者
	 */
	public void setPublisher(String publisher) {
		this.publisher = publisher;
	}

	/**
	 * 
	 * @param summary 新聞摘要
	 */
	public void setSummary(String summary) {
		this.summary = summary;
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
	 * @return baseurl
	 */
	public String getBaseUrl() {
		return baseUrl;
	}

	/**
	 * 
	 * @param baseUrl baseurl
	 */
	public void setBaseUrl(String baseUrl) {
		this.baseUrl = baseUrl;
	}

}
