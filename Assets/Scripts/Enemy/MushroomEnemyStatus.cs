using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MushroomEnemyStatus : EnemyStatusBase, IDamagable, IEnemyStatus
{
    public int MaxHP { get => m_maxHP; set {  } }
    public int CurrentHP { get => m_currentHP; set { } }
    public int CurrentMP { get => m_currentMP; set { } }
    public int AttackPow { get => m_attackPow; set { } }
    public int MagicPow { get => m_magicPow; set { } }
    public int DefensivePower { get => m_defensivePower; set { } }
    public int Agility { get => m_agility; set { } }
    public int MaxAgility { get => m_maxAgility; set { } }
    public int Exp { get => m_exp; set { } }


    [SerializeField] MushroomCommandBattleAnimation m_battleAnimation;
    [SerializeField] MushroomDeath m_mushroomDeath;
    [SerializeField] IntReactiveProperty m_mushroomMaxHP = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomCurrentHP = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomCurrentMP = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomAttackPow = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomMagicPow = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomDefensivePower = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomAgility = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomMaxAgility = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomExp = new IntReactiveProperty(0);

    public MushroomCommandBattleAnimation BattleAnimation { get => m_battleAnimation; }
    public MushroomDeath MushroomDeath { get => m_mushroomDeath; }
    private void Start()
    {
        m_mushroomMaxHP.Value = MaxHP;
        m_mushroomCurrentHP.Value = CurrentHP;
        m_mushroomCurrentMP.Value = CurrentMP;
        m_mushroomAttackPow.Value = AttackPow;
        m_mushroomMagicPow.Value = MagicPow;
        m_mushroomDefensivePower.Value = DefensivePower;
        m_mushroomAgility.Value = Agility;
        m_mushroomMaxAgility.Value = MaxAgility;
        m_mushroomExp.Value = Exp;
    }
    public void ReceiveDamage(int damage)
    {
        CurrentHP -= damage;
    }
    public int AddDamage(int attack, int magicDamage, int defense)
    {
        if (0 >= attack + magicDamage - defense / 2)
        {
            return 0;
        }
        return attack + magicDamage - defense / 2;
    }
}
