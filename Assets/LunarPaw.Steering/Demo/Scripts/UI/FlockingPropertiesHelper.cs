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

        private void Start()
        {
            //ApplyCurrentValues();
        }

        private TMP_Text GetTextMeshPro(string name)
        {
            return GetComponentsInChildren<TMP_Text>().Where(ch => ch.name.Contains(name,
                StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }

        public void SetAgentCount(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.SetAgentCount((int)value);

            var text = GetTextMeshPro("agent count");
            if (text != null)
                text.SetText(AgentCountText, value);

            ApplyCurrentValues();
        }

        public void SetAlignmentWeight(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.AlignmentWeight = value / 100f;

            var text = GetTextMeshPro("alignment");
            if (text != null)
                text.SetText(AlignmentText, value);
        }

        public void SetCohesionWeight(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.CohesionWeight = value / 100f;

            var text = GetTextMeshPro("cohesion");
            if (text != null)
                text.SetText(CohesionText, value);
        }

        public void SetSeparationWeight(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.SeparationWeight = value / 100f;

            var text = GetTextMeshPro("separation");
            if (text != null)
                text.SetText(SeparationText, value);
        }

        public void SetRadius(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.NeighborDistance = value;

            var text = GetTextMeshPro("radius");
            if (text != null)
                text.SetText(RadiusText, value);
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

        public IEnumerator DelayApplyCurrentValues()
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

                if (slider.name.Contains("alignment", StringComparison.InvariantCultureIgnoreCase))
                {
                    SetAlignmentWeight(slider.value);
                }
                else if (slider.name.Contains("cohesion", StringComparison.InvariantCultureIgnoreCase))
                {
                    SetCohesionWeight(slider.value);
                }
                else if (slider.name.Contains("separation", StringComparison.InvariantCultureIgnoreCase))
                {
                    SetSeparationWeight(slider.value);
                }
                else if (slider.name.Contains("velocity", StringComparison.InvariantCultureIgnoreCase))
                {
                    SetAgentVelocity(slider.value);
                }
            }

            var toggles = GetComponentsInChildren<Toggle>();
            foreach (var toggle in toggles)
            {
                if (toggle.name.Contains("forces", StringComparison.InvariantCultureIgnoreCase))
                    ShowForces(toggle.isOn);
                if (toggle.name.Contains("radius", StringComparison.InvariantCultureIgnoreCase))
                    ShowRadius(toggle.isOn);
            }
        }

        public void SetAgentVelocity(Single value)
        {
            var controller = FindObjectsByType<FlockingController>(FindObjectsSortMode.None).FirstOrDefault();
            controller.SetAgentVelocity(value);

            var text = GetTextMeshPro("velocity");
            if (text != null)
                text.SetText(VelocityText, value);
        }
    }
}