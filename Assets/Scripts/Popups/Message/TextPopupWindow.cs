using Model.Popups;
using TMPro;
using UnityEngine;

namespace Popups.Message
{
	public class TextPopupWindow : PopupBase
	{
		[SerializeField] private TMP_Text message;
		[SerializeField] private EPopup type;

		public override EPopup Type => type;
		
		private TextPopupSettings Settings => _settings as TextPopupSettings;

		override protected void OnShow()
		{
			if (Settings == null)
				return;
			
			message.text = Settings.Message;
		}
		
		override protected void OnHide()
		{
		}
	}
}