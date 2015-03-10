import java.io.IOException;
import java.util.Iterator;

public class TimeTestRunner {

	public static void main(String[] args) {
		String[] gogo = new String[4];
		gogo[0] = "/force";
		// gogo[0] = null;
		gogo[1] = "C:/Users/aviadh/Downloads/test/books.txt"; // src
		gogo[2] = "C:/Users/aviadh/Downloads/test/newBook.txt"; // dest
		String[] buffSizes = new String[5];
		buffSizes[0] = "128";
		buffSizes[1] = "256";
		buffSizes[2] = "512";
		buffSizes[3] = "1024";
		buffSizes[4] = "2048";
		try {
			for (String buff : buffSizes) {
				gogo[3] = buff;
				TimeTest.main(gogo);
			}

		} catch (IOException e) {
			// TODO Auto-generated catch block
			// e.printStackTrace();
		}
	}
}
