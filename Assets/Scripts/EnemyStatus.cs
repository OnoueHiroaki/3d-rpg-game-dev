using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    //敵のHP
    public int EnemyHP { get ; set; } = 30;
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
        EnemyHP -= damage;
        OnEnemyHPChange?.Invoke();
    }
}
