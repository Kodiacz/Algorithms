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
			int lastIndex = list.Count - 1;

			MyQuickSort(list, lastIndex, -1, 0);

			return list;
		}

		public void MyQuickSort(IList<T> list, int pivot, int i, int j)
		{
			for (int k = 0; k < list.Count; k++)
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

			if (list.Count == 2 || list.Count == 1) return;

			var leftArray = list.Take(pivot - 1).ToList();
			var rightArray = list.Skip(pivot).ToList();

			var leftPivot = leftArray.Count - 1;
			var rightPivot = rightArray.Count - 1;

			this.MyQuickSort(leftArray, leftPivot, -1, 0);
			this.MyQuickSort(rightArray, rightPivot, -1, 0);
		}


		private void Swap<T>(IList<T> list, int left, int right)
		{
			T temp = list[left];
			list[left] = list[right];
			list[right] = temp;
		}
	}
}
