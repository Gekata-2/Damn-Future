using System.Collections.Generic;
using UnityEngine;

namespace CombatState
{
    public class TestBattleConfig : MonoBehaviour
    {
        [SerializeField] public List<Unit> leftUnits;
        [SerializeField] public List<Unit> rightUnits;
    }
}