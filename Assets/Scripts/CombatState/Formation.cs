using System.Collections.Generic;
using System.IO;

namespace CombatState
{
    public class Formation
    {
        private List<UnitContainer> Units { get; set; }
        private const int MaxSize = 4;

        public Formation(List<UnitContainer> units)
        {
            Units = units;
            SortUnits();
        }

        public Formation(List<Unit> units)
        {
            Units = new List<UnitContainer>();
            foreach (var unit in units) AddUnit(unit);
            SortUnits();
        }

        public void AddUnit(Unit unit, int pos)
        {
            if (IsPositionVacant(pos) && !IsFull())
            {
                Units.Add(new UnitContainer
                    { Formation = this, CurrentActions = 0, IsAlive = true, Position = pos, Unit = unit });
            }

            SortUnits();
        }

        public void AddUnit(Unit unit)
        {
            int pos = FindFirstVacantPos();
            if (pos != -1) AddUnit(unit, pos);
        }


        public void AddUnit(UnitContainer unitContainer)
        {
            Units.Add(unitContainer);
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