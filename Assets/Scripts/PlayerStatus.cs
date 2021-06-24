using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private static int m_playerHp = 20;
    private static int m_playerMp = 5;
    private static int m_playerAttackPow = 5;
    private static int m_playerMagicPow = 5;
    private static int m_playerDefensivePower = 5;
    // private static int m_player

    Slider m_hpSlider;
    Slider m_mpSlider;
    void Start()
    {
        m_hpSlider = GameObject.Find("HpBar").GetComponent<Slider>();
        m_mpSlider = GameObject.Find("MpBar").GetComponent<Slider>();
        m_hpSlider.maxValue = m_playerHp;
    }

    void Update()
    {
        m_hpSlider.value = m_playerHp;
        m_mpSlider.value = m_playerMp;
        Attck();
    }
    void Attck()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_playerHp -= 5;
        }
        
    }
}
