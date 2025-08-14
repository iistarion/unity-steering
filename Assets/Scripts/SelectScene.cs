using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    [SerializeField]
    private ScenesDescription _sceneDescriptions;
    [SerializeField]
    private TMP_Text _sceneDescription;
    private string _currentScene;
    private TMP_Dropdown _sceneDropdown;

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
        _sceneDescription.SetText(_sceneDescriptions.SceneDescriptions[_currentScene]);
    }

    private void UnloadScene(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
            SceneManager.UnloadSceneAsync(sceneName);
    }
}
