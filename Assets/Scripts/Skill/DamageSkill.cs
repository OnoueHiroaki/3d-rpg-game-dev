using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSkill : SkillBase
{
    PlayerStatus m_playerStatus;
    [SerializeField] PlayerAttackDamage m_playerAttackDamage;
    public override void MagicArrow(EnemyTarget enemyTarget ,Slider agilitySlider, Slider mPSlider)
    {
        if (agilitySlider.value == agilitySlider.maxValue && mPSlider.value >= 3)
        {
            m_playerAttackDamage.GetAttackDamage(enemyTarget, m_playerStatus.MagicPow, 3);
            m_playerStatus.PlayerMPDown(3);
            //EnemyHPSliderUpdate();
            //EndAttack(m_playerAgilitySlider);
            //if (m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].m_currentHP > 0)
            //{
            //    m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].DamageAnim();
            //}
        }
    }
}
