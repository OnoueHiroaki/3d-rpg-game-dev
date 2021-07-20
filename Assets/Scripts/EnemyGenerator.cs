using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Vector3[] m_position;
    [SerializeField] private GameObject m_enemy;
    private int r;
    void Start()
    {
        EnemyGenerate();
    }

    void Update()
    {

    }
    void EnemyGenerate()
    {
        r = Random.Range(1, 4);
        for (int i = 0; i < r; i++)
        {
            var a = Instantiate(m_enemy);
            a.transform.position = m_position[i];
        }
    }
}
