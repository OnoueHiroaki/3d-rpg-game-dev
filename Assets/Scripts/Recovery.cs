using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    PlayerStatus m_playerStatus;
    PlayerHPChange m_playerHPChange;
    [SerializeField] PlayerLevelController m_playerLevelController;
    [SerializeField] GameObject m_panel;
    void Start()
    {
        m_playerStatus = PlayerStatus.Instance;
        m_playerHPChange = PlayerHPChange.Instance;
        m_playerHPChange.PlyerStatusChange(m_playerStatus, m_playerLevelController);
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerStatus.CurrentHP = m_playerStatus.MaxHP;
            m_playerStatus.CurrentMP = m_playerStatus.MaxMP;
            StartCoroutine("TextActive");
        }
    }
    private IEnumerator TextActive()
    {
        m_panel.SetActive(true);
        yield return new WaitForSeconds(3);
        m_panel.SetActive(false);
    }
}
