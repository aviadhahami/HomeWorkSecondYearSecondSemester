/*
 * Name: Aviya Sela
 * ID No: 302221403
 */

import java.io.File;

public class Searcher implements Runnable {

	private String extension; 
	private SynchronizedQueue<File> directories;
	private SynchronizedQueue<File> results;

	/**
	 * Constructor. Initializes the searcher thread. 
	 * @param extension - File extension to look for 
	 * @param directories - Lists all the files in the directory
	 * @param results - Lists all extension-matching files
	 */
	public Searcher(String extension, SynchronizedQueue<File> directories, SynchronizedQueue<File> results) {
		this.extension = extension;
		this.directories = directories;
		this.results = results; 
	}

	/**
	 * Runs the searcher thread. 
	 * 
	 * Thread will fetch a directory to search in from the directory queue, 
	 * then search all files inside it (but will not recursively search subdirectories!). 
	 * Files that are found to have the given extension are enqueued to the results queue.
	 *  
	 * This method begins by registering to the results queue as a producer and when finishes, it unregisters from it.
	 */
	@Override
	public void run() {

		File[] files;

		int currentPos;
		File currentDir;
		String currentFile;
		String currentExt;

		// Enqueues directories to search in
		while ((currentDir = directories.dequeue()) != null) {

			files = currentDir.listFiles();

			this.results.registerProducer();

			if (files == null) {
				results.unregisterProducer();
				return;
			}

			// Goes through all files in the current directory
			for (int i = 0; i < files.length; i++) {

				currentFile = files[i].getName();
				currentPos = currentFile.lastIndexOf('.');
				currentExt = currentFile.substring(currentPos + 1);

				// Compares their extension with the required extension
				if (currentPos > 0 && currentExt.equals(extension)) {
					results.enqueue(files[i]);
				}
			}
			
			results.unregisterProducer();	// Done
		}

	}

}
