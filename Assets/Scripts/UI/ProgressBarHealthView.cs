using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressBarHealthView : HealthView
    {
        [SerializeField] private Image healthBarImage;
        [Range(1, 15)] [SerializeField] private float colorIntensityMultiplier = 2.75f;


        private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
        private static readonly int Smoothness = Shader.PropertyToID("_Smoothness");
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        private Material _materialLowHealth;
        private Material _materialMidHealth;
        private Material _materialFullHealth;

        private readonly Color _baseColor = Color.black;

        protected override void Init()
        {
            _materialLowHealth = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            _materialMidHealth = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            _materialFullHealth = new Material(Shader.Find("Universal Render Pipeline/Lit"));

            ConfigureMaterial(_materialLowHealth, lowHealthColor);
            ConfigureMaterial(_materialMidHealth, midHealthColor);
            ConfigureMaterial(_materialFullHealth, fullHealthColor);
        }

        private void ConfigureMaterial(Material material, Color color)
        {
            material.EnableKeyword("_EMISSION");
            material.SetColor(BaseColor, _baseColor);
            material.SetColor(EmissionColor, color * colorIntensityMultiplier);
            material.SetFloat(Smoothness, 0);
            material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        }

        protected override void UpdateHealthViewValue() => healthBarImage.fillAmount = Health / MaximumHealth;
        protected override void SetLowHealthColor() => healthBarImage.material = _materialLowHealth;
        protected override void SetMidHealthColor() => healthBarImage.material = _materialMidHealth;
        protected override void SetFullHealthColor() => healthBarImage.material = _materialFullHealth;
    }
}