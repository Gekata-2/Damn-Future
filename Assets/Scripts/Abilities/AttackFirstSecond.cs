using CombatState;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/AttackFirstSecond", fileName = "AttackFirstSecond")]
    public class AttackFirstSecond : Ability
    {
        [SerializeField] private float damage;

        public override void Use(Formation formation)
        {
            if (formation.TryGetUnitContainer(0, out UnitContainer unitContainerFirst))
                unitContainerFirst.Unit.TakeDamage(damage);

            if (formation.TryGetUnitContainer(1, out UnitContainer unitContainerSecond))
                unitContainerSecond.Unit.TakeDamage(damage);
        }
    }
}