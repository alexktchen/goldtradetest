package com.foxconn.cic.service;

import java.util.List;

import org.compass.core.support.search.CompassSearchCommand;
import org.compass.core.support.search.CompassSearchResults;

import com.foxconn.cic.model.Price;

public interface PriceManager extends Manager {
	/**
	 * Retrieves all of the prices
	 */
	public List getPrices(Price price);

	/**
	 * Gets price's information based on id.
	 * 
	 * @param id
	 *            the price's id
	 * @return price populated price object
	 */
	public Price getPrice(final String id);

	/**
	 * Saves a price's information
	 * 
	 * @param price
	 *            the object to be saved
	 */
	public Price savePrice(Price price);

	/**
	 * Removes a price from the database by id
	 * 
	 * @param id
	 *            the price's id
	 */
	public void removePrice(final String id);

	public CompassSearchResults search(CompassSearchCommand searchCommand);
}
