using UnityEngine;
using UnityEngine.Rendering;

namespace LunarPaw.Steering.Runtime.Demo.Scenes
{
    [CreateAssetMenu(fileName = "ScenesDescription", menuName = "Scenes Description/Data", order = 1)]
    public class ScenesDescription : ScriptableObject
    {
        public SerializedDictionary<string, string> SceneDescriptions = new SerializedDictionary<string, string>
        {
            { "Seek", "Demonstrates how boids can seek a target." },
            { "Arrive", "Shows how boids can arrive at a target." },
            { "Flee", "Demonstrates how boids can flee from a target." },
            { "Evade", "Shows how boids can evade a target." },
            { "Pursue", "Demonstrates how boids can pursue a target." },
            { "Flocking", "Demonstrates multiple boids with a flocking behaviour." },
        };
    }
}