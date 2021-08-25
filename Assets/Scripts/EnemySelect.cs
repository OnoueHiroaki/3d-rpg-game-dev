using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelect : MonoBehaviour
{
    public int SelectedNum { get; set; }
    public int Num { get; set; }
    EnemyUIList m_enemyUIScript;
    void Start()
    {
        m_enemyUIScript = GameObject.Find("EnemyUIManager").GetComponent<EnemyUIList>();
    }
    public void OnSelect()
    {
        SelectedNum = m_enemyUIScript.EnemyNum[Num];
        Debug.Log(Num);
    }
}
