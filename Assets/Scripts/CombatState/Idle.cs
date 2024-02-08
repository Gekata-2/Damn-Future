using System;
using PlayerInput;
using UnityEngine;

namespace CombatState
{
    public class Idle : ICombatState
    {
        public void EnterState(CombatStateHandler combatStateHandler)
        {
            if (combatStateHandler.IsAllLeftUnitsPerformedActions())
            {
                combatStateHandler.SwitchState(combatStateHandler.EnemyTurn);
            }
        }

        public void HandleAbilityUse(CombatStateHandler combatStateHandler,
            KeyboardInput.AbilityUsedEventArgs abilityUsedArgs)
        {
        }

        public void HandleLeftMouseButtonClick(CombatStateHandler combatStateHandler,
            MouseCombatClicksHandler.LeftMouseClickedEventArgs inputEventArgs)

        {
            if (inputEventArgs.RaycastHitUnit == null) // No unit clicked
                return;

            Unit unit = inputEventArgs.RaycastHitUnit;

            combatStateHandler.SelectUnit(unit);
            combatStateHandler.SwitchState(combatStateHandler.UnitSelected);
        }

        public string GetName() => "Idle";
    }
}