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
    }
}