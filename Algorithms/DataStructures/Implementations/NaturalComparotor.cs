namespace DataStructures.Implementations
{
	public class NaturalComparotor<T> : IComparer<T> where T : IComparable<T>
	{
		public int Compare(T? x, T? y)
		{
			return x!.CompareTo(y);
		}
	}
}
