using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    //最大HP
    public int m_playerMaxHp = 20;
    //現在のHP
    public int m_playerCurrentHp = 20;
    //現在のMP
    public int m_playerMp = 5;
    //プレイヤー自身の攻撃力
    public int m_playerAttackPow = 5;
    //プレイヤー自身の魔法攻撃力
    public int m_playerMagicPow = 5;
    //プレイヤー自身の守備力
    public int m_playerDefensivePower = 5;
    //プレイヤーの素早さ
    public int m_playerAgility = 3;
    //素早さの最大値(AgilityBarのMaxValue)
    public int m_playerMaxAgility = 100;

    static bool m_isExists;
    void Start()
    {
       
    }

    void Update()
    {
    }
    void Awake()
    {
        if (m_isExists == true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_isExists = true;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
