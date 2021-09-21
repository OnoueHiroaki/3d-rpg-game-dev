using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamage : PlayerStatus
{
    static PlayerAttackDamage m_instance = new PlayerAttackDamage();
    static public new PlayerAttackDamage Instance => m_instance;
    public PlayerAttackDamage() { }
}
