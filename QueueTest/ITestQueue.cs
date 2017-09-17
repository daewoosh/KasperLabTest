namespace QueueTest
{
	public interface ITestQueue<T>
	{
		void Push(T element);

		T Pop();
	}
}
