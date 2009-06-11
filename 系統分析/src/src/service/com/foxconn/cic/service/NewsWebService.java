package com.foxconn.cic.service;

import com.foxconn.cic.model.News;
/**
 *
 * @author ldapeng
 * @aegis.mapping
 */
public interface NewsWebService {

	/**
	 * 搜索新聞
	 * @param query
	 * @param page
	 * @return
	 */
	public NewsSearchResults search(String query,Integer page);

	/**
	 * 獲得新聞信息
	 * @param id
	 * @return
	 */
	public News getNews(final String id);

	/**
	 * 獲得新聞信息，重要用于其他系統導入<br/>
	 * 此方法會在返回新聞內容前，使用virtualDirectory替換原有img標簽中src屬性。
	 * 例如：原有src='{$1}',virtualDirectory的值為/images/,則返回的src='/images/圖片的filepath'
	 * @param id 新聞id
	 * @param virtualDirectory 
	 * @return
	 */
	public News getNews(final String id,String virtualDirectory);
	
	/**
	 * 判斷新聞是否存在
	 * @param title
	 * @param url
	 * @return
	 */
	public boolean isExisted(News news);
}
