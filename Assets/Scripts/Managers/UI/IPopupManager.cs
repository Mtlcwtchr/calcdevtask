using Model.Popups;
using Popups;
using Popups.Settings;

namespace Managers.UI
{
	public interface IPopupManager
	{
		public void Create(EPopup type, IPopupSettings settings);
		
		public void Open(IPopup popup);

		public void Close(EPopup type);
	}
}