using System;
using CombatState;
using UnityEngine;

namespace View
{
    public class UnitSelection : MonoBehaviour
    {
        [SerializeField] private GameObject selectionIndicator;
        [SerializeField] private Material playerUnitSelected;
        [SerializeField] private Material enemyUnitSelected;
        [SerializeField] private Unit unit;

        private CombatStateHandler _combatStateHandler;

        private void Start()
        {
            GameObject combatZone = GameObject.FindGameObjectWithTag("CombatZone");

            selectionIndicator.GetComponent<Renderer>().material = unit.side switch
            {
                Side.Left => playerUnitSelected,
                Side.Right => enemyUnitSelected,
                _ => throw new ArgumentOutOfRangeException()
            };

            if (combatZone.TryGetComponent(out _combatStateHandler))
                _combatStateHandler.OnUnitSelected += OnUnitSelected;
        }

        private void Update()
        {
        }

        private void OnUnitSelected(object sender, CombatStateHandler.UnitSelectedEventArgs e)
        {
            if (e.SelectedUnit == unit) Show();
            else Hide();
        }


        private void Show() => selectionIndicator.SetActive(true);

        private void Hide() => selectionIndicator.SetActive(false);

        private void OnDestroy()
        {
            _combatStateHandler.OnUnitSelected -= OnUnitSelected;
        }
    }
}