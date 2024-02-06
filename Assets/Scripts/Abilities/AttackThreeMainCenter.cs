using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/AttackThreeMainCenter", fileName = "AttackThreeMainCenter")]
    public class AttackThreeMainCenter : Ability
    {
        [SerializeField] private float damage;
        [SerializeField] private float damageLeft;
        [SerializeField] private float damageRight;

        public override void Use(Unit target, Unit[] allUnits)
        {
            var targets = Targeting.GetThreeTargetsMainCenter(target, allUnits);

            targets.MainTarget.TakeDamage(damage);

            targets.LeftTarget?.TakeDamage(damageLeft);
            targets.RightTarget?.TakeDamage(damageRight);
        }
    }
}