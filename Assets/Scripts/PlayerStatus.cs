using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //最大HP
    public int m_playerMaxHP = 20;
    //現在のHP
    public int PlayerCurrentHP { get; set; } = 20;
    //最大MP
    public int m_playerMaxMp = 10;
    //現在のMP
    public int m_playerCurrentMp = 5;
    //プレイヤー自身の攻撃力
    public int m_playerAttackPow = 5;
    //プレイヤー自身の魔法攻撃力
    public int m_playerMagicPow = 5;
    //プレイヤー自身の守備力
    public int m_playerDefensivePower = 5;
    //プレイヤーの素早さ
    public int m_playerAgility = 3;
    //素早さの最大値(AgilityBarのMaxValue)
    public int m_playerMaxAgility = 100;

    static bool m_isExists;
    DamageCaster m_damage;
    EnemyStatus m_enemy;
    public event Action OnPlayeHPChange;
    void Awake()
    {
        if (m_isExists == true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_isExists = true;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    //event
    public void PlayerDamage(int damage)
    {
        PlayerCurrentHP -= damage;
        OnPlayeHPChange?.Invoke();
        if (m_playerCurrentMp <= 0)
        {
            //HPがゼロになった時の処理
        }
    }
}
