using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NumbersFinder
{
	public class NumbersFinder
	{

		/// <summary>
		/// метод для поиска пар чисел, которые в сумме дают заданное число. Сложность данного алгоритма O(n)
		/// </summary>
		/// <param name="numbers">коллекция чисел</param>
		/// <param name="sum">сумма</param>
		/// <returns>если в коллекции есть несколько одинаковых чисел, которые в сумме дают заданное число
		///  то программа вернет все возможные пары таких чисел</returns>
		public IEnumerable<Tuple<int, int>> FindNumbers(int[] numbers, int sum)
		{
			//результирующая коллекция
			List<Tuple<int, int>> result = new List<Tuple<int, int>>();

			Dictionary<int, int> dict = new Dictionary<int, int>();

			//заполним словарь  таким образом, что ключом будет каждое уникальное число из коллекции
			//а значением - количество вхождений каждого числа в коллекцию
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
				//ключ для поиска в словаре определяем как разность между искомой суммой и очередным числом коллекции
				int dif = sum - numbers[i];

				int count;
				//если такого ключа нет, то переходим дальше

				if (dict.TryGetValue(dif, out count))
				{
					//если текущее число это половина от искомой суммы (sum/2)
					if (dif == numbers[i])
						//то если число встречается в коллекции больше чем один раз , добавим его в результат
						if (count % 2 == 0 || count > 2)
						{
							result.Add(new Tuple<int, int>(numbers[i], dif));
							dict[dif]--;
							continue;
						}
						else continue;
					//добавим числа к результату
					result.Add(new Tuple<int, int>(numbers[i], dif));
					//извелчем из словаря значение с ключем = текущему числу, чтобы избежать повторений
					dict.Remove(numbers[i]);
				}
			}

			return result;
		}
	}
}
