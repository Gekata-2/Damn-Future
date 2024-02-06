using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/HealAll", fileName = "HealAll")]
    public class HealAll : Ability
    {
        [SerializeField] private float heal;

        public override void Use(Unit[] allUnits)
        {
            var targets = Targeting.GetAllTargets(allUnits);

            if (targets.FirstTarget != null) targets.FirstTarget.TakeHeal(heal);

            if (targets.SecondTarget != null) targets.SecondTarget.TakeHeal(heal);

            if (targets.ThirdTarget != null) targets.ThirdTarget.TakeHeal(heal);

            if (targets.FourthTarget != null) targets.FourthTarget.TakeHeal(heal);
        }
    }
}