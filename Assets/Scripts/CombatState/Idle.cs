using System;
using PlayerInput;
using UnityEngine;

namespace CombatState
{
    public class Idle : ICombatState
    {
        public void EnterState(CombatStateHandler combatStateHandler)
        {
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

            switch (unit.side) // Unit clicked
            {
                case Side.Left: // Player unit
                    combatStateHandler.SelectUnit(unit);
                    combatStateHandler.SwitchState(combatStateHandler.UnitSelected);
                    break;
                case Side.Right: // Enemy unit
                    combatStateHandler.SelectUnit(unit);
                    combatStateHandler.SwitchState(combatStateHandler.UnitSelected);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetName() => "Idle";
    }
}