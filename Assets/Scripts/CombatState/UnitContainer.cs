using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CombatState
{
    [Serializable]
    public class UnitContainer
    {
        [field: NonSerialized] public Formation Formation { get; set; }
        public Unit Unit { get; set; }
        public GameObject UnitGameObject { get; set; }
        public Side Side { get; set; }
        public int ActionsLeft { get; set; }
        public int Position { get; set; }
        public bool IsAlive { get; set; }

        public UnitContainer GetLeft() => Formation.GetUnitContainer(Position - 1);
        public UnitContainer GetRight() => Formation.GetUnitContainer(Position + 1);
        public void ActionPerformed() => ActionsLeft -= 1;
        public void ResetActions() => ActionsLeft = 1;

        public UnitContainer(Formation formation, Unit unit, Side side, int actionsLeft, int position, bool isAlive)
        {
            Formation = formation;
            Unit = unit;
            Side = side;
            ActionsLeft = actionsLeft;
            Position = position;
            IsAlive = isAlive;
        }

       
        public void OnDeath()
        {
            Object.Destroy(UnitGameObject);
        }
    }
}