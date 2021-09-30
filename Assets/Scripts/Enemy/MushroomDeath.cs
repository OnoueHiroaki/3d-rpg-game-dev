using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomDeath : MonoBehaviour
{
    bool m_deathFlag1 = false;
    bool m_deathFlag2 = false;
    bool m_deathFlag3 = false;
    public void OneMushroomEnemyDeath(MushroomEnemyStatus[] mushroomEnemy, PlayerStatus playerStatus, GetExp getExp)
    {
        var exp = mushroomEnemy[0].Exp;
        mushroomEnemy[0].Agility = 0;
        playerStatus.CurrentExp = getExp.SetExp(playerStatus.CurrentExp, exp);
        mushroomEnemy[0].BattleAnimation.DeathAnim();
        playerStatus.Agility = 0;
    }
    public void TwoMushroomEnemyDeath(MushroomEnemyStatus[] mushroomEnemy, PlayerStatus playerStatus, GetExp getExp)
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
        var exp = mushroomEnemy[0].Exp + mushroomEnemy[1].Exp;
        playerStatus.CurrentExp = getExp.SetExp(playerStatus.CurrentExp, exp);
        playerStatus.Agility = 0;
    }
    public void ThreeMushroomEnemyDeath(MushroomEnemyStatus[] mushroomEnemy, PlayerStatus playerStatus, GetExp getExp)
    {
        if (0 >= mushroomEnemy[0].CurrentHP && !flag1)
        {
            mushroomEnemy[0].Agility = 0;
            mushroomEnemy[0].BattleAnimation.DeathAnim();
            flag1 = true;
        }
        if (0 >= mushroomEnemy[1].CurrentHP && !flag2)
        {
            mushroomEnemy[1].Agility = 0;
            mushroomEnemy[1].BattleAnimation.DeathAnim();
            flag2 = true;
        }
        if (0 >= mushroomEnemy[2].CurrentHP && !flag3)
        {
            mushroomEnemy[2].Agility = 0;
            mushroomEnemy[2].BattleAnimation.DeathAnim();
            flag3 = false;
        }
        if (0 >= mushroomEnemy[0].CurrentHP && 0 >= mushroomEnemy[1].CurrentHP &&
            0 >= mushroomEnemy[2].CurrentHP)
        {
            var exp = mushroomEnemy[0].Exp + mushroomEnemy[1].Exp + mushroomEnemy[2].Exp;
            playerStatus.CurrentExp = getExp.SetExp(playerStatus.CurrentExp, exp);
            playerStatus.Agility = 0;
            m_playerHPChange.PlyerStatusChange(playerStatus, m_playerLevelController);
            m_winPanel.gameObject.SetActive(true);
            m_uIManager.WinButton.gameObject.SetActive(true);
        }
        
    }
}
