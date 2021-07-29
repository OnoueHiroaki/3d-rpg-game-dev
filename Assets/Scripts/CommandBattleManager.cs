﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommandBattleManager : MonoBehaviour
{
    //プレイヤーのHPスライダー
    [SerializeField] private Slider m_playerHPSlider;
    //プレイヤーのMPスライダー
    [SerializeField] private Slider m_playerMPSlider;
    //プレイヤーの素早さのスライダー
    [SerializeField] private Slider m_playerAgilitySlider;
    //敵のHPスライダー
    [SerializeField] private Slider m_enemyHPSlider;
    //敵の素早さのスライダー
    [SerializeField] private Slider m_enemyAgilitySlider;

    [SerializeField] private Text m_hPText;
    [SerializeField] private Text m_mPText;
    [SerializeField] private Animator m_firstPanel;
    [SerializeField] private Animator m_secondPanel;
    [SerializeField] private EnemyStatus m_enemy;
    PlayerStatus m_player;
    [SerializeField]private DamageCaster m_damage;

    void Start()
    {
        //m_enemy.m_enemyCurrentHP = m_enemy.m_enemyMaxHP;
        m_player = PlayerStatus.Instance;
        m_firstPanel.SetBool("FirstOpen", true);
        m_secondPanel.SetBool("SecondOpen", false);
        //プレイヤーのスライダー
        m_playerHPSlider.maxValue = m_player.m_playerMaxHP;
        m_playerHPSlider.value = PlayerStatus.PlayerCurrentHP;
        m_playerMPSlider.maxValue = m_player.m_playerMaxMp;
        m_playerMPSlider.value = PlayerStatus.PlayerCurrentMP;
        m_playerAgilitySlider.maxValue = m_player.m_playerMaxAgility;
        m_playerAgilitySlider.value = 0;
        //敵のスライダー
        m_enemyHPSlider.maxValue = m_enemy.m_enemyMaxHP;
        m_enemyHPSlider.value = m_enemy.m_enemyCurrentHP;
        m_enemyAgilitySlider.maxValue = m_enemy.m_enemyMaxAgility;
        m_enemyAgilitySlider.value = 0;

        m_player.OnPlayeHPChange += PlayerHPSliderUpdate;
        m_player.OnPlayerMPChange += PlayerMPSliderUpdate;
        //m_enemy.OnEnemyHPChange += EnemyHPSliderUpdate;

    }

    void Update()
    {
        m_enemyAgilitySlider.value += m_enemy.m_enemyAgility * Time.deltaTime;
        m_playerAgilitySlider.value += m_player.m_playerAgility * Time.deltaTime;
        EnemyAttack();
        EnemyDeath();
        m_hPText.text = "HP            " + PlayerStatus.PlayerCurrentHP;
        m_mPText.text = "MP            " + PlayerStatus.PlayerCurrentMP;
    }
    /// <summary>
    /// プレイヤーがボタンを使って攻撃するためのメソッド
    /// </summary>
    public void PlayerAttack()
    {
        if (m_playerAgilitySlider.value == m_playerAgilitySlider.maxValue)
        {
            m_enemy.EnemyDamage(m_damage.PlayerNormalAttack(m_player.m_playerAttackPow,m_enemy.m_enemyDefensivePower));
            //m_damage.EnemyDamageText(m_hpText);

            EnemyHPSliderUpdate();
            EndAttack(m_playerAgilitySlider);
        }
    }
    public void MagicArrowAttack()
    {
        if (m_playerAgilitySlider.value == m_playerAgilitySlider.maxValue && m_playerMPSlider.value >= 3)
        {
            m_enemy.EnemyDamage(m_damage.PlayerMagicArrowAttack(m_player.m_playerMagicPow,m_enemy.m_enemyDefensivePower));
            m_player.PlayerMPDown(3);
            EnemyHPSliderUpdate();
            EndAttack(m_playerAgilitySlider);
        }
    }
    /// <summary>
    /// プレイヤーがボタンを使って逃げるためのメソッド
    /// </summary>
    public void PlayerEscape()
    {
        SceneManager.LoadScene("ExploreScene");
    }
    /// <summary>
    /// 敵の攻撃処理
    /// </summary>
    private void EnemyAttack()
    {
        if (m_enemyAgilitySlider.value == m_enemyAgilitySlider.maxValue)
        {
            //playerの関数の中にDmageCasterの関数
            m_player.PlayerDamage(m_damage.EnemyNormalAttack(m_enemy.m_enemyAttackPow, m_player.m_playerDefensivePower));
            EndAttack(m_enemyAgilitySlider);
            //m_damage.EndAttack(m_enemyAgilitySlider);
        }
    }
    void PlayerHPSliderUpdate()
    {
        m_playerHPSlider.value = PlayerStatus.PlayerCurrentHP;
    }
    void PlayerMPSliderUpdate()
    {
        m_playerMPSlider.value = PlayerStatus.PlayerCurrentMP;
    }
    void EnemyHPSliderUpdate()
    {
        m_enemyHPSlider.value = m_enemy.m_enemyCurrentHP;
    }
    /// <summary>
    /// 敵の死亡判定
    /// </summary>
    void EnemyDeath()
    {
        if (m_enemyHPSlider.value <= 0)
        {
            //SceneManager.LoadScene("ExploreScene");
        }
    }
    public void FirstPanelInactive()
    {
        m_firstPanel.SetBool("FirstOpen", false);
        m_secondPanel.SetBool("SecondOpen", true);
    }
    public void SecondPanelInactive()
    {
        m_firstPanel.SetBool("FirstOpen", true);
        m_secondPanel.SetBool("SecondOpen", false);
    }
    public void EndAttack(Slider agility)
    {
        agility.value = 0;
    }
}
