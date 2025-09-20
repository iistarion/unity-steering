using TMPro;
using UnityEngine;

namespace Assets.LunarPaw.Steering.Runtime.Common
{
    public static class HelperFuncs
    {
        public static TMP_Text GetTextMeshPro(this GameObject gameObject, string name)
        {
            var children = gameObject.GetComponentsInChildren<TMP_Text>();
            foreach (var ch in children)
                if (ch.name.ToLower().Contains(name))
                    return ch;
            return null;
        }
    }
}
