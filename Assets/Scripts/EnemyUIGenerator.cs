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
    //生成する数を持ってくる
    [SerializeField] EnemyGenerator instance;
    [SerializeField] Transform[] m_uIPosition;
    public GameObject EnemyUI { get; set; }
    ///<summary>UIを生成</summary>
    private void Awake()
    {
        EnemyUIList = new GameObject[instance.RandomNum + 1];
        for (int i = 1; i <= instance.RandomNum; i++)
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
