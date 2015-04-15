import java.io.File;

public class Searcher implements Runnable {
	private String i_fileExtension;
	private SynchronizedQueue<File> i_directoryQue;
	private SynchronizedQueue<File> o_resultsQue;

	public Searcher(SynchronizedQueue<File> dirQ, SynchronizedQueue<File> resQ, String fEx) {
		// initialize private variables
		i_fileExtension = fEx;
		o_resultsQue = resQ;
		i_directoryQue = dirQ;

		o_resultsQue.registerProducer();
	}

	@Override
	public void run() {
		File i_currentDir;
		String i_fName;
		File[] i_directoryFilesArray;
		String fNameRegex = i_fileExtension + "$";

		while ((i_currentDir = i_directoryQue.dequeue()) != null) {
			i_directoryFilesArray = i_currentDir.listFiles();
			if (i_directoryFilesArray != null) {
				for (int i = 0; i < i_directoryFilesArray.length; i++) {
					// TODO: fix the regex
					if (i_directoryFilesArray[i].getName().matches(fNameRegex)) {
						o_resultsQue.enqueue(i_directoryFilesArray[i]);
					}
				}
			}

		}
		o_resultsQue.unregisterProducer();

	}

}
