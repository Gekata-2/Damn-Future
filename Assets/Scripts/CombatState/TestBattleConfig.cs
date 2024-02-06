using System.Collections.Generic;
using UnityEngine;

namespace CombatState
{
    public class TestBattleConfig : MonoBehaviour
    {
        [SerializeField] private bool hasToBeUsed;
        [SerializeField] private List<Unit> leftUnits;
        [SerializeField] private List<Unit> rightUnits;
    }
}