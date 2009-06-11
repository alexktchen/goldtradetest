
package com.foxconn.cic.service;

import java.util.List;

import com.foxconn.cic.model.NewsImage;

public interface NewsImageManager extends Manager {

	/**
	 * 設置圖片儲存的路徑
	 * @param path
	 */
	public void setFilePath(String path);

	public String getFilePath();
    /**
     * Retrieves all of the newsImages
     */
    public List getNewsImages(NewsImage newsImage);

    /**
     * Gets newsImage's information based on id.
     * @param id the newsImage's id
     * @return newsImage populated newsImage object
     */
    public NewsImage getNewsImage(final String id);

    /**
     * Saves a newsImage's information
     * @param newsImage the object to be saved
     */
    public void saveNewsImage(NewsImage newsImage);

    /**
     * Removes a newsImage from the database by id
     * @param id the newsImage's id
     */
    public void removeNewsImage(final String id);

     /**
     * 得到下載不成功的圖片。
     * @return
     */
    public List<NewsImage> getFilepathIsNullNewsImages();
}

