using System;

namespace CombatState
{
    [Serializable]
    public class UnitContainer
    {
        [field: NonSerialized] public Formation Formation { get; set; }
        public Unit Unit { get; set; }

        public Side Side { get; set; }
        public int ActionsLeft { get; set; }
        public int Position { get; set; }
        public bool IsAlive { get; set; }

        public UnitContainer GetLeft() => Formation.GetUnitContainer(Position - 1);
        public UnitContainer GetRight() => Formation.GetUnitContainer(Position + 1);
        public void ActionPerformed() => ActionsLeft -= 1;
        public void ResetActions() => ActionsLeft = 1;
    }
}