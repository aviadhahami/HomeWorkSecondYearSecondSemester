/*
 * Name: Aviya Sela
 * ID No: 302221403
 */

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class Copier implements Runnable {

	private SynchronizedQueue<File> resultsQue;
	private File fileDest;

	// Size of buffer used for a single file copy process
	private static final int COPY_BUFFER_SIZE = 4096;

	/**
	 * Constructor. 
	 * Initializes the worker with a destination directory and a queue of files to copy. 
	 * @param destination - Destination directory
	 * @param results - Queue of files found, to be copied
	 */
	public Copier(File destination, SynchronizedQueue<File> results) {
		resultsQue = results;
		fileDest = destination;
	}

	/**
	 * Runs the copier thread.
	 * 
	 * Thread will fetch files from queue and copy them, one after each other, 
	 * to the destination directory.
	 *  
	 *  When the queue has no more files, the thread finishes.
	 */
	@Override
	public void run() {

		File currentFile;
		File newFile;
		int size;

		while ((currentFile = resultsQue.dequeue()) != null) {

			// Sets the ground for try phrase
			FileInputStream input = null;
			FileOutputStream output = null;
			byte[] buffer = new byte[COPY_BUFFER_SIZE];

			String path = fileDest.getAbsolutePath();
			newFile = new File(path, currentFile.getName());

			try {
				input = new FileInputStream(currentFile);
				output = new FileOutputStream(newFile);

				// Copies file one buffer at a time
				while ((size = input.read(buffer, 0, COPY_BUFFER_SIZE)) > -1) {
					output.write(buffer, 0, size);
				}
			} catch (IOException e) {
				// Skips problem as directed 
				
			} finally {

				// Closes streams
				try {
					if (input != null) {
						input.close();
					}
					if (output != null) {
						output.close();
					}
				} catch (Exception e) {
					System.err.println("I/O Streams didn't close properly: " + e.getMessage());
				}

			}
		}
	}
}
