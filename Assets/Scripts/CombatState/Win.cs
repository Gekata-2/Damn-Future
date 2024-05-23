using PlayerInput;
using UnityEngine;

namespace CombatState
{
    public class Win : ICombatState
    {
        public void EnterState(CombatStateHandler combatStateHandler)
        {
            if (combatStateHandler.LeftUnits.IsEmpty())
                Debug.Log("Right units win");
            else if (combatStateHandler.RightUnits.IsEmpty())
                Debug.Log("Left units win");
        }

        public void HandleAbilityUse(CombatStateHandler combatStateHandler,
            KeyboardInput.AbilityUsedEventArgs abilityUsedArgs)
        {
    
        }

        public void HandleLeftMouseButtonClick(CombatStateHandler combatStateHandler,
            MouseCombatClicksHandler.LeftMouseClickedEventArgs inputEventArgs)
        {
          
        }

        public string GetName() => "Win state";
    }
}