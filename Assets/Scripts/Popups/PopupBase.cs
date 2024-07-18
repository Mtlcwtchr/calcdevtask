using System.Collections;
using Managers.UI;
using Model.Popups;
using Popups.Settings;
using UnityEngine;

namespace Popups
{
	public abstract class PopupBase : MonoBehaviour, IPopup
	{
		public abstract EPopup Type { get; }

		protected IPopupSettings _settings;

		private GameObject _go;
		private bool _goActive;

		private void Awake()
		{
			_go = gameObject;
			_goActive = _go.activeSelf;
		}

		public void Open(IPopupSettings settings)
		{
			_settings = settings;
			PopupManager.Instance.Open(this);
		}

		public void Close()
		{
			PopupManager.Instance.Close(Type);
		}

		public void Show()
		{
			SetActive(true);
			
			OnShow();
		}
		
		public void Hide()
		{
			SetActive(false);
			
			OnHide();
		}

		private void SetActive(bool isActive)
		{
			if (_goActive == isActive)
				return;
			
			_goActive = isActive;
			_go.SetActive(isActive);
		}

		protected abstract void OnShow();
		protected abstract void OnHide();
	}
}