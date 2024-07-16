namespace Calculator.Operations.Factory
{
	public interface IOperationFactory<T>
	{
		public IOperation<T> Create(EOperation operation);
	}
}