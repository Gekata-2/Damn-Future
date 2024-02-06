using System;
using Abilities;
using PlayerInput;
using TMPro;
using UnityEngine;

namespace CombatState
{
    [Serializable]
    public class CombatStateHandler : MonoBehaviour
    {
        [SerializeField] public Unit[] leftUnits = new Unit[4];
        [SerializeField] public Unit[] rightUnits = new Unit[4];

        [Header("   Debug   ")] [SerializeField]
        private TextMeshProUGUI stateText;

        [SerializeField] private TextMeshProUGUI lastSelectedUnitText;
        [SerializeField] private TextMeshProUGUI selectedAbilityText;


        public Idle Idle = new();
        public UnitSelected UnitSelected = new();
        public AbilityConfirm AbilityConfirm = new();
        public EnemyTurn EnemyTurn = new();

        private GameObject Player { set; get; }
        private KeyboardInput _keyboardInput;
        private MouseCombatClicksHandler _mouseInput;

        private Unit _selectedUnit;
        private Ability _selectedAbility;
        private ICombatState _currentState;

        public event EventHandler<UnitSelectedEventArgs> OnUnitSelected;

        public class UnitSelectedEventArgs : EventArgs
        {
            public Unit SelectedUnit;
        }


        private void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            if (Player.TryGetComponent(out _mouseInput))
                _mouseInput.OnLeftMouseButtonClicked += OnLeftMouseButtonClicked;

            if (Player.TryGetComponent(out _keyboardInput))
                _keyboardInput.OnPlayerAbilityUsed += OnPlayerAbilityUsed;

            SwitchState(Idle);
        }

        public void SwitchState(ICombatState state)
        {
            _currentState = state;
            state.EnterState(this);
            UpdateDebugInfo();
        }

        private void OnPlayerAbilityUsed(object sender, KeyboardInput.AbilityUsedEventArgs e)
        {
            _currentState.HandleAbilityUse(this, e);
        }

        private void OnLeftMouseButtonClicked(object sender, MouseCombatClicksHandler.LeftMouseClickedEventArgs e)
        {
            _currentState.HandleLeftMouseButtonClick(this, e);
        }

        public void ResetSelection()
        {
            CancelSelectedUnit();
            ClearSelectedAbility();
        }


        public Unit GetSelectedUnit() => _selectedUnit;

        public void SelectUnit(Unit unit)
        {
            _selectedUnit = unit;
            OnUnitSelected?.Invoke(this, new UnitSelectedEventArgs { SelectedUnit = unit });
            UpdateDebugInfo();
        }

        public void CancelSelectedUnit()
        {
            _selectedUnit = null;
            OnUnitSelected?.Invoke(this, new UnitSelectedEventArgs { SelectedUnit = null });
            UpdateDebugInfo();
        }


        public Ability GetSelectedAbility() => _selectedAbility;

        public void SelectAbility(Ability ability)
        {
            _selectedAbility = ability;
            UpdateDebugInfo();
        }

        public void ClearSelectedAbility()
        {
            _selectedAbility = null;
            UpdateDebugInfo();
        }

        public Unit[] GetUnitAllies(Unit unit)
        {
            return unit.side switch
            {
                Side.Left => leftUnits,
                Side.Right => rightUnits,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public Unit[] GetUnitEnemies(Unit unit)
        {
            return unit.side switch
            {
                Side.Left => rightUnits,
                Side.Right => leftUnits,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void UpdateDebugInfo()
        {
            stateText.text = _currentState.GetName();
            lastSelectedUnitText.text = _selectedUnit == null ? "None" : _selectedUnit.name;
            selectedAbilityText.text = _selectedAbility == null ? "None" : _selectedAbility.Name;
        }
    }
}