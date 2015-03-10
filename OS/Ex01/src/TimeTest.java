/*
 * @Author - Aviad Hahami
 */
public class TimeTest {
	// force-flagged main method
	public static void main(String[] args) {

		/*
		 * The application should receive the source file path, target file path
		 * and buffer size as command line arguments. By default, the
		 * application does not overwrite an existing file. This can be forced
		 * by adding the /force argument.
		 */
		// Usage: java TimeTest [/force] source_file target_file buffer_size

		//not enough args -> we're out
		if (args[3] == null) {
			System.err.println("check inputs");
			System.exit(1);
		}

		String sourceFilePath, destFilePath;
		int buffSize;
		// some input checks
		boolean forceFlag = args[0] == "/force" ? true : false;
		try {
			if (forceFlag) {
				// means we go full params
				sourceFilePath = args[1];
				destFilePath = args[2];
				buffSize = Integer.getInteger(args[3]);
			} else {
				// we aint got forcer
				sourceFilePath = args[0];
				destFilePath = args[1];
				buffSize = Integer.getInteger(args[2]);
			}
		} catch (Exception e) {
			e.printStackTrace();
			System.err.println("check inputs.");
			System.exit(1);
		}

		// done playing with inputs. GOGO!

	}
}
