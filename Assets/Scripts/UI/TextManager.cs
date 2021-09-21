using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] Text m_winText;
    [SerializeField] Text m_hPText;
    [SerializeField] Text m_mPText;
    PlayerStatus m_playerStatus;
    private void Start()
    {
        m_playerStatus = PlayerStatus.Instance;
    }
    public void PlayerStatusUpdate(int m_currentHP, int m_currentMP)
    {
        m_hPText.text = "HP                          " + m_currentHP;
        m_mPText.text = "MP                          " + m_currentMP;
    }
    public void WinLevelUpText(int m_playerLevel)
    {
        var exp = m_playerStatus.MaxExp - m_playerStatus.CurrentExp;
        m_winText.text = "レベルが" + m_playerLevel + "になった" + "\n"
                         + "次のレベルまであと" + exp + "Expです";
    }
}
