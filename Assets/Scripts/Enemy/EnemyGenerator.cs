using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵を生成するスクリプト
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator Instance { get; private set; }
    [SerializeField] Transform[] m_position;
    [SerializeField] GameObject m_enemyPrefab;
    /// <summary>生成した敵オブジェクトを入れるための変数</summary>
    public GameObject[] EnemyList { get;set; }
    /// <summary>敵を生成する数</summary>
    public int RandomNum { get; private set; }
    public int SelectNum { get; set; }
    void Awake()
    {
        Instance = this;
        EnemyGenerate();
    }
    /// <summary>敵を生成する関数</summary>
    void EnemyGenerate()
    {
        RandomNum = Random.Range(1, 4);
        EnemyList = new GameObject[RandomNum];
        for (int i = 0; i < RandomNum; i++)
        {
            EnemyList[i] = Instantiate(m_enemyPrefab);
            EnemyList[i].transform.position = m_position[i].position;            
            
        }
    }
}
