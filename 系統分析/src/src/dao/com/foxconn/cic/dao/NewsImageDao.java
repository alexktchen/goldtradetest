
package com.foxconn.cic.dao;

import java.util.List;

import com.foxconn.cic.model.NewsImage;

public interface NewsImageDao extends Dao {

    /**
     * Retrieves all of the newsImages
     */
    public List getNewsImages(NewsImage newsImage);

    /**
     * Gets newsImage's information based on primary key. An
     * ObjectRetrievalFailureException Runtime Exception is thrown if
     * nothing is found.
     *
     * @param id the newsImage's id
     * @return newsImage populated newsImage object
     */
    public NewsImage getNewsImage(final Long id);

    /**
     * Saves a newsImage's information
     * @param newsImage the object to be saved
     */
    public void saveNewsImage(NewsImage newsImage);

    /**
     * Removes a newsImage from the database by id
     * @param id the newsImage's id
     */
    public void removeNewsImage(final Long id);

    /**
     * 得到下載不成功的圖片。
     * @param great 大於多少分鐘
     * @param lower	小於多少分鐘
     * @return
     */
    public List<NewsImage> getFilepathIsNullNewsImages(int gt,int lt);
}

