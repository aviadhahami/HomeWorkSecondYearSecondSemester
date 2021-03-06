import java.io.File;

public class Searcher implements Runnable {
	private String i_fileExtension;
	private SynchronizedQueue<File> o_directoryQue;
	private SynchronizedQueue<File> o_resultsQue;

	public Searcher(String fEx, SynchronizedQueue<File> resQ, SynchronizedQueue<File> dirQ) {
		// initialize private variables
		i_fileExtension = fEx;
		o_resultsQue = resQ;
		o_directoryQue = dirQ;

		o_resultsQue.registerProducer();
	}

	@Override
	public void run() {
		File i_currentDir;
		File[] i_directoryFilesArray;
		int fileEndingPos;
		while ((i_currentDir = o_directoryQue.dequeue()) != null) {
			i_directoryFilesArray = i_currentDir.listFiles();
			if (i_directoryFilesArray != null) {
				for (int i = 0; i < i_directoryFilesArray.length; i++) {
					fileEndingPos = i_directoryFilesArray[i].getName().lastIndexOf('.');
					if (fileEndingPos > 0 && i_directoryFilesArray[i].getName().substring(++fileEndingPos).equals(i_fileExtension)) {
						o_resultsQue.enqueue(i_directoryFilesArray[i]);
					}
				}
			}

		}
		o_resultsQue.unregisterProducer();

	}
}
