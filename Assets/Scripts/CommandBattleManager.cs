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
    [SerializeField] Text m_winText;

    [SerializeField] Animator m_firstPanel;
    [SerializeField] Animator m_secondPanel;

    [SerializeField] EnemyGenerator m_enemyGenerator;
    [SerializeField] EnemyUIGenerator m_enemyUIGenerator;
    [SerializeField] PlayerLevelController m_playerLevelController;
    [SerializeField] GetExp m_getExp;
    [SerializeField] GameObject m_winPanel;
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
        PlayerState();
        for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
        {
            m_enemyUI[i] = m_enemyUIGenerator.EnemyUIList[i].GetComponent<EnemyUI>();
            m_mushroomEnemy[i] = m_enemyGenerator.EnemyList[i]
            .GetComponent<MushroomEnemyStatus>();
        }
        GetEnemyHPSlider();
        GetEnemyAgilitySlider();

        m_winText.gameObject.SetActive(false);
        m_winPanel.gameObject.SetActive(false);
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
        m_playerAgilitySlider.value += m_player.Agility * Time.deltaTime;
        EnemyAttack();
        m_hPText.text = "HP                          " + m_player.CurrentHP;
        m_mPText.text = "MP                          " + m_player.CurrentMP;
    }
    void PlayerState()
    {
        m_player.MaxHP = m_playerLevelController.GetData(m_player.CurrentLevel).MaxHP;
        m_player.MaxMP = m_playerLevelController.GetData(m_player.CurrentLevel).MaxMP;
        m_player.AttackPow = m_playerLevelController.GetData(m_player.CurrentLevel).AttackPow;
        m_player.MaxAgility = m_playerLevelController.GetData(m_player.CurrentLevel).MaxAgility;
        m_player.Agility = m_playerLevelController.GetData(m_player.CurrentLevel).Agility;
        m_player.MagicPow = m_playerLevelController.GetData(m_player.CurrentLevel).MagicAttackPow;
        m_player.DefensivePower = m_playerLevelController.GetData(m_player.CurrentLevel).Defence;
        m_player.MaxExp = m_playerLevelController.GetData(m_player.CurrentLevel).MaxExp;
        //m_player.CurrentLevel = m_playerLevelController.GetData(m_player.CurrentLevel).Level;
    }
    void GetEnemyAgilityUpdate()
    {
        m_enemyUI[0].EnemyAgilityUpdate(m_mushroomEnemy[0].m_agility);
        if (2 == EnemyGenerator.Instance.RandomNum)
        {
            m_enemyUI[1].EnemyAgilityUpdate(m_mushroomEnemy[1].m_agility);
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            m_enemyUI[1].EnemyAgilityUpdate(m_mushroomEnemy[1].m_agility);
            m_enemyUI[2].EnemyAgilityUpdate(m_mushroomEnemy[2].m_agility);
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
                        EnemyDamage(damage.ReceiveDamage(m_player.MagicPow,
                        m_mushroomEnemy[num].m_defensivePower));
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
        m_player.PlayerDamage(damage.ReceiveDamage(m_mushroomEnemy[num].m_attackPow, m_player.DefensivePower)); ;
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
            m_mushroomEnemy[EnemyGenerator.Instance.SelectNum].m_currentHP;
        if (1 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_currentHP)
            {
                m_mushroomEnemy[0].m_agility = 0;
                var getExp = m_mushroomEnemy[0].m_exp;
                m_winText.gameObject.SetActive(true);
                m_winPanel.gameObject.SetActive(true);
                m_getExp.SetExp(m_player.CurrentExp, getExp);
                m_winText.text = m_player.CurrentLevel.ToString();
                //SceneManager.LoadScene("ExploreScene");
            }
        }
        else if (2 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_currentHP && 0 >= m_mushroomEnemy[1].m_currentHP)
            {
                var getExp = m_mushroomEnemy[0].m_exp + m_mushroomEnemy[1].m_exp;
                m_winText.gameObject.SetActive(true);
                m_winPanel.gameObject.SetActive(true);
                m_getExp.SetExp(m_player.CurrentExp, getExp);
                //SceneManager.LoadScene("ExploreScene");
            }
            if (0 >= m_mushroomEnemy[0].m_currentHP)
            {
                m_mushroomEnemy[0].m_agility = 0;
            }
            if (0 >= m_mushroomEnemy[1].m_currentHP)
            {
                m_mushroomEnemy[1].m_agility = 0;
            }
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            if (0 >= m_mushroomEnemy[0].m_currentHP && 0 >= m_mushroomEnemy[1].m_currentHP && 
                0 >= m_mushroomEnemy[2].m_currentHP)
            {
                var getExp = m_mushroomEnemy[0].m_exp + m_mushroomEnemy[1].m_exp + 
                    m_mushroomEnemy[2].m_exp;
                m_winText.gameObject.SetActive(true);
                m_winPanel.gameObject.SetActive(true);
                m_getExp.SetExp(m_player.CurrentExp, getExp);
                //SceneManager.LoadScene("ExploreScene");
            }
            if (0 >= m_mushroomEnemy[0].m_currentHP)
            {
                m_mushroomEnemy[0].m_agility = 0;
            }
            if (0 >= m_mushroomEnemy[1].m_currentHP)
            {
                m_mushroomEnemy[1].m_agility = 0;
            }
            if (0 >= m_mushroomEnemy[2].m_currentHP)
            {
                m_mushroomEnemy[2].m_agility = 0;
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
        m_playerHPSlider.value = m_player.CurrentHP;
    }
    /// <summary>プレイヤーのMPバーが現在のMPと同じ数値にする関数</summary>
    void PlayerMPSliderUpdate()
    {
        m_playerMPSlider.value = m_player.CurrentMP;
    }

    void StartEnemyUI()
    {
        if (1 == EnemyGenerator.Instance.RandomNum)
        {
            EnemyUI(0);
        }
        else if (2 == EnemyGenerator.Instance.RandomNum)
        {
            for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
            {
                EnemyUI(i);
            }
        }
        else if (3 == EnemyGenerator.Instance.RandomNum)
        {
            for (int i = 0; i < EnemyGenerator.Instance.RandomNum; i++)
            {
                EnemyUI(i);
            }
        }
    }
    void EnemyUI(int index)
    {
        m_enemyHPSlider[index].maxValue = m_mushroomEnemy[index].m_maxHP;
        m_enemyHPSlider[index].value = m_mushroomEnemy[index].m_currentHP;
        m_enemyAgilitySlider[index].maxValue = m_mushroomEnemy[index].MaxAgility;
        m_enemyAgilitySlider[index].value = 0;
    }

    void PlayerUI()
    {
        m_playerHPSlider.maxValue = m_player.MaxHP;
        m_playerHPSlider.value = m_player.CurrentHP;
        m_playerMPSlider.maxValue = m_player.MaxMP;
        m_playerMPSlider.value = m_player.CurrentMP;
        m_playerAgilitySlider.maxValue = m_player.MaxAgility;
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
