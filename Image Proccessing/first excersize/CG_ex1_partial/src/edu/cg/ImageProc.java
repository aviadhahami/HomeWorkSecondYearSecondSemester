/*
 * This class defines some static methods of image processing.
 */

package edu.cg;

import java.awt.Color;
import java.awt.image.BufferedImage;

public class ImageProc {

	public static BufferedImage scaleDown(BufferedImage img, int factor) {
		if (factor <= 0)
			throw new IllegalArgumentException();
		int newHeight = img.getHeight() / factor;
		int newWidth = img.getWidth() / factor;
		BufferedImage out = new BufferedImage(newWidth, newHeight,
				img.getType());
		for (int x = 0; x < newWidth; x++)
			for (int y = 0; y < newHeight; y++)
				out.setRGB(x, y, img.getRGB(x * factor, y * factor));
		return out;
	}

	public static BufferedImage grayScale(BufferedImage img) {
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());
		for (int x = 0; x < img.getWidth(); x++) {
			for (int y = 0; y < img.getHeight(); y++) {
				int rgb = img.getRGB(x, y);
				int r = (rgb >> 16) & 0xFF;
				int g = (rgb >> 8) & 0xFF;
				int b = (rgb & 0xFF);

				int grayLevel = (r + g + b) / 3;
				int gray = (grayLevel << 16) + (grayLevel << 8) + grayLevel;
				out.setRGB(x, y, gray);

			}
		}
		return out;
	}

	public static BufferedImage horizontalDerivative(BufferedImage img) {
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());
		for (int x = 0; x < img.getWidth() - 1; x++) {
			for (int y = 0; y < img.getHeight(); y++) {
				if (x == 0 || y == 0 || x == img.getWidth() - 1
						|| y == img.getHeight() - 1) {
					out.setRGB(x, y, 0);
				} else {
					Color x_prevPix = new Color(img.getRGB(x - 1, y));
					int x_prevPixGrey = (x_prevPix.getRed()
							+ x_prevPix.getBlue() + x_prevPix.getGreen()) / 3;

					Color x_nextPix = new Color(img.getRGB(x + 1, y));
					int x_nxtPixGrey = (x_nextPix.getRed()
							+ x_nextPix.getGreen() + x_nextPix.getBlue()) / 3;

					int xDeriv = ((x_prevPixGrey - x_nxtPixGrey + 255) / 2);

					out.setRGB(x, y, new Color(xDeriv, xDeriv, xDeriv).getRGB());
				}

			}
		}

		return out;
	}

	public static BufferedImage verticalDerivative(BufferedImage img) {
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());
		for (int x = 0; x < img.getWidth() - 1; x++) {
			for (int y = 0; y < img.getHeight(); y++) {
				if (x == 0 || y == 0 || x == img.getWidth() - 1
						|| y == img.getHeight() - 1) {
					out.setRGB(x, y, 0);
				} else {
					Color y_prevPix = new Color(img.getRGB(x, y - 1));
					int y_prevPixGrey = (y_prevPix.getRed()
							+ y_prevPix.getBlue() + y_prevPix.getGreen()) / 3;

					Color y_nextPix = new Color(img.getRGB(x, y + 1));
					int y_nxtPixGrey = (y_nextPix.getRed()
							+ y_nextPix.getGreen() + y_nextPix.getBlue()) / 3;

					int yDeriv = ((y_prevPixGrey - y_nxtPixGrey + 255) / 2);

					out.setRGB(x, y, new Color(yDeriv, yDeriv, yDeriv).getRGB());
				}

			}
		}

		return out;
	}

	public static BufferedImage gradientMagnitude(BufferedImage img) {
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());
		for (int x = 0; x < img.getWidth() - 1; x++) {
			for (int y = 0; y < img.getHeight(); y++) {
				if (x == 0 || y == 0 || x == img.getWidth() - 1
						|| y == img.getHeight() - 1) {
					out.setRGB(x, y, 0);
				} else {
					Color x_prevPix = new Color(img.getRGB(x - 1, y));
					int x_prevPixGrey = (x_prevPix.getRed()
							+ x_prevPix.getBlue() + x_prevPix.getGreen()) / 3;

					Color x_nextPix = new Color(img.getRGB(x + 1, y));
					int x_nxtPixGrey = (x_nextPix.getRed()
							+ x_nextPix.getGreen() + x_nextPix.getBlue()) / 3;

					int xDeriv = ((x_prevPixGrey - x_nxtPixGrey + 255) / 2);

					Color y_prevPix = new Color(img.getRGB(x, y - 1));
					int y_prevPixGrey = (y_prevPix.getRed()
							+ y_prevPix.getBlue() + y_prevPix.getGreen()) / 3;

					Color y_nextPix = new Color(img.getRGB(x, y + 1));
					int y_nxtPixGrey = (y_nextPix.getRed()
							+ y_nextPix.getGreen() + y_nextPix.getBlue()) / 3;

					int yDeriv = ((y_prevPixGrey - y_nxtPixGrey + 255) / 2);

					int gradVal = (int) Math.sqrt(xDeriv * xDeriv - yDeriv
							* yDeriv);

					out.setRGB(x, y,
							new Color(gradVal, gradVal, gradVal).getRGB());

				}

			}
		}

		return out;
	}

	public static BufferedImage retargetSize(BufferedImage img, int width,
			int height) {
		// TODO implement this
		return null;
	}

	public static BufferedImage showSeams(BufferedImage img, int width,
			int height) {
		// TODO implement this
		return null;

	}

}
//