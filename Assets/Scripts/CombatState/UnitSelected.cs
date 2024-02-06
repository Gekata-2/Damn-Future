using Abilities;
using PlayerInput;
using UnityEngine;

namespace CombatState
{
    public class UnitSelected : ICombatState
    {
        public void EnterState(CombatStateHandler combatStateHandler)
        {
        }

        public void HandleAbilityUse(CombatStateHandler combatStateHandler,
            KeyboardInput.AbilityUsedEventArgs abilityUsedArgs)
        {
           
            
            Unit selectedUnit = combatStateHandler.GetSelectedUnit();
            
            // if (selectedUnit.side == Side.Enemy)
            //     return;

            if (selectedUnit.TryGetAbility(abilityUsedArgs.AbilityIdx, out Ability ability))
            {
                combatStateHandler.SelectAbility(ability);
                combatStateHandler.SwitchState(combatStateHandler.AbilityConfirm);
            }
        }

        public void HandleLeftMouseButtonClick(CombatStateHandler combatStateHandler,
            MouseCombatClicksHandler.LeftMouseClickedEventArgs inputEventArgs)
        {
        
            if (inputEventArgs.RaycastHitUnit == null) // No unit clicked
            {
                combatStateHandler.CancelSelectedUnit();
                combatStateHandler.SwitchState(combatStateHandler.Idle);
            }
            else
            {
                combatStateHandler.SelectUnit(inputEventArgs.RaycastHitUnit);
            }
        }

        public string GetName() => "UnitSelected";
    }
}