using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUIController : MonoBehaviour
{
    List<Slider> m_hPSlider;
    List<Slider> m_agilitySlider;
    List<IEnemyStatus> m_enemyStatus;
    List<EnemyUI> m_enemyUIList;
    EnemyUIGenerator m_enemyUIGenerator;
    int EnemyMaxHp { get; set; }
    int EnemyMaxAgility { get; set; }
    private void Start()
    {
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            m_enemyStatus[i] = EnemyGenerator.Instance.EnemyList[i].GetComponent<IEnemyStatus>();
            m_enemyUIList[i] = m_enemyUIGenerator.EnemyUIArray[i].GetComponent<EnemyUI>();
            EnemyMaxHp = m_enemyStatus[i].MaxHP.Value;
            EnemyMaxAgility = m_enemyStatus[i].MaxAgility.Value;
        }
    }
    void StartEnemyUI(int enemyIndexNumber)
    {
        m_hPSlider[enemyIndexNumber].value = m_enemyStatus[enemyIndexNumber].CurrentHP.Value / (float)EnemyMaxHp;
        m_agilitySlider[enemyIndexNumber].value = 0;
    }
    void AgilityUpdate(int enemyIndexNumber)
    {
        m_agilitySlider[enemyIndexNumber].value = (m_enemyStatus[enemyIndexNumber].Agility.Value / (float)EnemyMaxAgility) * Time.deltaTime;

    }
}
