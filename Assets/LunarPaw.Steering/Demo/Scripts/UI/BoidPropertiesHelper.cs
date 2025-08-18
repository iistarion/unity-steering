using LunarPaw.Steering.Runtime.Agents;
using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LunarPaw.Steering.Runtime.Demo.UI
{
    public class BoidPropertiesHelper : MonoBehaviour
    {
        public string MaxVelocityText = "Max Velocity {0}";
        public string MaxForceText = "Max Force {0}";
        public string MassText = "Mass {0}";

        private void Awake()
        {
            ApplyCurrentValues();
        }

        public Boid[] GetAllBoids()
        {
            return FindObjectsByType<Boid>(FindObjectsSortMode.None);
        }

        private TMP_Text GetTextMeshPro(string asd)
        {
            return GetComponentsInChildren<TMP_Text>().Where(ch => ch.name.Contains(asd,
                StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }

        public void MaxVelocityValueChanged(Single value)
        {
            foreach (var boid in GetAllBoids())
                boid.MaxVelocity = value;

            var text = GetTextMeshPro("velocity");
            if (text != null)
                text.SetText(MaxVelocityText, value);
        }

        public void MaxForceValueChanged(Single value)
        {
            foreach (var boid in GetAllBoids())
                boid.MaxForce = value;

            var text = GetTextMeshPro("force");
            if (text != null)
                text.SetText(MaxForceText, value);
        }

        public void MassValueChanged(Single value)
        {
            foreach (var boid in GetAllBoids())
                boid.Mass = value;

            var text = GetTextMeshPro("mass");
            if (text != null)
                text.SetText(MassText, value);
        }

        public void ShowForces(bool value)
        {
            foreach (var boid in GetAllBoids())
                boid.ShowForces = value;
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
                if (slider.name.Contains("velocity", StringComparison.InvariantCultureIgnoreCase))
                {
                    MaxVelocityValueChanged(slider.value);
                }
                else if (slider.name.Contains("force", StringComparison.InvariantCultureIgnoreCase))
                {
                    MaxForceValueChanged(slider.value);
                }
                else if (slider.name.Contains("mass", StringComparison.InvariantCultureIgnoreCase))
                {
                    MassValueChanged(slider.value);
                }
            }

            var toggle = GetComponentsInChildren<Toggle>()
                .FirstOrDefault();

            if (toggle != null)
                ShowForces(toggle.isOn);
        }
    }
}