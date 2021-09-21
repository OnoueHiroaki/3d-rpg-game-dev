using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button m_winButton;
    public Button WinButton { get => m_winButton; }
    public void OnClickWin()
    {
        SceneManager.LoadScene("ExploreScene");
    }
}
