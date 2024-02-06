using System;
using UnityEngine;

namespace Abilities
{
    public class Ability : ScriptableObject
    {
        public enum Type
        {
            Target,
            NonTarget
        }

        public enum TargetedSide
        {
            Allies,
            Enemies
        }

        [SerializeField] public Type type;
        [SerializeField] public TargetedSide targetedSide;
        [SerializeField] public string Name;

        public virtual void Use(Unit target, Unit[] allUnits)
        {
            Debug.LogError("Default ability should not be used");
        }

        public virtual void Use(Unit[] units)
        {
            Debug.LogError("Default ability should not be used");
        }


        public bool CanBeUsed(Unit invoker, Unit target)
        {
            bool canBeUsed;

            Side invokerSide = invoker.side;
            Side targetSide = target.side;

            switch (targetedSide)
            {
                case TargetedSide.Allies:
                    canBeUsed = IsOnTheSameSide(invokerSide, targetSide);
                    break;
                case TargetedSide.Enemies:
                    canBeUsed = IsOnTheOppositeSides(invokerSide, targetSide);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return canBeUsed;
        }

        private bool IsOnTheSameSide(Side invokerSide, Side targetSide) => invokerSide == targetSide;
        private bool IsOnTheOppositeSides(Side invokerSide, Side targetSide) => invokerSide != targetSide;
    }
}