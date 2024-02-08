﻿using System.Collections.Generic;
using System.IO;

namespace CombatState
{
    public class Formation
    {
        public List<UnitContainer> Units { get; private set; }
        private const int MaxSize = 4;
        private Side _side;

        public Formation(List<UnitContainer> units, Side side)
        {
            Units = units;
            _side = side;

            foreach (var unitContainer in Units) unitContainer.Side = _side;

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
                Units.Add(new UnitContainer
                {
                    Formation = this, CurrentActions = 0, IsAlive = true, Position = pos, Unit = unit, Side = _side
                });

            SortUnits();
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

        public bool IsFull() => Units.Count > 4;
        public bool IsEmpty() => Units.Count == 0;
    }
}