namespace Persistent
{
	public interface IRepository
	{
		public string Get(string key);
		public void Save(string key, string value);
	}
}