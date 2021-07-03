using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    EnemyStatus m_enemy = default;
    PlayerStatus m_player = default;
    

    void Start()
    {
        m_player = GetComponent<PlayerStatus>();
        m_enemy = GetComponent<EnemyStatus>();
    }

    void Update()
    {
        
    }
     public void Attack()
    {
        int enemyHp = m_enemy.m_enemyHp;
        int playerHp = m_player.m_playerMaxHp;
        if (Input.GetButtonDown("Fire1")) 
        {
            //m_player.PlayerAttack(enemyHp);
        }
        //m_enemy.EnemyAttack(playerHp);
    }
    //public void Damage()
    //{
    //    int player = m_player.m_playerAttackPow;
    //    m_enemy.EnemyDamage(player);
    //}

}
