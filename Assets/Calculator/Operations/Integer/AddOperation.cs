namespace Calculator.Operations.Integer
{
	public class AddOperation : IOperation<int>
	{
		public int Evaluate(int val1, int val2)
		{
			return val1 + val2;
		}
	}
}