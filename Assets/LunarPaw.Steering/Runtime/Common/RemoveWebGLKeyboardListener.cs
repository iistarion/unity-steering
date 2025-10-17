using UnityEngine;

public class RemoveWebGLKeyboardListener : MonoBehaviour
{
    private void Awake()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = false;
        #endif
    }
}
