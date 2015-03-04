package edu.cg;

import java.awt.image.BufferedImage;

//Retargeter – A class that does seam carving.
public class Retargeter {

	public Retargeter(BufferedImage m_img, boolean m_isVertical) {
		// TODO do initialization and preprocessing here
		//  does all necessary preprocessing, including the calculation
		// of the seam order matrix. You should implement this.
		calculateSeamsOrderMatrix();
	}

	public void getSeamsOrderMatrix() {
		// you can implement this (change the output type)
	}

	public void getOrigPosMatrix() {
		// you can implement this (change the output type)
	}

	public BufferedImage retarget(int newSize) {
		// TODO implement this
		return null;
	}

	private void calculateSeamsOrderMatrix() {
		// TODO implement this - this calculates the order in which seams are
		// extracted

	}

	private void calculateCostsMatrix(int w) {
		// TODO implement this - cost matrix should be calculated for a given
		// image width w
		// to be used inside calculateSeamsOrderMatrix()
	}

}
