using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyStatus : MonoBehaviour
{
    public int m_enemyHp = 30;
    public int m_enemyMp = 3;
    public int m_enemyAttackPow = 3;
    public int m_enemyMagicPow = 3;
    public int m_enemyDefensivePower = 3;
    public int m_enemyAgility = 3;
    public int m_enemyMaxAgility = 100;

    public Slider m_hpSlider;
    public Slider m_agilitySlider;
    [SerializeField] private PlayerStatus m_player;
    void Start()
    {
        
    }

    void Update()
    {
    }
    public void EnemyAttack()
    {
        if (m_agilitySlider.value == m_agilitySlider.maxValue)
        {
            m_player.m_hpSlider.value -= m_enemyAttackPow - m_player.m_playerDefensivePower;
            m_agilitySlider.value = 0;
        }
    }


    public void EnemyDeath()
    {
        if (m_hpSlider.value == 0)
        {
            SceneManager.LoadScene("ExploreScene");
        }
    }
}
