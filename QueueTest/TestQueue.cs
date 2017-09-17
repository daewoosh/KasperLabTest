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

		private ReaderWriterLockSlim _rwSlim;
		private ManualResetEventSlim _mreSlim;

		public TestQueue()
		{
			_queueInternal = new Queue<T>();
			_rwSlim = new ReaderWriterLockSlim();
			_mreSlim = new ManualResetEventSlim(false);
		}

		public void Push(T element)
		{
			try
			{
				_rwSlim.EnterWriteLock();
				_queueInternal.Enqueue(element);
				_mreSlim.Set();
			}
			finally
			{
				_rwSlim.ExitWriteLock();
			}
		}

		public T Pop()
		{
			try
			{
				_mreSlim.Wait();
				_rwSlim.EnterReadLock();
				var element = _queueInternal.Dequeue();
				var count = _queueInternal.Count;
				if (count == 0)
					_mreSlim.Reset();
				return element;
			}
			finally
			{

				_rwSlim.ExitReadLock();
			}
		}

	}
}
