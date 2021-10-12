using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomDeath : MonoBehaviour
{
    UIManager m_uIManager;
    PlayerStatusChange m_playerHPChange;
    bool m_deathFlag1 = false;
    bool m_deathFlag2 = false;
    bool m_deathFlag3 = false;
    private void Start()
    {
        m_uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    public void OneMushroomEnemyDeath(MushroomEnemyStatus[] mushroomEnemy, PlayerStatus playerStatus, GetExp getExp, PlayerLevelController playerLevelController)
    {
        var exp = mushroomEnemy[0].Exp;
        mushroomEnemy[0].Agility = 0;
        playerStatus.Agility = 0;
        playerStatus.CurrentExp = getExp.SetExp(playerStatus.CurrentExp, exp);
        m_playerHPChange.PlyerStatusChange(playerStatus, playerLevelController);
        m_uIManager.WinPanel.gameObject.SetActive(true);
        m_uIManager.WinButton.gameObject.SetActive(true);
        mushroomEnemy[0].BattleAnimation.DeathAnim();
    }
    public void TwoMushroomEnemyDeath(MushroomEnemyStatus[] mushroomEnemy, PlayerStatus playerStatus, GetExp getExp, PlayerLevelController playerLevelController)
    {
        if (0 >= mushroomEnemy[0].CurrentHP && !m_deathFlag1)
        {
            mushroomEnemy[0].Agility = 0;
            mushroomEnemy[0].BattleAnimation.DeathAnim();
            m_deathFlag1 = true;
        }
        if (0 >= mushroomEnemy[1].CurrentHP && !m_deathFlag2)
        {
            mushroomEnemy[1].Agility = 0;
            mushroomEnemy[1].BattleAnimation.DeathAnim();
            m_deathFlag2 = true;
        }
        if (0 >= mushroomEnemy[0].CurrentHP && 0 >= mushroomEnemy[1].CurrentHP)
        {
            var exp = mushroomEnemy[0].Exp + mushroomEnemy[1].Exp;
            playerStatus.CurrentExp = getExp.SetExp(playerStatus.CurrentExp, exp);
            playerStatus.Agility = 0;
            m_playerHPChange.PlyerStatusChange(playerStatus, playerLevelController);
            m_uIManager.WinPanel.gameObject.SetActive(true);
            m_uIManager.WinButton.gameObject.SetActive(true);
        }
    }
    public void ThreeMushroomEnemyDeath(MushroomEnemyStatus[] mushroomEnemy, PlayerStatus playerStatus, GetExp getExp,PlayerLevelController playerLevelController)
    {
        if (0 >= mushroomEnemy[0].CurrentHP && !m_deathFlag1)
        {
            mushroomEnemy[0].Agility = 0;
            mushroomEnemy[0].BattleAnimation.DeathAnim();
            m_deathFlag1 = true;
        }
        if (0 >= mushroomEnemy[1].CurrentHP && !m_deathFlag2)
        {
            mushroomEnemy[1].Agility = 0;
            mushroomEnemy[1].BattleAnimation.DeathAnim();
            m_deathFlag2 = true;
        }
        if (0 >= mushroomEnemy[2].CurrentHP && !m_deathFlag3)
        {
            mushroomEnemy[2].Agility = 0;
            mushroomEnemy[2].BattleAnimation.DeathAnim();
            m_deathFlag3 = true;
        }
        if (0 >= mushroomEnemy[0].CurrentHP && 0 >= mushroomEnemy[1].CurrentHP &&
            0 >= mushroomEnemy[2].CurrentHP)
        {
            var exp = mushroomEnemy[0].Exp + mushroomEnemy[1].Exp + mushroomEnemy[2].Exp;
            playerStatus.CurrentExp = getExp.SetExp(playerStatus.CurrentExp, exp);
            playerStatus.Agility = 0;
            m_playerHPChange.PlyerStatusChange(playerStatus, playerLevelController);
            m_uIManager.WinPanel.gameObject.SetActive(true);
            m_uIManager.WinButton.gameObject.SetActive(true);
        }
    }
}
