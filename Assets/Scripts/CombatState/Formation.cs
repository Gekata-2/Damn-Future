using System.Collections.Generic;

namespace CombatState
{
    public class Formation
    {
        private List<UnitContainer> Units { get; set; }

        public Formation(List<UnitContainer> units)
        {
            Units = units;
        }

        public void AddUnit(Unit unit, int pos)
        {
            if (IsPositionVacant(pos) && !IsFull())
            {
                Units.Add(new UnitContainer
                    { Formation = this, CurrentActions = 0, IsAlive = true, Position = pos, Unit = unit });
            }
        }

        public void AddUnit(UnitContainer unitContainer)
        {
            Units.Add(unitContainer);
        }

        public void RemoveUnit(Unit unit)
        {
            if (ContainsUnit(unit)) Units.Remove(GetUnitContainer(unit));
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

        private UnitContainer GetUnitContainer(Unit unit)
        {
            foreach (var unitContainer in Units)
                if (unitContainer.Unit == unit)
                    return unitContainer;

            return null;
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

        public bool IsFull() => Units.Count > 4;
        public bool IsEmpty() => Units.Count == 0;
    }
}