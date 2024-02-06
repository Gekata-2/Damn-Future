using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace PlayerInput
{
    [RequireComponent(typeof(MouseRaycast3D))]
    public class MouseCombatClicksHandler : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;
        private MouseRaycast3D _mouseRaycast;

        //public event EventHandler<UnitClickedEventArgs> OnUnitClicked;
        public event EventHandler<LeftMouseClickedEventArgs> OnLeftMouseButtonClicked;

        public class LeftMouseClickedEventArgs : EventArgs
        {
            public Unit RaycastHitUnit;
        }


        private void Awake()
        {
            _mouseRaycast = GetComponent<MouseRaycast3D>();
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Combat.Enable();
            _playerInputActions.Combat.LeftMouseClick.performed += OnLeftMouseClickPerformed;
        }

        private void OnLeftMouseClickPerformed(InputAction.CallbackContext obj)
        {
            if (_mouseRaycast.CurrentTransform == null)
                OnLeftMouseButtonClicked?.Invoke(this,
                    new LeftMouseClickedEventArgs { RaycastHitUnit = null });
            else if (_mouseRaycast.CurrentTransform.TryGetComponent(out Unit clickedUnit))
                OnLeftMouseButtonClicked?.Invoke(this,
                    new LeftMouseClickedEventArgs { RaycastHitUnit = clickedUnit });
        }
    }
}