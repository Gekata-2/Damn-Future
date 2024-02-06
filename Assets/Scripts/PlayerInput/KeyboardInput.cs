using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerInput
{
    public class KeyboardInput : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;
        public event EventHandler<AbilityUsedEventArgs> OnPlayerAbilityUsed;

        public class AbilityUsedEventArgs
        {
            public int AbilityIdx;
        }

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Combat.Enable();
            _playerInputActions.Combat.Ability0.performed += OnAbility0Performed;
            _playerInputActions.Combat.Ability1.performed += OnAbility1Performed;
            _playerInputActions.Combat.Ability2.performed += OnAbility2Performed;
            _playerInputActions.Combat.Ability3.performed += OnAbility3Performed;
            _playerInputActions.Combat.Ability4.performed += OnAbility4Performed;
            _playerInputActions.Combat.Ability5.performed += OnAbility5Performed;
            _playerInputActions.Combat.Ability6.performed += OnAbility6Performed;
        }

        private void OnAbility0Performed(InputAction.CallbackContext obj)
        {
            OnPlayerAbilityUsed?.Invoke(this, new AbilityUsedEventArgs { AbilityIdx = 0 });
        }

        private void OnAbility1Performed(InputAction.CallbackContext obj)
        {
            OnPlayerAbilityUsed?.Invoke(this, new AbilityUsedEventArgs { AbilityIdx = 1 });
        }

        private void OnAbility2Performed(InputAction.CallbackContext obj)
        {
            OnPlayerAbilityUsed?.Invoke(this, new AbilityUsedEventArgs { AbilityIdx = 2 });
        }

        private void OnAbility3Performed(InputAction.CallbackContext obj)
        {
            OnPlayerAbilityUsed?.Invoke(this, new AbilityUsedEventArgs { AbilityIdx = 3 });
        }

        private void OnAbility4Performed(InputAction.CallbackContext obj)
        {
            OnPlayerAbilityUsed?.Invoke(this, new AbilityUsedEventArgs { AbilityIdx = 4 });
        }

        private void OnAbility5Performed(InputAction.CallbackContext obj)
        {
            OnPlayerAbilityUsed?.Invoke(this, new AbilityUsedEventArgs { AbilityIdx = 5 });
        }

        private void OnAbility6Performed(InputAction.CallbackContext obj)
        {
            OnPlayerAbilityUsed?.Invoke(this, new AbilityUsedEventArgs { AbilityIdx = 6 });
        }
    }
}