using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerStatus instance;

    private int m_hp;
    void Start()
    {
    }

    void Update()
    {

    }
    void KeepPlayerData()
    {
        SceneManager.sceneLoaded += SceneLoad;
        
    }
    void SceneLoad(Scene scene,LoadSceneMode loadSceneMode)
    {
        m_hp = instance.m_playerCurrentHp;
        SceneManager.sceneLoaded -= SceneLoad;
    }
}
