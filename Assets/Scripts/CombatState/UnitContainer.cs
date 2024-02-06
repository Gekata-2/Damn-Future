namespace CombatState
{
    public class UnitContainer
    {
        public Formation Formation { get; set; }
        public Unit Unit { get; set; }
        
        public int CurrentActions { get; set; }
        public int Position { get; set; }
        public bool IsAlive { get; set; }
    }
}