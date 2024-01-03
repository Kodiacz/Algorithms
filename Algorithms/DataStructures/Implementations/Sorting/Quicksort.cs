using System.Runtime.CompilerServices;

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

		private void ChatGPTQuicksort(IList<T> array, int low, int high) 
		{
			if (low < high)
			{
				int partitionIndex = ChatGPTPartition(array, low, high);

				ChatGPTQuicksort(array, low, partitionIndex - 1);
				ChatGPTQuicksort(array, partitionIndex + 1, high);
			}
		}

		private int ChatGPTPartition(IList<T> array, int low, int high) 
		{
			T pivot = array[high];
			int i = low - 1;

			for (int j = low; j < high; j++)
			{
				if (this.comparer.Compare(array[j], pivot) <= 0)
				{
					i++;
					Swap(array, i, j);
				}
			}

			Swap(array, i + 1, high);
			return i + 1;
		}

		public void GPTQuicksortV2(IList<T> array, int left, int right)
		{
			if (left < right)
			{
				// Partition the array, and get the index of the pivot element
				int pivotIndex = GPTPartitionV2(array, left, right);

				// Recursively sort the subarrays
				if (pivotIndex > 0)
				{
					GPTQuicksortV2(array, left, pivotIndex - 1);
				}

				GPTQuicksortV2(array, pivotIndex + 1, right);
			}
		}

		private int GPTPartitionV2(IList<T> array, int left, int right)
		{
			T pivot = array[left];
			int i = left + 1;
			int j = right;

			while (i <= j)
			{
				// Find element greater than pivot
				while (i <= j && this.comparer.Compare(array[i], pivot) <= 0)
				{
					i++;
				}

				// Find element less than pivot
				while (i <= j && this.comparer.Compare(array[j], pivot) > 0)
				{
					j--;
				}

				// Swap elements if found
				if (i < j)
				{
					T temp = array[i];
					array[i] = array[j];
					array[j] = temp;
				}
			}

			// Swap pivot with j
			T tempPivot = array[left];
			array[left] = array[j];
			array[j] = tempPivot;

			return j;
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
