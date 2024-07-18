using UnityEngine;

namespace Core
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
	{
		private static T _instance;
		public static T Instance => _instance;

		protected virtual void Awake()
		{
			if (_instance != null)
			{
				Debug.LogError($"Attempt to instantiate singleton twice: {name}");
				return;
			}
			
			_instance = (T)this;
		}

		protected virtual void OnDestroy()
		{
			_instance = null;
		}
	}
}