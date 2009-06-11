package com.foxconn.cic.model;

import java.util.List;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

/**
 * @hibernate.class
 */
public class Catalog extends BaseObject{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1131662879099806028L;
	
	/**
	 * id
	 */
	private Long id;
	
	/**分類名稱*/
	private String name;
	
	/**分類描述*/
	private String description;
	
	/**分類類型*/
	private CatalogType type;
	
	/**查詢語句*/
	private String queryString;
	
	/**子分類*/
	private List<Catalog> children;
	
	/**父分類*/
	private Catalog parent;
	
	/**
     * @param other 比較的對象
     * @return 如果相等返回true，否則返回false
     */
	public boolean equals(final Object other) {
		if (!(other instanceof Catalog))
			return false;
		Catalog castOther = (Catalog) other;
		return new EqualsBuilder().append(id, castOther.id).isEquals();
	}
	
	/**
     * @return hash code
     */
	public int hashCode() {
		return new HashCodeBuilder().append(id).toHashCode();
	}
	
	/**
     * @return 返回toString結果
     */
	public String toString() {
		return new ToStringBuilder(this).append("id", id).append("name", name)
				.toString();
	}
	/**
	 * @hibernate.id generator-class = "sequence" unsaved-value="null"
	 * @hibernate.generator-param
	 *   value = "catalog_sequence"
	 *   name = "sequence"
	 * @return id
	 */	
	public Long getId() {
		return id;
	}
	
	/**
	 * @hibernate.property
	 * @return 名稱
	 */
	public String getName() {
		return name;
	}
	/**
	 * @hibernate.property
	 * @return 描述
	 */
	public String getDescription() {
		return description;
	}
	/**
	 * @hibernate.many-to-one cascade = "none"
	 * @return 類型
	 */
	public CatalogType getType() {
		return type;
	}
	/**
     * @hibernate.bag cascade="all" inverse = "true" 
     * @hibernate.one-to-many class="com.foxconn.cic.model.Catalog"
     * @hibernate.index column="position"
     * @hibernate.key column="parent_id"
     * 
	 * @return 子分類
	 */
	public List<Catalog> getChildren() {
		return children;
	}
	
	/**
	 * @hibernate.many-to-one cascade = "none"
     * @hibernate.column name = "parent_id"
	 * @return 父分類
	 */
	public Catalog getParent() {
		return parent;
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
     * 設置在父分類中的位置
     * @param position 位置
     */
    public void setPosition(int position) { /* not used */ } 
	
    /**
     * 
     * @param children 子分類
     */
	public void setChildren(List<Catalog> children) {
		this.children = children;
	}
	
	/**
	 * 
	 * @param description 描述
	 */
	public void setDescription(String description) {
		this.description = description;
	}
	
	/**
	 * 
	 * @param id id
	 */
	public void setId(Long id) {
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
	 * 
	 * @param parent 父分類
	 */
	public void setParent(Catalog parent) {
		this.parent = parent;
	}
	
	/**
	 * 
	 * @param type 類型
	 */
	public void setType(CatalogType type) {
		this.type = type;
	}
	/**
	 * @hibernate.property
	 * @return 查詢語句
	 */
	public String getQueryString() {
		return queryString;
	}
	
	/**
	 * 
	 * @param queryString 查詢語句
	 */
	public void setQueryString(String queryString) {
		this.queryString = queryString;
	}
}
