using System;
using System.Collections.Generic;
using Calculator;
using Persistent;
using View.Calculator;

namespace Model.Calculator
{
	public class CalculatorWindowModel : IModel
	{
		private const string ERROR_LABEL = "ERROR";

		private const string SAVED_EXPRESSION_KEY = "EXPRESSION";

		public event Action<string> OnExpressionEvaluated;

		private CalculatorWindow _view;
		private ICalculator<int> _calculator;
		private List<string> _results;

		private IRepository _repository;
		
		public CalculatorWindowModel(CalculatorWindow view, ICalculator<int> calculator, IRepository repository)
		{
			_view = view;
			_calculator = calculator;
			_results = new List<string>();
			_repository = repository;
		}

		public void EvaluateExpression(string expression)
		{
			var res = _calculator.TryEvaluate(expression, out var result) ? result.ToString() : ERROR_LABEL;
			ProceedResult(expression, res);
		}

		public void SavePersistent()
		{
			_repository.Save(SAVED_EXPRESSION_KEY, _view.Expression);
		}

		public string LoadPersistent()
		{
			return _repository.Get(SAVED_EXPRESSION_KEY);
		}
		
		private void ProceedResult(string expression, string value)
		{
			var result = $"{expression}={value}";
			SaveResult(result);
		}

		private void SaveResult(string result)
		{
			_results.Add(result);
			OnExpressionEvaluated?.Invoke(result);
		}
	}
}