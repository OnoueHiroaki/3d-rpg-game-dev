﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackIdentification : MonoBehaviour
{
    [SerializeField] Button[] m_enemy;
    private int m_enemyNum;
    public int PlayerAttackIdentification()
    {
        return m_enemyNum;
    }
    public void Enemy1 ()
    {
        m_enemyNum = 0;
    }
    public void Enemy2()
    {
        m_enemyNum = 1;

    }
    public void Enemy3()
    {
        m_enemyNum = 2;

    }
}