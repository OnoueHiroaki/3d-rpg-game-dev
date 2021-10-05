using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyStatus : MonoBehaviour, IDamagable
{
    public int MaxHP { get; set; } = 10;
    public int CurrentHP { get; set; } = 10;
    //敵のMP
    public int CurrentMP { get; set; } = 3;
    //敵の攻撃力
    public int AttackPow { get; set; } = 3;
    //敵の魔法攻撃力
    public int MagicPow { get; set; } = 3;
    //敵の守備力
    public int DefensivePower { get; set; } = 3;
    //敵の素早さ(素早さのvalue)
    public int Agility { get; set; } = 20;
    //敵の最大素早さ(素早さのMaxValue)
    public int MaxAgility { get; set; } = 100;
    //敵が持っている経験値
    public int Exp { get; set; } = 30;
    public event Action OnEnemyHPChange;
    [SerializeField] MushroomCommandBattleAnimation m_battleAnimation;
    [SerializeField] MushroomDeath m_mushroomDeath;
    public MushroomCommandBattleAnimation BattleAnimation { get => m_battleAnimation; }
    public MushroomDeath MushroomDeath { get => m_mushroomDeath; }
    public void EnemyDamage(int damage)
    {
        CurrentHP -= damage;
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
