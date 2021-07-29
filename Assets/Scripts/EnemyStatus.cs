using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamage
{
    public int m_enemyMaxHP = 30;
    public int m_enemyCurrentHP = 20;
    //敵のHP
    public int m_enemyHP = 30;
    //敵のMP
    public int EnemyMP = 3;
    //敵の攻撃力
    public int m_enemyAttackPow = 3;
    //敵の魔法攻撃力
    public int m_enemyMagicPow = 3;
    //敵の守備力
    public int m_enemyDefensivePower = 3;
    //敵の素早さ(素早さのvalue)
    public int m_enemyAgility = 3;
    //敵の最大素早さ(素早さのMaxValue)
    public int m_enemyMaxAgility = 100;

    public event Action OnEnemyHPChange;

    public void EnemyDamage(int damage)
    {
        m_enemyCurrentHP -= damage;
        OnEnemyHPChange?.Invoke();
    }
    int IDamage.ReceiveDamage(int attack, int defense)
    {
       return m_enemyCurrentHP -= attack - defense / 2;
    }
}
