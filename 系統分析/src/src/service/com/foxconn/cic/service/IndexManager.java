package com.foxconn.cic.service;

import com.foxconn.cic.model.News;

public interface IndexManager{

	/**
	 * 獲得索引中的文件數量
	 * @return
	 */
	public int getDocumentSize();

	/**
	 * 獲得索引中最大的文件編號
	 * @return
	 */
	public int getDocumentMaxNumber();

	/**
	 * 與資料庫同步
	 * @param beginId 開始ID
	 * @param endId 結束id
	 */
	public void syncIndex(String beginId,String endId);

	/**
	 * 從索引中獲得新聞
	 * @param id 新聞id
	 */
	public News getNews(String id);

	/**
	 * 從索引中刪除新聞
	 * @param id 新聞id
	 */
	public void deleteNews(String id);
}
