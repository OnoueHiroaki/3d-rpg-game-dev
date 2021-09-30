using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSliderUpdate : MonoBehaviour
{
    [SerializeField] Slider m_hPSlider;
    [SerializeField] Slider m_mPSlider;
    [SerializeField] Slider m_agilitySlider;
    public Slider HPSlider { get => m_hPSlider; }
    public Slider MPSlider { get => m_mPSlider; }
    public Slider AgilitySlider { get => m_agilitySlider; }
    PlayerStatus m_playerStatus;
    private void Start()
    {
        m_playerStatus = PlayerStatus.Instance;
    }
    /// <summary>プレイヤーのHPバーが現在のHPと同じ数値にする関数</summary>
    public void PlayerHPSliderUpdate()
    {
        m_hPSlider.value = m_playerStatus.CurrentHP;
    }
    /// <summary>プレイヤーのMPバーが現在のMPと同じ数値にする関数</summary>
    public void PlayerMPSliderUpdate()
    {
        m_mPSlider.value = m_playerStatus.CurrentMP;
    }
    public void PlayerUI()
    {
        Debug.Log(m_playerStatus.MaxHP);
        HPSlider.maxValue = m_playerStatus.MaxHP;
        MPSlider.value = m_playerStatus.CurrentHP;
        HPSlider.maxValue = m_playerStatus.MaxHP;
        MPSlider.value = m_playerStatus.CurrentMP;
        AgilitySlider.maxValue = m_playerStatus.MaxAgility;
        AgilitySlider.value = 0;
    }
}
