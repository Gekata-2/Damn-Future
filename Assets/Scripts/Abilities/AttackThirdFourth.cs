using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/AttackThirdFourth", fileName = "AttackThirdFourth")]
    public class AttackThirdFourth : Ability
    {
        [SerializeField] private float damage;

        public override void Use(Unit[] allUnits)
        {
            var targets = Targeting.GetLastTwo(allUnits);

            if (targets.ThirdTarget != null) targets.ThirdTarget.TakeDamage(damage);
            if (targets.FourthTarget != null) targets.FourthTarget.TakeDamage(damage);
        }
    }
}