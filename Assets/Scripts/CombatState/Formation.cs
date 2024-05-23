using System;
using System.Collections.Generic;
using System.Linq;

namespace CombatState
{
    [Serializable]
    public class Formation
    {
        public List<UnitContainer> Units { get; private set; }
        private const int MaxSize = 4;
        private Side _side;

        public Formation(List<UnitContainer> units, Side side)
        {
            Units = units;
            _side = side;

            foreach (var unitContainer in Units)
            {
                unitContainer.Side = _side;
                unitContainer.Formation = this;
                unitContainer.Unit.OnDeath += OnUnitDeath;
            }

            SortUnits();
        }

        public Formation(List<Unit> units, Side side)
        {
            Units = new List<UnitContainer>();
            _side = side;
            foreach (var unit in units) AddUnit(unit);
            SortUnits();
        }

        public void AddUnit(Unit unit, int pos)
        {
            if (IsPositionVacant(pos) && !IsFull())
            {
                Units.Add(new UnitContainer(formation: this, unit: unit, side: _side, actionsLeft: 0, position: pos,
                    isAlive: true));
                unit.OnDeath += OnUnitDeath;
            }

            SortUnits();
        }

        private void OnUnitDeath(object sender, EventArgs e)
        {
            if (sender is not Unit unit) return;
            if (!TryGetUnitContainer(unit, out UnitContainer unitContainer)) return;

            unitContainer.OnDeath();
            RemoveUnit(unit);
        }


        public void AddUnit(Unit unit)
        {
            int pos = FindFirstVacantPos();
            if (pos != -1) AddUnit(unit, pos);
        }

        public bool TryGetUnitContainer(int pos, out UnitContainer unitContainer)
        {
            foreach (var container in Units)
            {
                if (container.Position != pos) continue;

                unitContainer = container;
                return true;
            }

            unitContainer = null;
            return false;
        }


        public void AddUnit(UnitContainer unitContainer)
        {
            Units.Add(unitContainer);
            SortUnits();
        }

        public void RemoveUnit(Unit unit)
        {
            if (ContainsUnit(unit)) Units.Remove(GetUnitContainer(unit));
            SortUnits();
        }

        private bool IsPositionVacant(int pos)
        {
            bool isVacant = true;


            foreach (var unit in Units)
                if (unit.Position == pos)
                    isVacant = false;

            if (pos > 4) isVacant = false;
            return isVacant;
        }

        public UnitContainer GetUnitContainer(Unit unit)
        {
            foreach (var unitContainer in Units)
                if (unitContainer.Unit == unit)
                    return unitContainer;

            return null;
        }

        public UnitContainer GetUnitContainer(int pos)
        {
            foreach (var unitContainer in Units)
                if (unitContainer.Position == pos)
                    return unitContainer;

            return null;
        }

        public bool TryGetUnitContainer(Unit unit, out UnitContainer unitContainer)
        {
            foreach (var container in Units)
                if (container.Unit == unit)
                {
                    unitContainer = container;
                    return true;
                }

            unitContainer = null;
            return false;
        }

        private Unit GetUnitFromContainer(UnitContainer unitContainer)
        {
            foreach (var container in Units)
                if (unitContainer == container)
                    return container.Unit;

            return null;
        }

        private bool ContainsUnit(Unit unit)
        {
            bool contains = false;
            foreach (var unitContainer in Units)
                if (unitContainer.Unit == unit)
                    contains = true;

            return contains;
        }

        private void SortUnits()
        {
            Units.Sort((unit1, unit2) =>
            {
                if (unit1.Position < unit2.Position)
                    return 1;

                if (unit1.Position == unit2.Position)
                    return 0;

                return -1;
            });
        }

        private int FindFirstVacantPos()
        {
            for (int i = 0; i < MaxSize; i++)
            {
                bool isVacant = true;
                foreach (var unit in Units)
                    if (unit.Position == i)
                        isVacant = false;

                if (isVacant)
                    return i;
            }

            return -1;
        }

        public void ResetActions()
        {
            foreach (var unitContainer in Units) unitContainer.ResetActions();
        }

        public bool IsFull() => Units.Count > 4;
        public bool IsEmpty() => Units.Count == 0;

        public bool IsAllUnitsPerformedActions()
        {
            int actionsLeft = Units.Sum(unitContainer => unitContainer.ActionsLeft);
            return actionsLeft == 0;
        }
    }
}