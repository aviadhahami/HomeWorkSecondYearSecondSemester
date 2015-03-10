import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

/*
 * @Author - Aviad Hahami
 */
public class TimeTest {

	public static void main(String[] args) throws IOException {

		// not enough args -> we're out
		if (args.length < 3) {
			System.err.println("check inputs");
			System.exit(1);
		}

		String sourceFilePath = null, destFilePath = null;
		int buffSize = 0;
		// some input checks
		boolean forceFlag = args[0] == "/force" ? true : false;
		try {
			if (forceFlag) {
				// means we go full params
				sourceFilePath = args[1];
				destFilePath = args[2];
				buffSize = Integer.parseInt(args[3]);
			} else {
				// we aint got forcer
				sourceFilePath = args[0];
				destFilePath = args[1];
				buffSize = Integer.getInteger(args[2]);
			}
		} catch (Exception e) {
			e.printStackTrace();
			System.err.println("check inputs, you've generated " + e);
			System.exit(1);
		}

		// done playing with inputs. GOGO!

		// copy file
		long startTime = System.currentTimeMillis();
		// copy logic
		boolean result = copyFile(sourceFilePath, destFilePath, buffSize, forceFlag);
		if (!result) {
			// copy didnt go well -> we leave
			System.err.println("Copying failed.");
			System.exit(1);
		}
		long endTime = System.currentTimeMillis();

		System.out.println("File " + sourceFilePath + " was copied to " + destFilePath);
		System.out.println("Runtime: " + (endTime - startTime) + "ms");

		/*
		 * Guidelines for the force flag: If the force flag was present, the
		 * copy operation should overwrite the target file, if not, and a file
		 * exists, some error message should be displayed and the copy will not
		 * overwrite the existing file
		 */
	}

	/*
	 * Copies a file to a specific path, using the specified buffer size.
	 * 
	 * @param srcFileName File to copy
	 * 
	 * @param toFileName Destination file name
	 * 
	 * @param bufferSize Buffer size in bytes
	 * 
	 * @param bOverwrite If file already exists, overwrite it
	 * 
	 * @return true when copy succeeds, false otherwise
	 */

	public static boolean copyFile(String srcFileName, String toFileName, int bufferSize, boolean bOverwrite) throws IOException {

		// lets check if the file is there.
		// if so, and if bOverwrite is false -> we're out boy !
		File f = new File(toFileName);
		if (f.exists() && !f.isDirectory() && !bOverwrite) {
			return false;
		}

		BufferedReader inputStream = null;
		PrintWriter outputStream = null;

		try {
			inputStream = new BufferedReader(new FileReader(srcFileName), bufferSize);
			outputStream = new PrintWriter(new FileWriter(toFileName));

			String line;
			while ((line = inputStream.readLine()) != null) {
				outputStream.println(line);
			}

		} catch (Exception e) {
			// oh-oh ! something happened...!
			if (inputStream != null) {
				inputStream.close();
			}
			if (outputStream != null) {
				outputStream.close();
			}

			return false;
		} finally {
			if (inputStream != null) {
				inputStream.close();
			}
			if (outputStream != null) {
				outputStream.close();
			}
		}
		return true;

	}
}
