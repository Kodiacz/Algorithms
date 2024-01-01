using System.Security.Cryptography;
using System.Security.Principal;

namespace DataStructures.Implementations.Sorting
{
	public class ShellSort<T> : IListSorter<T>
	{
		private readonly IComparer<T> comparer;
		private int[] increments = new int[] { 121, 40, 13, 4, 1 };


		public ShellSort(IComparer<T> comparer)
		{
			this.comparer = comparer ?? throw new NullReferenceException($"{nameof(Comparer)} cannot be null");
		}

		public IList<T> Sort(IList<T> list)
		{
			for (int i = 0; i < increments.Length; i++)
			{
				int increment = this.increments[i];
				hSort(list, increment);
			}

			return list;
		}

		private void hSort(IList<T> list, int increment)
		{
			if (list.Count < (increment * 2)) return;

			for (int i = 0; i < increment; i++)
			{
				sortSublist(list, i, increment);
			}
		}

		private void sortSublist(IList<T> list, int startIndex, int increment)
		{
			for (int i = startIndex + increment; i < list.Count; i += increment)
			{
				T value = list[i];
				int j;

				for (j = i; j > startIndex; j -= increment)
				{
					T previousValue = list[j - increment];
					if (comparer.Compare(value, previousValue) >= 0) break;
					list[j] = previousValue;
				}

				list[j] = value;
			}
		}
	}
}
