using System.Collections.Generic;
using Core;
using Model.Popups;
using Popups;
using Popups.Settings;
using UnityEngine;

namespace Managers.UI
{
	public class PopupManager : SingletonMonoBehaviour<PopupManager>, IPopupManager
	{
		[SerializeField] private List<PopupBase> popups;
		[SerializeField] private Transform root;

		private Dictionary<EPopup, IPopup> _opened;

		private Dictionary<EPopup, IPopup> _instances;

		override protected void Awake()
		{
			base.Awake();

			_opened = new Dictionary<EPopup, IPopup>();
			_instances = new Dictionary<EPopup, IPopup>();
		}

		override protected void OnDestroy()
		{
			foreach (var (type, _) in _opened)
			{
				Close(type);
			}

			base.OnDestroy();
		}

		public void Create(EPopup type, IPopupSettings settings)
		{
			var popup = Get(type);
			if (popup == null)
				return;

			if (!_instances.TryGetValue(type, out var popupWindow))
			{
				popupWindow = Instantiate(popup, root);
				_instances.Add(type, popupWindow);
			}
			
			popupWindow.Open(settings);
		}

		private PopupBase Get(EPopup type)
		{
			for (var i = 0; i < popups.Count; i++)
			{
				if (popups[i].Type == type)
				{
					return popups[i];
				}
			}

			return null;
		}

		public void Open(IPopup popup)
		{
			if (_opened.ContainsKey(popup.Type))
				return;

			_opened.Add(popup.Type, popup);
			popup.Show();
		}

		public void Close(EPopup type)
		{
			if (_opened.TryGetValue(type, out var popup))
			{
				popup.Hide();
				_opened.Remove(type);
			}
		}
	}
}