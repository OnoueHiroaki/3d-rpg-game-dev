using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    PlayerStatus m_playerStatus;
    PlayerHPChange m_playerHPChange;
    [SerializeField] PlayerLevelController m_playerLevelController;
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
            Debug.Log("aaa");
            m_playerStatus.CurrentHP = m_playerStatus.MaxHP;
            m_playerStatus.CurrentMP = m_playerStatus.MaxMP;
        }
    }
}
