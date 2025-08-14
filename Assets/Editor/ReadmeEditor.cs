// ReadmeSimpleEditor.cs
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Readme))]
public class ReadmeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var readme = (Readme)target;

        if (!string.IsNullOrEmpty(readme.Data.Title))
        {
            GUILayout.Label(readme.Data.Title, EditorStyles.boldLabel);
        }

        if (!string.IsNullOrEmpty(readme.Data.Description))
        {
            EditorGUILayout.HelpBox(readme.Data.Description, MessageType.Info);
        }

        if (readme.Data.Image != null)
        {
            GUILayout.Label(readme.Data.Image, GUILayout.Height(100));
        }
    }
}
