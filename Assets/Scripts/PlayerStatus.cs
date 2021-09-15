using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStatus
{
    static PlayerStatus m_instance = new PlayerStatus();
    static public PlayerStatus Instance => m_instance;
    private PlayerStatus() { }
    static PlayerLevelController m_playerLevelController;
    //現在のレベル
    public int m_currentLevel { get; set; } = m_playerLevelController.Level;
    //最大HP
    public int m_maxHP { get; set; } = m_playerLevelController.MaxHP;
    //現在のHP
    public int CurrentHP { get; private set; } = 30;
    //最大MP
    public int m_maxMp { get; set; } = 10;
    //現在のMP
    public int CurrentMP { get; private set; } = m_playerLevelController.MaxMP;
    //プレイヤー自身の攻撃力
    public int m_AttackPow = 10;
    //プレイヤー自身の魔法攻撃力
    public int m_magicPow = 10;
    //プレイヤー自身の守備力
    public int m_defensivePower = 10;
    //プレイヤーの素早さ
    public int m_agility = 30;
    //素早さの最大値(AgilityBarのMaxValue)
    public int m_maxAgility = 50;
    public event Action OnPlayeHPChange;
    public event Action OnPlayerMPChange;
    //event
    public void PlayerDamage(int damage)
    {
        CurrentHP -= damage;
        OnPlayeHPChange?.Invoke();
        if (CurrentHP <= 0)
        {
            //HPがゼロになった時の処理
        }
    }
    public void PlayerMPDown(int mpDown)
    {
        CurrentMP -= mpDown;
        OnPlayerMPChange?.Invoke();
        if (CurrentMP <= mpDown)
        {
            Debug.Log("MPが足りません");
        }
    }
}
