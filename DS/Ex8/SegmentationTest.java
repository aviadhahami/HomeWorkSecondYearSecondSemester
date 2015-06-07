public class SegmentationTest {


	public static void main(String[] args) {

		dummyTest("maze1.PNG");
		dummyTest("maze2.PNG");
		dummyTest("maze3.PNG");
		dummyTest("maze4.PNG");
		dummyTest("maze5.PNG");
		dummyTest("maze6.PNG");
		dummyTest("maze7.PNG");
		dummyTest("maze8.PNG");
	}

	public static void dummyTest(String imagePath) {
		
		System.out.println("Results for " + imagePath);
		Segmentation seg = new Segmentation(imagePath);
		
		System.out.println(seg.areConnected(0, 0, 4, 3));
		System.out.println(seg.areConnected(2, 3, 8, 8));
		System.out.println(seg.areConnected(2, 3, 6, 15));
		System.out.println(seg.areConnected(13, 11, 6, 15));
		System.out.println(seg.areConnected(6, 44, 42, 74));
		System.out.println(seg.areConnected(38, 60, 39, 60));
		System.out.println(seg.areConnected(79, 79, 0, 0));
		System.out.println("Number of components: " + seg.getNumComponents());
		System.out.println("Maze has solution: " + seg.mazeHasSolution());
		
		System.out.println("------------------------------------------------");
	}
}
