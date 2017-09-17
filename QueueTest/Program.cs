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
			List<int> poped = new List<int>();

			Thread popThread = new Thread(() => poped.Add(q.Pop()));
			Thread popThread1 = new Thread(() => poped.Add(q.Pop()));
			Thread popThread2 = new Thread(() => poped.Add(q.Pop()));

			q.Push(8);

			
			

			Thread pushThread = new Thread(() => q.Push(12));

			q.Push(13);
			popThread2.Start();
			popThread.Start();
			popThread1.Start();
			

			pushThread.Start();
			Thread.Sleep(1000);
			foreach (var item in poped)
			{
				Console.WriteLine(item);
			}
			
			Console.ReadLine();
		}


	}
}
