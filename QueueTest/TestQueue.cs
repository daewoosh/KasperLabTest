using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueTest
{
	public class TestQueue<T> : ITestQueue<T>
	{
		private Queue<T> _queueInternal;

		private object _lockObject;

		public TestQueue()
		{
			_queueInternal = new Queue<T>();
			_lockObject = new object();
		}

		public void Push(T element)
		{
			lock (_lockObject)
			{
				_queueInternal.Enqueue(element);
			}
		}


		public T Pop()
		{
			T element = default(T);
			bool hasItems = false;
			while (!hasItems)
			{
				lock (_lockObject)
				{
					var count = _queueInternal.Count;
					hasItems = count != 0;
					if (!hasItems)
						continue;
					element = _queueInternal.Dequeue();
					return element;
				}
			}
			return element;
		}
	}
}


