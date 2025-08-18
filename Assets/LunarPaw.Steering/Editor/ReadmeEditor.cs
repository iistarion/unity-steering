using UnityEngine;
using UnityEditor;
using LunarPaw.Steering.Readme;

namespace LunarPaw.Steering.EditorScripts
{
    [CustomEditor(typeof(ReadmeContainer))]
    public class ReadmeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var readme = (ReadmeContainer)target;

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

}
