// using System;
// using Abilities;
// using PlayerInput;
// using UnityEngine;
//
// public class CombatZone : MonoBehaviour
// {
//     [SerializeField] public Unit[] playerUnits = new Unit[4];
//     [SerializeField] public Unit[] enemyUnits = new Unit[4];
//
//
//     enum Turn
//     {
//         Player,
//         Enemy
//     }
//
//     private MouseCombatClicksHandler _playerMouseInput;
//     private KeyboardInput _keyboardInput;
//     private Unit _currentActor;
//     private Turn _turn;
//
//     private void Start()
//     {
//         GameObject player = GameObject.FindGameObjectWithTag("Player");
//         
//         if (player.TryGetComponent(out _keyboardInput))
//         {
//             _keyboardInput.OnPlayerAbilityUsed += OnPlayerAbilityUsed;
//         }
//     }
//
//     private void OnPlayerAbilityUsed(object sender, KeyboardInput.AbilityUsedEventArgs e)
//     {
//         if (_currentActor.TryGetAbility(e.AbilityIdx, out Ability ability))
//         {
//             switch (ability.type)
//             {
//                 case Ability.Type.Target:
//                     break;
//                 case Ability.Type.NonTarget:
//                     OnNonTargetAbilityUsed(_currentActor, ability);
//                     break;
//                 default:
//                     throw new ArgumentOutOfRangeException();
//             }
//         }
//     }
//
//   
//
//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space)) //NormalAttack
//         {
//             OnTargetAbilityUsed(playerUnits[0], playerUnits[0].abilities[0], enemyUnits[0]);
//         }
//
//         if (Input.GetKeyDown(KeyCode.T)) //AttackAll
//         {
//             OnNonTargetAbilityUsed(enemyUnits[0], enemyUnits[0].abilities[0]);
//         }
//
//         if (Input.GetKeyDown(KeyCode.R)) //AttackFirstSecond
//         {
//             OnNonTargetAbilityUsed(enemyUnits[0], enemyUnits[0].abilities[1]);
//         }
//
//         if (Input.GetKeyDown(KeyCode.S)) //AttackThirdFourth
//         {
//             OnNonTargetAbilityUsed(enemyUnits[0], enemyUnits[0].abilities[2]);
//         }
//
//         if (Input.GetKeyDown(KeyCode.N)) //AttackThreeMainCenter
//         {
//             OnTargetAbilityUsed(enemyUnits[0], enemyUnits[0].abilities[3], playerUnits[0]);
//         }
//     }
//
//     private void OnTargetAbilityUsed(Unit invoker, Ability ability, Unit target)
//     {
//         if (invoker == null || target == null)
//             return;
//
//         switch (invoker.side)
//         {
//             case Side.Player:
//                 invoker.UseTargetAbility(ability, target, enemyUnits);
//                 break;
//             case Side.Enemy:
//                 invoker.UseTargetAbility(ability, target, playerUnits);
//                 break;
//             default:
//                 throw new ArgumentOutOfRangeException();
//         }
//     }
//
//     private void OnNonTargetAbilityUsed(Unit invoker, Ability ability)
//     {
//         if (invoker == null) return;
//
//         switch (invoker.side)
//         {
//             case Unit.Side.Player:
//                 invoker.UseNonTargetAbility(ability, enemyUnits);
//                 break;
//             case Unit.Side.Enemy:
//                 invoker.UseNonTargetAbility(ability, playerUnits);
//                 break;
//             default:
//                 throw new ArgumentOutOfRangeException();
//         }
//     }
// }