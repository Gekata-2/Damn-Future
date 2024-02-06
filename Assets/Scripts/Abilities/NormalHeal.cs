using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/NormalHeal", fileName = "NormalHeal")]
    public class NormalHeal : Ability
    {
        [SerializeField] private float heal;

        public override void Use(Unit target, Unit[] allUnits)
        {
            target.TakeHeal(heal);
        }
    }
}