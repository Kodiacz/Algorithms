namespace DataStructures.Implementations
{
	public class CallCountComparator<T> : IComparer<T> where T : IComparable<T>
	{
		private ulong callCaount = 0;

		public int Compare(T? x, T? y)
		{
			callCaount++;
			return x!.CompareTo(y);
		}

		public ulong CallCount => this.callCaount;

		public void ResetCallCount() => callCaount = 0;
	}
}
