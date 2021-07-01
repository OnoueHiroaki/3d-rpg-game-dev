using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    //プレイヤーの体力
    public int m_playerHp = 20;
    //プレイヤーのMP
    public int m_playerMp = 5;
    //プレイヤーの攻撃力
    public int m_playerAttackPow = 5;
    //プレイヤーの魔法攻撃力
    public int m_playerMagicPow = 5;
    //プレイヤーの守備力
    public int m_playerDefensivePower = 5;

    [SerializeField] private Slider m_hpSlider;
    
    [SerializeField] private Slider m_mpSlider;

    [SerializeField] private EnemyStatus m_enemy = default;
    void Start()
    {
        m_hpSlider.maxValue = m_playerHp;
        m_hpSlider.value = m_playerHp;
    }

    void Update()
    {
        
    }
    public void PlayerAttack()
    {
        m_enemy.m_hpSlider.value -= m_playerAttackPow - m_enemy.m_enemyDefensivePower;
    }
    public void PlayerMagicAttack()
    {
        m_enemy.m_enemyHp -= m_playerMagicPow;
    }
}
