using System;
using System.Collections.Generic;
using System.Text;
using Calculator;
using Persistent;
using View.Calculator;

namespace Model.Calculator
{
	public class CalculatorWindowModel : IModel
	{
		private const string ERROR_LABEL = "ERROR";

		private const string SAVED_EXPRESSION_KEY = "EXPRESSION";
		private const string SAVED_HISTORY_KEY = "HISTORY";

		private const string DELIMETER = "&";

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

			var sb = new StringBuilder();
			for (var i = 0; i < _results.Count; i++)
			{
				sb.Append($"{_results[i]}{DELIMETER}");
			}
			_repository.Save(SAVED_HISTORY_KEY, sb.ToString());
		}

		public void LoadPersistent(out string expression, List<string> history)
		{
			expression = _repository.Get(SAVED_EXPRESSION_KEY);
			var savedHistory = _repository.Get(SAVED_HISTORY_KEY);
			var results = savedHistory.Split(DELIMETER);
			for (var i = 0; i < results.Length; i++)
			{
				if(String.IsNullOrEmpty(results[i]) || string.IsNullOrWhiteSpace(results[i]))
					continue;
				
				_results.Add(results[i]);
				history.Add(results[i]);
			}
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