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
    public int m_agility = 3;

    public Slider m_hpSlider;//[SerializeField] private
    PlayerStatus m_player = default;
    void Start()
    {
        //m_hpSlider = GetComponent<Slider>();
        m_hpSlider.maxValue = m_enemyHp;
        m_hpSlider.value = m_enemyHp;
    }

    void Update()
    {
        EnemyDeath();
    }
    //public void EnemyAttack()
    //{
    //    playerHp -= m_enemyAttackPow;
    //}
    //public void EnemyMagicAttack()
    //{
    //    playerHp -= m_enemyMagicPow;
    //}
    //public void EnemyDmage(int playerAttackPow)
    //{
    //    m_enemyHp -= playerAttackPow;
    //}

    void EnemyDeath()
    {
        if (m_hpSlider.value == 0)
        {
            SceneManager.LoadScene("ExploreScene");
        }
    }
}
