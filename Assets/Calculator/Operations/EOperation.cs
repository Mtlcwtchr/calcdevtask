using System;
namespace Calculator.Operations
{
	public enum EOperation
	{
		Add,
	}

	public static class EOperationUtils
	{
		public static EOperation FromChar(char op)
		{
			if (op == '+')
				return EOperation.Add;

			throw new ArgumentException();
		}
	}
}