namespace Abilities
{
    public static class Targeting
    {
        public struct SingleTarget
        {
            public Unit MainTarget;
        }

        public struct ThreeTargetsMainCenter
        {
            public Unit MainTarget;
            public Unit LeftTarget;
            public Unit RightTarget;
        }

        public struct AllTargets
        {
            public Unit FirstTarget;
            public Unit SecondTarget;
            public Unit ThirdTarget;
            public Unit FourthTarget;
        }


        public struct FirstTwoTargets
        {
            public Unit FirstTarget;
            public Unit SecondTarget;
        }

        public struct LastTwoTargets
        {
            public Unit ThirdTarget;
            public Unit FourthTarget;
        }

        public static SingleTarget GetSingleTarget(Unit target) => new SingleTarget() { MainTarget = target };

        public static FirstTwoTargets GetFirstTwo(Unit[] targets) => new FirstTwoTargets()
            { FirstTarget = targets[0], SecondTarget = targets[1] };

        public static LastTwoTargets GetLastTwo(Unit[] targets) => new LastTwoTargets()
            { ThirdTarget = targets[2], FourthTarget = targets[3] };

        public static ThreeTargetsMainCenter GetThreeTargetsMainCenter(Unit target, Unit[] targets)
        {
            ThreeTargetsMainCenter threeTargets = new()
            {
                LeftTarget = null,
                MainTarget = target,
                RightTarget = null
            };

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] == target)
                {
                    int prevIdx = i - 1, nextIdx = i + 1;

                    if (prevIdx >= 0 && targets[prevIdx] != null)
                        threeTargets.LeftTarget = targets[prevIdx];

                    if (nextIdx < targets.Length && targets[nextIdx] != null)
                        threeTargets.RightTarget = targets[nextIdx];
                }
            }

            return threeTargets;
        }

        public static AllTargets GetAllTargets(Unit[] targets) => new AllTargets()
        {
            FirstTarget = targets[0],
            SecondTarget = targets[1],
            ThirdTarget = targets[2],
            FourthTarget = targets[3]
        };
    }
}