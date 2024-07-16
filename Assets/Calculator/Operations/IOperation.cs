namespace Calculator.Operations
{
	public interface IOperation<T>
	{
		public T Evaluate(T val1, T val2);
	}
}