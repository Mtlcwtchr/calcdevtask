using TMPro;
using UnityEngine;

namespace View.Calculator
{
	public class HistoryScroll : MonoBehaviour
	{
		[SerializeField] private GameObject resultElement;
		[SerializeField] private Transform historyRoot;

		public void Add(string expression)
		{
			var go = Instantiate(resultElement, historyRoot);
			go.SetActive(true);
			if (go.TryGetComponent<TMP_Text>(out var textField))
			{
				textField.SetText(expression);
			}
		}
	}
}