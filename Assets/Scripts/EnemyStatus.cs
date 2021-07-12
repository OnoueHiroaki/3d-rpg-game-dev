using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyStatus : MonoBehaviour
{
    //敵のHP
    public int m_enemyHp = 30;
    //敵のMP
    public int m_enemyMp = 3;
    //敵の攻撃力
    public int m_enemyAttackPow = 3;
    //敵の魔法攻撃力
    public int m_enemyMagicPow = 3;
    //敵の守備力
    public int m_enemyDefensivePower = 3;
    //敵の素早さ(素早さのvalue)
    public int m_enemyAgility = 3;
    //敵の最大素早さ(素早さのMaxValue)
    public int m_enemyMaxAgility = 100;
    
    void Start()
    {
       
    }
    void Update()
    {

    }
}
