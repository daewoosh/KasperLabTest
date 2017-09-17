namespace QueueTest
{
	/// <summary>
	/// очередь, которая работает с потоками
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ITestQueue<T>
	{
		/// <summary>
		/// добавить элемент в очередь
		/// </summary>
		/// <param name="element"></param>
		void Push(T element);

		/// <summary>
		/// извлечь элемент из очереди при условии что элементы присутствуют.
		/// если же элементов нет, то очередь будет дожидаться вставки элемента чтобы его вернуть
		/// </summary>
		/// <returns></returns>
		T Pop();
	}
}
