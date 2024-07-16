using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
	public abstract class Calculator<T> : ICalculator<T>
	{
		protected char[] _operatorSigns;

		protected abstract T Evaluate(T v1, T v2, char op);

		protected abstract bool FromString(string entry, out T value);

		public bool TryEvaluate(string expression, out T result)
		{
			result = default(T);
			
			var operators = new Stack<char>();
			var values = new Stack<T>();
			
			for (var i = 0; i < expression.Length; i++)
			{
				var entry = expression[i];

				if (char.IsWhiteSpace(entry))
					return false;

				if (char.IsDigit(entry))
				{
					var number = string.Empty;
					while (i < expression.Length && char.IsDigit(expression[i]))
					{
						number += expression[i++];
					}
					
					if (!FromString(number, out var value))
						return false;

					values.Push(value);
					--i;
					continue;
				}

				if (IsOperator(entry))
				{
					operators.Push(entry);
					continue;
				}

				return false;
			}

			while (values.Count > 1)
			{
				var val1 = values.Pop();
				var val2 = values.Pop();

				if (operators.Count <= 0)
					return false;
				
				var op = operators.Pop();
				var newVal= Evaluate(val1, val2, op);
				values.Push(newVal);
			}

			result = values.Pop();
			return true;
		}
		
		private bool IsOperator(char с) => _operatorSigns.Contains(с);
		
	}
}