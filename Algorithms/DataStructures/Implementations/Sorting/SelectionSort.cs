namespace DataStructures.Implementations.Sorting
{
    public class SelectionSort<T> : IListSorter<T>
    {
        private readonly IComparer<T> comparer;

        public SelectionSort(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new NullReferenceException($"{nameof(Comparer)} cannot be null");
        }

        public IList<T> Sort(IList<T> list)
        {
            int size = list.Count;

            for (int slot = 0; slot < size - 1; slot++)
            {
                int smallest = slot;

                for (int check = slot + 1; check < size; check++)
                {
                    if (comparer.Compare(list[check], list[smallest]) < 0)
                    {
                        smallest = check;
                    }
                }

                Swap(list, smallest, slot);
            }

            return list;
        }

		public IList<T> SortDescending(IList<T> list)
		{
			int size = list.Count;

			for (int slot = 0; slot < size - 1; slot++)
			{
				int smallest = slot;

				for (int check = slot + 1; check < size; check++)
				{
					if (comparer.Compare(list[check], list[smallest]) > 0)
					{
						smallest = check;
					}
				}

				Swap(list, smallest, slot);
			}

			return list;
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
