using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBattleManager : MonoBehaviour
{
    [SerializeField] private PlayerStatus m_player;
    [SerializeField] private EnemyStatus m_enemy;
    void Start()
    {
        
    }

    void Update()
    {
        m_enemy.EnemyAttack();
        m_enemy.EnemyDeath();
        m_player.m_agilitySlider.value += m_player.m_playerAgility * Time.deltaTime;
        m_enemy.m_agilitySlider.value += m_enemy.m_enemyAgility * Time.deltaTime;
    }
    public void Attack()
    {
        m_player.PlayerAttack();
    }
}
