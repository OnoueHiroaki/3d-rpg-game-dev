using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Vector3[] m_position;
    [SerializeField] GameObject m_cavas;
    public GameObject m_enemyPrefab;
    public GameObject[] m_enemyList { get; private set; }
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
            m_enemyList[i] = m_enemyPrefab;
            var a = Instantiate(m_enemyList[i]) ;
            a.transform.position = m_position[i];
            a.transform.SetParent(m_cavas.transform);
        }
    }
}
