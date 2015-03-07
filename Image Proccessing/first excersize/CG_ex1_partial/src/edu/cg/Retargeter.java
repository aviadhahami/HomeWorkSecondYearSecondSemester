package edu.cg;

import java.awt.image.BufferedImage;

//Retargeter – A class that does seam carving.
public class Retargeter {

	private BufferedImage originalImg;
	private BufferedImage currImg;

	public Retargeter(BufferedImage m_img, boolean m_isVertical) {
		// TODO do initialization and preprocessing here
		// does all necessary preprocessing, including the calculation
		// of the seam order matrix. You should implement this.
		this.originalImg = m_img;
		this.currImg = m_img;
		calculateSeamsOrderMatrix();
	}

	public int[][] getSeamsOrderMatrix() {
		return this.calculateSeamsOrderMatrix();
	}

	public int[] getOrigPosMatrix() {
		return this.calculateCostsMatrix(this.currImg.getWidth());
	}

	public BufferedImage retarget(int newSize) {
		// TODO implement this
		return null;
	}

	private int[][] calculateSeamsOrderMatrix() {

		// TODO implement this - this calculates the order in which seams are
		// extracted
		return null;

	}

	private int[] calculateCostsMatrix(int w) {
		return null;
		// TODO implement this - cost matrix should be calculated for a given
		// image width w
		// to be used inside calculateSeamsOrderMatrix()
	}

}
