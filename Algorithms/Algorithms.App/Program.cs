//CustomLinkedListTest();
//BlockingQueTest();

const int size = 10000;
const string worstCase = "worst case";
const string bestCase = "best case";
const string averageCase = "average case";

BubblesortTest();
SellectionSortTest();
InsertionSortTest();
ShellSortTest();

//var test = BenchmarkRunner.Run<BenchmarkSortingAlgorithms>();

void ShellSortTest()
{
	List<int> randomItems = new List<int>();
	List<int> sortedItems = new List<int>();
	List<int> reversedItems = new List<int>();
	var rnd = new Random();

	for (int i = 1; i <= size; i++)
	{
		randomItems.Add(rnd.Next());
	}

	for (int i = 0; i < size; i++)
	{
		sortedItems.Add(i);
	}

	for (int i = size; i > 0; i--)
	{
		reversedItems.Add(i);
	}

	var comparator = new CallCountComparator<int>();
	var shellSort = new ShellSort<int>(comparator);
	var shellSortMethod = shellSort.Sort;

	RunMethod(shellSortMethod, sortedItems, comparator, nameof(shellSortMethod), bestCase);

	RunMethod(shellSortMethod, randomItems, comparator, nameof(shellSortMethod), averageCase);

	RunMethod(shellSortMethod, reversedItems, comparator, nameof(shellSortMethod), worstCase);

	Console.WriteLine($"End of {nameof(InsertionSortTest)}");
}

void InsertionSortTest()
{
	List<int> randomItems = new List<int>();
	List<int> sortedItems = new List<int>();
	List<int> reversedItems = new List<int>();
	var rnd = new Random();

	for (int i = 0; i < size; i++)
	{
		randomItems.Add(rnd.Next());
	}

	for (int i = 0; i < size; i++)
	{
		sortedItems.Add(i);
	}

	for (int i = size; i > 0; i--)
	{
		reversedItems.Add(i);
	}

	var comparator = new CallCountComparator<int>();
	var insertionSort = new InsertionSort<int>(comparator);
	var insertionSortGPTVersionTwo = insertionSort.InsertionSortGPTVersionTwo;
	var insertionSortGPT = insertionSort.InsertionSortGPT;

	RunMethod(insertionSortGPTVersionTwo, sortedItems, comparator, nameof(insertionSortGPTVersionTwo), bestCase);
	//RunMethod(insertionSortGPT, sortedItems, comparator, nameof(insertionSortGPT), bestCase);

	RunMethod(insertionSortGPTVersionTwo, randomItems, comparator, nameof(insertionSortGPTVersionTwo), averageCase);
	//RunMethod(insertionSortGPT, randomItems, comparator, nameof(insertionSortGPT), averageCase);

	RunMethod(insertionSortGPTVersionTwo, reversedItems, comparator, nameof(insertionSortGPTVersionTwo), worstCase);
	//RunMethod(insertionSortGPT, reversedItems, comparator, nameof(insertionSortGPT), worstCase);

	Console.WriteLine($"End of {nameof(InsertionSortTest)}");
}

void SellectionSortTest()
{
	List<int> randomItems = new List<int>();
	List<int> sortedItems = new List<int>();
	List<int> reversedItems = new List<int>();
	var rnd = new Random();

	for (int i = 0; i < size; i++)
	{
		randomItems.Add(rnd.Next());
	}

	for (int i = 0; i < size; i++)
	{
		sortedItems.Add(i);
	}

	for (int i = size; i > 0; i--)
	{
		reversedItems.Add(i);
	}

	var comparator = new CallCountComparator<int>();
	var selectionSort = new SelectionSort<int>(comparator);

	var selectionSortMethod = selectionSort.Sort;

	RunMethod(selectionSortMethod, sortedItems, comparator, nameof(selectionSortMethod), bestCase);

	RunMethod(selectionSortMethod, randomItems, comparator, nameof(selectionSortMethod), averageCase);

	RunMethod(selectionSortMethod, reversedItems, comparator, nameof(selectionSort), worstCase);

	Console.WriteLine($"End of {nameof(SellectionSortTest)}");
}

void BubblesortTest()
{
	List<int> randomItems = new List<int>();
	List<int> sortedItems = new List<int>();
	List<int> reversedItems = new List<int>();
	var rnd = new Random();

	for (int i = 0; i < size; i++)
	{
		randomItems.Add(rnd.Next());
	}

	for (int i = 0; i < size; i++)
	{
		sortedItems.Add(i);
	}

	for (int i = size; i > 0; i--)
	{
		reversedItems.Add(i);
	}

	var comparator = new CallCountComparator<int>();
	var bubbleSorter = new Bubblesort<int>(comparator);

	var bubbleSortMethod = bubbleSorter.Sort;

	RunMethod(bubbleSortMethod, sortedItems, comparator, nameof(bubbleSortMethod), bestCase);

	RunMethod(bubbleSortMethod, randomItems, comparator, nameof(bubbleSortMethod), averageCase);

	RunMethod(bubbleSortMethod, reversedItems, comparator, nameof(bubbleSortMethod), worstCase);

	Console.WriteLine($"End of {nameof(BubblesortTest)}");
}

void CustomLinkedListTest()
{
	var test = new CustomLinkedList<string>();

	test.Add("a");
	test.Add("b");
	test.Add("c");
	test.Delete(1);

	foreach (var item in test)
	{
		Console.WriteLine(item);
	}
}

void BlockingQueTest()
{
	BlockingQueue<int> blockingQueue = new BlockingQueue<int>(2);

	// Producer
	ThreadPool.QueueUserWorkItem(_ =>
	{
		for (int i = 0; i < 10; i++)
		{
			blockingQueue.Enqueue(i);
			Console.WriteLine($"Enqueued: {i}");
			Thread.Sleep(10);
		}
	});

	// Consumer
	ThreadPool.QueueUserWorkItem(_ =>
	{
		for (int i = 0; i < 10; i++)
		{
			int value = blockingQueue.Dequeue();
			Console.WriteLine($"Dequeued: {value}");
			Thread.Sleep(3000);
		}
	});
}

void PrintResult(string algorithmName, string caseName, ulong callCount, TimeSpan miliseconds)
{
	ChangeConsoleColor(nameof(algorithmName));
	Console.Write($"{algorithmName}");

	ChangeConsoleColor();
	Console.Write(" : ");

	ChangeConsoleColor(caseName);
	Console.Write($"{caseName}");

	ChangeConsoleColor();
	Console.Write(" : ");

	ChangeConsoleColor("compared");
	Console.Write($"{callCount} times compared");

	ChangeConsoleColor();
	Console.Write(" : ");

	ChangeConsoleColor("time");
	Console.WriteLine($"{miliseconds}");

	ChangeConsoleColor();
}

void RunMethod<T>(
	Func<IList<T>, IList<T>> action,
	IList<T> list,
	CallCountComparator<T> comparer,
	string nameOfAlgorithm,
	string caseName,
	bool shouldPrintResult = false) where T : IComparable<T>
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	comparer.ResetCallCount();

	var result = action(list);

	if (shouldPrintResult) Console.WriteLine(string.Join(" ", result));

	sw.Stop();
	PrintResult(nameOfAlgorithm, caseName, comparer.CallCount, sw.Elapsed);
}

void ChangeConsoleColor(string color = "")
{
	switch (color)
	{
		case "worst case":
			Console.ForegroundColor = ConsoleColor.Red;
			break;
		case "average case":
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			break;
		case "best case":
			Console.ForegroundColor = ConsoleColor.Green;
			break;
		case "algorithmName":
			Console.ForegroundColor = ConsoleColor.Blue;
			break;
		case "time":
			Console.ForegroundColor = ConsoleColor.Magenta;
			break;
		case "compared":
			Console.ForegroundColor = ConsoleColor.Cyan;
			break;
		default:
			Console.ForegroundColor = ConsoleColor.White;
			break;
	}
}