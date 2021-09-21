using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStatus
{
    static PlayerStatus m_instance = new PlayerStatus();
    static public PlayerStatus Instance => m_instance;
    public PlayerStatus() { }

    public int CurrentLevel { get; set; }
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; } = 20;
    public int MaxMP { get; set; }
    public int CurrentMP { get; set; } = 3;
    public int AttackPow { get; set; }
    public int MagicPow { get; set; }
    public int DefensePower { get; set; }
    public int Agility { get; set; }
    public int MaxAgility { get; set; }
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
