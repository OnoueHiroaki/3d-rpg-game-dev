using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommandBattleManager : MonoBehaviour
{
    //プレイヤーのHPスライダー
    [SerializeField] private Slider m_playerHPSlider;
    //プレイヤーのMPスライダー
    [SerializeField] private Slider m_playerMPSlider;
    //プレイヤーの素早さのスライダー
    [SerializeField] private Slider m_playerAgilitySlider;
    ////敵のHPスライダー
    //[SerializeField] private Slider[] m_enemyHPSlider;
    ////敵の素早さのスライダー
    //[SerializeField] private Slider[] m_enemyAgilitySlider;
    [SerializeField] private Text m_hPText;
    [SerializeField] private Text m_mPText;
    [SerializeField] private Animator m_firstPanel;
    [SerializeField] private Animator m_secondPanel;
    //[SerializeField] private MushroomEnemyStatus m_enemy;
    EnemyGenerator m_enemy;
    EnemySelect m_enemySelect;
    [SerializeField] private EnemyUIList m_enemyUI;
    PlayerStatus m_player;
    void Start()
    {
        m_player = PlayerStatus.Instance;
        SecondPanelInactive();
        PlayerUI();
        EnemyUI();
        m_player.OnPlayeHPChange += PlayerHPSliderUpdate;
        m_player.OnPlayerMPChange += PlayerMPSliderUpdate;
        //m_enemy.OnEnemyHPChange += EnemyHPSliderUpdate;
    }
    void Update()
    {
        //m_enemyUI.m_enemyAgilitySlider[0].value += m_enemy.m_enemyAgility * Time.deltaTime;
        m_playerAgilitySlider.value += m_player.m_playerAgility * Time.deltaTime;
        //EnemyAttack();
        m_hPText.text = "HP                   " + m_player.PlayerCurrentHP;
        m_mPText.text = "MP                   " + m_player.PlayerCurrentMP;
    }
    /// <summary>プレイヤーがボタンを使って攻撃するためのメソッド</summary>
    public void PlayerAttack()
    {
        if (m_playerAgilitySlider.value == m_playerAgilitySlider.maxValue)
        {
            var enemy = m_enemy.m_enemyList[m_enemySelect.Num].GetComponent<MushroomEnemyStatus>();
            var damage = m_enemy.m_enemyList[m_enemySelect.Num].GetComponent<IDamagable>();
            enemy.EnemyDamage(damage.ReceiveDamage(m_player.m_playerAttackPow, enemy.m_enemyDefensivePower));
            //EnemyHPSliderUpdate();
            EndAttack(m_playerAgilitySlider);
        }
    }
    /// <summary>プレイヤーの魔法攻撃</summary>
    public void MagicArrowAttack()
    {
        if (m_playerAgilitySlider.value == m_playerAgilitySlider.maxValue && m_playerMPSlider.value >= 3)
        {
            var enemy = m_enemy.m_enemyList[m_enemySelect.Num].GetComponent<MushroomEnemyStatus>();
            var damage = m_enemy.m_enemyList[m_enemySelect.Num].GetComponent<IDamagable>();
            enemy.EnemyDamage(damage.ReceiveDamage(m_player.m_playerMagicPow, enemy.m_enemyDefensivePower));
            m_player.PlayerMPDown(3);
            //EnemyHPSliderUpdate();
            EndAttack(m_playerAgilitySlider);
        }
    }
    /// <summary>プレイヤーがボタンを使って逃げるためのメソッド</summary>
    public void PlayerEscape()
    {
        SceneManager.LoadScene("ExploreScene");
    }
    /// <summary>敵の攻撃処理</summary>
    //private void EnemyAttack()
    //{
    //    if (m_enemyUI.m_enemyAgilitySlider[0].value == m_enemyUI.m_enemyAgilitySlider[0].maxValue ||
    //        m_enemyUI.m_enemyAgilitySlider[0].value == m_enemyUI.m_enemyAgilitySlider[0].maxValue ||
    //        m_enemyUI.m_enemyAgilitySlider[0].value == m_enemyUI.m_enemyAgilitySlider[0].maxValue)
    //    {
    //        var damage = m_enemy.GetComponent<IDamagable>();
    //        m_player.PlayerDamage(damage.ReceiveDamage(m_enemy.m_enemyAttackPow, m_player.m_playerDefensivePower)); ;
    //        EndAttack(m_enemyUI.m_enemyAgilitySlider[0]);
    //    }
    //}
    /// <summary>プレイヤーのHPバーが現在のHPと同じ数値にする関数</summary>
    void PlayerHPSliderUpdate()
    {
        m_playerHPSlider.value = m_player.PlayerCurrentHP;
    }
    /// <summary>プレイヤーのMPバーが現在のMPと同じ数値にする関数</summary>
    void PlayerMPSliderUpdate()
    {
        m_playerMPSlider.value = m_player.PlayerCurrentMP;
    }
    /// <summary>エネミーのHPバーが現在のHPと同じ数値にする関数</summary>
    //void EnemyHPSliderUpdate()
    //{
    //    m_enemyUI.m_enemyAgilitySlider[0].value = m_enemy.m_enemyCurrentHP;
    //}
    /// <summary>最初のパネルを隠して二番目のパネルを表示する</summary>
    public void FirstPanelInactive()
    {
        m_firstPanel.SetBool("FirstOpen", false);
        m_secondPanel.SetBool("SecondOpen", true);
    }
    /// <summary>二番目のパネルを隠して最初のパネルを表示する</summary>
    public void SecondPanelInactive()
    {
        m_firstPanel.SetBool("FirstOpen", true);
        m_secondPanel.SetBool("SecondOpen", false);
    }
    /// <summary>攻撃した後に素早さゲージを０にする</summary>
    /// <param name="agility">攻撃するオブジェクトのAgilitySlider</param>
    public void EndAttack(Slider agility)
    {
        agility.value = 0;
    }
    void EnemyUI()
    {
        //m_enemyUI.m_enemyHPSlider.maxValue = m_enemy.m_enemyMaxHP;
        //m_enemyUI.m_enemyHPSlider.value = m_enemy.m_enemyCurrentHP;
        //m_enemyUI.m_enemyAgilitySlider.maxValue = m_enemy.m_enemyMaxAgility;
        //m_enemyUI.m_enemyAgilitySlider.value = 0;
    }
    void PlayerUI()
    {
        m_playerHPSlider.maxValue = m_player.m_playerMaxHP;
        m_playerHPSlider.value = m_player.PlayerCurrentHP;
        m_playerMPSlider.maxValue = m_player.m_playerMaxMp;
        m_playerMPSlider.value = m_player.PlayerCurrentMP;
        m_playerAgilitySlider.maxValue = m_player.m_playerMaxAgility;
        m_playerAgilitySlider.value = 0;
    }
}
