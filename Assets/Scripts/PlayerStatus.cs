using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance { get; private set; }
    //最大HP
    public int m_playerMaxHP = 20;
    //現在のHP
    public static int PlayerCurrentHP { get; private set; } = 20;
    //最大MP
    public int m_playerMaxMp = 10;
    //現在のMP
    public static int PlayerCurrentMP { get; private set; } = 10;
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
    public event Action OnPlayeHPChange;
    public event Action OnPlayerMPChange;
    EnemyStatus m_enemy;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
            return; 
        }
        Instance = this;
    }
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
