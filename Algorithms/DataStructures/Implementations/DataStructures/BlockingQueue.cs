public class BlockingQueue<T>
{
	private readonly Queue<T> queue = new Queue<T>();
	private readonly object syncLock = new object();
	private readonly int maxCapacity;

	public BlockingQueue(int maxCapacity)
	{
		if (maxCapacity <= 0)
		{
			throw new ArgumentException("Max capacity must be greater than zero.");
		}

		this.maxCapacity = maxCapacity;
	}

	public void Enqueue(T item)
	{
		lock (syncLock)
		{
			while (queue.Count == maxCapacity)
			{
				Monitor.Wait(syncLock); // Wait until there is space to enqueue
			}

			queue.Enqueue(item);
			Monitor.Pulse(syncLock); // Notify any waiting dequeue operation
		}
	}

	public T Dequeue()
	{
		lock (syncLock)
		{
			while (queue.Count == 0)
			{
				Monitor.Wait(syncLock); // Wait until there is an item to dequeue
			}

			T item = queue.Dequeue();
			Monitor.Pulse(syncLock); // Notify any waiting enqueue operation
			return item;
		}
	}

	public int Count
	{
		get
		{
			lock (syncLock)
			{
				return queue.Count;
			}
		}
	}

	public int MaxCapacity => maxCapacity;
}