using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MushroomEnemyStatus : MonoBehaviour, IDamagable
{
    public int m_enemyMaxHP = 30;
    public int m_enemyCurrentHP = 20;
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
        if (m_enemyCurrentHP <= 0)
        {
            SceneManager.LoadScene("ExploreScene");
        }
    }
    int IDamagable.ReceiveDamage(int attack, int defense)
    {
       return attack - defense / 2;
    }
}
