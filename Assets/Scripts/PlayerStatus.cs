using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    //プレイヤーの最大体力
    public int m_playerMaxHp = 20;
    public int m_playerCurrentHp = 20;
    //プレイヤーのMP
    public int m_playerMp = 5;
    //プレイヤーの攻撃力
    public int m_playerAttackPow = 5;
    //プレイヤーの魔法攻撃力
    public int m_playerMagicPow = 5;
    //プレイヤーの守備力
    public int m_playerDefensivePower = 5;
    //プレイヤーの素早さ
    public int m_playerAgility = 3;

    public int m_playerMaxAgility = 100;
    public Slider m_hpSlider;
    
    public Slider m_mpSlider;

    public Slider m_agilitySlider;

    [SerializeField] private EnemyStatus m_enemy = default;
    void Start()
    {
        m_hpSlider.maxValue = m_playerMaxHp;
        m_hpSlider.value = m_playerCurrentHp;
        m_agilitySlider.maxValue = m_playerMaxAgility;
        m_agilitySlider.value = 0;
    }

    void Update()
    {
        //m_agilitySlider.value += m_playerAgility * Time.deltaTime;
    }
    public void PlayerAttack()
    {
        if (m_agilitySlider.value == m_agilitySlider.maxValue)
        {
            m_enemy.m_hpSlider.value -= m_playerAttackPow - m_enemy.m_enemyDefensivePower;
            m_agilitySlider.value = 0;
        }
    }
    public void PlayerMagicAttack()
    {
        m_enemy.m_enemyHp -= m_playerMagicPow;
    }
    public void PlayerEscape()
    {
        SceneManager.LoadScene("ExploreScene");
    }
}
