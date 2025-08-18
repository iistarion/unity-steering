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
    private BoidPropertiesHelper _boidProperties;
    private BehaviourPropertiesHelper _behaviourPropertiesHelper;

    private void Awake()
    {
        _sceneDropdown = GetComponent<TMP_Dropdown>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.name != "START_HERE")
                UnloadScene(scene.name);
        }
        _boidProperties = FindObjectsByType<BoidPropertiesHelper>(FindObjectsSortMode.None).FirstOrDefault();
        _behaviourPropertiesHelper = FindObjectsByType<BehaviourPropertiesHelper>(FindObjectsSortMode.None).FirstOrDefault();
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
        if (_boidProperties != null)
            _boidProperties.StartCoroutine("DelayApplyCurrentValues");
        if (_behaviourPropertiesHelper != null)
            _behaviourPropertiesHelper.StartCoroutine("DelayApplyCurrentValues", _currentScene);
    }

    private void UnloadScene(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
            SceneManager.UnloadSceneAsync(sceneName);
    }
}
