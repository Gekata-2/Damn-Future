using System.Collections.Generic;
using UnityEngine;

namespace CombatState
{
    public class TestBattleConfig : MonoBehaviour
    {
        [SerializeField] private List<GameObject> leftUnits;
        [SerializeField] private List<GameObject> rightUnits;

        public List<UnitContainer> leftUnitContainers;
        public List<UnitContainer> rightUnitContainers;


        private void Awake()
        {
            for (int i = 0; i < leftUnits.Count; i++)
            {
                if (leftUnits[i].TryGetComponent(out Unit unit))
                {
                    UnitContainer unitContainer = new UnitContainer(formation: null, unit, side: Side.Left,
                        actionsLeft: 0, position: i, isAlive: true)
                    {
                        UnitGameObject = leftUnits[i]
                    };
                    leftUnitContainers.Add(unitContainer);
                }
            }

            for (int i = 0; i < rightUnits.Count; i++)
            {
                if (rightUnits[i].TryGetComponent(out Unit unit))
                {
                    UnitContainer unitContainer = new UnitContainer(formation: null, unit, side: Side.Left,
                        actionsLeft: 0, position: i, isAlive: true)
                    {
                        UnitGameObject = rightUnits[i]
                    };
                    rightUnitContainers.Add(unitContainer);
                }
            }
        }
    }
}