using CombatState;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/AttackThirdFourth", fileName = "AttackThirdFourth")]
    public class AttackThirdFourth : Ability
    {
        [SerializeField] private float damage;

        public override void Use(Formation formation)
        {
            if (formation.TryGetUnitContainer(2, out UnitContainer unitContainerFirst))
                unitContainerFirst.Unit.TakeDamage(damage);

            if (formation.TryGetUnitContainer(3, out UnitContainer unitContainerSecond))
                unitContainerSecond.Unit.TakeDamage(damage);
        }
    }
}