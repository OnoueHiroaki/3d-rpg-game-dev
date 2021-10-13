using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IEnemyStatus
{
    IReadOnlyReactiveProperty<int> MaxHP { get; set; }
    IReadOnlyReactiveProperty<int> CurrentHP { get; set; }
    IReadOnlyReactiveProperty<int> MaxMP { get; set; }
    IReadOnlyReactiveProperty<int> CurrentMP { get; set; }
    IReadOnlyReactiveProperty<int> AttackPow { get; set; }
    IReadOnlyReactiveProperty<int> MagicPow { get; set; }
    IReadOnlyReactiveProperty<int> DefensivePower { get; set; }
    IReadOnlyReactiveProperty<int> Agility { get; set; }
    IReadOnlyReactiveProperty<int> MaxAgility { get; set; }
    IReadOnlyReactiveProperty<int> Exp { get; set; }
    void ReceiveDamage(int damage);
}
