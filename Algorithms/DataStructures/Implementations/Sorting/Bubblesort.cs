namespace DataStructures.Implementations.Sorting
{
    public class Bubblesort<T> : IListSorter<T>
    {
        private readonly IComparer<T> comparer;

        public Bubblesort(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new NullReferenceException($"{nameof(Comparer)} cannot be null");
        }

        public IList<T> Sort(IList<T> list)
        {
            int size = list.Count;

            for (int pass = 1; pass < size; pass++)
            {
                for (int left = 0; left < size - pass; left++)
                {
                    int right = left + 1;

                    if (comparer.Compare(list[left], list[right]) > 0)
                    {
                        Swap(list, left, right);
                    }
                }
            }

            return list;
        }
        
        public IList<T> SortDescesnding(IList<T> list)
        {
            int size = list.Count;

            for (int pass = 1; pass < size; pass++)
            {
                for (int left = 0; left < size - pass; left++)
                {
                    int right = left + 1;

                    if (comparer.Compare(list[left], list[right]) < 0)
                    {
                        Swap(list, left, right);
                    }
                }
            }

            return list;
        }

        private void Swap<T>(IList<T> list, int left, int right)
        {
            T temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
