import java.io.File;

/**
 * Main application class. This application searches for all files under some
 * given path that contain a given textual pattern. All files found are copied
 * to some specific directory.
 */
public class DiskSearcher {

	private static final int DIRECTORY_QUEUE_CAPACITY = 1000;
	private static final int RESULTS_QUEUE_CAPACITY = 1000;

	public static void main(String[] args) {
		int o_numberOfSearchThreads = 0;
		int o_numberOfCopyThreads = 0;

		if (args.length != 5) {
			System.err.println("Wrong number of args! expected " + 5 + " but recieved : " + args.length);
			System.exit(1);
		}

		// catching incoming arguments
		String o_fileExtention = args[0];
		File o_rootFolder = new File(args[1]);
		File o_destFolder = new File(args[2]);

		try {
			o_numberOfSearchThreads = Integer.parseInt(args[3]);
			o_numberOfCopyThreads = Integer.parseInt(args[4]);
		} catch (NumberFormatException e) {
			System.err.println("Expected two numbers, got sh*t instead");
			System.exit(1);
		}
		if (o_numberOfCopyThreads < 1 || o_numberOfSearchThreads < 1) {
			System.err.println("Negative number, negative attitude -> you're out ! ");
			System.exit(1);
		}

		// if no destination folder we generate it
		if (!o_destFolder.isDirectory()) {
			o_destFolder.mkdir();
		}

		// initializing queues
		SynchronizedQueue<File> o_directoryQueue = new SynchronizedQueue<File>(DIRECTORY_QUEUE_CAPACITY);
		SynchronizedQueue<File> o_resultsQueue = new SynchronizedQueue<File>(RESULTS_QUEUE_CAPACITY);

		// gogo gadget - > SCOUT
		Scouter o_scouter = new Scouter(o_directoryQueue, o_rootFolder);
		Thread o_scoutingThread = new Thread(o_scouter);
		o_scoutingThread.start();

		// put water in the pools
		Thread[] io_searchersPool = new Thread[o_numberOfSearchThreads];
		Thread[] io_copiersPool = new Thread[o_numberOfCopyThreads];

		// initialize search threads sequence
		for (int i = 0; i < o_numberOfSearchThreads; i++) {
			io_searchersPool[i] = new Thread(new Searcher(o_fileExtention, o_resultsQueue, o_directoryQueue));
			// DEOPLOY THE SENTINELS!
			io_searchersPool[i].start();
		}

		// initialize copy threads sequence
		for (int i = 0; i < o_numberOfCopyThreads; i++) {
			io_copiersPool[i] = new Thread(new Copier(o_destFolder, o_resultsQueue));
			// DEOPLOY THE SENTINELS!
			io_copiersPool[i].start();
		}

		try {
			// prepare to die threads !
			o_scoutingThread.join();
			for (int i = 0; i < io_searchersPool.length; i++) {
				io_searchersPool[i].join();
			}
			// are you dead?
			for (int i = 0; i < io_copiersPool.length; i++) {
				io_copiersPool[i].join();
			}
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		System.out.println("VICTORY! ALL YOUR BASE ARE BELONG TO US!");
	}

}