using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MushroomEnemyStatus : EnemyStatusBase, IDamagable, IEnemyStatus
{
    public IReadOnlyReactiveProperty<int> MaxHP { get => m_mushroomMaxHP; set { } }
    public IReadOnlyReactiveProperty<int> CurrentHP { get => m_mushroomCurrentHP; set { } }
    public IReadOnlyReactiveProperty<int> MaxMP { get => m_mushroomMaxMP; set { } }
    public IReadOnlyReactiveProperty<int> CurrentMP { get => m_mushroomCurrentMP; set { } }
    public IReadOnlyReactiveProperty<int> AttackPow { get => m_mushroomAttackPow; set { } }
    public IReadOnlyReactiveProperty<int> MagicPow { get => m_mushroomMagicPow; set { } }
    public IReadOnlyReactiveProperty<int> DefensivePower { get => m_mushroomDefensivePower; set { } }
    public IReadOnlyReactiveProperty<int> Agility { get => m_mushroomAgility; set { } }
    public IReadOnlyReactiveProperty<int> MaxAgility { get => m_mushroomMaxAgility; set { } }
    public IReadOnlyReactiveProperty<int> Exp { get => m_mushroomExp; set { } }

    [SerializeField] MushroomCommandBattleAnimation m_battleAnimation;
    [SerializeField] MushroomDeath m_mushroomDeath;

    [SerializeField] IntReactiveProperty m_mushroomMaxHP = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomCurrentHP = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomMaxMP = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomCurrentMP = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomAttackPow = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomMagicPow = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomDefensivePower = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomAgility = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomMaxAgility = new IntReactiveProperty(0);
    [SerializeField] IntReactiveProperty m_mushroomExp = new IntReactiveProperty(0);

    [SerializeField] EnemyData m_enemyData;
    public MushroomCommandBattleAnimation BattleAnimation { get => m_battleAnimation; }
    public MushroomDeath MushroomDeath { get => m_mushroomDeath; }
    private void Start()
    {
        //m_mushroomMaxHP.Value = Ma;
        //m_mushroomCurrentHP.Value = CurrentHP;
        //m_mushroomCurrentMP.Value = CurrentMP;
        //m_mushroomAttackPow.Value = AttackPow;
        //m_mushroomMagicPow.Value = MagicPow;
        //m_mushroomDefensivePower.Value = DefensivePower;
        //m_mushroomAgility.Value = Agility;
        //m_mushroomMaxAgility.Value = MaxAgility;
        //m_mushroomExp.Value = Exp;
    }
    public override void ReceiveDamage(int damage)
    {
        m_mushroomCurrentHP.Value -= damage;
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
