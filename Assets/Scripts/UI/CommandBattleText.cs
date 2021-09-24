using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandBattleText : MonoBehaviour
{
    [SerializeField] Text m_winText;
    [SerializeField] Text m_hPText;
    [SerializeField] Text m_mPText;

    public Text WinText { get => m_winText; }
    public Text HPText { get => m_hPText; }
    public Text MPText { get => m_mPText; }
}
