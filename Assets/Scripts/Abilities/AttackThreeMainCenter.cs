using CombatState;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/AttackThreeMainCenter", fileName = "AttackThreeMainCenter")]
    public class AttackThreeMainCenter : Ability
    {
        [SerializeField] private float damage;
        [SerializeField] private float damageLeft;
        [SerializeField] private float damageRight;

        public override void Use(UnitContainer target, Formation units)
        {
            target.Unit.TakeDamage(damage);
            target.GetLeft()?.Unit.TakeDamage(damageLeft);
            target.GetRight()?.Unit.TakeDamage(damageRight);
        }
    }
}