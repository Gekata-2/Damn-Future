using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "SO/Abilities/NormalAttack",fileName = "NormalAttack")]
    public class NormalAttack:Ability
    {
        [SerializeField] private float damage;
        public override void Use(Unit target, Unit[] allUnits)
        {
            target.TakeDamage(damage);
        }
    }
}