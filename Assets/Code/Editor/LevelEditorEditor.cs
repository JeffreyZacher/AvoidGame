using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(LevelEditor))]
public class LevelEditorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		LevelEditor levelEditor = (LevelEditor)target;

		if (GUILayout.Button("Generate level"))
		{
			levelEditor.CreatePlatform(levelEditor.PlatfromCenterTile);
		}

		if (GUILayout.Button("Delete Levels"))
		{
			int j = levelEditor.levelParent.transform.childCount;
			for (int i = 1; i < j; i++)
			{
				DestroyImmediate(levelEditor.levelParent.transform.GetChild(1).gameObject);
			}
		}
	}
}
