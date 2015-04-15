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
				for (File i_currFileInArr : i_filesArray) {
					if (i_currFileInArr.isDirectory()) {
						o_directoryQue.enqueue(i_currFileInArr);
						i_scoutedItemsList.addLast(i_currFileInArr);
					}
				}
			}
		}
		o_directoryQue.unregisterProducer();
	}

}
