using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Transform[] m_position;
    [SerializeField] GameObject m_enemyPrefab;
    public GameObject[] m_enemyList { get;set; }
    public int RandomNum { get; private set; }
    void Awake()
    {
        EnemyGenerate();
    }
    void EnemyGenerate()
    {
        RandomNum = Random.Range(1, 4);
        m_enemyList = new GameObject[RandomNum];
        for (int i = 0; i < RandomNum; i++)
        {
            var enemy = Instantiate(m_enemyPrefab);
            m_enemyList[i] = enemy;
            m_enemyList[i].transform.position = m_position[i].position;
        }
    }
}
