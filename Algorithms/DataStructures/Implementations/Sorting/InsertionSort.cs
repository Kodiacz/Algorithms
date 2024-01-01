using System;
using System.Runtime.CompilerServices;

namespace DataStructures.Implementations.Sorting
{
	public class InsertionSort<T> : IListSorter<T>
	{
		private readonly IComparer<T> comparer;

		public InsertionSort(IComparer<T> comparer)
		{
			this.comparer = comparer ?? throw new NullReferenceException($"{nameof(Comparer)} cannot be null");
		}

		//      public IList<T> Sort(IList<T> list)
		//      {
		//	int n = list.Count;

		//	for (int i = 1; i < n; i++)
		//	{
		//		T key = list[i];
		//		int j = i - 1;

		//		// Move elements of list[0..i-1] that are greater than key
		//		// to one position ahead of their current position
		//		while (j >= 0 && comparer.Compare(list[j], key) > 0/*list[j].CompareTo(key) > 0*/)
		//		{
		//			list[j + 1] = list[j];
		//			j--;
		//		}

		//		list[j + 1] = key;
		//	}

		//	return list;
		//}

		//public IList<T> SortDescending(IList<T> list)
		//{
		//	int n = list.Count;

		//	for (int i = 1; i < n; i++)
		//	{
		//		T key = list[i];
		//		int j = i - 1;

		//		// Move elements of list[0..i-1] that are greater than key
		//		// to one position ahead of their current position
		//		while (j >= 0 && comparer.Compare(list[j], key) < 0/*list[j].CompareTo(key) > 0*/)
		//		{
		//			list[j + 1] = list[j];
		//			j--;
		//		}

		//		list[j + 1] = key;
		//	}

		//	return list;
		//}

		public IList<T> Sort(IList<T> list)
		{
			List<T> result = new List<T>();

			foreach (T item in list)
			{
				int i = 0;

				while (i < result.Count && this.comparer.Compare(result[i], item) < 0)
				{
					i++;
				}

				result.Insert(i, item);
			}

			return result;
		}

		public IList<T> InsertionSortGPT(IList<T> list)
		{
			int n = list.Count;

			for (int i = 1; i < n; i++)
			{
				T key = list[i];
				int j = i - 1;

				while (j >= 0 && this.comparer.Compare(list[j], key) > 0)
				{
					list[j + 1] = list[j];
					j = j - 1;
				}

				list[j + 1] = key;
			}

			return list;
		}

		public IList<T> InsertionSortGPTVersionTwo(IList<T> list)
		{
			if (list == null)
				throw new ArgumentNullException(nameof(list));

			List<T> result = new List<T>();

			foreach (T item in list)
			{
				int slot = result.Count;

				while (slot > 0)
				{
					if (comparer.Compare(item, result[slot - 1]) >= 0)
					{
						break;
					}
					--slot;
				}

				result.Insert(slot, item);
			}

			return result;
		}

		public IList<T> SortDescending(IList<T> list)
		{
			List<T> result = new List<T>();

			foreach (T item in list)
			{
				int i = 0;

				while (i < result.Count && this.comparer.Compare(result[i], item) > 0)
				{
					i++;
				}

				result.Insert(i, item);
			}

			return result;
		}
	}
}
