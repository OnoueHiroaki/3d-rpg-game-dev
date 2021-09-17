using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>敵のUIを生成するスクリプト</summary>
public class EnemyUIGenerator : MonoBehaviour
{
    //UIを表示させるために親オブジェクトのCanvas
    [SerializeField] GameObject m_canvasObject;
    [SerializeField] GameObject m_enemyUIPrefab;
    //生成したUIを入れるための配列
    public GameObject[] EnemyUIList { get; set; }
    [SerializeField] Transform[] m_uIPosition;
    public GameObject EnemyUI { get; set; }
    ///<summary>UIを生成</summary>
    private void Awake()
    {
        EnemyUIList = new GameObject[EnemyGenerator.Instance.RandomNum];
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            EnemyUI = Instantiate(m_enemyUIPrefab);
            EnemyUIList[i] = EnemyUI;
            var select = EnemyUIList[i].GetComponent<EnemyUI>();
            select.Num = i;
            EnemyUIList[i].transform.SetParent(m_canvasObject.transform);
            EnemyUIList[i].transform.localScale = Vector3.one;
            EnemyUIList[i].transform.position = m_uIPosition[i].position;
        }
    }
}
