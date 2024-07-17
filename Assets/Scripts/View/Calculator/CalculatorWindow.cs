using System.Collections.Generic;
using Calculator;
using Model.Calculator;
using Persistent;
using TMPro;
using UnityEngine;

namespace View.Calculator
{
	public class CalculatorWindow : MonoBehaviour
	{
		[SerializeField] private TMP_InputField inputField;
		[SerializeField] private HistoryScroll historyScroll;

		private CalculatorWindowModel _model;

		public string Expression => inputField.text;

		private void Awake()
		{
			_model = new CalculatorWindowModel(this, new IntegerAdder(), new PrefsRepository());
			_model.OnExpressionEvaluated += UpdateHistory;

			var lastHistory = new List<string>();
			_model.LoadPersistent(out var expression, lastHistory);
			for (var i = 0; i < lastHistory.Count; i++)
			{
				UpdateHistory(lastHistory[i]);
			}
			SetExpression(expression);
		}

		private void OnDestroy()
		{
			_model.OnExpressionEvaluated -= UpdateHistory;
		}

		private void OnApplicationQuit()
		{
			_model.SavePersistent();
		}

		private void UpdateHistory(string expression)
		{
			SetExpression(string.Empty);
			historyScroll.Add(expression);
		}

		public void SetExpression(string value)
		{
			inputField.text = value;
		}

		public void Evaluate()
		{
			_model.EvaluateExpression(inputField.text);
		}
	}
}