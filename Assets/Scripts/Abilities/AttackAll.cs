using CombatState;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/AttackAll", fileName = "AttackAll")]
    public class AttackAll : Ability
    {
        [SerializeField] private float damage;

        public override void Use(Formation formation)
        {
            foreach (UnitContainer unitContainer in formation.Units)
            {
                unitContainer.Unit.TakeDamage(damage);
            }
        }
    }
}