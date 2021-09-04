using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommandBattleManager : MonoBehaviour
{
    //プレイヤーのHPスライダー
    [SerializeField] Slider m_playerHPSlider;
    //プレイヤーのMPスライダー
    [SerializeField] Slider m_playerMPSlider;
    //プレイヤーの素早さのスライダー
    [SerializeField] Slider m_playerAgilitySlider;
    //敵のHPスライダー
    Slider[] m_enemyHPSlider = default;
    //敵のAgilityスライダー
    Slider[] m_enemyAgilitySlider = default;
    [SerializeField] Text m_hPText;
    [SerializeField] Text m_mPText;
    [SerializeField] Animator m_firstPanel;
    [SerializeField] Animator m_secondPanel;
    [SerializeField] EnemyGenerator m_enemyGenerator;
    [SerializeField] EnemyUIGenerator m_enemyUIGenerator;
    EnemyUI[] m_enemyUI;
    MushroomEnemyStatus[] m_mushroomEnemy;
    PlayerStatus m_player;
    void Start()
    {
        m_enemyUI = new EnemyUI[EnemyGenerator.Instance.RandomNum];
        m_enemyHPSlider = new Slider[EnemyGenerator.Instance.RandomNum];
        m_enemyAgilitySlider = new Slider[EnemyGenerator.Instance.RandomNum];
        m_mushroomEnemy = new MushroomEnemyStatus[EnemyGenerator.Instance.RandomNum];
        m_player = PlayerStatus.Instance;
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            m_enemyUI[i] = m_enemyUIGenerator.EnemyUIList[i].GetComponent<EnemyUI>();
            m_mushroomEnemy[i] = m_enemyGenerator.EnemyList[i]
            .GetComponent<MushroomEnemyStatus>();
        }
        GetEnemyHPSlider();
        GetEnemyAgilitySlider();
        SecondPanelInactive();
        PlayerUI();
        StartEnemyUI();
        m_player.OnPlayeHPChange += PlayerHPSliderUpdate;
        m_player.OnPlayerMPChange += PlayerMPSliderUpdate;
        m_mushroomEnemy[0].OnEnemyHPChange += EnemyHPSliderUpdate;
        if (2 == EnemyGenerator.Instance.RandomNum)
        {
            m_mushroomEnemy[1].OnEnemyHPChange += EnemyHPSliderUpdate;
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            m_mushroomEnemy[1].OnEnemyHPChange += EnemyHPSliderUpdate;
            m_mushroomEnemy[2].OnEnemyHPChange += EnemyHPSliderUpdate;
        }

    }
    void Update()
    {
        GetEnemyAgilityUpdate();
        m_playerAgilitySlider.value += m_player.m_playerAgility * Time.deltaTime;
        EnemyAttack();
        m_hPText.text = "HP                          " + m_player.PlayerCurrentHP;
        m_mPText.text = "MP                          " + m_player.PlayerCurrentMP;
    }

    void GetEnemyAgilityUpdate()
    {
        m_enemyUI[0].EnemyAgilityUpdate(m_mushroomEnemy[0].m_enemyAgility);
        if (2 == EnemyGenerator.Instance.RandomNum)
        {
            m_enemyUI[1].EnemyAgilityUpdate(m_mushroomEnemy[1].m_enemyAgility);
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            m_enemyUI[1].EnemyAgilityUpdate(m_mushroomEnemy[1].m_enemyAgility);
            m_enemyUI[2].EnemyAgilityUpdate(m_mushroomEnemy[2].m_enemyAgility);
        }
    }
    /// <summary>プレイヤーがボタンを使って攻撃するためのメソッド</summary>
    public void PlayerAttack()
    {
        if (m_playerAgilitySlider.value == m_playerAgilitySlider.maxValue)
        {
            PlayerAttackDamage(EnemyGenerator.Instance.SelectNum);
            EnemyHPSliderUpdate();
            EndAttack(m_playerAgilitySlider);
        }
    }
    /// <summary>プレイヤーの魔法攻撃</summary>
    public void MagicArrowAttack()
    {
        if (m_playerAgilitySlider.value == m_playerAgilitySlider.maxValue && m_playerMPSlider.value >= 3)
        {
            PlayerAttackDamage(EnemyGenerator.Instance.SelectNum);
            m_player.PlayerMPDown(3);
            EnemyHPSliderUpdate();
            EndAttack(m_playerAgilitySlider);
        }
    }
    void PlayerAttackDamage(int num)
    {
        GetMushroomEnemy(num);
        var damage = m_mushroomEnemy[num].GetComponent<IDamagable>();
        m_mushroomEnemy[num].
                        EnemyDamage(damage.ReceiveDamage(m_player.m_playerMagicPow,
                        m_mushroomEnemy[num].m_enemyDefensivePower));
    }
    /// <summary>プレイヤーがボタンを使って逃げるためのメソッド</summary>
    public void PlayerEscape()
    {
        SceneManager.LoadScene("ExploreScene");
    }
    /// <summary>敵の攻撃処理</summary>
    private void EnemyAttack()
    {
        if (m_enemyAgilitySlider[0].value == m_enemyAgilitySlider[0].maxValue)
        {
            EnemyAttackDamage(0);
        }
        if (2 == EnemyGenerator.Instance.RandomNum)
        {
            if (m_enemyAgilitySlider[1].value == m_enemyAgilitySlider[1].maxValue)
            {
                EnemyAttackDamage(1);
            }
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            if (m_enemyAgilitySlider[1].value == m_enemyAgilitySlider[1].maxValue)
            {
                EnemyAttackDamage(1);
            }
            else if (m_enemyAgilitySlider[2].value == m_enemyAgilitySlider[2].maxValue)
            {
                EnemyAttackDamage(2);
            }
        }
    }
    void EnemyAttackDamage(int num)
    {
        var damage = m_mushroomEnemy[num].GetComponent<IDamagable>();
        m_player.PlayerDamage(damage.ReceiveDamage(m_mushroomEnemy[num].m_enemyAttackPow, m_player.m_playerDefensivePower)); ;
        EndAttack(m_enemyAgilitySlider[num]);
    }

    /// <summary>攻撃した後に素早さゲージを０にする</summary>
    /// <param name="agility">攻撃するオブジェクトのAgilitySlider</param>
    public void EndAttack(Slider agility)
    {
        agility.value = 0;
    }

    void GetEnemyHPSlider()
    {
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            m_enemyHPSlider[i] = m_enemyUI[i].EnemyHPSlider;
        }
    }

    /// <summary>エネミーのHPバーが現在のHPと同じ数値にする関数</summary>
    void EnemyHPSliderUpdate()
    {
        m_enemyHPSlider[EnemyGenerator.Instance.SelectNum].value =
            m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].m_enemyCurrentHP;
        if (1 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_enemyCurrentHP)
            {
                SceneManager.LoadScene("ExploreScene");
            }
        }
        else if (2 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_enemyCurrentHP && 0 >= m_mushroomEnemy[1].m_enemyCurrentHP)
            {
                SceneManager.LoadScene("ExploreScene");
            }
            if (0 >= m_mushroomEnemy[0].m_enemyCurrentHP)
            {
                m_mushroomEnemy[0].m_enemyAgility = 0;
            }
            if (0 >= m_mushroomEnemy[1].m_enemyCurrentHP)
            {
                m_mushroomEnemy[1].m_enemyAgility = 0;
            }
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_enemyCurrentHP && 0 >= m_mushroomEnemy[1].m_enemyCurrentHP && 0 >= m_mushroomEnemy[2].m_enemyCurrentHP)
            {
                SceneManager.LoadScene("ExploreScene");
            }
            if (0 >= m_mushroomEnemy[0].m_enemyCurrentHP)
            {
                m_mushroomEnemy[0].m_enemyAgility = 0;
            }
            if (0 >= m_mushroomEnemy[1].m_enemyCurrentHP)
            {
                m_mushroomEnemy[1].m_enemyAgility = 0;
            }
            if (0 >= m_mushroomEnemy[2].m_enemyCurrentHP)
            {
                m_mushroomEnemy[2].m_enemyAgility = 0;
            }
        }
    }
    void GetEnemyAgilitySlider()
    {
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            m_enemyAgilitySlider[i] = m_enemyUI[i].EnemyAgilitySlider;
        }
    }

    void GetMushroomEnemy(int selectNum)
    {
        m_mushroomEnemy[selectNum] = m_enemyGenerator.EnemyList[selectNum]
            .GetComponent<MushroomEnemyStatus>();
    }

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

    void StartEnemyUI()
    {
        if (1 == EnemyGenerator.Instance.RandomNum)
        {
            EnemyUI(0);
        }
        else if (2 == EnemyGenerator.Instance.RandomNum)
        {
            EnemyUI(0);
            EnemyUI(1);
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            EnemyUI(0);
            EnemyUI(1);
            EnemyUI(2);
        }
    }
    void EnemyUI(int index)
    {
        m_enemyHPSlider[index].maxValue = m_mushroomEnemy[index].m_enemyMaxHP;
        m_enemyHPSlider[index].value = m_mushroomEnemy[index].m_enemyCurrentHP;
        m_enemyAgilitySlider[index].maxValue = m_mushroomEnemy[index].m_enemyMaxAgility;
        m_enemyAgilitySlider[index].value = 0;
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
}
