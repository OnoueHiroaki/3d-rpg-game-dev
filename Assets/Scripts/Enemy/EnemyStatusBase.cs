using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusBase : MonoBehaviour,IEnemyStatus
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

    public virtual int MaxHP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int CurrentHP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int MaxMP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int CurrentMP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int AttackPow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int MagicPow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int DefensivePower { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int Agility { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int MaxAgility { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual int Exp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public virtual void ReceiveDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
