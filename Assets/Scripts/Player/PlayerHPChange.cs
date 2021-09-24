using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPChange 
{
    static PlayerHPChange m_instance = new PlayerHPChange();
    static public PlayerHPChange Instance => m_instance;
    public PlayerHPChange() { }
    public void PlyerStatusChange(PlayerStatus playerStatus ,PlayerLevelController playerLevelController)
    {
        playerStatus.MaxHP = playerLevelController.GetData(playerStatus.CurrentLevel).MaxHP;
        playerStatus.MaxMP = playerLevelController.GetData(playerStatus.CurrentLevel).MaxMP;
        playerStatus.AttackPow = playerLevelController.GetData(playerStatus.CurrentLevel).AttackPow;
        playerStatus.MaxAgility = playerLevelController.GetData(playerStatus.CurrentLevel).MaxAgility;
        playerStatus.Agility = playerLevelController.GetData(playerStatus.CurrentLevel).Agility;
        playerStatus.MagicPow = playerLevelController.GetData(playerStatus.CurrentLevel).MagicAttackPow;
        playerStatus.DefensePower = playerLevelController.GetData(playerStatus.CurrentLevel).Defense;
        //playerStatus.MaxExp = m_playerLevelController.GetData(playerStatus.CurrentLevel).MaxExp;
        //playerStatus.CurrentLevel = m_playerLevelController.GetData(playerStatus.CurrentLevel).Level;
    }
}
