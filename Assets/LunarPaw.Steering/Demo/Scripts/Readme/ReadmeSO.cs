using UnityEngine;

namespace LunarPaw.Steering.Readme
{
    [CreateAssetMenu(menuName = "Readme/Data")]
    public class ReadmeSO : ScriptableObject
    {
        public string Title;
        [TextArea] public string Description;
        public Texture2D Image;
    }
}