package com.foxconn.cic.model;

import java.io.Serializable;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;

import org.acegisecurity.GrantedAuthority;
import org.acegisecurity.userdetails.UserDetails;
import org.apache.commons.lang.builder.ToStringBuilder;
import org.apache.commons.lang.builder.ToStringStyle;

/**
 * This class is used to generate Spring Validation rules
 * as well as the Hibernate mapping file.
 *
 * <p><a href="User.java.html"><i>View Source</i></a>
 *
 * @author <a href="mailto:matt@raibledesigns.com">Matt Raible</a>
 *         Updated by Dan Kibler (dan@getrolling.com)
 *  Extended to implement Acegi UserDetails interface
 *      by David Carter david@carter.net
 *
 * @hibernate.class table="app_user"
 * 
 * @author Decorated for use with xfire webservice by <a href="mailto:mikagoeckel@codehaus.org">Mika Goeckel</a>
 * @aegis.mapping 
 */
public class User extends BaseObject implements Serializable, UserDetails {
	/**Serial ID*/
    private static final long serialVersionUID = 3832626162173359411L;

    /**ID*/
    protected Long id;
    /**用戶名*/
    protected String username;                    // required
    /**密碼*/
    protected String password;                    // required
    /**確認密碼*/
    protected String confirmPassword;
    /**FireName*/
    protected String firstName;                   // required
    /**LastName*/
    protected String lastName;                    // required
    /**地址*/
    protected Address address = new Address();
    /**電話號碼*/
    protected String phoneNumber;
    /**電子郵件*/
    protected String email;                       // required; unique
    /**個人網站地址*/
    protected String website;
    /**密碼提示*/
    protected String passwordHint;
    
    protected Integer version;
    /**角色*/
    protected Set roles = new HashSet();
    protected boolean enabled;
    protected boolean accountExpired;
    protected boolean accountLocked;
    protected boolean credentialsExpired;

    /**
     * */
    public User() {}

    /**
     * @param username 用戶名
     */
    public User(String username) {
        this.username = username;
    }

    /**
     * @hibernate.id column="id" generator-class="native" unsaved-value="null"
     * @return id
     */
    public Long getId() {
        return id;
    }

    /**
     * @hibernate.property length="50" not-null="true" unique="true"
     * @return 用戶名
     */
    public String getUsername() {
        return username;
    }

    /**
     * @hibernate.property column="password" not-null="true"
     * @return 密碼
     */
    public String getPassword() {
        return password;
    }

    /**
     * 
     * @return 確認密碼
     */
    public String getConfirmPassword() {
        return confirmPassword;
    }

    /**
     * @hibernate.property column="first_name" not-null="true" length="50"
     * @return FirstName
     */
    public String getFirstName() {
        return firstName;
    }

    /**
     * @hibernate.property column="last_name" not-null="true" length="50"
     * @return LastName
     */
    public String getLastName() {
        return lastName;
    }

    /**
     * Returns the full name.
     * @aegis.property ignore="true"
     * @return 全名
     */
    public String getFullName() {
        return firstName + ' ' + lastName;
    }

    /**
     * @hibernate.component
     * @return 地址
     */
    public Address getAddress() {
        return address;
    }

    /**
     * @hibernate.property name="email" not-null="true" unique="true"
     * @return 郵件地址
     */
    public String getEmail() {
        return email;
    }

    /**
     * @hibernate.property column="phone_number" not-null="false"
     * @return 電話號碼
     */
    public String getPhoneNumber() {
        return phoneNumber;
    }

    /**
     * @hibernate.property column="website" not-null="false"
     * @return 個人網站
     */
    public String getWebsite() {
        return website;
    }

    /**
     * @hibernate.property column="password_hint" not-null="false"
     * @return 密碼提示
     */
    public String getPasswordHint() {
        return passwordHint;
    }

    /**
     * @hibernate.set table="user_role" cascade="save-update" lazy="false"
     * @hibernate.collection-key column="user_id"
     * @hibernate.collection-many-to-many class="com.foxconn.cic.model.Role" column="role_id"
     * @aegis.property componentType="com.foxconn.cic.model.Role"
     * @return 角色
     */
    public Set getRoles() {
        return roles;
    }

    /**
     * Adds a role for the user
     * @param role 角色
     */
    public void addRole(Role role) {
        getRoles().add(role);
    }

    /**
     * @see org.acegisecurity.userdetails.UserDetails#getAuthorities()
     * @aegis.property ignore="true"
     */
    public GrantedAuthority[] getAuthorities() {
        return (GrantedAuthority[]) roles.toArray(new GrantedAuthority[0]);
    }

    /**
     * @hibernate.version
     */
    public Integer getVersion() {
        return version;
    }
    
    /**
     * @hibernate.property column="account_enabled" type="yes_no"
     */
    public boolean isEnabled() {
        return enabled;
    }
    
    /**
     * @hibernate.property column="account_expired" not-null="true" type="yes_no"
     */
    public boolean isAccountExpired() {
        return accountExpired;
    }
    
    /**
     * @see org.acegisecurity.userdetails.UserDetails#isAccountNonExpired()
     * @aegis.property ignore="true"
     */
    public boolean isAccountNonExpired() {
        return !isAccountExpired();
    }

    /**
     * @hibernate.property column="account_locked" not-null="true" type="yes_no"
     */
    public boolean isAccountLocked() {
        return accountLocked;
    }
    
    /**
     * @see org.acegisecurity.userdetails.UserDetails#isAccountNonLocked()
     * @aegis.property ignore="true"
     */
    public boolean isAccountNonLocked() {
        return !isAccountLocked();
    }

    /**
     * @hibernate.property column="credentials_expired" not-null="true"  type="yes_no"
     */
    public boolean isCredentialsExpired() {
        return credentialsExpired;
    }
    
    /**
     * @see org.acegisecurity.userdetails.UserDetails#isCredentialsNonExpired()
     * @aegis.property ignore="true"
     */
    public boolean isCredentialsNonExpired() {
        return !credentialsExpired;
    }

    public void setId(Long id) {
        this.id = id;
    }

    /**
     * @spring.validator type="required"
     */
    public void setUsername(String username) {
        this.username = username;
    }

    /**
     * @spring.validator type="required"
     * @spring.validator type="twofields" msgkey="errors.twofields"
     * @spring.validator-args arg1resource="user.password"
     * @spring.validator-args arg1resource="user.confirmPassword"
     * @spring.validator-var name="secondProperty" value="confirmPassword"
     */
    public void setPassword(String password) {
        this.password = password;
    }

    /**
     * @spring.validator type="required"
     */
    public void setConfirmPassword(String confirmPassword) {
        this.confirmPassword = confirmPassword;
    }

    /**
     * @spring.validator type="required"
     */
    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    /**
     * @spring.validator type="required"
     */
    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    /**
     * @spring.validator
     */
    public void setAddress(Address address) {
        this.address = address;
    }

    /**
     * @spring.validator type="required"
     * @spring.validator type="email"
     */
    public void setEmail(String email) {
        this.email = email;
    }

    /**
     * @spring.validator type="mask" msgkey="errors.phone"
     * @spring.validator-var name="mask" value="${phone}"
     */
    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public void setWebsite(String website) {
        this.website = website;
    }

    /**
     * @spring.validator type="required"
     */
    public void setPasswordHint(String passwordHint) {
        this.passwordHint = passwordHint;
    }

    public void setRoles(Set roles) {
        this.roles = roles;
    }

    public void setVersion(Integer version) {
        this.version = version;
    }
    
    public void setEnabled(boolean enabled) {
        this.enabled = enabled;
    }
    
    /**
     * Convert user roles to LabelValue objects for convenience.  
     * @aegis.property ignore="true"
     */
    public List getRoleList() {
        List userRoles = new ArrayList();

        if (this.roles != null) {
            for (Iterator it = roles.iterator(); it.hasNext();) {
                Role role = (Role) it.next();

                // convert the user's roles to LabelValue Objects
                userRoles.add(new LabelValue(role.getName(),
                                             role.getName()));
            }
        }

        return userRoles;
    }

    public void setAccountExpired(boolean accountExpired) {
        this.accountExpired = accountExpired;
    }
    
    public void setAccountLocked(boolean accountLocked) {
        this.accountLocked = accountLocked;
    }

    public void setCredentialsExpired(boolean credentialsExpired) {
        this.credentialsExpired = credentialsExpired;
    }

    /**
     * @param o 比較的對象
     * @return 如果相等返回true，否則返回false
     */
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof User)) return false;

        final User user = (User) o;

        if (username != null ? !username.equals(user.getUsername()) : user.getUsername() != null) return false;

        return true;
    }

    /**
     * @return hash code
     */
    public int hashCode() {
        return (username != null ? username.hashCode() : 0);
    }

    /**
     * @return 返回toString結果
     */
    public String toString() {
        ToStringBuilder sb = new ToStringBuilder(this,
                ToStringStyle.DEFAULT_STYLE).append("username", this.username)
                .append("enabled", this.enabled)
                .append("accountExpired",this.accountExpired)
                .append("credentialsExpired",this.credentialsExpired)
                .append("accountLocked",this.accountLocked);

        GrantedAuthority[] auths = this.getAuthorities();
        if (auths != null) {
            sb.append("Granted Authorities: ");

            for (int i = 0; i < auths.length; i++) {
                if (i > 0) {
                    sb.append(", ");
                }
                sb.append(auths[i].toString());
            }
        } else {
            sb.append("No Granted Authorities");
        }
        return sb.toString();
    }
}
