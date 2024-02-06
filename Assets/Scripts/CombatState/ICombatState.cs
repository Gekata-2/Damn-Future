using PlayerInput;

namespace CombatState
{
    public interface ICombatState
    {
        public void EnterState(CombatStateHandler combatStateHandler);

        public void HandleAbilityUse(CombatStateHandler combatStateHandler,
            KeyboardInput.AbilityUsedEventArgs abilityUsedArgs);

        public void HandleLeftMouseButtonClick(CombatStateHandler combatStateHandler,
            MouseCombatClicksHandler.LeftMouseClickedEventArgs inputEventArgs);

        public string GetName();
    }
}