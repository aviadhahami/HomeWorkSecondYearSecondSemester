/*
 * Name: Aviya Sela
 * ID No: 302221403
 */

import java.io.File;

public class DiskSearcher {

	// Capacity of the queue that holds the directories to be searched
	public static final int DIRECTORY_QUEUE_CAPACITY = 1000;

	// Capacity of the queue that holds the files found
	public static final int RESULTS_QUEUE_CAPACITY = 1000;

	private static final String USAGE = "Usage: java DiskSearcher " + "<extension> <root directory> <destination directory>" + "<# of searchers>"
			+ "<# of copiers>";

	/**
	 * Main method. Reads arguments from command line and starts the search.
	 * 
	 * @param args
	 *            - Command line arguments
	 */
	public static void main(String[] args) {

		// Validates number of arguments
		if (args.length != 5) {
			System.out.println(USAGE);
			System.exit(1);
		}

		// Gets all of the Arguments
		String extension = args[0];
		File root = new File(args[1]);
		File destination = new File(args[2]);
		int numOfSearcher = 0;
		int numOfCopier = 0;

		// Validates digits input
		try {
			numOfSearcher = Integer.parseInt(args[3]);
			numOfCopier = Integer.parseInt(args[4]);
		} catch (Exception e) {
			System.out.println(USAGE);
			System.exit(2); // Does not consist of digits
		}

		// Validates amount input
		if (numOfSearcher < 1 || numOfCopier < 1) {
			System.out.println(USAGE);
			System.exit(3); // Too few number of threads
		}

		// Validates directory input
		if (!destination.isDirectory()) {
			destination.mkdir();
		}

		// Starts the search
		search(extension, root, destination, numOfSearcher, numOfCopier);

	}

	/**
	 * Performs the search with Scouter, Searcher and Copier, according with the
	 * given command lines:
	 * 
	 * @param extension
	 *            - The file extension to be searched.
	 * @param root
	 *            - The directory to start searching from.
	 * @param destination
	 *            - The directory to copy all files to.
	 * @param searchThreads
	 *            - Number of Search threads to use.
	 * @param copierThreads
	 *            - Number of Copier threads to use.
	 */
	private static void search(String extension, File root, File destination, int numOfSearcher, int numOfCopier) {

		SynchronizedQueue<File> directories = new SynchronizedQueue<File>(DIRECTORY_QUEUE_CAPACITY);
		SynchronizedQueue<File> results = new SynchronizedQueue<File>(RESULTS_QUEUE_CAPACITY);

		Searcher[] searchers = new Searcher[numOfSearcher];
		Thread[] searcherThreads = new Thread[numOfSearcher];

		Copier[] copiers = new Copier[numOfCopier];
		Thread[] copierThreads = new Thread[numOfCopier];

		Scouter scouter = new Scouter(directories, root);
		Thread scouterThread = new Thread(scouter);

		scouterThread.start();

		// Starts all Searcher Threads
		for (int i = 0; i < numOfSearcher; i++) {
			searchers[i] = new Searcher(extension, directories, results);
			searcherThreads[i] = new Thread(searchers[i]);
			searcherThreads[i].start();
			System.out.println("search thread started, id " + searcherThreads[i].getName());
		}

		// Starts all Copier Threads
		for (int i = 0; i < numOfCopier; i++) {
			copiers[i] = new Copier(destination, results);
			copierThreads[i] = new Thread(copiers[i]);
			copierThreads[i].start();
			System.out.println("copy thread started, id " + copierThreads[i].getName());
		}

		// Waits for all threads to finish
		try {

			scouterThread.join();

			for (int i = 0; i < numOfSearcher; i++) {
				searcherThreads[i].join();
			}

			for (int i = 0; i < numOfCopier; i++) {
				copierThreads[i].join();
			}
		} catch (InterruptedException e) {
			System.err.println(e);
		}

		System.out.println("Good God!");

	}

}
