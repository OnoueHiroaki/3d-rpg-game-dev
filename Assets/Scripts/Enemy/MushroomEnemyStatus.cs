using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyStatus : MonoBehaviour, IDamagable
{
    public int m_maxHP = 10;
    public int m_currentHP = 10;
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
    public int MaxAgility { get; set; } = 100;
    //敵が持っている経験値
    public int m_exp = 30;
    public event Action OnEnemyHPChange;
    Animation m_anim;
    void Start()
    {
        m_anim = gameObject.GetComponent<Animation>();
    }

    public void AttackAnim()
    {
        m_anim.Play("Attack");
    }
    public void DamageAnim()
    {
        m_anim.Play("Damage");
    }
    public void DeathAnim()
    {
        m_anim.Play("Death");
    }
    public void EnemyDamage(int damage)
    {
        m_currentHP -= damage;
        OnEnemyHPChange?.Invoke();
    }
    int IDamagable.ReceiveDamage(int attack, int magicDamage, int defense)
    {
        if (0 >= attack + magicDamage - defense / 2)
        {
            return 0;
        }
        return attack + magicDamage - defense / 2;
    }
}
