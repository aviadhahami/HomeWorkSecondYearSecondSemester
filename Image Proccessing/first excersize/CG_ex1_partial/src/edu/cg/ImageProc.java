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
		BufferedImage out = img;
		for (int x = 0; x < out.getWidth(); ++x) {
			for (int y = 0; y < out.getHeight(); ++y) {
				int rgb = out.getRGB(x, y);
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
		BufferedImage grayed = grayScale(img);
		BufferedImage out = new BufferedImage(grayed.getWidth(),
				grayed.getHeight(), grayed.getType());

		for (int x = 0; x < grayed.getWidth() - 1; x++) {
			for (int y = 0; y < grayed.getHeight(); y++) {
				if (x == 0) {
					out.setRGB(x, y, 0);
				} else {
					int I = grayed.getRGB(x + 1, y);
					int I_1 = grayed.getRGB(x, y);

					out.setRGB(x, y, I - I_1);
				}
			}
		}
		return out;
	}

	public static BufferedImage verticalDerivative(BufferedImage img) {
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());

		return out;
	}

	public static BufferedImage gradientMagnitude(BufferedImage img) {
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());
		// implement
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
