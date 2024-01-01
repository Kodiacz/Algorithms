namespace Algorithms.App
{
	[ShortRunJob]
	[MemoryDiagnoser]
	public class BenchmarkSortingAlgorithms
	{
		const ulong size = 100_000;
		List<ulong> randomItems = new List<ulong>();
		List<ulong> sortedItems = new List<ulong>();
		List<ulong> reversedItems = new List<ulong>();

		[GlobalSetup]
		public void GlobalSetup()
		{
			var rnd = new Random();

			for (ulong i = 0; i < size; i++)
			{
				randomItems.Add((ulong)rnd.Next());
			}

			for (ulong i = 0; i < size; i++)
			{
				sortedItems.Add(i);
			}

			for (ulong i = size; i > 0; i--)
			{
				reversedItems.Add(i);
			}
		}

		[Benchmark]
		public void TestWorstCaseBubbleSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new Bubblesort<ulong>(callCountComparator).Sort(reversedItems);
			this.ReportCalls(nameof(Bubblesort<ulong>), callCountComparator.CallCount);
		}

		[Benchmark]
		public void TestWorstCaseSelectionSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new SelectionSort<ulong>(callCountComparator).Sort(reversedItems);
			this.ReportCalls(nameof(SelectionSort<ulong>), callCountComparator.CallCount);
		}

		[Benchmark]
		public void TestWorstCaseInsertionSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new InsertionSort<ulong>(callCountComparator).InsertionSortGPT(reversedItems);
			this.ReportCalls(nameof(InsertionSort<ulong>), callCountComparator.CallCount);
		}

		[Benchmark]
		public void TestBestCaseBubbleSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new Bubblesort<ulong>(callCountComparator).Sort(sortedItems);
			this.ReportCalls(nameof(Bubblesort<ulong>), callCountComparator.CallCount);
		}

		[Benchmark]
		public void TestBestCaseSelectionSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new SelectionSort<ulong>(callCountComparator).Sort(sortedItems);
			this.ReportCalls(nameof(InsertionSort<ulong>), callCountComparator.CallCount);
		}

		[Benchmark]
		public void TestBestCaseInsertionSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new InsertionSort<ulong>(callCountComparator).InsertionSortGPT(sortedItems);
			this.ReportCalls(nameof(InsertionSort<ulong>), callCountComparator.CallCount);
		}

		[Benchmark]
		public void TestAverageCaseBubbleSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new Bubblesort<ulong>(callCountComparator).Sort(randomItems);
			this.ReportCalls(nameof(Bubblesort<ulong>), callCountComparator.CallCount);
		}

		[Benchmark]
		public void TestAverageCaseSelectionSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new SelectionSort<ulong>(callCountComparator).Sort(randomItems);
			this.ReportCalls(nameof(SelectionSort<ulong>), callCountComparator.CallCount);
		}

		[Benchmark]
		public void TestAverageCaseInsertionSort()
		{
			CallCountComparator<ulong> callCountComparator = new CallCountComparator<ulong>();
			new InsertionSort<ulong>(callCountComparator).InsertionSortGPT(randomItems);
			this.ReportCalls(nameof(InsertionSort<ulong>), callCountComparator.CallCount);

		}

		private void ReportCalls(string sortAlgorithmName, ulong calls)
		{
			Console.WriteLine($"{sortAlgorithmName} : {calls}");
		}
	}
}
