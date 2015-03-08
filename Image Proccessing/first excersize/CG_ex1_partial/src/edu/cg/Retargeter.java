package edu.cg;

import java.awt.image.BufferedImage;
import java.lang.reflect.Array;

//Retargeter – A class that does seam carving.
public class Retargeter {

	private BufferedImage originalImg;
	private BufferedImage currImg;
	private int[][] seamOrderMatrix;
	private int[][] costsMatrix;

	public Retargeter(BufferedImage m_img, boolean m_isVertical) {
		// TODO do initialization and preprocessing here
		// does all necessary preprocessing, including the calculation
		// of the seam order matrix. You should implement this.
		this.originalImg = m_img;
		this.currImg = m_img;
		this.seamOrderMatrix = calculateSeamsOrderMatrix();
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

	private int[][] calculateCostsMatrix(int w) {

		// TODO implement this - cost matrix should be calculated for a given
		// image width w
		// to be used inside calculateSeamsOrderMatrix()
		int[][] costMatrix = new int[this.currImg.getWidth()][this.currImg.getHeight()];
		// TODO: Flow - we should calc this matrix using the base value of the
		// gradient
		// plus the "price"/cost of the pixel's value in the grayscale mode
		for (int x = 0; x < this.currImg.getWidth(); x++) {
			for (int y = 0; y < this.currImg.getHeight(); y++) {
				// TODO: create edge case for edges

				// init the costs
				int totalCostLeft = costMatrix[x - 1][y - 1] + costLeft;
				int totalCostVertical = costMatrix[x - 1][y] + costVertical;
				int totalCostRight = costMatrix[x - 1][y - 1] + costRight;
				// find min
				int min = Math.min(totalCostLeft, Math.min(totalCostVertical, totalCostRight));

				costMatrix[x][y] = min;
			}
		}

		return costMatrix;
	}

}
