using System;
using Abilities;
using PlayerInput;

namespace CombatState
{
    public class AbilityConfirm : ICombatState
    {
        public void EnterState(CombatStateHandler combatStateHandler)
        {
        }

        public void HandleAbilityUse(CombatStateHandler combatStateHandler,
            KeyboardInput.AbilityUsedEventArgs abilityUsedArgs)
        {
            Unit selectedUnit = combatStateHandler.GetSelectedUnitContainer().Unit;

            if (selectedUnit.TryGetAbility(abilityUsedArgs.AbilityIdx, out Ability ability))
                combatStateHandler.SelectAbility(ability);
        }

        public void HandleLeftMouseButtonClick(CombatStateHandler combatStateHandler,
            MouseCombatClicksHandler.LeftMouseClickedEventArgs inputEventArgs)
        {
            UnitContainer selectedUnitContainer = combatStateHandler.GetSelectedUnitContainer();
            Ability ability = combatStateHandler.GetSelectedAbility();

            if (inputEventArgs.RaycastHitUnit == null) // Clicked in empty space
            {
                switch (ability.type)
                {
                    case Ability.Type.Target: // Cancel ability use
                        combatStateHandler.SwitchState(combatStateHandler.UnitSelected);
                        combatStateHandler.ClearSelectedAbility();
                        break;
                    case Ability.Type.NonTarget: // Use ability
                        UseNonTargetAbility(combatStateHandler);
                        combatStateHandler.ResetSelection();
                        combatStateHandler.SwitchState(combatStateHandler.Idle);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else // Clicked on Unit
            {
                UnitContainer secondSelectedUnitContainer =
                    combatStateHandler.FindUnitContainer(inputEventArgs.RaycastHitUnit);


                switch (ability.type)
                {
                    case Ability.Type.Target:
                        if (ability.CanBeUsed(selectedUnitContainer, //Need to check, if second clicked unit,
                                secondSelectedUnitContainer)) //  is on the side, that ability must be used
                        {
                            UseTargetAbility(combatStateHandler, secondSelectedUnitContainer);
                            combatStateHandler.ResetSelection();
                            combatStateHandler.SwitchState(combatStateHandler.Idle);
                        }

                        break;
                    case Ability.Type.NonTarget
                        : // Use ability. Second clicked unit doesn't matter in non target ability
                        UseNonTargetAbility(combatStateHandler);
                        combatStateHandler.ResetSelection();
                        combatStateHandler.SwitchState(combatStateHandler.Idle);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        public string GetName() => "AbilityConfirm";


        private void UseTargetAbility(CombatStateHandler combatStateHandler, UnitContainer target)
        {
            UnitContainer invokerContainer = combatStateHandler.GetSelectedUnitContainer();

            Ability ability = combatStateHandler.GetSelectedAbility();

            switch (ability.targetedSide)
            {
                case Ability.TargetedSide.Allies:
                    invokerContainer.Unit.UseTargetAbility(ability, target,
                        combatStateHandler.GetUnitAllies(invokerContainer));
                    break;
                case Ability.TargetedSide.Enemies:
                    invokerContainer.Unit.UseTargetAbility(ability, target,
                        combatStateHandler.GetUnitEnemies(invokerContainer));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UseNonTargetAbility(CombatStateHandler combatStateHandler)
        {
            UnitContainer invoker = combatStateHandler.GetSelectedUnitContainer();
            Ability ability = combatStateHandler.GetSelectedAbility();

            if (invoker.Unit == null) return;

            switch (ability.targetedSide)
            {
                case Ability.TargetedSide.Allies:
                    invoker.Unit.UseNonTargetAbility(ability, combatStateHandler.GetUnitAllies(invoker));
                    break;
                case Ability.TargetedSide.Enemies:
                    invoker.Unit.UseNonTargetAbility(ability, combatStateHandler.GetUnitEnemies(invoker));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}