using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIList : MonoBehaviour
{
    [SerializeField] GameObject[] m_enemy;
    [SerializeField] GameObject[] m_enemyHPSlider;
    [SerializeField] GameObject[] m_enemyAgilitySlider;
    private int m_enemyNum;
    [SerializeField] EnemyGenerator instance;
    private void Start()
    {
        for (int i = 0; i < instance.RandomNum; i++)
        {
            m_enemy[i].SetActive(true);
            m_enemyHPSlider[i].SetActive(true);
            m_enemyAgilitySlider[i].SetActive(true);
        }
    }
    public int PlayerAttackIdentification()
    {
        return m_enemyNum;
    }
    public void Enemy1 ()
    {
        m_enemyNum = 0;
        Debug.Log(m_enemyNum);
    }
    public void Enemy2()
    {
        m_enemyNum = 1;
        Debug.Log(m_enemyNum);
    }
    public void Enemy3()
    {
        m_enemyNum = 2;
        Debug.Log(m_enemyNum);
    }
}
