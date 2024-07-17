using UnityEditor;
using UnityEngine;
namespace Editor
{
	public static class EditorUtil
	{
		[MenuItem("Utils/ClearPlayerPrefs")]
		public static void ClearPlayerPrefs()
		{
			PlayerPrefs.DeleteAll();
		}
	}
}