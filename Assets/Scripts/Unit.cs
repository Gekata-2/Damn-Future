using System;
using System.Collections.Generic;
using Abilities;
using CombatState;
using UnityEngine;

public enum Side
{
    Left,
    Right
}

public class Unit : MonoBehaviour, IDamageble
{
    [SerializeField] public List<Ability> abilities;
    [SerializeField] private new string name;

    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public event EventHandler<HealthChangedEventArgs> OnHealthChanged;
    public event EventHandler<HealthChangedEventArgs> OnMaximumHealthChanged;
    public event EventHandler OnDeath;

    public class HealthChangedEventArgs : EventArgs
    {
        public float Health;
    }


    private bool _isFirstUpdate = true;

    private void FixedUpdate()
    {
        if (_isFirstUpdate)
        {
            _isFirstUpdate = false;
            FireHealthChanged();
            FireMaxHealthChanged();
        }
    }

    public void UseTargetAbility(Ability ability, UnitContainer target, Formation formation)
    {
        ability.Use(target, formation);
    }

    public void UseNonTargetAbility(Ability ability, Formation formation)
    {
        ability.Use(formation);
    }

    public bool TryGetAbility(int idx, out Ability ability)
    {
        Debug.Log(idx);
        if (abilities.Count > idx)
        {
            ability = abilities[idx];
            return true;
        }

        ability = null;
        return false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        FireHealthChanged();

        if (health <= 0)
        {
            OnDeath?.Invoke(this, null);
        }
    }

    public void FireEvents()
    {
        FireHealthChanged();
        FireMaxHealthChanged();
    }

    private void FireHealthChanged() =>
        OnHealthChanged?.Invoke(this, new HealthChangedEventArgs { Health = health });

    private void FireMaxHealthChanged() =>
        OnMaximumHealthChanged?.Invoke(this, new HealthChangedEventArgs { Health = maxHealth });


    public void TakeHeal(float heal)
    {
        health += heal;
        //if (health > maxHealth) health = maxHealth;
        FireHealthChanged();
    }
}