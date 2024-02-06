using TMPro;
using UnityEngine;

namespace UI
{
    public class TextHealthView : HealthView
    {
        [SerializeField] private TextMeshProUGUI healthText;
        protected override void UpdateHealthViewValue() => healthText.text = Health.ToString();
        protected override void SetLowHealthColor() => healthText.color = lowHealthColor;
        protected override void SetMidHealthColor() => healthText.color = midHealthColor;
        protected override void SetFullHealthColor() => healthText.color = fullHealthColor;
    }
}