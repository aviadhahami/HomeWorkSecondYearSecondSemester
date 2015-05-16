public class MergeSortModified implements Sort {
	private static final int INSERTION_SORT_THRESHOLD = 8;

	public int[] sort(int[] input) {
		// TODO Auto-generated method stub
		return null;
	}

	public static final <E extends Comparable<? super E>> void sort(final E[] array) {
		sort(array, 0, array.length);
	}

	/**
	 * Sorts a specific range in the input array.
	 */
	public static final <E extends Comparable<? super E>> void sort(final E[] array, final int fromIndex, final int toIndex) {
		final int RANGE_LENGTH = toIndex - fromIndex;

		if (RANGE_LENGTH < 2) {
			// Trivially sorted or indices are ass-backwards.
			return;
		}

		final E[] buffer = array.clone();
		sortImpl(buffer, array, fromIndex, toIndex);
	}
	private static <E extends Comparable<? super E>> void sortImpl(final E[] source, final E[] target, final int fromIndex, final int toIndex) {
		final int RANGE_LENGTH = toIndex - fromIndex;

		if (RANGE_LENGTH < INSERTION_SORT_THRESHOLD) {
			// We need slightly larger range length than two elements in order
			// to avoid infinite recursion and, thus, stack overflow.
			for (int i = fromIndex + 1; i < toIndex; ++i) {
				int j = i - 1;

				while (j >= fromIndex && target[j].compareTo(target[j + 1]) > 0) {
					final E tmp = target[j];
					target[j] = target[j + 1];
					target[j + 1] = tmp;
					--j;
				}
			}

			return;
		}

		final int MID1 = fromIndex + RANGE_LENGTH / 3;
		final int MID2 = MID1 + RANGE_LENGTH / 3;

		sortImpl(target, source, fromIndex, MID1);
		sortImpl(target, source, MID1, MID2);
		sortImpl(target, source, MID2, toIndex);

		merge(source, target, fromIndex, MID1, MID2, toIndex);
	}

	private static <E extends Comparable<? super E>> void merge(final E[] source, final E[] target, final int p1, final int p2, final int p3,
			final int p4) {
		int i = p1;
		int idx1 = p1;
		int idx2 = p2;
		int idx3 = p3;

		while (idx1 < p2 && idx2 < p3 && idx3 < p4) {
			if (source[idx3].compareTo(source[idx1]) < 0) {
				if (source[idx3].compareTo(source[idx2]) < 0) {
					target[i++] = source[idx3++];
				} else {
					target[i++] = source[idx2++];
				}
			} else if (source[idx1].compareTo(source[idx2]) <= 0) {
				target[i++] = source[idx1++];
			} else {
				target[i++] = source[idx2++];
			}
		}

		while (idx1 < p2 && idx2 < p3) {
			target[i++] = source[idx1].compareTo(source[idx2]) <= 0 ? source[idx1++] : source[idx2++];
		}

		while (idx2 < p3 && idx3 < p4) {
			target[i++] = source[idx2].compareTo(source[idx3]) <= 0 ? source[idx2++] : source[idx3++];
		}

		while (idx1 < p2 && idx3 < p4) {
			target[i++] = source[idx1].compareTo(source[idx3]) <= 0 ? source[idx1++] : source[idx3++];
		}

		while (idx1 < p2) {
			target[i++] = source[idx1++];
		}
		while (idx2 < p3) {
			target[i++] = source[idx2++];
		}
		while (idx3 < p4) {
			target[i++] = source[idx3++];
		}
	}
}