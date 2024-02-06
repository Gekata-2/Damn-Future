namespace CombatState
{
    public class UnitContainer
    {
        private Formation Formation { get; set; }
        private Unit Unit { get; set; }
        private int CurrentActions { get; set; }
        private int Position { get; set; }
        private bool IsAlive { get; set; }
    }
}