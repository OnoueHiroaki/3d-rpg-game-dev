using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBattleManager : MonoBehaviour
{
    [SerializeField] private PlayerStatus m_player;
    [SerializeField] private EnemyStatus m_enemy;

    //[SerializeField]private  PlayerStatus 
    //[SerializeField] private Slider m_playerHpSlider;

    void Start()
    {
        
        //プレイヤーのスライダー
        m_player.m_hpSlider.maxValue = m_player.m_playerMaxHp;
        m_player.m_hpSlider.value = m_player.m_playerCurrentHp;
        m_player.m_agilitySlider.maxValue = m_player.m_playerMaxAgility;
        m_player.m_agilitySlider.value = 0;
        //エネミーのスライダー
        m_enemy.m_hpSlider.maxValue = m_enemy.m_enemyHp;
        m_enemy.m_hpSlider.value = m_enemy.m_enemyHp;
        m_enemy.m_agilitySlider.maxValue = m_enemy.m_enemyMaxAgility;
        m_enemy.m_agilitySlider.value = 0;
    }

    void Update()
    {
        m_enemy.m_agilitySlider.value = m_enemy.m_enemyAgility * Time.deltaTime;
        m_player.m_agilitySlider.value = m_player.m_playerAgility * Time.deltaTime;
    }
    public void Attack()
    {
        m_player.PlayerAttack();
    }
    public void PlayerEscape()
    {
        m_player.PlayerEscape();
    }
}
