package com.foxconn.cic.model;

import java.util.Date;
import java.util.List;
import java.util.Set;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * @hibernate.class
 * 
 * @aegis.mapping
 */
public class Website  extends BaseObject{

	/**Serial ID*/
	private static final long serialVersionUID = -7355304629158890984L;
	/**ID*/
	private String id = null;
	/**父網站*/
	private Website parent;
	/**子網站*/
	private List<Website> children;
	/**名稱*/
	private String name;
	/**網址*/
	private String url;
	/**
	 * 類型
	 * @see WebsiteConstants.TYPE_NEWS,WebsiteConstants.TYPE_PRICE,WebsiteConstants.TYPE_EXCHANGERATE,WebsiteConstants.TYPE_INTERESTRATE
	 * */
	private int type;
	/**
	 * 狀態
	 * @see WebsiteConstants
	 */
	private String status;
	/**排程*/
	private String schedule;
	/**
	 * 復雜度
	 * @see WebsiteConstants
	 */
	private Integer complication=WebsiteConstants.COMPLICATION_NORMAL;
	/**更新頻率*/
	private String period;
	/**引用者*/
	private Set<Quoter> quoters;
	/**創建時間*/
	private Date createdDate;
	/**更新時間*/
	private Date updatedDate;

	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (!(other instanceof Website))
			return false;
		Website castOther = (Website) other;
		return new EqualsBuilder().append(id, castOther.id).append(name,
				castOther.name).append(url, castOther.url).isEquals();
	}
	
	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder().append(id).append(name).append(url)
				.toHashCode();
	}
	
	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("name", name)
				.append("url", url).toString();
	}
	/**
	 *@hibernate.id column="id"  generator-class="uuid.hex" unsaved-value="null"
	 * @return id
	 */
	public String getId() {
		return id;
	}

	/**
     * @hibernate.property unique = "true" not-null = "true" length="100"
     * @return 名稱
     */
	public String getName() {
		return name;
	}

	/**
     * @hibernate.property
     * @return 網址
     */
	public String getUrl() {
		return url;
	}


	/**
	 * 設置id
	 * @param id id
	 */
	public void setId(String id) {
		this.id = id;
	}
	/**
     * @spring.validator type="required" msgkey="errors.required"
     * @param name 名稱
     */
	public void setName(String name) {
		this.name = name;
	}
	
	/**
	 * 設置網址
	 * @param url 網址
	 */
	public void setUrl(String url) {
		this.url = url;
	}

	/**
	 * 獲得創建日期
	 * @hibernate.property type = "timestamp"
	 * @return 創建日期
	 */
	public Date getCreatedDate() {
		return createdDate;
	}

	/**
	 * @hibernate.many-to-one cascade = "none"
     * @hibernate.column name = "parent_id"
	 * @return 父網站
	 */
	public Website getParent() {
		return parent;
	}

	/**
	 * 獲得網站類型
	 * @hibernate.property
	 * @return 網站類型
	 * @see WebsiteConstants
	 */
	public int getType() {
		return type;
	}

	/**
	 * 獲得更新日期
	 * @hibernate.property type = "timestamp"
	 * @return 更新日期
	 */
	public Date getUpdatedDate() {
		return updatedDate;
	}
	/**
	 * 設置創建日期
	 * @param createdDate 創建日期
	 */
	public void setCreatedDate(Date createdDate) {
		this.createdDate = createdDate;
	}
	
	/**
	 * 設置父網站
	 * @param parent 父網站
	 */
	public void setParent(Website parent) {
		this.parent = parent;
	}
	
	/**
	 * 獲得網站類型
	 * @param type 網站類型
	 * @see WebsiteConstants
	 */
	public void setType(int type) {
		this.type = type;
	}
	
	/**
	 * 設置更新時間
	 * @param updatedDate 更新時間
	 */
	public void setUpdatedDate(Date updatedDate) {
		this.updatedDate = updatedDate;
	}

	/**
     * @hibernate.bag cascade="all" inverse = "true" lazy = "true"
     * @hibernate.one-to-many class="com.foxconn.cic.model.Website"
     * @hibernate.index column="position"
     * @hibernate.key column="parent_id"
     * 
	 * @aegis.property ignore="true"
	 * @return 子網站
	 */
	public List<Website> getChildren() {
		return children;
	}
	/**
	 * 設置子網站
	 * @param children 子網站
	 */
	public void setChildren(List<Website> children) {
		this.children = children;
	}

	/**
     * Returns the position of the node in the children list.
     * @return int
     *
     * @hibernate.property column="position"
     */
    public int getPosition() {
        try{
            return parent.getChildren().indexOf(this);
        }
        catch(NullPointerException e){
            // if it has no parent, position makes no sense
            return -1;
        }
    }

    /**
     * not used
     * @param position 位置
     */
    public void setPosition(int position) { /* not used */ }
    
    /**
	 * @hibernate.property
	 * @return 網站狀態
	 */
	public String getStatus() {
		return status;
	}
	
	/**
	 * 設置網站狀態
	 * @param status 網站狀態
	 */
	public void setStatus(String status) {
		this.status = status;
	}
	
	/**
	 * @hibernate.property
	 * @return 排程
	 */
	public String getSchedule() {
		return schedule;
	}
	
	/**
	 * 请参考Quartz
	 * @param schedule 排程
	 */
	public void setSchedule(String schedule) {
		this.schedule = schedule;
	}
	
	/**
	 * @hibernate.property
	 * @return 復雜度
	 */
	public Integer getComplication() {
		return complication;
	}
	
	/**
	 * {@value COMPLICATION_SIMPLE,COMPLICATION_NORMAL,COMPLICATION_COMPLICATED}
	 * @param complication 復雜度
	 */
	public void setComplication(Integer complication) {
		this.complication = complication;
	}
	
	/**
	 * @hibernate.property
	 * @return 更新頻率
	 */
	public String getPeriod() {
		return period;
	}
	
	/**
	 * 格式是 '*m *w *d *h ' (表示月,星期,天,小時 - * 表示可以是任意數字)
	 * @param period 更新頻率
	 */
	public void setPeriod(String period) {
		this.period = period;
	}

	/**
	 * 获得Website的properties
	 * 
	 * @aegis.property ignore="true"
	 * @return 屬性列表
	 */
	public String getProperties(){
		StringBuffer properties=new StringBuffer();
		properties.append("schedule="+((this.getSchedule()!=null)?this.getSchedule():"")+"\r\n");
		properties.append("websiteId="+this.getId()+"\r\n");
		properties.append("websiteName="+this.getName()+"\r\n");
		properties.append("url="+this.getUrl()+"\r\n");
		properties.append("status="+this.getStatus()+"\r\n");
		properties.append("type="+this.getType()+"\r\n");
		properties.append("parentWebsiteId="+((this.getParent()!=null)?this.getParent().getId():"")+"\r\n");		
		properties.append("parentWebsiteName="+((this.getParent()!=null)?this.getParent().getName():"")+"\r\n");
		return properties.toString();
	}
	
	/**
	 * @hibernate.set table="website_quoter" cascade="save-update" lazy="true"
     * @hibernate.collection-key column="website_id"
     * @hibernate.collection-many-to-many class="com.foxconn.cic.model.Quoter" column="quoter_id"
	 * @return 引用者
	 */
	public Set<Quoter> getQuoters() {
		return quoters;
	}
	
	/**
	 * 設置引用者
	 * @param quoters 引用者
	 */
	public void setQuoters(Set<Quoter> quoters) {
		this.quoters = quoters;
	}
}
