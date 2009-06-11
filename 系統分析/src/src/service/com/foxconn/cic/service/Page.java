package com.foxconn.cic.service;

public class Page {
	private int from;

	private int to;

	private int size;

	private boolean selected;

	/**
	 * Returns the hit number the page starts from.
	 */
	public int getFrom() {
		return from;
	}

	/**
	 * Sets the hit number the page starts from.
	 */
	public void setFrom(int from) {
		this.from = from;
	}

	/**
	 * Returns <code>true</code> if the page is selected, i.e. the results
	 * that are shown are part of the page.
	 */
	public boolean isSelected() {
		return selected;
	}

	/**
	 * Sets if the page is selected or not.
	 */
	public void setSelected(boolean selected) {
		this.selected = selected;
	}

	/**
	 * Returns the size of the hits in the page.
	 */
	public int getSize() {
		return size;
	}

	/**
	 * Sets the size of the hits in the page.
	 */
	public void setSize(int size) {
		this.size = size;
	}

	/**
	 * Returns the hit number that the page ends at.
	 */
	public int getTo() {
		return to;
	}

	/**
	 * Sets the hit number that the page ends at.
	 */
	public void setTo(int to) {
		this.to = to;
	}
}
