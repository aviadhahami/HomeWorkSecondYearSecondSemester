/*
 * Name: Aviya Sela
 * ID No: 302221403
 */

import java.io.File;
import java.util.LinkedList;

public class Scouter implements Runnable {

	SynchronizedQueue<File> directories;
	File root;

	/**
	 * Constructor. 
	 * Initializes the scouter with a queue for the directories to be searched and a root directory to start from. 
	 * @param directories - A queue for directories to be searched
	 * @param root - Root directory to start from 
	 */
	public Scouter(SynchronizedQueue<File> directories, File root) {
		this.directories = directories;
		this.root = root; 
	}


	/**
	 * Starts the scouter thread. 
	 * 
	 * Lists directories under root directory and adds them to queue, 
	 * then lists directories in the next level and enqueues them and so on. 
	 * 
	 * This method begins by registering to the directory queue as a producer and when finishes, it unregisters from it.  
	 */
	@Override	
	public void run() {

		File currentDir;
		File[] files;

		// Holds all directories to scout, to allow recursive scouting
		LinkedList<File> tempDirList = new LinkedList<File>();

		this.directories.registerProducer();

		directories.enqueue(root);
		tempDirList.addLast(root);

		// Recursively scout all directories and their subdirectories
		while ((currentDir = tempDirList.poll()) != null) {

			files = currentDir.listFiles();

			if (files == null) {
				directories.unregisterProducer();
				return;
			}

			// Looks for subdirectories in the current directory 
			for (int i = 0; i < files.length; i++) {

				if (files[i].isDirectory()) {
					directories.enqueue(files[i]);
					tempDirList.addLast(files[i]);
				}
			}

			directories.unregisterProducer();	// Done
		}
	}
}
