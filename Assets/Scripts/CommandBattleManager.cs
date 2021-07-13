using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommandBattleManager : MonoBehaviour
{
    //プレイヤーのHPスライダー
    [SerializeField] private Slider m_playerHpSlider;
    //プレイヤーのMPスライダー
    [SerializeField] private Slider m_playerMpSlider;
    //プレイヤーの素早さのスライダー
    [SerializeField] private Slider m_playerAgilitySlider;
    //敵のHPスライダー
    [SerializeField] private Slider m_enemyHpSlider;
    //敵の素早さのスライダー
    [SerializeField] private Slider m_enemyAgilitySlider;

    [SerializeField] private Animator m_firstPanel;
    [SerializeField] private Animator m_secondPanel;
    [SerializeField] private EnemyStatus m_enemy;
    PlayerStatus m_player;
    bool m_firstOpen;
    bool m_secondOpen;
    void Start()
    {
        m_player = GameObject.Find("Player").GetComponent<PlayerStatus>();
        m_firstPanel.SetBool("FirstOpen",true);
        m_secondPanel.SetBool("SecondOpen",false);
        //m_secondPanel.SetActive(false);
        //プレイヤーのスライダー
        m_playerHpSlider.maxValue = m_player.m_playerMaxHp;
        m_playerHpSlider.value = m_player.m_playerCurrentHp;
        m_playerMpSlider.maxValue = m_player.m_playerMaxMp;
        m_playerMpSlider.value = m_player.m_playerCurrentMp;
        m_playerAgilitySlider.maxValue = m_player.m_playerMaxAgility;
        m_playerAgilitySlider.value = 0;
        //敵のスライダー
        m_enemyHpSlider.maxValue = m_enemy.m_enemyHp;
        m_enemyHpSlider.value = m_enemy.m_enemyHp;
        m_enemyAgilitySlider.maxValue = m_enemy.m_enemyMaxAgility;
        m_enemyAgilitySlider.value = 0;
    }

    void Update()
    {
        m_enemyAgilitySlider.value += m_enemy.m_enemyAgility * Time.deltaTime;
        m_playerAgilitySlider.value += m_player.m_playerAgility * Time.deltaTime;
        EnemyAttack();
        EnemyDeath();
    }
    /// <summary>
    /// プレイヤーがボタンを使って攻撃するためのメソッド
    /// </summary>
    public void PlayerAttack()
    {
        if (m_playerAgilitySlider.value == m_playerAgilitySlider.maxValue)
        {
            m_enemyHpSlider.value -= m_player.m_playerAttackPow - m_enemy.m_enemyDefensivePower;
            m_enemy.m_enemyHp -= m_player.m_playerAttackPow - m_enemy.m_enemyDefensivePower;
            m_playerAgilitySlider.value = 0;
        }
    }
    public void MagicArrow()
    {
        if (m_playerAgilitySlider.value == m_playerAgilitySlider.maxValue && m_playerMpSlider.value >= 3)
        {
            m_enemyHpSlider.value -= m_player.m_playerMagicPow + 5 - m_enemy.m_enemyDefensivePower;
            m_enemy.m_enemyHp -= m_player.m_playerMagicPow + 5 - m_enemy.m_enemyDefensivePower;
            m_playerMpSlider.value -= 3;
            m_player.m_playerCurrentMp -= 3;
            m_playerAgilitySlider.value = 0;
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
    void EnemyAttack()
    {
        if (m_enemyAgilitySlider.value == m_enemyAgilitySlider.maxValue)
        {
            m_playerHpSlider.value -= m_enemy.m_enemyAttackPow - m_player.m_playerDefensivePower;
            m_player.m_playerCurrentHp -= m_enemy.m_enemyAttackPow - m_player.m_playerDefensivePower;
            m_enemyAgilitySlider.value = 0;
        }
    }
    /// <summary>
    /// 敵の死亡判定
    /// </summary>
    void EnemyDeath()
    {
        if (m_enemyHpSlider.value == 0)
        {
            SceneManager.LoadScene("ExploreScene");
        }
    }
    public void FirstPanelInactive()
    {
        m_firstPanel.SetBool("FirstOpen",false);
        m_secondPanel.SetBool("SecondOpen",true);
    }
    public void SecondPanelInactive()
    {
        m_firstPanel.SetBool("FirstOpen",true);
        m_secondPanel.SetBool("SecondOpen",false);
    }
}
