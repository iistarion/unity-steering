using Assets.LunarPaw.Steering.Runtime.Common;
using LunarPaw.Steering.Runtime.Behaviours.Steering;
using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LunarPaw.Steering.Runtime.Demo.UI
{
    public class SteeringPropertiesHelper : MonoBehaviour
    {
        public string SimulateTimeText = "Simulate {0} seconds";
        public string ArrivalRadiusText = "Arrival radius {0}";
        public string StopRadiusText = "Stop radius {0}";

        public GameObject SimulateTime;
        public GameObject ArrivalRadius;
        public GameObject StopRadius;
        public GameObject TogglePrediction;
        public GameObject NoPropertiesDescription;

        private void Awake()
        {
            ApplyCurrentValues();
        }

        public SteeringBehaviour[] GetAllBehaviours()
        {
            return FindObjectsByType<SteeringBehaviour>(FindObjectsSortMode.None);
        }

        public void SimulateTimeChanged(Single value)
        {
            foreach (var steeringBehaviour in GetAllBehaviours())
            {
                switch (steeringBehaviour)
                {
                    case PursueBehaviour pursueBehaviour:
                        pursueBehaviour.TimeInAdvance = value;
                        break;
                    case ArriveBehaviour arriveBehaviour:
                        break;
                    case SeekBehaviour seekBehaviour:
                        break;
                    case FleeBehaviour fleeBehaviour:
                        break;
                    case EvadeBehaviour evadeBehaviour:
                        evadeBehaviour.TimeInAdvance = value;
                        break;
                    default:
                        Debug.LogWarning($"Unsupported steering behaviour type: {steeringBehaviour.GetType()}");
                        break;
                }
            }

            var text = gameObject.GetTextMeshPro("simulate");
            if (text != null)
                text.SetText(SimulateTimeText, value);
        }

        public void ArrivalRadiusChanged(Single value)
        {
            foreach (var steeringBehaviour in GetAllBehaviours())
            {
                switch (steeringBehaviour)
                {
                    case PursueBehaviour pursueBehaviour:
                        break;
                    case ArriveBehaviour arriveBehaviour:
                        arriveBehaviour.ArrivalRadius = value;
                        break;
                    case SeekBehaviour seekBehaviour:
                        break;
                    case FleeBehaviour fleeBehaviour:
                        break;
                    case EvadeBehaviour evadeBehaviour:
                        break;
                    default:
                        Debug.LogWarning($"Unsupported steering behaviour type: {steeringBehaviour.GetType()}");
                        break;
                }
            }

            var text = gameObject.GetTextMeshPro("arrival");
            if (text != null)
                text.SetText(ArrivalRadiusText, value);
        }

        public void StopRadiusChanged(Single value)
        {
            foreach (var steeringBehaviour in GetAllBehaviours())
            {
                switch (steeringBehaviour)
                {
                    case PursueBehaviour pursueBehaviour:
                        break;
                    case ArriveBehaviour arriveBehaviour:
                        arriveBehaviour.StopRadius = value;
                        break;
                    case SeekBehaviour seekBehaviour:
                        break;
                    case FleeBehaviour fleeBehaviour:
                        break;
                    case EvadeBehaviour evadeBehaviour:
                        break;
                    default:
                        Debug.LogWarning($"Unsupported steering behaviour type: {steeringBehaviour.GetType()}");
                        break;
                }
            }

            var text = gameObject.GetTextMeshPro("stop");
            if (text != null)
                text.SetText(StopRadiusText, value);
        }

        public void ShowPrediction(bool value)
        {
            foreach (var steeringBehaviour in GetAllBehaviours())
            {
                switch (steeringBehaviour)
                {
                    case PursueBehaviour pursueBehaviour:
                        pursueBehaviour.ShowDebugInterception = value;
                        break;
                    case ArriveBehaviour arriveBehaviour:
                        break;
                    case SeekBehaviour seekBehaviour:
                        break;
                    case FleeBehaviour fleeBehaviour:
                        break;
                    case EvadeBehaviour evadeBehaviour:
                        evadeBehaviour.ShowDebugInterception = value;
                        break;
                    default:
                        Debug.LogWarning($"Unsupported steering behaviour type: {steeringBehaviour.GetType()}");
                        break;
                }
            }
        }

        public IEnumerator DelayApplyCurrentValues(string currentScene)
        {
            yield return new WaitForSeconds(0.1f);
            switch (currentScene)
            {
                case "Pursue":
                    SimulateTime.SetActive(true);
                    ArrivalRadius.SetActive(false);
                    StopRadius.SetActive(false);
                    TogglePrediction.SetActive(true);
                    NoPropertiesDescription.SetActive(false);
                    break;
                case "Arrive":
                    SimulateTime.SetActive(false);
                    ArrivalRadius.SetActive(true);
                    StopRadius.SetActive(true);
                    TogglePrediction.SetActive(false);
                    NoPropertiesDescription.SetActive(false);
                    break;
                case "Seek":
                    SimulateTime.SetActive(false);
                    ArrivalRadius.SetActive(false);
                    StopRadius.SetActive(false);
                    TogglePrediction.SetActive(false);
                    NoPropertiesDescription.SetActive(true);
                    break;
                case "Flee":
                    SimulateTime.SetActive(false);
                    ArrivalRadius.SetActive(false);
                    StopRadius.SetActive(false);
                    TogglePrediction.SetActive(false);
                    NoPropertiesDescription.SetActive(true);
                    break;
                case "Evade":
                    SimulateTime.SetActive(true);
                    ArrivalRadius.SetActive(false);
                    StopRadius.SetActive(false);
                    TogglePrediction.SetActive(true);
                    NoPropertiesDescription.SetActive(false);
                    break;
                case "Flocking":
                    break;
                default:
                    Debug.LogWarning($"Unsupported scene: {currentScene}");
                    break;
            }
            ApplyCurrentValues();
        }

        public void ApplyCurrentValues()
        {
            var sliders = GetComponentsInChildren<Slider>();

            foreach (var slider in sliders)
            {
                if (!slider.IsActive())
                    continue;

                if (slider.name.ToLower().Contains("simulate"))
                {
                    SimulateTimeChanged(slider.value);
                }
                else if (slider.name.ToLower().Contains("arrival"))
                {
                    ArrivalRadiusChanged(slider.value);
                }
                else if (slider.name.ToLower().Contains("stop"))
                {
                    StopRadiusChanged(slider.value);
                }
            }

            var toggle = GetComponentsInChildren<Toggle>()
                .FirstOrDefault();

            if (toggle != null)
                ShowPrediction(toggle.isOn);
        }
    }
}