using UnityEngine;

namespace UI
{
    public abstract class HealthView : MonoBehaviour
    {
        [SerializeField] protected Unit unit;

        [SerializeField] protected Color lowHealthColor = Color.red;
        [SerializeField] protected Color midHealthColor = Color.yellow;
        [SerializeField] protected Color fullHealthColor = Color.green;


        [Range(0, 1)] [SerializeField] private float lowHealthThreshold = 0.25f;

        [Range(0, 1)] [SerializeField] private float midHealthThreshold = 0.75f;


        protected float Health;
        protected float MaximumHealth;

        private void Start()
        {
            unit.OnHealthChanged += OnHealthChanged;
            unit.OnMaximumHealthChanged += UnitOnMaximumHealthChanged;
            Init();
        }

        private void UnitOnMaximumHealthChanged(object sender, Unit.HealthChangedEventArgs e)
        {
            MaximumHealth = e.Health;
            UpdateHealthView();
        }

        private void OnHealthChanged(object sender, Unit.HealthChangedEventArgs e)
        {
            Health = e.Health;
            UpdateHealthView();
        }

        private void UpdateHealthView()
        {
            SetHealthColor();
            UpdateHealthViewValue();
        }


        private void SetHealthColor()
        {
            float healthPercentage = Health / MaximumHealth;

            if (healthPercentage <= lowHealthThreshold)
                SetLowHealthColor();
            else if (lowHealthThreshold < healthPercentage && healthPercentage <= midHealthThreshold)
                SetMidHealthColor();
            else if (midHealthThreshold < healthPercentage)
                SetFullHealthColor();
        }

        protected abstract void UpdateHealthViewValue();
        protected abstract void SetLowHealthColor();
        protected abstract void SetMidHealthColor();
        protected abstract void SetFullHealthColor();
        
        protected virtual void Init(){}
    }
}