using PlayerInput;
using UnityEngine;

namespace CombatState
{
    public class EnemyTurn : ICombatState
    {
        public void EnterState(CombatStateHandler combatStateHandler)
        {
            throw new System.NotImplementedException();
        }

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