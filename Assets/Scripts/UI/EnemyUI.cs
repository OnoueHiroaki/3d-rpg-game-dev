using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    [SerializeField] Slider m_enemyHPSlider;

    public Slider EnemyHPSlider { get { return m_enemyHPSlider; } private set { } }

    [SerializeField] Slider m_enemyAgilitySlider;

    public Slider EnemyAgilitySlider { get { return m_enemyAgilitySlider; } private set { } }

    public int SelectedNum { get; set; }
    public int Num { get; set; }
    public void OnSelect()
    {
        EnemyGenerator.Instance.SelectNum = Num;
    }
    public void EnemyAgilityUpdate(int enemyAgility)
    {
        m_enemyAgilitySlider.value += enemyAgility * Time.deltaTime;
    }
}
