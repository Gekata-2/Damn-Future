using CombatState;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/HealAll", fileName = "HealAll")]
    public class HealAll : Ability
    {
        [SerializeField] private float heal;

        public override void Use(Formation formation)
        {
            foreach (UnitContainer unitContainer in formation.Units)
            {
                unitContainer.Unit.TakeHeal(heal);
            }
        }
    }
}