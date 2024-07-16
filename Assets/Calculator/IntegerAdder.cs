using System.Collections.Generic;
using Calculator.Operations;
using Calculator.Operations.Factory;

namespace Calculator
{
	public class IntegerAdder : Calculator<int>
	{
		private IOperationFactory<int> _factory;

		private Stack<string> _values;
		private Stack<string> _operators;
		
		public IntegerAdder()
		{
			_factory = new IntegerOperationFactory();
			_operatorSigns = new []
			{
				'+'
			};
		}

		override protected int Evaluate(int v1, int v2, char op)
		{
			var operationType = EOperationUtils.FromChar(op);
			var operation = _factory.Create(operationType);
			return operation.Evaluate(v1, v2);
		}
		
		override protected bool FromString(string entry, out int value)
		{
			return int.TryParse(entry, out value);
		}
	}
}