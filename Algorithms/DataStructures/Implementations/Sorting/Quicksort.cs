namespace DataStructures.Implementations.Sorting
{
	public class Quicksort<T> : IListSorter<T>
	{
		private readonly IComparer<T> comparer;

		public Quicksort(IComparer<T> comparer)
		{
			this.comparer = comparer ?? throw new NullReferenceException($"{nameof(Comparer)} cannot be null");
		}

		public IList<T> Sort(IList<T> list)
		{
			this.QuickSort(list, 0, list.Count - 1);

			return list;
		}

		public void MyQuickSort(IList<T> list, int pivot, int i, int j)
		{
			for (int k = 0; k < pivot; k++)
			{
				if (this.comparer.Compare(list[pivot], list[j]) > 0)
				{
					i++;
					this.Swap(list, i, j);
				}

				j++;

				if (j == pivot)
				{
					if (i > 0 && this.comparer.Compare(list[j], list[i]) > 0)
					{
						i++;
						this.Swap(list, i, j);
					}
					else
					{
						if (i < 0) i++;
						this.Swap(list, i, j);
					}
				}
			}

			if (pivot <= 0) return;

			this.MyQuickSort(list, i - 1, -1, 0);
			this.MyQuickSort(list, list.Count - 1, -1, 0);
		}

		public void QuickSort(IList<T> list, int startIndex, int endIndex)
		{
			if (startIndex < 0 || endIndex >= list.Count) return;

			if (endIndex <= startIndex) return;

			T value = list[endIndex];

			int partition = this.Partition(list, value, startIndex, endIndex - 1);

			if (this.comparer.Compare(list[partition], value) < 0)
			{
				partition++;
			}

			this.Swap(list, partition, endIndex);

			this.QuickSort(list, startIndex, partition - 1);
			this.QuickSort(list, partition + 1, endIndex);
		}

		private int Partition(IList<T> list, T value, int lefIndex, int rightIndex)
		{
			int left = lefIndex;
			int right = rightIndex;

			while (left < right)
			{
				if (this.comparer.Compare(list[left], value) < 0)
				{
					left++;
					continue;
				}

				if (this.comparer.Compare(list[right], value) >= 0)
				{
					right--;
					continue;
				}

				this.Swap(list, left, right);
				left++;
			}

			return left;
		}

		private void Swap<T>(IList<T> list, int left, int right)
		{
			if (left == right) return;
			
			T temp = list[left];
			list[left] = list[right];
			list[right] = temp;
		}
	}
}
