using Popups.Settings;
namespace Popups.Message
{
	public class TextPopupSettings : IPopupSettings
	{
		public string Message { get; }

		public TextPopupSettings(string message)
		{
			Message = message;
		}
	}
}