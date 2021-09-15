using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MushroomEnemyStatus : MonoBehaviour, IDamagable
{
    public int m_maxHP = 30;
    public int m_currentHP = 20;
    //敵のMP
    public int m_mP = 3;
    //敵の攻撃力
    public int m_attackPow = 3;
    //敵の魔法攻撃力
    public int m_magicPow = 3;
    //敵の守備力
    public int m_defensivePower = 3;
    //敵の素早さ(素早さのvalue)
    public int m_agility = 3;
    //敵の最大素早さ(素早さのMaxValue)
    public int m_maxAgility = 100;
    //敵が持っている経験値
    public int m_exp = 30;
    public event Action OnEnemyHPChange;

    public void EnemyDamage(int damage)
    {
        m_currentHP -= damage;
        OnEnemyHPChange?.Invoke();
    }
    int IDamagable.ReceiveDamage(int attack, int defense)
    {
       return attack - defense / 2;
    }
}
