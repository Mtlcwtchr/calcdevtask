using UnityEngine;
namespace Persistent
{
	public class PrefsRepository : IRepository
	{
		public string Get(string key)
		{
			return PlayerPrefs.GetString(key);
		}
		
		public void Save(string key, string value)
		{
			PlayerPrefs.SetString(key, value);
			PlayerPrefs.Save();
		}
	}
}