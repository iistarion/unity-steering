using Assets.LunarPaw.Steering.Runtime.Common;
using LunarPaw.Steering.Runtime.Agents;
using LunarPaw.Steering.Runtime.Behaviours.Steering;
using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LunarPaw.Steering.Runtime.Demo.UI
{
    public class FlockingPropertiesHelper : MonoBehaviour
    {
        public string AlignmentText = "Alignment Weight {0}%";
        public string CohesionText = "Cohesion Weight {0}%";
        public string SeparationText = "Separation Weight {0}%";
        public string AgentCountText = "Agent Count {0}";
        public string VelocityText = "Max Velocity {0}";
        public string RadiusText = "Radius {0}";

        private TMP_Text _agentCount, _alignment, _cohesion, _separation, _velocity, _radius;

        private void Start()
        {
            //ApplyCurrentValues();
            _agentCount = gameObject.GetTextMeshPro("agent count");
            _alignment = gameObject.GetTextMeshPro("alignment");
            _cohesion = gameObject.GetTextMeshPro("cohesion");
            _separation = gameObject.GetTextMeshPro("separation");
            _velocity = gameObject.GetTextMeshPro("velocity");
            _radius = gameObject.GetTextMeshPro("radius");
        }

        public void SetAgentCount(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.SetAgentCount((int)value);

            _agentCount.SetText(AgentCountText, value);

            ApplyCurrentValues();
        }

        public void SetAlignmentWeight(Single value)
        {
            var controller = FindAnyObjectByType<FlockingController>();
            controller.AlignmentWeight = value / 100f;

            _alignment.SetText(AlignmentText, value);
        }

        public void SetCohesionWeight(Single value)
        {
            var controller = FindAnyObjectByType<FlockingController>();
            controller.CohesionWeight = value / 100f;

            _cohesion.SetText(CohesionText, value);
        }

        public void SetSeparationWeight(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.SeparationWeight = value / 100f;

            _separation.SetText(SeparationText, value);
        }

        public void SetRadius(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.NeighborDistance = value;

            _radius.SetText(RadiusText, value);
        }

        public void ShowForces(bool value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.SetShowForces(value);
        }

        public void ShowRadius(bool value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.SetShowRadius(value);
        }

        public IEnumerator DelayApplyCurrentValues(string currentScene)
        {
            yield return new WaitForSeconds(0.1f);
            ApplyCurrentValues();
        }

        public void ApplyCurrentValues()
        {
            var sliders = GetComponentsInChildren<Slider>();
            foreach (var slider in sliders)
            {
                if (!slider.IsActive())
                    continue;

                if (slider.name.ToLower().Contains("alignment"))
                {
                    SetAlignmentWeight(slider.value);
                }
                else if (slider.name.ToLower().Contains("cohesion"))
                {
                    SetCohesionWeight(slider.value);
                }
                else if (slider.name.ToLower().Contains("separation"))
                {
                    SetSeparationWeight(slider.value);
                }
                else if (slider.name.ToLower().Contains("velocity"))
                {
                    SetAgentVelocity(slider.value);
                }
            }

            var toggles = GetComponentsInChildren<Toggle>();
            foreach (var toggle in toggles)
            {
                if (toggle.name.ToLower().Contains("forces"))
                    ShowForces(toggle.isOn);
                if (toggle.name.ToLower().Contains("radius"))
                    ShowRadius(toggle.isOn);
            }
        }

        public void SetAgentVelocity(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.SetAgentVelocity(value);

            _velocity.SetText(VelocityText, value);
        }
    }
}