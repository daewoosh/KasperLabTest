using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NumbersFinder
{
	public class NumbersFinder
	{
		public IEnumerable<Tuple<int, int>> FindNumbers(int[] numbers, int sum)
		{
			List<Tuple<int, int>> result = new List<Tuple<int, int>>();

			Dictionary<int, int> dict = new Dictionary<int, int>();

			for (int i = 0; i < numbers.Length; i++)
			{
				int index = numbers[i];
				if (dict.ContainsKey(index))
					dict[index]++;
				else
					dict[index] = 1;
			}

			for (int i = 0; i < numbers.Length; i++)
			{
				int dif = sum - numbers[i];

				int count;
				if (dict.TryGetValue(dif, out count))
				{
					if (dif == numbers[i])
						if (count % 2 == 0 || count > 2)
						{
							result.Add(new Tuple<int, int>(numbers[i], dif));
							dict[dif]--;
							continue;
						}
						else continue;
					result.Add(new Tuple<int, int>(numbers[i], dif));
					dict.Remove(numbers[i]);
				}
			}

			return result;
		}
	}
}
