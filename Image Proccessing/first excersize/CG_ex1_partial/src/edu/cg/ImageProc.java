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
				Color rgb = new Color(img.getRGB(x, y));
				int red = (int) (rgb.getRed() * 0.299);
				int green = (int) (rgb.getGreen() * 0.587);
				int blue = (int) (rgb.getBlue() * 0.114);
				int sum = red + green + blue;
				Color greyed = new Color(sum, sum, sum);
				out.setRGB(x, y, greyed.getRGB());
			}
		}
		return out;
	}

	public static BufferedImage horizontalDerivative(BufferedImage img) {
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());
		int currentDerivitive;
		for (int x = 0; x < img.getWidth(); x++) {
			for (int y = 0; y < img.getHeight(); y++) {
				if (x == 0 || y == 0 || x == img.getWidth() - 1
						|| y == img.getHeight() - 1) {
					currentDerivitive = 0;
				} else {
					currentDerivitive = img.getRGB(x + 1, y)
							- img.getRGB(x - 1, y);
				}

				out.setRGB(x, y, currentDerivitive);
			}
		}
		return out;
	}

	public static BufferedImage verticalDerivative(BufferedImage img) {
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());
		int currentDerivitive;
		for (int x = 0; x < img.getWidth(); x++) {
			for (int y = 0; y < img.getHeight(); y++) {
				if (x == 0 || y == 0 || x == img.getWidth() - 1
						|| y == img.getHeight() - 1) {
					currentDerivitive = 0;
				} else {
					currentDerivitive = img.getRGB(x, y + 1)
							- img.getRGB(x, y - 1);
				}

				out.setRGB(x, y, currentDerivitive);
			}
		}
		return out;
	}

	public static BufferedImage gradientMagnitude(BufferedImage img) {
		// TODO implement this
		return null;
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
