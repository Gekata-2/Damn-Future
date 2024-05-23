using System;
using Abilities;
using PlayerInput;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CombatState
{
    public class EnemyTurn : ICombatState
    {
        public void EnterState(CombatStateHandler combatStateHandler)
        {
            Debug.Log("Enemy Turn!");
            foreach (var unit in combatStateHandler.RightUnits.Units)
            {
                Ability ability = GetRandomAbility(unit.Unit);
                if (ability == null) continue;

                UnitContainer randomUnitContainer = GetRandomUnit(combatStateHandler.LeftUnits);
                if (randomUnitContainer != null)
                {
                    switch (ability.type)
                    {
                        case Ability.Type.Target:
                            if (ability.CanBeUsed(unit, randomUnitContainer))
                            {
                                unit.Unit.UseTargetAbility(ability, randomUnitContainer, combatStateHandler.LeftUnits);
                                Debug.Log($"Enemy used ability{ability.Name} on unit {randomUnitContainer.Unit.name}");
                            }

                            break;
                        case Ability.Type.NonTarget:
                            switch (ability.targetedSide)
                            {
                                case Ability.TargetedSide.Allies:
                                    unit.Unit.UseNonTargetAbility(ability, combatStateHandler.GetUnitAllies(unit));
                                    break;
                                case Ability.TargetedSide.Enemies:
                                    unit.Unit.UseNonTargetAbility(ability, combatStateHandler.GetUnitEnemies(unit));
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            Debug.Log($"Enemy used ability{ability.Name}");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }


            combatStateHandler.ResetLeftUnitsActions();
            combatStateHandler.SwitchState(combatStateHandler.Idle);
        }

        private UnitContainer GetRandomUnit(Formation formation) =>
            !formation.IsEmpty() ? formation.Units[Random.Range(0, formation.Units.Count)] : null;

        private Ability GetRandomAbility(Unit unit) =>
            unit.abilities.Count > 0 ? unit.abilities[Random.Range(0, unit.abilities.Count)] : null;

        public void HandleAbilityUse(CombatStateHandler combatStateHandler,
            KeyboardInput.AbilityUsedEventArgs abilityUsedArgs)
        {
            Debug.Log("EnemyTurn HandleAbilityUse");
        }

        public void HandleLeftMouseButtonClick(CombatStateHandler combatStateHandler,
            MouseCombatClicksHandler.LeftMouseClickedEventArgs inputEventArgs)
        {
            Debug.Log("EnemyTurn HandleLeftMouseButtonClick");
        }

        public string GetName() => "EnemyTurn";
    }
}