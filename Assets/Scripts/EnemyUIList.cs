using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIList : MonoBehaviour
{
    [SerializeField] private GameObject m_canvasObject;
    [SerializeField] GameObject m_enemyUI;
    private int m_enemyNum;
    [SerializeField] EnemyGenerator instance;
    [SerializeField] private Transform[] m_uIPosition;
    private void Start()
    {
        //var canvas = GameObject.Find("Canvas");
        for (int i = 0; i < instance.RandomNum; i++)
        {
            //var position = Instantiate(m_enemyUI, canvas.transform);
            var position = Instantiate(m_enemyUI);
            position.transform.SetParent(m_canvasObject.transform);
            position.transform.localScale = Vector3.one;
            position.transform.position = m_uIPosition[i].position;
        }
    }
}
