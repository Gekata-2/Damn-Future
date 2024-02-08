using CombatState;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/NormalAttack", fileName = "NormalAttack")]
    public class NormalAttack : Ability
    {
        [SerializeField] private float damage;

        public override void Use(UnitContainer target, Formation units)
        {
            Debug.Log("Normal attack");
            target.Unit.TakeDamage(damage);
        }
    }
}