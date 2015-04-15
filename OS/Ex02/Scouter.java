import java.io.File;
import java.util.LinkedList;

public class Scouter implements Runnable {

	private File i_headDir;
	private LinkedList<File> i_scoutedItemsList;
	private SynchronizedQueue<File> o_directoryQue;

	public Scouter(SynchronizedQueue<File> dirQue, File startingPoint) {
		i_headDir = startingPoint;
		o_directoryQue = dirQue;

		i_scoutedItemsList = new LinkedList<File>();
		o_directoryQue.registerProducer();
	}

	@Override
	public void run() {
		File[] i_filesArray;
		File i_currentDirectory;

		o_directoryQue.enqueue(i_headDir);
		i_scoutedItemsList.addLast(i_headDir);

		while ((i_currentDirectory = i_scoutedItemsList.poll()) != null) {
			i_filesArray = i_currentDirectory.listFiles();
			if (i_filesArray != null) {
				for (int i = 0; i < i_filesArray.length; i++) {
					if (i_filesArray[i].isDirectory()) {
						o_directoryQue.enqueue(i_filesArray[i]);
						i_scoutedItemsList.addLast(i_filesArray[i]);
					}
				}
			}
		}
		o_directoryQue.unregisterProducer();
	}

}
