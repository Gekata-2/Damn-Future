using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/AttackAll", fileName = "AttackAll")]
    public class AttackAll : Ability
    {
        [SerializeField] private float damage;

        public override void Use(Unit[] units)
        {
            var targets = Targeting.GetAllTargets(units);

            if (targets.FirstTarget != null) targets.FirstTarget.TakeDamage(damage);

            if (targets.SecondTarget != null) targets.SecondTarget.TakeDamage(damage);

            if (targets.ThirdTarget != null) targets.ThirdTarget.TakeDamage(damage);

            if (targets.FourthTarget != null) targets.FourthTarget.TakeDamage(damage);
        }
    }
}