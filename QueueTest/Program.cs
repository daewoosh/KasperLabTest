using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueTest
{
	class Program
	{
		static void Main()
		{
			var q = new TestQueue<int>();


			Thread popThread = new Thread(() => PopFromQueue(q));
			Thread popThread1 = new Thread(() => PopFromQueue(q));
			Thread popThread2 = new Thread(() => PopFromQueue(q));


			popThread.Start();
			popThread1.Start();

			PushToQueue(q, 8);
			Thread pushThread = new Thread(() => PushToQueue(q, 12));
			PushToQueue(q, 13);
			pushThread.Start();
			popThread2.Start();
			Console.ReadLine();
		}

		private static void PopFromQueue<T>(ITestQueue<T> queue)
		{
			var value = queue.Pop();
			Console.WriteLine($"Pop element from thread with ID {Thread.CurrentThread.ManagedThreadId} with value = {value}");
		}

		private static void PushToQueue<T>(ITestQueue<T> queue, T value)
		{
			queue.Push(value);
			Console.WriteLine($"Push element from thread with ID {Thread.CurrentThread.ManagedThreadId} with value = {value}");
		}


	}
}
