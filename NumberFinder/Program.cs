using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NumbersFinder
{
	class Program
	{
		static void Main(string[] args)
		{
			var test = new NumbersFinder();
			int sum = 8;
			var res = test.FindNumbers(new int[] { 1, 2, 3, 4, 5, 4, 6, 7, -1, 0, 13, 6, 4, 4 }, sum);
			foreach (var item in res)
			{
				Console.WriteLine("{0}+{1}={2}", item.Item1, item.Item2, sum);
			}
			Console.ReadLine();
		}
	}
}
