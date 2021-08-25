using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIList : MonoBehaviour
{
    [SerializeField] private GameObject m_canvasObject;
    [SerializeField] GameObject m_enemyUI;
    public int[] EnemyNum { get; set; }
    [SerializeField] EnemyGenerator instance;
    [SerializeField] private Transform[] m_uIPosition;
    //[SerializeField] EnemySelect m_select;
    public int m_enemySelectNum;
    private void Start()
    {
        //var canvas = GameObject.Find("Canvas");
        EnemyNum = new int[instance.RandomNum];
        for (int i = 0; i < instance.RandomNum; i++)
        {
            //var position = Instantiate(m_enemyUI, canvas.transform);
            var enemyUI = Instantiate(m_enemyUI);
            var select = enemyUI.GetComponent<EnemySelect>();
            select.Num = i;
            enemyUI.transform.SetParent(m_canvasObject.transform);
            enemyUI.transform.localScale = Vector3.one;
            enemyUI.transform.position = m_uIPosition[i].position;
            //EnemyNum[m_enemySelectNum] = i;
            m_enemySelectNum++;
        }
    }
}
