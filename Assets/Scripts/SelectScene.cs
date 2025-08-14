using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _sceneDescription;
    private string _currentScene;
    private TMP_Dropdown _sceneDropdown;

    private Dictionary<string, string> _sceneDescriptions = new Dictionary<string, string>
    {
        { "Seek", "Demonstrates how boids can seek a target." },
        { "Arrive", "Shows how boids can arrive at a target." },
        { "Flee", "Demonstrates how boids can flee from a target." },
        { "Evade", "Shows how boids can evade a target." },
        { "Pursue", "Demonstrates how boids can pursue a target." },
    };

    private void Awake()
    {
        _sceneDropdown = GetComponent<TMP_Dropdown>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.name != "START_HERE")
                UnloadScene(scene.name);
        }
    }

    private void Start()
    {
        _currentScene = _sceneDropdown.options.FirstOrDefault().text;
        OpenScene();
    }

    public void ChangeScene()
    {
        UnloadScene(_currentScene);
        OpenScene();
    }

    public void OpenScene()
    {
        var dropdownScene = _sceneDropdown.options[_sceneDropdown.value].text;
        SceneManager.LoadScene(dropdownScene, LoadSceneMode.Additive);
        _currentScene = dropdownScene;
        _sceneDescription.SetText(_sceneDescriptions[_currentScene]);
    }

    private void UnloadScene(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
            SceneManager.UnloadSceneAsync(sceneName);
    }
}
