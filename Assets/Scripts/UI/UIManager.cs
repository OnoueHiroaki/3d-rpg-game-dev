using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button m_winButton;
    [SerializeField] GameObject m_winPanel;
    public GameObject WinPanel { get => m_winPanel; set { } }
    public Button WinButton { get => m_winButton; }
    public void OnClickWin()
    {
        SceneManager.LoadScene("ExploreScene");
    }
}
