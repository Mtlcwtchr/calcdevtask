using Model.Popups;
using Popups.Settings;

namespace Popups
{
	public interface IPopup
	{
		public EPopup Type { get; }

		public void Open(IPopupSettings settings);
		public void Close();
		
		public void Show();
		public void Hide();
	}
}