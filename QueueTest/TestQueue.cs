using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueTest
{
	public interface ITestQueue<T>
	{
		void Push(T element);

		T Pop();
	}


	public class TestQueue<T> : ITestQueue<T>
	{
		private Queue<T> _queueInternal;

		private volatile bool _hasElement;

		private object _lockForRead = new object();
		private object _lockForWrite = new object();

		public TestQueue()
		{
			_queueInternal = new Queue<T>();
			_hasElement = false;
		}

		public void Push(T element)
		{
			lock (_lockForWrite)
			{
				_queueInternal.Enqueue(element);
				_hasElement = true;
			}

		}

		public T Pop()
		{
			lock (_lockForRead)
			{
				while (!_hasElement)
				{ }
				var res = _queueInternal.Dequeue();
				_hasElement = _queueInternal.Count > 0;
				return res;
			}
		}

	}
}
