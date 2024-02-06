using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/AttackFirstSecond", fileName = "AttackFirstSecond")]
    public class AttackFirstSecond : Ability
    {
        [SerializeField] private float damage;

        public override void Use(Unit[] allUnits)
        {
            var targets = Targeting.GetFirstTwo(allUnits);

            if (targets.FirstTarget != null) targets.FirstTarget.TakeDamage(damage);
            if (targets.SecondTarget != null) targets.SecondTarget.TakeDamage(damage);
        }
    }
}