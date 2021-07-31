using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIList : MonoBehaviour
{
    [SerializeField] private GameObject m_canvasObject;
    public Button[] m_enemySelectList { get; private set; }
    public Slider[] m_enemyHPSliderList { get; private set; }
    public Slider[] m_enemyAgilitySliderList { get; private set; }
    public Button m_enemySelect;
    public Slider m_enemyHPSlider;
    public Slider m_enemyAgilitySlider;
    private int m_enemyNum;
    [SerializeField] EnemyGenerator instance;
    [SerializeField] private Transform[] m_selectPosition;
    [SerializeField] private Transform[] m_hpSliderPosition;
    [SerializeField] private Transform[] m_agilitySliderPosition;
    private void Start()
    {
        for (int i = 0; i < instance.RandomNum; i++)
        {
            var select = Instantiate(m_enemySelect);
            select.transform.SetParent(m_canvasObject.transform);
            //m_enemySelectList[i] = select;
            var hp = Instantiate(m_enemyHPSlider);
            hp.transform.SetParent(m_canvasObject.transform);
            //m_enemyHPSliderList[i] = hp;
            var agility = Instantiate(m_enemyAgilitySlider);
            agility.transform.SetParent(m_canvasObject.transform);
            //m_enemyAgilitySliderList[i] = agility;
            select.transform.position = m_selectPosition[i].position;
            hp.transform.position = m_hpSliderPosition[i].position;
            agility.transform.position = m_agilitySliderPosition[i].position;
        }
    }
    //public int PlayerAttackIdentification()
    //{
    //    return m_enemyNum;
    //}
    public void Enemy1()
    {
        m_enemyNum = 0;
    }
    public void Enemy2()
    {
        m_enemyNum = 1;
    }
    public void Enemy3()
    {
        m_enemyNum = 2;
    }
}
