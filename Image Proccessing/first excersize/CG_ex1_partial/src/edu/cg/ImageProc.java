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
				int red = (int) (rgb.getRed() * 0.2126);
				int green = (int) (rgb.getGreen() * 0.7152);
				int blue = (int) (rgb.getBlue() * 0.0722);
				int sum = red + green + blue;
				Color greyed = new Color(sum, sum, sum);
				out.setRGB(x, y, greyed.getRGB());
			}
		}
		return out;
	}

	public static BufferedImage horizontalDerivative(BufferedImage img) {
		BufferedImage grayed = grayScale(img);
		BufferedImage out = new BufferedImage(img.getWidth(), img.getHeight(),
				img.getType());
		try {
			for (int x = 0; x < grayed.getWidth() - 1; x++) {
				for (int y = 0; y < grayed.getHeight(); y++) {
					Color rgb_x = new Color(grayed.getRGB(x, y));
					Color rgb_x_1 = new Color(grayed.getRGB(x + 1, y));

					//R G B are equal in greyscale color.
					//calculating the delta three times
					//then pushing it into the new RGB map
					int val = rgb_x.getRed() - rgb_x_1.getRed();
					val = val * 3;
					System.out.println(Integer.toHexString(val));
					out.setRGB(x, y, val);

				}
			}
		} catch (Exception e) {
			System.out.println(e);
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
