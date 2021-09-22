using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>敵のUIを生成するスクリプト</summary>
public class EnemyUIGenerator : MonoBehaviour
{
    //UIを表示させるために親オブジェクトのCanvas
    [SerializeField] GameObject m_canvasObject;
    [SerializeField] GameObject m_enemyUIPrefab;
    [SerializeField] GameObject m_enemyArrowPrefab;
    [SerializeField] Transform[] m_uIPosition;
    [SerializeField] Transform[] m_arrowPosition; 
    //生成したUIを入れるための配列
    public GameObject[] EnemyUIArray { get; set; }
    public GameObject[] EnemyArrowPrefabArray { get; set; }
    public GameObject EnemyUI { get; set; }
    public GameObject EnemyArrowPrefab { get; set; }
    ///<summary>UIを生成</summary>
    private void Awake()
    {
        EnemyUIArray = new GameObject[EnemyGenerator.Instance.RandomNum];
        EnemyArrowPrefabArray = new GameObject[EnemyGenerator.Instance.RandomNum];
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            EnemyUI = Instantiate(m_enemyUIPrefab);
            EnemyArrowPrefab = Instantiate(m_enemyArrowPrefab);
            EnemyUIArray[i] = EnemyUI;
            EnemyArrowPrefabArray[i] = EnemyArrowPrefab;
            var select = EnemyUIArray[i].GetComponent<EnemyUI>();
            select.Num = i;
            EnemyUIArray[i].transform.SetParent(m_canvasObject.transform,false);
            EnemyArrowPrefabArray[i].transform.SetParent(m_canvasObject.transform,false);
            EnemyUIArray[i].transform.position = m_uIPosition[i].position;
            EnemyArrowPrefabArray[i].transform.position = m_arrowPosition[i].position;
        }
    }
}
