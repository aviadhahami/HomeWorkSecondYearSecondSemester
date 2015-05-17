import java.util.ArrayList;

/**
 * @author Aviad Hahami && Hila Ben Hamo
 *
 */
public class MergeSortModified implements Sort {
	/*
	 * Divide by 3 merge sort
	 */
	public int[] sort(int[] i_InputArray) {
		ArrayList<Integer> io_GivenArray = new ArrayList<>();
		for (Integer i_currentIntFromInput : i_InputArray) {
			io_GivenArray.add(i_currentIntFromInput);
		}
		io_GivenArray.trimToSize();
		return convertIntegerArrayListToIntegerArray(mergeSortThreeWay(io_GivenArray));
	}

	/*
	 * Actual sorter, the previous one is just to meet interface
	 */
	private ArrayList<Integer> mergeSortThreeWay(ArrayList<Integer> i_InputArray) {
		if (i_InputArray.size() <= 1) {
			return i_InputArray;
		}
		// calculate array size divided by three
		int i_CurrentSizeDividedByThree = i_InputArray.size() / 3;

		// allocate new arrays for further usage
		ArrayList<Integer> io_LeftArray = new ArrayList<>(i_CurrentSizeDividedByThree);
		ArrayList<Integer> io_MiddleArray = new ArrayList<>(i_CurrentSizeDividedByThree);
		ArrayList<Integer> io_RightArray = new ArrayList<>(i_CurrentSizeDividedByThree);
		// copy arrays to new allocations
		for (int i = 0; i < i_InputArray.size(); i++) {
			if (i <= i_CurrentSizeDividedByThree) {
				io_LeftArray.add(i_InputArray.get(i));
			} else if (i > i_CurrentSizeDividedByThree && i <= i_CurrentSizeDividedByThree * 2) {
				io_MiddleArray.add(i_InputArray.get(i));
			} else {
				io_RightArray.add(i_InputArray.get(i));
			}
		}

		// send to sorter
		io_LeftArray = mergeSortThreeWay(io_LeftArray);
		io_MiddleArray = mergeSortThreeWay(io_MiddleArray);
		io_RightArray = mergeSortThreeWay(io_RightArray);

		return merge(io_LeftArray, io_MiddleArray, io_RightArray);
	}

	private ArrayList<Integer> merge(ArrayList<Integer> io_LeftArray, ArrayList<Integer> io_MiddleArray, ArrayList<Integer> io_RightArray) {

		// allocate array list in triple the size
		ArrayList<Integer> i_SortedArray = new ArrayList<Integer>(io_LeftArray.size() * 3);

		// allocoate arrays for the inputs
		ArrayList<Integer> i_LeftArray = new ArrayList<>(io_LeftArray.size());
		ArrayList<Integer> i_MiddleArray = new ArrayList<>(io_MiddleArray.size());
		ArrayList<Integer> i_RightArray = new ArrayList<>(io_RightArray.size());

		// copy the stuff
		i_LeftArray.addAll(io_LeftArray);
		i_MiddleArray.addAll(io_MiddleArray);
		i_RightArray.addAll(io_RightArray);

		// Initialize some containers
		int i_CurrentLeftElement, i_CurrentMiddleElement, i_CurrentRightElement;

		// that's a bit different from the regular merge
		while (listHasMoreElements(i_LeftArray) || listHasMoreElements(i_MiddleArray) || listHasMoreElements(i_RightArray)) {

			// first iteration over all three
			while (listHasMoreElements(i_LeftArray) && listHasMoreElements(i_MiddleArray) && listHasMoreElements(i_RightArray)) {
				// make it stylish
				i_CurrentLeftElement = i_LeftArray.get(0);
				i_CurrentMiddleElement = i_MiddleArray.get(0);
				i_CurrentRightElement = i_RightArray.get(0);

				// filter by smallest
				if (i_CurrentLeftElement <= i_CurrentRightElement && i_CurrentLeftElement <= i_CurrentMiddleElement) {
					i_SortedArray.add(i_CurrentLeftElement);
					i_LeftArray.remove(0);
				} else if (i_CurrentMiddleElement <= i_CurrentLeftElement && i_CurrentMiddleElement <= i_CurrentRightElement) {
					i_SortedArray.add(i_CurrentMiddleElement);
					i_MiddleArray.remove(0);
				} else {
					i_SortedArray.add(i_CurrentRightElement);
					i_RightArray.remove(0);
				}

			}

			/*
			 * FOLLOWING PART EXPLANATION ! assuming we've arrived here, we can
			 * tell that we have at least one empty array. Unlike regular merge,
			 * we can not just "dump" everything inside the main result as we
			 * have 2 other arrays that may or may not be ordered. Therefore - I
			 * test all three comparison permutations. At the end of this, I
			 * still might have one (and one only!) non-empty array, So I just
			 * dump everything inside and keep going with my life. This thing is
			 * not pretty, but I have a shit load of homework to complete so I
			 * will go with this. Please don't show this to job recruiters :)
			 */

			// left and mid iterator...
/*			while (listHasMoreElements(i_LeftArray) && listHasMoreElements(i_MiddleArray)) {
				// make it stylish
				i_CurrentLeftElement = i_LeftArray.get(0);
				i_CurrentMiddleElement = i_MiddleArray.get(0);

				// filter by smallest
				if (i_CurrentLeftElement <= i_CurrentMiddleElement) {
					i_SortedArray.add(i_CurrentLeftElement);
					i_LeftArray.remove(0);
				} else {
					i_SortedArray.add(i_CurrentMiddleElement);
					i_MiddleArray.remove(0);
				}

			}

			// left and right
			while (listHasMoreElements(i_LeftArray) && listHasMoreElements(i_RightArray)) {
				// make it stylish
				i_CurrentLeftElement = i_LeftArray.get(0);
				i_CurrentRightElement = i_RightArray.get(0);

				// filter by smallest
				if (i_CurrentLeftElement <= i_CurrentRightElement) {
					i_SortedArray.add(i_CurrentLeftElement);
					i_LeftArray.remove(0);
				} else {
					i_SortedArray.add(i_CurrentRightElement);
					i_RightArray.remove(0);
				}

			}

			// right and mid
			while (listHasMoreElements(i_MiddleArray) && listHasMoreElements(i_RightArray)) {
				// make it stylish
				i_CurrentMiddleElement = i_MiddleArray.get(0);
				i_CurrentRightElement = i_RightArray.get(0);

				// filter by smallest
				if (i_CurrentMiddleElement <= i_CurrentRightElement) {
					i_SortedArray.add(i_CurrentMiddleElement);
					i_MiddleArray.remove(0);
				} else {
					i_SortedArray.add(i_CurrentRightElement);
					i_RightArray.remove(0);
				}

			}*/

			// dumping in
			i_SortedArray.addAll(i_LeftArray);
			i_SortedArray.addAll(i_MiddleArray);
			i_SortedArray.addAll(i_RightArray);

			// ALL IN ! GET OUT !
			break;
		}
		return i_SortedArray;
	}

	/*
	 * long name for simple iterator
	 */
	private int[] convertIntegerArrayListToIntegerArray(ArrayList<Integer> i_SortedArray) {

		// fixed size
		i_SortedArray.trimToSize();

		// allocate size
		int[] io_CopiedArray = new int[i_SortedArray.size()];
		int i_CopyPointer = 0;

		// copy from the array list to array
		for (int i_currentItem : i_SortedArray) {
			io_CopiedArray[i_CopyPointer] = i_currentItem;
			i_CopyPointer++;
		}

		return io_CopiedArray;
	}

	/*
	 * returns true if the given array has elements
	 */
	private boolean listHasMoreElements(ArrayList<Integer> i_arr) {
		return i_arr.size() == 0 ? false : true;
	}

}
