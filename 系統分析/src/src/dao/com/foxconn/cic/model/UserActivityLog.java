package com.foxconn.cic.model;

import java.util.Date;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * 用戶行為記錄
 * @hibernate.class table = "User_Activity_Log"
 */
public class UserActivityLog extends BaseObject {

	/**Serial id*/
	private static final long serialVersionUID = -450187618780958588L;

	/**id*/
	private Long id;
	/**用戶名*/
	private String userName;
	/**用戶行為*/
	private String activity;
	/**相關行為數據*/
	private String metaData;
	/**客戶端IP地址*/
	private String ipAddress;
	/**訪問方式，如：UserActivityLogConstants.TYPE_WEB或UserActivityLogConstants.TYPE_WEBSERVCIE*/
	private String type;
	/**創建日期*/
	private Date createdDate;

	/**
     * @return 返回toString結果
     */
	@Override
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("userName",
				userName).append("activity", activity).append("metaData",
				metaData).append("ipAddress", ipAddress).append("type", type)
				.append("createdDate", createdDate).toString();
	}

	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	@Override
	public boolean equals(final Object other) {
		if (!(other instanceof UserActivityLog))
			return false;
		UserActivityLog castOther = (UserActivityLog) other;
		return new EqualsBuilder().append(id, castOther.id).append(userName,
				castOther.userName).append(activity, castOther.activity)
				.append(metaData, castOther.metaData).append(ipAddress,
						castOther.ipAddress).append(type, castOther.type)
				.append(createdDate, castOther.createdDate).isEquals();
	}

	/**
     * @return hash code
     */
	@Override
	public int hashCode() {
		return new HashCodeBuilder().append(id).append(userName).append(
				activity).append(metaData).append(ipAddress).append(type)
				.append(createdDate).toHashCode();
	}

	/**
	 * @hibernate.id generator-class = "sequence" unsaved-value="null"
	 * @hibernate.generator-param
	 *   value = "UserActivityLog_sequence"
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
	 * @hibernate.property
	 * @return 用戶名
	 */
	public String getUserName() {
		return userName;
	}

	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param userName 用戶名
	 */
	public void setUserName(String userName) {
		this.userName = userName;
	}

	/**
	 * @hibernate.property
	 * @return 用戶行為
	 */
	public String getActivity() {
		return activity;
	}

	/**
	 * @spring.validator type="required" msgkey="errors.required"
	 * @param activity 用戶行為
	 */
	public void setActivity(String activity) {
		this.activity = activity;
	}

	/**
	 * @hibernate.property length = "2000"
	 * @return 相關行為數據
	 */
	public String getMetaData() {
		return metaData;
	}

	/**
	 * 
	 * @param metaData 相關行為數據
	 */
	public void setMetaData(String metaData) {
		this.metaData = metaData;
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
	 * @hibernate.property length = "20"
	 * @return 客戶端ip地址
	 */
	public String getIpAddress() {
		return ipAddress;
	}
	
	/**
	 * 
	 * @param ipAddress 客戶端ip地址
	 */
	public void setIpAddress(String ipAddress) {
		this.ipAddress = ipAddress;
	}

	/**
	 * @hibernate.property length = "20"
	 * @return 訪問方式，如：UserActivityLogConstants.TYPE_WEB或UserActivityLogConstants.TYPE_WEBSERVCIE
	 */
	public String getType() {
		return type;
	}

	/**
	 * 
	 * @param type 訪問方式，如：UserActivityLogConstants.TYPE_WEB或UserActivityLogConstants.TYPE_WEBSERVCIE
	 */
	public void setType(String type) {
		this.type = type;
	}
}
