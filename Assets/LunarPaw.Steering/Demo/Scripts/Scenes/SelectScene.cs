using LunarPaw.Steering.Runtime.Demo.UI;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarPaw.Steering.Runtime.Demo.Scenes
{
    public class SelectScene : MonoBehaviour
    {
        [SerializeField]
        private ScenesDescription _sceneDescriptions;
        [SerializeField]
        private TMP_Text _sceneDescription;

        private FlockingPropertiesHelper _flockingProperties;
        private BoidPropertiesHelper _boidProperties;
        private SteeringPropertiesHelper _steeringPropertiesHelper;

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
            _boidProperties = FindObjectsByType<BoidPropertiesHelper>(FindObjectsSortMode.None).FirstOrDefault();
            _steeringPropertiesHelper = FindObjectsByType<SteeringPropertiesHelper>(FindObjectsSortMode.None).FirstOrDefault();
            _flockingProperties = FindObjectsByType<FlockingPropertiesHelper>(FindObjectsSortMode.None).FirstOrDefault();
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

            if (_currentScene.ToLower().Contains("flock"))
            {
                _flockingProperties.gameObject.SetActive(true);
                _steeringPropertiesHelper.gameObject.SetActive(false);
                _boidProperties.gameObject.SetActive(false);

                _flockingProperties.StartCoroutine("DelayApplyCurrentValues", _currentScene);
            }
            else
            {
                _flockingProperties.gameObject.SetActive(false);
                _steeringPropertiesHelper.gameObject.SetActive(true);
                _boidProperties.gameObject.SetActive(true);

                _steeringPropertiesHelper.StartCoroutine("DelayApplyCurrentValues", _currentScene);
                _boidProperties.StartCoroutine("DelayApplyCurrentValues", _currentScene);
            }
        }

        private void UnloadScene(string sceneName)
        {
            if (!string.IsNullOrWhiteSpace(sceneName))
                SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}