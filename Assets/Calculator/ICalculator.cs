namespace Calculator
{
	public interface ICalculator<T>
	{
		bool TryEvaluate(string expression, out T result);
	}
}