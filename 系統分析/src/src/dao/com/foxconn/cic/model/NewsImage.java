package com.foxconn.cic.model;

import java.util.Date;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;
import org.compass.annotations.Index;
import org.compass.annotations.Searchable;
import org.compass.annotations.SearchableId;
import org.compass.annotations.SearchableMetaData;
import org.compass.annotations.SearchableProperty;

/**
 * @hibernate.class table="news_image"
 * @aegis.mapping
 */
@Searchable(alias="newsimage",root=false)
public class NewsImage extends BaseObject{

	/**Serial ID*/
	private static final long serialVersionUID = -3971106172098907343L;
	/**ID*/
	@SearchableId
	private Long id;
	/**新聞id*/
	private Long newsId;
	/**標題*/
	private String title;
	/**位置*/
	private int position;
	/**原始url*/
	private String url;
	/**重組后url*/
	private String fixedUrl;
	/**圖片存儲路徑*/
	private String filePath;
	/**圖片類型。0為一般圖片，1為附件（如PDF等）*/
	private Integer type;
	/**圖片寬*/
	private Integer width;
	/**圖片高*/
	private Integer height;
	/**創建日期*/
	private Date createdDate=new Date();
	/**更新日期*/
	private Date updatedDate;

	/**
	 * @hibernate.property type = "timestamp"
	 * @return 創建日期
	 */
	@SearchableProperty
	@SearchableMetaData(name="imagecreateddate",index=Index.UN_TOKENIZED,format="yyyyMMdd HH:mm")
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
	@SearchableMetaData(name="imageupdateddate",index=Index.UN_TOKENIZED,format="yyyyMMdd HH:mm")
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
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (!(other instanceof NewsImage))
			return false;
		NewsImage castOther = (NewsImage) other;
		return new EqualsBuilder().append(position, castOther.position).append(
				url, castOther.url).isEquals();
	}
	
	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder().append(position).append(url).toHashCode();
	}
	
	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("position",
				position).append("url", url).append("filePath", filePath)
				.toString();
	}
	/**
	 * @hibernate.property
	 * @return 圖片存儲路徑
	 */
	@SearchableProperty
	@SearchableMetaData(name="imagefilepath",index=Index.UN_TOKENIZED)
	public String getFilePath() {
		return filePath;
	}
	
	/**
	 * 
	 * @param filePath 圖片存儲路徑
	 */
	public void setFilePath(String filePath) {
		this.filePath = filePath;
	}

	/**
	 * @hibernate.id generator-class = "sequence" unsaved-value="null"
	 * @hibernate.generator-param  value = "newsimage_sequence"  name = "sequence"
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
     * @hibernate.column name = "news_id" index ="idx_newsimage_newsid"
     *
	 * @return 新聞id
	 */
	public Long getNewsId() {
		return newsId;
	}
	
	/**
	 * 
	 * @param newsId 新聞id
	 */
	public void setNewsId(Long newsId) {
		this.newsId = newsId;
	}

	/**
	 * @hibernate.property
	 * @return 位置
	 */
	@SearchableProperty
	@SearchableMetaData(name="imageposition",index=Index.UN_TOKENIZED)
	public int getPosition() {
		return position;
	}
	
	/**
	 * 
	 * @param position 位置
	 */
	public void setPosition(int position) {
		this.position = position;
	}

	/**
	 * @hibernate.property
	 * @return 新聞圖片原始url
	 */
	@SearchableProperty
	@SearchableMetaData(name="imageurl",index=Index.UN_TOKENIZED)
	public String getUrl() {
		return url;
	}
	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param url 新聞圖片原始url
	 */
	public void setUrl(String url) {
		this.url = url;
	}
	
	/**
	 * @hibernate.property
	 * @return 新聞圖片類型
	 */
	@SearchableProperty
	@SearchableMetaData(name="imagetype",index=Index.UN_TOKENIZED)
	public Integer getType() {
		return type;
	}
	
	/**
	 * 
	 * @param type 新聞圖片類型
	 */
	public void setType(Integer type) {
		this.type = type;
		if (type == null) {
			this.type = NewsConstants.NEWSIMAGE_TYPE_NORMAL;
		}
	}
	
	/**
	 * @hibernate.property
	 * @return 標題
	 */
	@SearchableProperty
	@SearchableMetaData(name="imagetitle")
	public String getTitle() {
		return title;
	}
	
	/**
	 * 
	 * @param title 標題
	 */
	public void setTitle(String title) {
		this.title = title;
	}
	/**
	 * @hibernate.property
	 * @return 圖片寬度
	 */
	@SearchableProperty
	@SearchableMetaData(name="imagewidth",index=Index.UN_TOKENIZED)
	public Integer getWidth() {
		return width;
	}
	
	/**
	 * 
	 * @param width 圖片寬度
	 */
	public void setWidth(Integer width) {
		this.width = width;
	}
	/**
	 * @hibernate.property
	 * @return 圖片高度
	 */
	@SearchableProperty
	@SearchableMetaData(name="imageheight",index=Index.UN_TOKENIZED)
	public Integer getHeight() {
		return height;
	}
	
	/**
	 * 
	 * @param height 圖片高度
	 */
	public void setHeight(Integer height) {
		this.height = height;
	}
	
	/**
	 * @hibernate.property
	 * @return 重組后url
	 */
	@SearchableProperty
	@SearchableMetaData(name="imagefixedurl",index=Index.UN_TOKENIZED)
	public String getFixedUrl() {
		return fixedUrl;
	}
	
	/**
	 * 
	 * @param fixedUrl 重組后url
	 */
	public void setFixedUrl(String fixedUrl) {
		this.fixedUrl = fixedUrl;
	}
}
