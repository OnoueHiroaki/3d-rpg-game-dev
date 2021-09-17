using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStatus
{
    static PlayerStatus m_instance = new PlayerStatus();
    static public PlayerStatus Instance => m_instance;
    private PlayerStatus() { }

    //現在のレベル
    public int CurrentLevel { get; set; }

    //最大HP
    public int MaxHP { get; set; }
    //現在のHP
    public int CurrentHP { get; set; } = 20;

    //最大MP
    public int MaxMP { get; set; }
    //現在のMP
    public int CurrentMP { get; set; } = 3;

    //プレイヤー自身の攻撃力
    public int AttackPow { get; set; }
    //プレイヤー自身の魔法攻撃力
    public int MagicPow { get; set; }
    //プレイヤー自身の守備力
    public int DefensivePower { get; set; }

    //プレイヤーの素早さ
    public int Agility { get; set; }
    //素早さの最大値(AgilityBarのMaxValue)
    public int MaxAgility { get; set; }

    //最大経験値
    public int MaxExp { get; set; }
    public int CurrentExp { get; set; } = 0;

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
