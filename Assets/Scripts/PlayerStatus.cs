using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStatus
{
    static PlayerStatus m_instance = new PlayerStatus(); 
    static public PlayerStatus Instance => m_instance;
    private PlayerStatus() { }
    //最大HP
    public int m_playerMaxHP = 30;
    //現在のHP
    public int PlayerCurrentHP { get; private set; } = 30;
    //最大MP
    public int m_playerMaxMp = 10;
    //現在のMP
    public int PlayerCurrentMP { get; private set; } = 10;
    //プレイヤー自身の攻撃力
    public int m_playerAttackPow = 10;
    //プレイヤー自身の魔法攻撃力
    public int m_playerMagicPow = 10;
    //プレイヤー自身の守備力
    public int m_playerDefensivePower = 10;
    //プレイヤーの素早さ
    public int m_playerAgility = 30;
    //素早さの最大値(AgilityBarのMaxValue)
    public int m_playerMaxAgility = 50;
    public event Action OnPlayeHPChange;
    public event Action OnPlayerMPChange;
    //event
    public void PlayerDamage(int damage)
    {
        PlayerCurrentHP -= damage;
        OnPlayeHPChange?.Invoke();
        if (PlayerCurrentHP <= 0)
        {
            //HPがゼロになった時の処理
        }
    }
    public void PlayerMPDown(int mpDown)
    {
        PlayerCurrentMP -= mpDown;
        OnPlayerMPChange?.Invoke();
        if (PlayerCurrentMP <= mpDown)
        {
            Debug.Log("MPが足りません");
        }
    }
}
