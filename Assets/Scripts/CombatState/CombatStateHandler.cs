using System;
using Abilities;
using PlayerInput;
using TMPro;
using UnityEngine;

namespace CombatState
{
    public class CombatStateHandler : MonoBehaviour
    {
        [field: SerializeField] public Formation LeftUnits { get; private set; }
        [field: SerializeField] public Formation RightUnits { get; private set; }

        [Header("   Debug   ")] [SerializeField]
        private TextMeshProUGUI stateText;

        [SerializeField] private TextMeshProUGUI lastSelectedUnitText;
        [SerializeField] private TextMeshProUGUI selectedAbilityText;
        [SerializeField] private bool loadFromConfig;

        public Idle Idle = new();
        public UnitSelected UnitSelected = new();
        public AbilityConfirm AbilityConfirm = new();
        public EnemyTurn EnemyTurn = new();
        public Win Win = new();

        private GameObject Player { set; get; }
        private KeyboardInput _keyboardInput;
        private MouseCombatClicksHandler _mouseInput;

        private UnitContainer _selectedUnitContainer;
        private Ability _selectedAbility;
        private ICombatState _currentState;

        public event EventHandler<UnitSelectedEventArgs> OnUnitSelected;
        public event Action OnLoadedFromConfig;

        public class UnitSelectedEventArgs : EventArgs
        {
            public UnitContainer SelectedUnitContainer;
        }


        private void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            if (Player.TryGetComponent(out _mouseInput))
                _mouseInput.OnLeftMouseButtonClicked += OnLeftMouseButtonClicked;

            if (Player.TryGetComponent(out _keyboardInput))
                _keyboardInput.OnPlayerAbilityUsed += OnPlayerAbilityUsed;

            if (loadFromConfig) LoadFromConfig();

            SwitchState(Idle);
        }


        private void LoadFromConfig()
        {
            if (TryGetComponent(out TestBattleConfig testBattleConfig))
            {
                LeftUnits = new Formation(testBattleConfig.leftUnitContainers, Side.Left);
                RightUnits = new Formation(testBattleConfig.rightUnitContainers, Side.Right);
                LeftUnits.ResetActions();
                OnLoadedFromConfig?.Invoke();
            }
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


        public UnitContainer GetSelectedUnitContainer() => _selectedUnitContainer;

        public void SelectUnit(Unit unit)
        {
            _selectedUnitContainer = FindUnitContainer(unit);
            OnUnitSelected?.Invoke(this, new UnitSelectedEventArgs { SelectedUnitContainer = _selectedUnitContainer });
            UpdateDebugInfo();
        }

        public void CancelSelectedUnit()
        {
            _selectedUnitContainer = null;
            OnUnitSelected?.Invoke(this, new UnitSelectedEventArgs { SelectedUnitContainer = null });
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

        public Formation GetUnitAllies(UnitContainer unitContainer)
        {
            return unitContainer.Side switch
            {
                Side.Left => LeftUnits,
                Side.Right => RightUnits,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public Formation GetUnitEnemies(UnitContainer unitContainer)
        {
            return unitContainer.Side switch
            {
                Side.Left => RightUnits,
                Side.Right => LeftUnits,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public UnitContainer FindUnitContainer(Unit unit)
        {
            if (LeftUnits.TryGetUnitContainer(unit, out var unitContainer))
                return unitContainer;

            if (RightUnits.TryGetUnitContainer(unit, out unitContainer))
                return unitContainer;

            return null;
        }

        public Formation GetUnitAllies(Unit unit)
        {
            return FindUnitContainer(unit).Side switch
            {
                Side.Left => LeftUnits,
                Side.Right => RightUnits,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public Formation GetUnitEnemies(Unit unit)
        {
            return FindUnitContainer(unit).Side switch
            {
                Side.Left => RightUnits,
                Side.Right => LeftUnits,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void ResetLeftUnitsActions() => LeftUnits.ResetActions();
        public void ResetRightUnitsActions() => RightUnits.ResetActions();

        public bool IsAllLeftUnitsPerformedActions() => LeftUnits.IsAllUnitsPerformedActions();
        public bool IsAllRightUnitsPerformedActions() => RightUnits.IsAllUnitsPerformedActions();
        
        private void UpdateDebugInfo()
        {
            stateText.text = _currentState.GetName();
            lastSelectedUnitText.text =
                _selectedUnitContainer?.Unit == null ? "None" : _selectedUnitContainer.Unit.name;
            selectedAbilityText.text = _selectedAbility == null ? "None" : _selectedAbility.Name;
        }
    }
}