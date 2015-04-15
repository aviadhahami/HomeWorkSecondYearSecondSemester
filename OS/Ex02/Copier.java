import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

public class Copier implements Runnable {
	private File destFile;
	private String filePath;
	private SynchronizedQueue<File> resultQue;

	/**
	 * 
	 * @param resultQue
	 *            - Queue of results
	 * 
	 * @param destFile
	 *            - destination file
	 */
	public Copier(File destFile, SynchronizedQueue<File> resultQue) {
		this.filePath = destFile.getAbsolutePath();
		this.destFile = destFile;
		this.resultQue = resultQue;
	}

	@Override
	public void run() {
		File destinationFile;
		File f;
		while ((f = resultQue.dequeue()) != null) {
			try {
				destinationFile = new File(this.filePath, f.getName());
				copyFileContent(f, destinationFile);
			} catch (Exception e) {
				// we go on...
			}

		}

	}

	private void copyFileContent(File sourceFile, File destinationFile) throws IOException {
		int byteBufferSize = 2048;
		int length = 0;
		// file I/O streams
		InputStream fIS = null;
		OutputStream fOS = null;
		byte[] bufferSize = new byte[byteBufferSize];
		try {
			fIS = new FileInputStream(sourceFile);
			fOS = new FileOutputStream(destinationFile);
			while ((length = fIS.read(bufferSize)) > 0) {
				fOS.write(bufferSize, 0, length);

			}
		} catch (Exception e) {
			// TODO: handle exception
		} finally {
			// closing files
			fIS.close();
			fOS.close();
		}
	}
}
