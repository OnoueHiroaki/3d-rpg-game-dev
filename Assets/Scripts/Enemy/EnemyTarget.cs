using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] MushroomEnemyStatus m_mushroomEnemy;
    public MushroomEnemyStatus[] MushroomEnemy { get; set; }

    private void Start()
    {
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            MushroomEnemy[i] = m_mushroomEnemy;
        }
    }
    public void GetMushroomEnemy()
    {
        MushroomEnemy[EnemyGenerator.Instance.SelectNum] =
            EnemyGenerator.Instance.EnemyList[EnemyGenerator.Instance.SelectNum].
            GetComponent<MushroomEnemyStatus>();
    }
}
