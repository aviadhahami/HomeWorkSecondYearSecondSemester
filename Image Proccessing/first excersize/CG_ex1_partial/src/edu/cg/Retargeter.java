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
	}

	public int[][] getSeamsOrderMatrix() {
		return this.seamOrderMatrix;
	}

	public BufferedImage getOrigPosMatrix() {
		return this.originalImg;
	}

	public BufferedImage retarget(int newSize) {
		// TODO implement this
		return null;
	}

	private void calculateSeamsOrderMatrix() {

		calculateCostsMatrix();
		int k = 0;
		int min = this.costsMatrix[this.currImg.getWidth() - 1][this.currImg.getHeight() - 1];
		for (int x = this.currImg.getWidth() - 1; x > -1; x--) {
			for (int y = this.currImg.getHeight() - 1; y > -1; y--) {
				if (min > this.costsMatrix[x][y]) {
					min = this.costsMatrix[x][y];
					this.seamOrderMatrix[x][k] = y;
				}
			}
			k++;
		}

	}

	private void calculateCostsMatrix() {
		// Using forward energy

		// TODO implement this - cost matrix should be calculated for a given
		// image width w
		// to be used inside calculateSeamsOrderMatrix()

		BufferedImage intensityImg = ImageProc.grayScale(this.currImg);
		BufferedImage gradMagMatrix = ImageProc.gradientMagnitude(this.currImg);

		// moving for easier access
		int[][] costMatrix = new int[gradMagMatrix.getWidth()][gradMagMatrix.getHeight()];
		for (int i = 0; i < gradMagMatrix.getWidth(); i++) {
			for (int j = 0; j < gradMagMatrix.getHeight(); j++) {
				costMatrix[i][j] = gradMagMatrix.getRGB(i, j);
			}

		}

		// TODO: Flow - we should calc this matrix using the base value of the
		// gradient
		// plus the "price"/cost of the pixel's value in the grayscale mode

		for (int x = 0; x < this.currImg.getWidth(); x++) {
			for (int y = 0; y < this.currImg.getHeight(); y++) {
				// TODO: create edge case for edges

				// init the costs
				int costLeft = Math.abs(intensityImg.getRGB(x, y + 1) - intensityImg.getRGB(x, y - 1));
				costLeft += Math.abs(intensityImg.getRGB(x - 1, y) - intensityImg.getRGB(x, y - 1));

				int costVertical = Math.abs(intensityImg.getRGB(x, y + 1) - intensityImg.getRGB(x, y - 1));

				int costRight = Math.abs(intensityImg.getRGB(x, y + 1) - intensityImg.getRGB(x, y - 1));
				costRight += Math.abs(intensityImg.getRGB(x - 1, y) - intensityImg.getRGB(x, y - 1));

				// finalize the summation
				int totalCostLeft = costMatrix[x - 1][y - 1] + costLeft;
				int totalCostVertical = costMatrix[x - 1][y] + costVertical;
				int totalCostRight = costMatrix[x - 1][y - 1] + costRight;
				// find min
				int min = Math.min(totalCostLeft, Math.min(totalCostVertical, totalCostRight));

				costMatrix[x][y] = min;
			}
		}

		this.costsMatrix = costMatrix;
	}

}
