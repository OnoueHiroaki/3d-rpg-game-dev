using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] Text m_winText;
    [SerializeField] Text m_hPText;
    [SerializeField] Text m_mPText;

    public void PlayerStatusUpdate(int m_currentHP, int m_currentMP)
    {
        m_hPText.text = "HP                          " + m_currentHP;
        m_mPText.text = "MP                          " + m_currentMP;
    }
    public void WinText(int m_playerLevel, int m_playerMaxExp)
    {
        var level = m_playerLevel + 1;
        m_winText.text = "現在のレベルは " + level + " です" + "\n"
                         + "次のレベルまであと " + m_playerMaxExp + " Expです";
    }
}
