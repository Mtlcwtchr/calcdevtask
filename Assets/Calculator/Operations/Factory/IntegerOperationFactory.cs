using System;
using Calculator.Operations.Integer;

namespace Calculator.Operations.Factory
{
	public class IntegerOperationFactory : IOperationFactory<int>
	{
		private IOperation<int> _addOperation;

		public IntegerOperationFactory()
		{
			_addOperation = new AddOperation();
		}
		
		public IOperation<int> Create(EOperation operation)
		{
			return operation switch
			{
				EOperation.Add => _addOperation,
				_ => throw new ArgumentException()
			};
		}
	}
}