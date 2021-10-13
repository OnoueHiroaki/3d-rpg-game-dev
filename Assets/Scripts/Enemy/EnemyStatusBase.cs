using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyStatusBase : MonoBehaviour, IEnemyStatus
{
    protected int m_maxHP;
    protected int m_currentHP;
    protected int m_currentMP;
    protected int m_attackPow;
    protected int m_magicPow;
    protected int m_defensivePower;
    protected int m_agility;
    protected int m_maxAgility;
    protected int m_exp;

    IReadOnlyReactiveProperty<int> IEnemyStatus.MaxHP { get; set; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.CurrentHP { get; set; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.MaxMP { get; set; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.CurrentMP { get; set ; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.AttackPow { get ; set ; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.MagicPow { get ; set ; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.DefensivePower { get ; set ; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.Agility { get ; set ; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.MaxAgility { get ; set ; }
    IReadOnlyReactiveProperty<int> IEnemyStatus.Exp { get ; set ; }

    public virtual void ReceiveDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
