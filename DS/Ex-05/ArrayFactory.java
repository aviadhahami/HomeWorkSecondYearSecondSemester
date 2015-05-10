
public class ArrayFactory {
	
	public static int[] generateRandomArray(int size) {
		int[] array = new int[size];
		for (int i=0; i < size; i++)
			array[i] = (int)(Math.random()*size);
		return array;
	}
	
	public static void printArray(int [] array)
	{
		StringBuilder sb = new StringBuilder();
		sb.append('[');
		for(int i = 0; i<array.length; i++)
			sb.append(array[i]+ " ");
		sb.setCharAt(sb.length()-1, ']');
		
		System.out.println(sb.toString());
		
	}
}
